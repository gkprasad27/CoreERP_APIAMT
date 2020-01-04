using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/NoSeries")]
    public class NoSeriesController : ControllerBase
    {
           [HttpPost("RegisterNoSeries")]
        public async Task<IActionResult> RegisterNoSeries([FromBody]NoSeries noSeries)
        {
            APIResponse apiResponse = null;
            try
            {
        int result = NoSeriesHelper.RegisteNoSeries(noSeries);
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
      catch (Exception ex)
      {
        return BadRequest(" Registration Operation Failed");
      }
    }



        [HttpGet("GetNoSeriesList")]
        public async Task<IActionResult> GetNoSeriesList()
        {
            try
            {
                var noSeriesList = NoSeriesHelper.GetAllNoSeriesLists();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.noSeriesList = noSeriesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch
            {
                return BadRequest("No Data  Found");
            }
        }

        [HttpPut("UpdateNoSeries/{code}")]
        public async Task<IActionResult> UpdateNoSeries(string code, [FromBody] NoSeries noSeries)
        {
            APIResponse apiResponse = null;
            if (noSeries == null)
                return BadRequest($"{nameof(noSeries)} cannot be null");

            if (!string.IsNullOrWhiteSpace(noSeries.Code) && code != noSeries.Code)
                return BadRequest("Conflicting role id in parameter and model data");


            try
            {
             int rs = NoSeriesHelper.UpdateNoSeries(noSeries);
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
            catch(Exception ex)
            {
             return BadRequest($"{nameof(noSeries)} Updation Failed");
            }  
        }


        [HttpDelete("masters/noSeries/{code}")]
        [Produces(typeof(NoSeries))]
        public async Task<IActionResult> DeleteNoSeries(string noSeriesCode)
        {
            APIResponse apiResponse = null;
            if (string.IsNullOrWhiteSpace(noSeriesCode))
                return BadRequest($"{nameof(noSeriesCode)} cannot be null");
                        
            try
            {
        int rs = NoSeriesHelper.DeleteNoSeries(noSeriesCode);
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
                var companiesList = CompaniesHelper.GetListOfCompanies();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.companiesList = companiesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch
            {
                return BadRequest("No Data  Found");
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
       
