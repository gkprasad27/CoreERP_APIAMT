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
                dynamic expdoObj = new ExpandoObject();
                expdoObj.branchesList = branchesList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
            }
            catch
            {
                return BadRequest("No Data  Found");
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
                return BadRequest(ex);
            }

        }

        [HttpPost("RegisterBranch")]
        public async Task<IActionResult> RegisterBranch([FromBody]Branches branch)
        {
            APIResponse apiResponse = null;
            if (branch == null)
                return BadRequest($"{nameof(branch)} cannot be null");
            else
            {
                if (BrancheHelper.SearchBranch(branch.Code).Count() > 0)
                    return BadRequest($"Branch Code {nameof(branch.Code)} is already Present ,Please Use Different Code ");
                try
                {
                    int result = BrancheHelper.Register(branch);
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
                    return BadRequest(ex);
                }

            }
        } 



        [HttpPut("UpdateBranch/{code}")]
        public async Task<IActionResult> UpdateBranch(string code,[FromBody] Branches branch)
        {
            APIResponse apiResponse = null;
            if (branch == null)
                return BadRequest($"{nameof(branch)} cannot be null");

            try
            {
                int result=BrancheHelper.Update(branch);
                if (result > 0)
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
                return BadRequest(ex);
            }
        }


        // Delete Branch
        [HttpDelete("masters/branches/{code}")]
        public async Task<IActionResult> DeleteBranch(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                int result = BrancheHelper.Delete(code);
                if (result > 0)
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
                return BadRequest(ex);
            }
        }
    }
}