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
        //[HttpPost("RegisterNoSeries")]
        //public async Task<IActionResult> RegisterNoSeries([FromBody]NoSeries noSeries)
        //{
        //    APIResponse apiResponse = null;
        //    try
        //    {
        //        var result = NoSeriesHelper.RegisteNoSeries(noSeries);
        //        if (result !=null)
        //        {
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
        //        }

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }           
        //}



        //[HttpGet("GetNoSeriesList")]
        //public async Task<IActionResult> GetNoSeriesList()
        //{
        //    try
        //    {
        //        var noSeriesList = NoSeriesHelper.GetAllNoSeriesLists();
        //        if (noSeriesList.Count > 0)
        //        {
        //            dynamic expdoObj = new ExpandoObject();
        //            expdoObj.noSeriesList = noSeriesList;
        //            return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
        //        }
        //        else
        //            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpPut("UpdateNoSeries")]
        //public async Task<IActionResult> UpdateNoSeries([FromBody] NoSeries noSeries)
        //{
        //    APIResponse apiResponse = null;
        //    if (noSeries == null)
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(noSeries)} cannot be null" });

        //    try
        //    {
        //        var rs = NoSeriesHelper.UpdateNoSeries(noSeries);
        //        if (rs !=null)
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
        //        }
        //        else
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
        //        }
        //        return Ok(apiResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}


        //[HttpDelete("DeleteNoSeries/{code}")]
        //[Produces(typeof(NoSeries))]
        //public async Task<IActionResult> DeleteNoSeries(string code)
        //{
        //    APIResponse apiResponse = null;
        //    if (string.IsNullOrWhiteSpace(code))
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

        //    try
        //    {
        //        var rs = NoSeriesHelper.DeleteNoSeries(code);
        //        if (rs !=null)
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
        //        }
        //        else
        //        {
        //            apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
        //        }
        //        return Ok(apiResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpGet("GetCompanyList")]
        public async Task<IActionResult> GetCompanyList()
        {

            try
            {
                var companiesList = CompaniesHelper.GetListOfCompanies();
                if (companiesList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.companiesList = companiesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetBranchesList")]
        //public async Task<IActionResult> GetBranchesList()
        //{
        //    try
        //    {
        //        var branches = BrancheHelper.GetBranches();
        //        if (branches.Count > 0)
        //        {
        //            dynamic expando = new ExpandoObject();
        //            expando.branches = branches;
        //            return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expando });
        //        }
        //        else
        //            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data  Found" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetPartnerTypeList")]
        //[Produces(typeof(List<PartnerType>))]
        //public async Task<IActionResult> GetPartnerTypeList()
        //{
        //    try
        //    {
        //        var partnerTypeList = PartnerTypeHelper.GetPartnerTypeList();
        //        if (partnerTypeList.Count > 0)
        //        {
        //            dynamic expando = new ExpandoObject();
        //            expando.partnerTypeList = partnerTypeList;
        //            return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expando });
        //        }
        //        else
        //            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data  Found" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}
       
