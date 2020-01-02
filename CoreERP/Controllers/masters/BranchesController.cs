using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Branches")]
    public class BranchesController : ControllerBase
    {
       

        [HttpGet("masters/branches")]
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


        [HttpGet("masters/branches/cmplst")]

        public async Task<IActionResult> GetAllCompanys()
        {
            try { return Ok(CompaniesHelper.GetListOfCompanies()); }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost("masters/branches/register")]
        public async Task<IActionResult> Register([FromBody]Branches branch)
        {
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
                        return Ok(branch);

                    return BadRequest("Registraion  Failed");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
        } 



        [HttpPut("masters/branches/{code}")]
        public async Task<IActionResult> UpdateBrach(string code,[FromBody] Branches branch)
        {
            if (branch == null)
                return BadRequest($"{nameof(branch)} cannot be null");

            try
            {
                int result=BrancheHelper.Update(branch);
                if (result > 0)
                    return Ok(branch);

                //otherwise return 
                return BadRequest($"{nameof(branch)} Updation Failed");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("DeleteBranch")]
        public async Task<IActionResult> DeleteBranch(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                Branches brch = BrancheHelper.GetBranches(code);
                brch.Active = "N";
                int result = BrancheHelper.Update(brch);

                if (result > 0)
                    return Ok(code);

                return BadRequest("Deletion Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}