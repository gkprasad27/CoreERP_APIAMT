using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/AssignTaxacctoTaxcode")]
    public class AssignTaxacctoTaxcodeController : ControllerBase
    {
        [HttpPost("RegisterAssignTaxacctoTaxcode")]
        public IActionResult RegisterAssignTaxacctoTaxcode([FromBody]TblAssignTaxacctoTaxcode taxcode)
        {
            if (taxcode == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (AssignTaxacctoTaxcodeHelper.GetList(taxcode.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Ledger Code {nameof(taxcode.Code)} is already exists ,Please Use Different Code " });

                var result = AssignTaxacctoTaxcodeHelper.Register(taxcode);
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

        [HttpGet("GetAssignTaxacctoTaxcodeList")]
        public IActionResult GetAssignTaxacctoTaxcodeList()
        {
            try
            {
                var taxcodeList = AssignTaxacctoTaxcodeHelper.GetList();
                if (taxcodeList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.taxcodesList = taxcodeList;
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

        [HttpPut("UpdateAssignTaxacctoTaxcode")]
        public IActionResult UpdateAssignTaxacctoTaxcode([FromBody] TblAssignTaxacctoTaxcode taxcode)
        {
            if (taxcode == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(taxcode)} cannot be null" });

            try
            {
                var rs = AssignTaxacctoTaxcodeHelper .Update(taxcode);
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


        [HttpDelete("DeletAssignTaxacctoTaxcode/{code}")]
        public IActionResult DeletAssignTaxacctoTaxcodeByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = AssignTaxacctoTaxcodeHelper.Delete(code);
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