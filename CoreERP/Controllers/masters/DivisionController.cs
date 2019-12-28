using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/Division")]
    public class DivisionController : ControllerBase
    {
        [HttpPost("masters/divisions/insertdivision")]
        public async Task<IActionResult> Register([FromBody]Divisions division)
        {
            if (division == null)
                return BadRequest($"object can not be null");


            try
            {
                if (DivisionHelper.GetList(division.Code).Count() > 0)
                    return BadRequest($"Division Code {nameof(division.Code)} is already exists ,Please Use Different Code ");

                int result=DivisionHelper.Register(division);
                if(result > 0)
                return Ok(division);

                return BadRequest("Regestration Failed");
            }
            catch
            {
                return BadRequest("Regestration Failed");
            }
           
        }



        [HttpGet("masters/divisions")]
        public async Task<IActionResult> GetAllDivisions()
        {
            try 
            { 
                return Ok(new { divisions = DivisionHelper.GetList() }); 
            }
            catch
            { return BadRequest(); }
        }

        [HttpPut("masters/divisions/{code}")]
        public async Task<IActionResult> UpdateDivision(string code, [FromBody] Divisions division)
        {
            if (division == null)
                return BadRequest($"{nameof(division)} cannot be null");

            try
            {
                int rs = DivisionHelper.Update(division);
                if (rs > 0)
                    return Ok(division);

                return BadRequest($"{nameof(division)} Updation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(division)} Updation Failed");
            }
        }


        [HttpDelete("masters/divisions/{code}")]
        public async Task<IActionResult> DeleteDivisionByID(string code)
        {
            try
            {
                if(code == null)
                    return BadRequest("code can not be null");
                int rs = DivisionHelper.Delete(code);
                if (rs > 0)
                    return Ok(code);

                return BadRequest("Deletion Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Deletion Failed");
            }

            
        }
    }
}
