using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/masters/Branches")]
    public class BranchesController : ControllerBase
    {
     
        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                var branchesList = BrancheHelper.GetBranches();
                if (branchesList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.branchesList = branchesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAllCompanys")]
        public async Task<IActionResult> GetAllCompanys()
        {
            try
            {
                var companiesList = CompaniesHelper.GetListOfCompanies();
                dynamic expdoObj = new ExpandoObject();
                expdoObj.companiesList = companiesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterBranch")]
        public async Task<IActionResult> RegisterBranch([FromBody]Branches branch)
        {
            APIResponse apiResponse = null;
            if (branch == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(branch)} cannot be null"});
            else
            {
                if (BrancheHelper.SearchBranch(branch.BranchCode).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Branch Code {nameof(branch.BranchCode)} is already Present ,Please Use Different Code"});
                try
                {
                    var result = BrancheHelper.Register(branch);
                    if (result !=null)
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

            }
        }

        [HttpPut("UpdateBranch")]
        public async Task<IActionResult> UpdateBranch([FromBody] Branches branch)
        {
            APIResponse apiResponse = null;
            if (branch == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Request cannot be null"});

            try
            {
                var result=BrancheHelper.Update(branch);
                if (result !=null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }
        }

        [HttpDelete("DeleteBranches/{code}")]
        public async Task<IActionResult> DeleteBranch(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null"});

            try
            {
                var result = BrancheHelper.Delete(code);
                if (result !=null)
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
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}