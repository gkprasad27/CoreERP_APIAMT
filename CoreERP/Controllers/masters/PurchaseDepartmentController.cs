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
    [Route("api/PurchaseDepartment")]
    public class PurchaseDepartmentController : ControllerBase
    {
        [HttpPost("RegisterPurchaseDepartment")]
        public IActionResult RegisterPurchaseDepartment([FromBody]TblPurchaseDepartment prdept)
        {
            if (prdept == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (PurchaseDepartmentHelper.GetList(prdept.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"salesoffice Code {nameof(prdept.Code)} is already exists ,Please Use Different Code " });

                var result = PurchaseDepartmentHelper.Register(prdept);
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

        [HttpGet("GetPurchaseDepartment")]
        public IActionResult GetPurchaseDepartment()
        {
            try
            {
                var prdeptList = PurchaseDepartmentHelper.GetList();
                if (prdeptList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.prdeptList = prdeptList;
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

        [HttpPut("UpdatePurchaseDepartment")]
        public IActionResult UpdatePurchaseDepartment([FromBody] TblPurchaseDepartment prdept)
        {
            if (prdept == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(prdept)} cannot be null" });

            try
            {
                var rs = PurchaseDepartmentHelper.Update(prdept);
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


        [HttpDelete("DeletePurchaseDepartment/{code}")]
        public IActionResult DeletePurchaseDepartmentByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = PurchaseDepartmentHelper.Delete(code);
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