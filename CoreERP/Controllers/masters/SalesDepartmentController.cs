using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/SalesDepartment")]
    public class SalesDepartmentController : ControllerBase
    {
        private readonly IRepository<SalesDepartment> _sdRepository;
        public SalesDepartmentController(IRepository<SalesDepartment> sdRepository)
        {
            _sdRepository = sdRepository;
        }

        [HttpPost("RegisterSalesDepartment")]
        public IActionResult RegisterSalesDepartment([FromBody]SalesDepartment sdept)
        {
            if (sdept == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (SalesDepartmentHelper.GetList(sdept.DepartmentCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Salesdepartment Code {nameof(sdept.DepartmentCode)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _sdRepository.Add(sdept);
                if (_sdRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = sdept };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSalesDepartment")]
        public IActionResult GetSalesDepartment()
        {
            try
            {
                var salesdeptList = CommonHelper.GetSalesDepartments();
                if (salesdeptList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.salesdeptList = salesdeptList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateSalesDepartment")]
        public IActionResult UpdateSalesDepartment([FromBody] SalesDepartment sdept)
        {
            if (sdept == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(sdept)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _sdRepository.Update(sdept);
                if (_sdRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = sdept };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteSalesDepartment/{code}")]
        public IActionResult DeleteSalesDepartmentByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _sdRepository.GetSingleOrDefault(x => x.DepartmentCode.Equals(code));
                _sdRepository.Remove(record);
                if (_sdRepository.SaveChanges() > 0)
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