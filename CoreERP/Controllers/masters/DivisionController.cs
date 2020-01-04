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
                return BadRequest($"object can not be null");


            try
            {
                if (DivisionHelper.GetList(division.Code).Count() > 0)
                    return BadRequest($"Division Code {nameof(division.Code)} is already exists ,Please Use Different Code ");

                int result=DivisionHelper.Register(division);
                if (result > 0)
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
                return BadRequest("Regestration Failed");
            }
           
        }



        [HttpGet("GetDivisionsList")]
        public async Task<IActionResult> GetDivisionsList()
        {
            //try 
            //{ 
            //    return Ok(new { divisions = DivisionHelper.GetList() }); 
            //}
            try
            {
                var divisionsList = DivisionHelper.GetList();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.divisionsList = divisionsList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch
            { return BadRequest(); }
        }

        [HttpPut("UpdateDivision/{code}")]
        public async Task<IActionResult> UpdateDivision(string code, [FromBody] Divisions division)
        {
            APIResponse apiResponse = null;
            if (division == null)
                return BadRequest($"{nameof(division)} cannot be null");

            try
            {
                int rs = DivisionHelper.Update(division);
                if (rs > 0)
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
                return BadRequest($"{nameof(division)} Updation Failed");
            }
        }


        [HttpDelete("masters/divisions/{code}")]
        public async Task<IActionResult> DeleteDivisionByID(string code)
        {
            APIResponse apiResponse = null;
            try
            {
                if(code == null)
                    return BadRequest("code can not be null");
                int rs = DivisionHelper.Delete(code);
                if (rs > 0)
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
                return BadRequest("Deletion Failed");
            }

            
        }
    }
}
