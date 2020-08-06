using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/FunctionalDepartment")]
    public class FunctionalDepartmentController : ControllerBase
    {
        private readonly IRepository<TblFunctionalDepartment> _fdRepository;
        public FunctionalDepartmentController(IRepository<TblFunctionalDepartment> fdRepository)
        {
            _fdRepository = fdRepository;
        }

        [HttpPost("RegisterFunctionalDepartment")]
        public IActionResult RegisterFunctionalDepartment([FromBody]TblFunctionalDepartment fdept)
        {
            if (fdept == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (FunctionalDepartmentHelper.GetList(fdept.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"FunctionalDepartment Code {nameof(fdept.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _fdRepository.Add(fdept);
                if (_fdRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = fdept };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetFunctionalDepartment")]
        public IActionResult GetFunctionalDepartment()
        {
            try
            {
                var fdeptList = _fdRepository.GetAll();
                if (fdeptList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.fdeptList = fdeptList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateFunctionalDepartment")]
        public IActionResult UpdateFunctionalDepartment([FromBody] TblFunctionalDepartment fdept)
        {
            if (fdept == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(fdept)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _fdRepository.Update(fdept);
                if (_fdRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = fdept };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteFunctionalDepartment/{code}")]
        public IActionResult DeleteFunctionalDepartmentByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _fdRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _fdRepository.Remove(record);
                if (_fdRepository.SaveChanges() > 0)
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