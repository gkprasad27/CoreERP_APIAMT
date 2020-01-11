using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/masters/Division")]
    public class DivisionController : ControllerBase
    {
        [HttpPost("RegisterDivision")]
        public async Task<IActionResult> RegisterDivision([FromBody]Divisions division)
        {
            APIResponse apiResponse = null;
            if (division == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (DivisionHelper.GetList(division.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Division Code {nameof(division.Code)} is already exists ,Please Use Different Code " });

                var result=DivisionHelper.Register(division);
                if (result !=null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);

            }
            catch
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
        }



        [HttpGet("GetDivisionsList")]
        public async Task<IActionResult> GetDivisionsList()
        {
            try
            {
                var divisionsList = DivisionHelper.GetList();
                if (divisionsList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.divisionsList = divisionsList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch
            { return BadRequest(); }
        }

        [HttpPut("UpdateDivision")]
        public async Task<IActionResult> UpdateDivision([FromBody] Divisions division)
        {
            APIResponse apiResponse = null;
            if (division == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(division)} cannot be null" });

            try
            {
                var rs = DivisionHelper.Update(division);
                if (rs!=null)
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
            }
            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = " Updation Failed" });
        }


        [HttpDelete("DeleteDivision/{code}")]
        public async Task<IActionResult> DeleteDivisionByID(string code)
        {
            APIResponse apiResponse = null;
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = DivisionHelper.Delete(code);
                if (rs !=null)
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
            }

            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
        }
    }
}
