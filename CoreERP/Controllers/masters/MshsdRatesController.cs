using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/masters/MshsdRates")]
    public class MshsdRatesController : ControllerBase
    {

        [HttpGet("GetMshsdRateList")]
        public async Task<IActionResult> GetMshsdRateList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var mshsdRateList = new MshsdRatesHelper().GetListOfMshsdRates();
                    if (mshsdRateList.Count > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.mshsdRateList = mshsdRateList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.mshsdBranchesList = new MshsdRatesHelper().GetBranchesList().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


        [HttpGet("GetProductList")]
        public async Task<IActionResult> GetProductList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.mshsdProductsList = new MshsdRatesHelper().GetListOfMshsdRates().Select(x => new { ID = x.ProductCode, TEXT = x.ProductName }).Distinct();
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


        [HttpPost("RegisterMshsdRate")]
        public async Task<IActionResult> RegisterMshsdRate([FromBody]TblMshsdrates mshsdrates)
        {
            var result = await Task.Run(() =>
            {
                if (mshsdrates == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(mshsdrates)} cannot be null" });
                try
                {
                    var reponse = new MshsdRatesHelper().Register(mshsdrates);
                    if (reponse != null)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = reponse });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPut("UpdateMshsdRate")]
        public async Task<IActionResult> UpdateMshsdRate([FromBody] TblMshsdrates mshsdrates)
        {
            var result = await Task.Run(() =>
            {
                if (mshsdrates == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(mshsdrates)} cannot be null" });
                try
                {
                    APIResponse apiResponse = null;

                    TblMshsdrates result = new MshsdRatesHelper().Update(mshsdrates);
                    if (result != null)
                    {
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    }
                    else
                    {
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                    }
                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }


        [HttpDelete("DeleteMshsdRate/{code}")]
        public async Task<IActionResult> DeleteMshsdRate(int code)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

                try
                {
                    var result = new MshsdRatesHelper().Delete(code);
                    if (result != null)
                    {
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    }
                    else
                    {
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                    }
                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
    }
}