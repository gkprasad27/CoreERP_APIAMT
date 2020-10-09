using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/WorkCenterCreation")]
    public class WorkCenterCreationController : ControllerBase
    {
        private readonly IRepository<TblWorkcenterActivity> _workcenterActivityRepository;
        private readonly IRepository<TblWorkcenterMaster> _workcenterMasterRepository;
        private readonly IRepository<TblWorkCenterCapacity> _workCenterCapacityRepository;
        public WorkCenterCreationController(IRepository<TblWorkcenterMaster> workcenterMasterRepository,
            IRepository<TblWorkcenterActivity> workcenterActivityRepository, 
            IRepository<TblWorkCenterCapacity> workCenterCapacityRepository)
        {
            _workcenterMasterRepository = workcenterMasterRepository;
            _workcenterActivityRepository = workcenterActivityRepository;
            _workCenterCapacityRepository = workCenterCapacityRepository;
        }

        [HttpPost("RegisterWorkCenterCreation")]
        public IActionResult RegisterWorkCenterCreation([FromBody] JObject obj)
        {
            if (obj == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });
           
            try
            {
                var workcenterMaster = obj["mainasstHdr"].ToObject<TblWorkcenterMaster>();
                var workcenterActivity = obj["mainactvtyDetail"].ToObject<List<TblWorkcenterActivity>>();
                var workcenterCapacity = obj["mainassetcapacityDetail"].ToObject<List<TblWorkCenterCapacity>>();

                if (!new TransactionsHelper().AddWorkCenterCreation(workcenterMaster, workcenterCapacity, workcenterActivity))
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.workcentermaster = workcenterMaster;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });


            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetWorkCenterCreationList")]
        public IActionResult GetWorkCenterCreationList()
        {
            try
            {
                var wcmList = _workcenterMasterRepository.GetAll();
                if (wcmList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.wcmList = wcmList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateWorkCenterCreation")]
        public IActionResult UpdateWorkCenterCreation([FromBody] TblWorkcenterMaster wcm)
        {
            if (wcm == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(wcm)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _workcenterMasterRepository.Update(wcm);
                if (_workcenterMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = wcm };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteWorkCenterCreation/{code}")]
        public IActionResult DeleteWorkCenterCreationbyId(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _workcenterMasterRepository.GetSingleOrDefault(x => x.WorkcenterCode.Equals(code));
                _workcenterMasterRepository.Remove(record);
                if (_workcenterMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}