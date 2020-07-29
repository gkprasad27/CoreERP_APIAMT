using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
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
    [Route("api/SalesDepartment")]
    public class SalesDepartmentController : ControllerBase
    {
        [HttpPost("RegisterSalesDepartment")]
        public IActionResult RegisterSalesDepartment([FromBody]SalesDepartment sdept)
        {
            if (sdept == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (SalesDepartmentHelper.GetList(sdept.DepartmentCode).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Salesdepartment Code {nameof(sdept.DepartmentCode)} is already exists ,Please Use Different Code " });

                var result = SalesDepartmentHelper.Register(sdept);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

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
                var salesdeptList = SalesDepartmentHelper.GetList();
                if (salesdeptList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.salesdeptList = salesdeptList;
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

        [HttpPut("UpdateSalesDepartment")]
        public IActionResult UpdateSalesDepartment([FromBody] SalesDepartment sdept)
        {
            if (sdept == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(sdept)} cannot be null" });

            try
            {
                var rs = SalesDepartmentHelper.Update(sdept);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
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

                var rs = SalesDepartmentHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}