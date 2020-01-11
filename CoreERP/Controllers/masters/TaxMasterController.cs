using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using System.Dynamic;
using CoreERP.DataAccess;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/TaxMaster")]
    public class TaxMasterController : ControllerBase
    {
        [HttpGet("GetTaxmastersList")]
        public async Task<IActionResult> GetAllTaxMasters()
        {

            try
            {
                var taxmasterList = TaxmasterHelper.GetListOfTaxMasters();
                if (taxmasterList.Count() > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxmasterList = taxmasterList;

                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= expando });
                }
                else
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch(Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to loat Data ." });
        }


        [HttpPost("RegisterTaxMasters")]
        public async Task<IActionResult> RegisterTaxMasters([FromBody]TaxMasters taxmaster)
        {
            if (taxmaster == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(taxmaster)} cannot be null" });
           try
            {
                if (TaxmasterHelper.GetListOfTaxMasters().Where(x => x.Code == taxmaster.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Tax Master Code {nameof(taxmaster.Code)} is already exists ,Please Use Different Code " });


                var result = TaxmasterHelper.RegisterTaxMaster(taxmaster);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

            }
            catch
            {
            }
            return BadRequest("Registration Failed");
        }



        [HttpPut("UpdateTaxMaster")]
        public async Task<IActionResult> UpdateTaxMaster([FromBody] TaxMasters taxmaster)
        {
            if (taxmaster == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(taxmaster)} cannot be null" });

            try
            {
                var result = TaxmasterHelper.UpdateTaxMaster(taxmaster);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
        }


        // Delete Branch
        [HttpDelete("DeleteTaxMaster/{code}")]
        public async Task<IActionResult> DeleteTaxMaster(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var result = TaxmasterHelper.DeleteTaxMaster(code);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = result });
            }
            catch (Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
        }
    }
}