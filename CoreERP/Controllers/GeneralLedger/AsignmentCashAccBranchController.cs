using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.GL
{
    [ApiController]
    [Route("api/AsignmentCashAccBranch")]
    public class AsignmentCashAccBranchController : ControllerBase
    {
        [HttpPost("generalledger/asignmentcashaccbranch/register")]
        public async Task<IActionResult> Register([FromBody]AsignmentCashAccBranch asignmentCashAccBranch)
        {
            try
            {
                int result = GLHelper.RegisterCashAccToBranches(asignmentCashAccBranch);
                if (result > 0)
                    return Ok(asignmentCashAccBranch);
            }
            catch
            { }
            return BadRequest("Registration Failed");

        }

        [HttpGet("generalledger/asignmentcashaccbranch")]
        public async Task<IActionResult> GetAll()
        {
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
            return Ok(
               new
               {
                   asiCashAccBranch = GLHelper.GetAsignCashAccBranch(),
                   glCashBankAcc = (from cashbankacc in GLHelper.GetGLAccountsList().Where(glacc=>glacc.Nactureofaccount != null)
                                    where cashbankacc.Nactureofaccount.Equals("cash",StringComparison.OrdinalIgnoreCase)
                                    select cashbankacc),
                   glbankaccounts = (from bankacc in GLHelper.GetGLAccountsList().Where(glacc=>glacc.Nactureofaccount != null)
                                     where bankacc.Nactureofaccount.Equals("bank",StringComparison.OrdinalIgnoreCase)
                                     select bankacc)
               });

        }

        [HttpPut("generalledger/asignmentcashaccbranch/{code}")]
        public async Task<IActionResult> UpdateTaxIntegration(string code, [FromBody] AsignmentCashAccBranch asignmentCashAccBranch)
        {
            if (asignmentCashAccBranch == null)
                return BadRequest($"{nameof(asignmentCashAccBranch)} cannot be null");

            if (!string.IsNullOrWhiteSpace(asignmentCashAccBranch.Code) && code != asignmentCashAccBranch.Code)
                return BadRequest("Conflicting role id in parameter and model data");


            try
            {
                int result = GLHelper.UpdateCashAccToBranches(asignmentCashAccBranch);
                if (result > 0)
                    return Ok(asignmentCashAccBranch);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("generalledger/asignmentcashaccbranch/{code}")]
        public async Task<IActionResult> DeleteTaxIntegrationByID(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = GLHelper.DeleteCashAccToBranches(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");


        }


        [HttpGet("generalledger/asignmentcashaccbranch/brchlst")]
        public async Task<IActionResult> GetAllBranches()
        {
            try
            {
                return Ok(new { branches = GLHelper.GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.Name }) });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Branches.");
            }
        }



        [HttpGet("generalledger/asignmentcashaccbranch/bankacclst")]
        public async Task<IActionResult> GetBankAccounts()
        {

            try
            {
                var result = GLHelper.GetGLAccountsList()
                                     .Where(accounts => accounts.Nactureofaccount.Equals("Bank",StringComparison.OrdinalIgnoreCase)
                                                    || accounts.Nactureofaccount.Equals("Cash",StringComparison.OrdinalIgnoreCase)).ToList();
                return Ok(result);
            }
            catch
            {
                return NoContent();
            }
           
        }
    }
}