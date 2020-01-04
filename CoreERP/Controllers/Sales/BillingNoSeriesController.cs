using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/BillingNoSeries")]
    public class BillingNoSeriesController : ControllerBase
    {

        [HttpGet("getBillingNoSeriesList")]
        public async Task<IActionResult> GetBillingNoSeriesList()
        {
            return Ok(new { billinnoseries = BillingNoSeriesHelper.GetBillingNoSeriesList() });
        }

        [HttpGet("getCompanies")]
        public async Task<IActionResult> GetCompaniesList()
        {
            return Ok(new {compnays = BillingNoSeriesHelper.GetCompaniesList()});
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
                    return Ok(response);

                return BadRequest("Registration Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Registration Failed");
            }
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
                    return Ok(response);
              
                    return BadRequest("Updation Failed");
            }
            catch(Exception ex)
            {
                return BadRequest("Updation Failed");
            }
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
                return Ok(response);

                return BadRequest("Delete Operation Failed");
            }
            catch(Exception ex)
            {
                return BadRequest("Delete Operation Failed");
            }
            
        }
    }
}