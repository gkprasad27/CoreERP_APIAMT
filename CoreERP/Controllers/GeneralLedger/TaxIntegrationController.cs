using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/TaxIntegration")]
    public class TaxIntegrationController : ControllerBase
    {
     /*   [HttpPost("generalledger/taxintegration/register")]
        public async Task<IActionResult> Register([FromBody]TaxIntegration taxintegration)
        {
            try
            {
                int result = GLHelper.RegisterTaxIntegration(taxintegration);
                if (result > 0)
                    return Ok(taxintegration);
            }
            catch
            {
            }
            return BadRequest("Registration Failed");
        }


        [HttpGet("generalledger/taxintegration")]
       // [Produces(typeof(List<TaxIntegration>))]
        public async Task<IActionResult> GetAllTaxIntegration()
        {
            //return Json(
            //    new
            //    {
            //        taxintigration = _unitOfWork.TaxIntegration.GetAll(),
            //        companys = CompanyHelper.GetDistinctCompanyNames(this._unitOfWork),
            //        branch = _unitOfWork.Branches.GetAll(),
            //        taxcodeDescr = (from taxmast in _unitOfWork.TaxMasters.GetAll() select new { taxmast.Code, taxmast.Description }),
            //        taxaccounts = (from taxacc in (from glacc in _unitOfWork.GLAccounts.GetAll()
            //                                       where glacc.Nactureofaccount != null
            //                                       select glacc)
            //                       where taxacc.Nactureofaccount.ToLower() == "tax"
            //                       select taxacc)
            //   });
            return Ok(
               new
               {
                  taxintigration = GLHelper.GetTaxIntegrationList(),
                   //taxcodeDescr = (from taxmast in _unitOfWork.TaxMasters.GetAll() select new { taxmast.Code, taxmast.Description }),
               });

        }


        [HttpGet("generalledger/taxintegration/getTaxCodes")]
        public async Task<IActionResult> GetTaxCodes()
        {
            try
            {
                return Ok(new { taxcodeDescr = GLHelper.GetTaxMastersList().Select(x => new { ID = x.Code, TEXT = x.Description }) });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load companys.");
            }
        }



        [HttpGet("generalledger/taxintegration/getCompanys")]
        public async Task<IActionResult> GetCompanys()
        {
            try
            {
                return Ok(new { companys = GLHelper.GetCompanies().Select(x => new { ID = x.CompanyCode, TEXT = x.Name }) });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load companys.");
            }
        }

        [HttpGet("generalledger/taxintegration/getBranches")]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                return Ok(new { branches = GLHelper.GetBranches().Select(x => new { ID = x.CompanyCode, TEXT = x.Name }) });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Branches.");
            }
        }

        [HttpGet("generalledger/taxintegration/getTaxAccounts")]
        public async Task<IActionResult> GetTaxAccounts()
        {
            try
            {
                return Ok(new { taxacc = GLHelper.GetTaxAccounts() });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load Tax Accounts.");
            }
        }

        [HttpPut("generalledger/taxintegration/{code}")]
        public async Task<IActionResult> UpdateTaxIntegration(string code, [FromBody] TaxIntegration taxintegration)
        {
            if (taxintegration == null)
                return BadRequest($"{nameof(taxintegration)} cannot be null");

            try
            {
                int result = GLHelper.UpdateTaxIntegration(taxintegration);
                if (result > 0)
                    return Ok(taxintegration);
            }
            catch { }

            return BadRequest("Updation Failed");
        }


        [HttpDelete("generalledger/taxintegration/{code}")]
        public async Task<IActionResult> DeleteTaxIntegrationByID(string code)
        {
           // Division division = null;
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest($"{nameof(code)} cannot be null");

            try
            {
                int result = GLHelper.DeleteTaxIntegration(code);
                if (result > 0)
                    return Ok(code);
            }
            catch { }

            return BadRequest("Delete Operation Failed");


        }


        [HttpGet("generalledger/taxintegration/complist")]
        public async Task<IActionResult> GetAllCompanysMasters()
        {

            try
            {
                return Ok(new { companys = GLHelper.GetCompanies().Select(x => new { ID = x.CompanyCode, TEXT = x.Name }) });
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to load companys.");
            }
        }



        [HttpGet("generalledger/taxintegration/branchlist")]
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



        [HttpGet("generalledger/taxintegration/glacclist")]
        public async Task<IActionResult> GetAllGLAccounts()
        {
            //var result = (from account in _unitOfWork.GLAccounts.GetAll()
            //              where account.Nactureofaccount == "Tax"
            //              select account).ToList<GLAccounts>();
            var result = (from account in GLHelper.GetGLAccountsList()
                                where account.Nactureofaccount == "Tax"
                                select account).ToList<Glaccounts>();
            return Ok(result);
        }*/
    }
}
       
