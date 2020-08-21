using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Branches")]
    public class BranchesController : ControllerBase
    {
        private readonly IRepository<TblBranch> _branchRepository;
        private readonly IRepository<TblCompany> _companyRepository;
        public BranchesController(IRepository<TblBranch> branchRepository, IRepository<TblCompany> companyRepository)
        {
            _branchRepository = branchRepository;
            _companyRepository = companyRepository;
        }

        [HttpGet("GetAllCompanys")]
        public async Task<IActionResult> GetAllCompanys()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var companiesList = _companyRepository.GetAll();
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.companiesList = companiesList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
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
                    var branchesList = CommonHelper.GetBranches();
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
            });
            return result;
        }       

        [HttpPost("RegisterBranch")]
        public async Task<IActionResult> RegisterBranch([FromBody]TblBranch branch)
        {
            APIResponse apiResponse ;
            if (branch == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(branch)} cannot be null" });
            else
            {
                //if (BrancheHelper.SearchBranch(branch.BranchCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Branch Code {nameof(branch.BranchCode)} is already Present ,Please Use Different Code" });
                try
                {
                    _branchRepository.Add(branch);
                    if (_branchRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = branch };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPut("UpdateBranch")]
        public async Task<IActionResult> UpdateBranch([FromBody] TblBranch branch)
        {
            APIResponse apiResponse = null;
            if (branch == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _branchRepository.Update(branch);
                if (_branchRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = branch };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteBranches/{code}")]
        public async Task<IActionResult> DeleteBranch(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _branchRepository.GetSingleOrDefault(x => x.BranchCode.Equals(code));
                _branchRepository.Remove(record);
                if (_branchRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}