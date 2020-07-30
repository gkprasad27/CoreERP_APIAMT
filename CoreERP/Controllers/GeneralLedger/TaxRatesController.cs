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
    [Route("api/TaxRates")]
    public class TaxRatesController : ControllerBase
    {
        [HttpPost("RegisterTaxRates")]
        public async Task<IActionResult> RegisterTaxRates([FromBody]TblTaxRates taxrates)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (taxrates == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

                try
                {
                    var taxrateslist = new TaxratesHelpers().GetList(taxrates.TaxRateCode);
                    if (taxrateslist.Count() > 0)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"TaxRateCode {nameof(taxrates.TaxRateCode)} is already exists ,Please Use Different Code " });

                    var result = new TaxratesHelpers().Register(taxrates);
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
            });
            return result;
        }


        [HttpGet("GetTaxRatesList")]
        public async Task<IActionResult> GetTaxRatesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    var TaxRatesList = new TaxratesHelpers().GetList();
                    expando.TaxratesList = TaxRatesList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        

        [HttpPut("UpdateTaxRates")]
        public async Task<IActionResult> UpdateTaxRates([FromBody] TblTaxRates taxrates)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (taxrates == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(taxrates)} cannot be null" });

                try
                {
                    var rs = new TaxratesHelpers().Update(taxrates);
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
            });
            return result;
        }

        [HttpDelete("DeleteTaxRates/{code}")]
        public async Task<IActionResult> DeleteTaxRates(string code)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                try
                {
                    if (code == null)
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                    var rs = new TaxratesHelpers().Delete(code);
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
            });
            return result;
        }


        //[HttpDelete("DeleteTaxRates/{code}")]
        //public async Task<IActionResult> DeleteTaxRates(string code)
        //{
        //    var result = await Task.Run(() =>
        //    {
        //        APIResponse apiResponse = null;
        //        try
        //        {
        //            if (code == null)
        //                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

        //            var rs = new TaxratesHelpers().Delete(code);
        //            if (rs != null)
        //            {
        //                apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
        //            }
        //            else
        //            {
        //                apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
        //            }
        //            return Ok(apiResponse);
        //        }
        //        catch (Exception ex)
        //        {
        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //        }
        //    });
        //    return result;
        //}
        
    }
}