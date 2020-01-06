using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Models;
using System.Dynamic;
using CoreERP.DataAccess;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/BillingNoSeries")]
    public class BillingNoSeriesController : ControllerBase
    {

        [HttpGet("getBillingNoSeriesList")]
        public async Task<IActionResult> GetBillingNoSeriesList()
        {
            try
            {
                dynamic expanddo = new ExpandoObject();
                expanddo.billinnoseries = BillingNoSeriesHelper.GetBillingNoSeriesList();
                return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= expanddo});
            }
            catch(Exception ex) { }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load Biiling No Series." });
        }

        [HttpGet("getCompanies")]
        public async Task<IActionResult> GetCompaniesList()
        {
            try
            {
                dynamic expanddo = new ExpandoObject();
                expanddo.compnays = BillingNoSeriesHelper.GetCompaniesList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expanddo });
            }
            catch(Exception ex) { }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load Companies." });
        }


        [HttpPost("registerBillingNoSeries")]
        public async Task<IActionResult> RegisterBillingNoSeries([FromBody]BillingNoSeries billinnoserries)
        {
           
            if (billinnoserries == null)
                return BadRequest("Request object cannot be null");
            try
            {

                var response = BillingNoSeriesHelper.RegisterBillingNoSeries(billinnoserries);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch (Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
        }



        [HttpPut("UpdateBillingNoSeries")]
        [Produces(typeof(BillingNoSeries))]
        public async Task<IActionResult> UpdateBillingNoSeries([FromBody] BillingNoSeries billingnoseries)
        {
            if (billingnoseries == null)
                return BadRequest("Request object cannot be null");
           
            try
            {
                var response = BillingNoSeriesHelper.UpdateBillingNoSeries(billingnoseries);
                if (response !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch(Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
        }


       
        [HttpDelete("DeleteBillingNoSeries")]
        [Produces(typeof(BillingNoSeries))]
        public async Task<IActionResult> DeleteBillingNoSeries(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var billingNoSeries = BillingNoSeriesHelper.GetBillingNoSeries(code);
                billingNoSeries.Active = "N";
                var response = BillingNoSeriesHelper.UpdateBillingNoSeries(billingNoSeries);

                if(response !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch(Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
        }
    }
}