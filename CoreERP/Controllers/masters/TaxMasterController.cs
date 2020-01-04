using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/TaxMaster")]
    public class TaxMasterController : ControllerBase
    {
        [HttpGet("masters/taxmasters")]
        public async Task<IActionResult> GetAllTaxMasters()
        {

            try
            {
                return Ok(new
                {
                    taxMasters = TaxmasterHelper.GetListOfTaxMasters()
                });
            }
            catch
            {
                return BadRequest("No Data  Found");
            }

        }


        [HttpPost("masters/taxmasters/register")]
        public async Task<IActionResult> Register([FromBody]TaxMasters taxmaster)
        {
            if (taxmaster == null)
                return BadRequest($"{nameof(taxmaster)} cannot be null");
           try
            {
                if (TaxmasterHelper.GetListOfTaxMasters().Where(x => x.Code == taxmaster.Code).Count() > 0)
                    return BadRequest($"Tax Master Code {nameof(taxmaster.Code)} is already exists ,Please Use Different Code ");


                int result = TaxmasterHelper.RegisterTaxMaster(taxmaster);
                if (result > 0)
                    return Ok(taxmaster);

            }
            catch
            {
            }
            return BadRequest("Registration Failed");
        }



        [HttpPut("masters/taxmasters/{code}")]
        public async Task<IActionResult> UpdateTaxMaster(string code, [FromBody] TaxMasters taxmaster)
        {
            if (taxmaster == null)
                return BadRequest($"{nameof(taxmaster)} cannot be null");

            if (!string.IsNullOrWhiteSpace(taxmaster.Code) && code != taxmaster.Code)
                return BadRequest("Conflicting role id in parameter and model data");
            try
            {
                int result = TaxmasterHelper.UpdateTaxMaster(taxmaster);
                if (result > 0)
                    return Ok(taxmaster);

                //otherwise return 
                return BadRequest($"{nameof(taxmaster)} Updation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


        // Delete Branch
        [HttpDelete("masters/taxmasters/{code}")]
        public async Task<IActionResult> DeleteTaxMaster(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                int result = TaxmasterHelper.DeleteTaxMaster(code);
                if (result > 0)
                    return Ok(code);

                return BadRequest("Deletion Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}