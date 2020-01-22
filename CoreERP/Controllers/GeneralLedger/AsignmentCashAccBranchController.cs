using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/gl/AsignmentCashAccBranch")]
    public class AsignmentCashAccBranchController : ControllerBase
    {
        [HttpPost("RegisterAsigCashAccBranch")]
        public async Task<IActionResult> RegisterAsigCashAccBranch([FromBody]AsignmentCashAccBranch asignmentCashAccBranch)
        {
            try
            {
                AsignmentCashAccBranch result = GLHelper.RegisterCashAccToBranches(asignmentCashAccBranch);
                if (result != null)
                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "" });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

       [HttpGet("GetAsignCashAccBranchList")]
        public async Task<IActionResult> GetAsignCashAccBranchList()
        {
            try
            {
                var asignCashAccBranchList = GLHelper.GetAsignCashAccBranch();
                if (asignCashAccBranchList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.AsignCashAccBranchList = asignCashAccBranchList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            //return Json(
            //    new
            //    {
            //        asiCashAccBranch = _unitOfWork.AsignmentCashAccBranch.GetAll(),
            //        branch = _unitOfWork.Branches.GetAll(),
            //        glCashBankAcc = (from cashbankacc in (from glacc in _unitOfWork.GLAccounts.GetAll() where glacc.Nactureofaccount != null select glacc)
            //                         where cashbankacc.Nactureofaccount.ToLower() == "cash"
            //                         select cashbankacc),
            //        glbankaccounts = (from bankacc in (from glacc in _unitOfWork.GLAccounts.GetAll() where glacc.Nactureofaccount != null select glacc)
            //                          where bankacc.Nactureofaccount.ToLower() == "bank"
            //                          select bankacc)
            //    });            

        }

        [HttpPut("UpdateaAignmentCashAccBranch")]
        public async Task<IActionResult> UpdateaAignmentCashAccBranch([FromBody] AsignmentCashAccBranch asignmentCashAccBranch)
        {
            if (asignmentCashAccBranch == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(asignmentCashAccBranch)} cannot be null" });
            
            try
            {
                AsignmentCashAccBranch result = GLHelper.UpdateCashAccToBranches(asignmentCashAccBranch);
                if (result !=null)
                    return Ok(new APIResponse() {status=APIStatus.PASS.ToString(), response=result});

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteAignmentCashAccBranch/{code}")]
        public async Task<IActionResult> DeleteAignmentCashAccBranch(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                AsignmentCashAccBranch result = GLHelper.DeleteCashAccToBranches(code);
                if (result !=null)
                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = GLHelper.GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.Name });
                return Ok(new APIResponse(){status=APIStatus.PASS.ToString(),response= expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetBankAccounts")]
        //public async Task<IActionResult> GetBankAccounts()
        //{

        //    try
        //    {
        //       var GLCasnBankAccounts= GLHelper.GetGLAccountsList()
        //                               .Where(accounts => accounts.Nactureofaccount == NatureOfAccounts.BANK.ToString()
        //                                            || accounts.Nactureofaccount == NatureOfAccounts.CASH.ToString()).ToList();
        //        dynamic expando = new ExpandoObject();
        //        expando.GLCasnBankAccounts = GLCasnBankAccounts.Select(x => new { ID = x.Glcode, TEXT = x.Description });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}