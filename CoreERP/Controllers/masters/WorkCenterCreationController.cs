using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult RegisterWorkCenterCreation([FromBody]TblWorkcenterMaster wcm)
        {
            if (wcm == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                TblWorkCenterCapacity repo1 = new TblWorkCenterCapacity();
                repo1.WorkCenterCode= wcm.WorkcenterCode;
                repo1.Resource = wcm.Resource;
                repo1.Capacity = wcm.Capacity;
                repo1.WorkingHours =Convert.ToDecimal( wcm.WorkingHours);
                repo1.BreakTime = Convert.ToDecimal(wcm.BreakTime);
                repo1.NetHours = Convert.ToDecimal(wcm.NetHours);
                repo1.Shifts =Convert.ToInt32( wcm.Shifts);
                repo1.TotalCapacity = Convert.ToInt32(wcm.TotalCapacity);
                repo1.WeekDays = Convert.ToInt32(wcm.WeekDays);
                repo1.HoursPerWeek = Convert.ToInt32(wcm.HoursPerWeek);
                TblWorkcenterActivity repo= new  TblWorkcenterActivity();
                repo.WorkcenterCode = wcm.WorkcenterCode;
                repo.Description = wcm.Description;
                repo.Activity = wcm.Activity;
                repo.Uom = wcm.UOM;
                repo.CostCenter = wcm.CostCenter;
                repo.Formula = wcm.Formula;
                APIResponse apiResponse;
                _workcenterMasterRepository.Add(wcm);
                _workcenterActivityRepository.Add(repo);
                _workCenterCapacityRepository.Add(repo1);
                _workCenterCapacityRepository.SaveChanges();
                _workcenterActivityRepository.SaveChanges();
                if (_workcenterMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = wcm };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

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