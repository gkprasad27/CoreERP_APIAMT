using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/NoSeries")]
    public class NoSeriesController : ControllerBase
    {
           [HttpPost("masters/noSeries/register")]
        public async Task<IActionResult> Register([FromBody]NoSeries noSeries)
        {
            try
            {
        int result = NoSeriesHelper.RegisteNoSeries(noSeries);
        if (result > 0)
          return Ok(noSeries);

        return BadRequest(" Registration Operation Failed");
      }
      catch (Exception ex)
      {
        return BadRequest(" Registration Operation Failed");
      }
    }



        [HttpGet("masters/noSeries")]
        public async Task<IActionResult> GetAllNoSeries()
        {
      return Ok(new
      {

        noSerieslist = NoSeriesHelper.GetAllNoSeriesLists()
       
      });
    }

        [HttpPut("masters/noSeries/{code}")]
        public async Task<IActionResult> UpdateNoSeries(string code, [FromBody] NoSeries noSeries)
        {
            if (noSeries == null)
                return BadRequest($"{nameof(noSeries)} cannot be null");

            if (!string.IsNullOrWhiteSpace(noSeries.Code) && code != noSeries.Code)
                return BadRequest("Conflicting role id in parameter and model data");


            try
            {
             int rs = NoSeriesHelper.UpdateNoSeries(noSeries);
        if (rs > 0)
          return Ok(noSeries);

        return BadRequest($"{nameof(noSeries)} Updation Failed");
      }
            catch(Exception ex)
            {
             return BadRequest($"{nameof(noSeries)} Updation Failed");
            }  
        }


        [HttpDelete("masters/noSeries/{code}")]
        [Produces(typeof(NoSeries))]
        public async Task<IActionResult> DeleteNoSeries(string noSeriesCode)
        {
            if (string.IsNullOrWhiteSpace(noSeriesCode))
                return BadRequest($"{nameof(noSeriesCode)} cannot be null");
                        
            try
            {
        int rs = NoSeriesHelper.DeleteNoSeries(noSeriesCode);
        if (rs > 0)
          return Ok(noSeriesCode);

        return BadRequest($"{nameof(noSeriesCode)} Updation Failed");
      }
            catch(Exception ex)
            {
                return BadRequest();
            }


       }


        [HttpGet("masters/noSeries/complist")]
        public async Task<IActionResult> GetAllCompanysMasters()
        {

      try
      {
        return Ok(new { companies = CompaniesHelper.GetListOfCompanies() });
      }
      catch (Exception ex)
      {

        return Ok(new { companies = ex.Message });
      }
    }



        [HttpGet("masters/noSeries/branchlist")]
        public async Task<IActionResult> GetAllBranches()
        {

      try
      {
        return Ok(new
        {
          branches = BrancheHelper.GetBranches()
        });
      }
      catch
      {
        return BadRequest("No Data  Found");
      }

    }

    [HttpGet("masters/noSeries/partlist")]
        [Produces(typeof(List<PartnerType>))]
        public async Task<IActionResult> GetAllPartners()
        {

      return Ok(
          new
          {
            partnerType = PartnerTypeHelper.GetPartnerTypeList()

          });
    }
    }
}
       
