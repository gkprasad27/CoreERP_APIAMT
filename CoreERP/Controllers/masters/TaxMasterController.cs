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
                
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpPost("RegisterTaxMasters")]
        public async Task<IActionResult> RegisterTaxMasters([FromBody]TaxMasters taxmaster)
        {
            if (taxmaster == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Request cannot be null" });
           try
            {
                if (TaxmasterHelper.GetListOfTaxMasters().Where(x => x.Code == taxmaster.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Tax Master Code {nameof(taxmaster.Code)} is already exists" });


                var result = TaxmasterHelper.RegisterTaxMaster(taxmaster);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
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
           
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteTaxMaster/{code}")]
        public async Task<IActionResult> DeleteTaxMaster(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var result = TaxmasterHelper.DeleteTaxMaster(code);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}