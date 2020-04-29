using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/gl/TaxIntegration")]
    public class TaxIntegrationController : ControllerBase
    {
        [HttpPost("RegisterTaxIntegration")]
        public IActionResult RegisterTaxIntegration([FromBody]TaxIntegration taxintegration)
        {
            if (taxintegration == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
            try
            {
                if (GLHelper.GetTaxIntegrationList(taxintegration.TaxCode).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Tax Code ={taxintegration.TaxCode} alredy exists." });

                TaxIntegration result = GLHelper.RegisterTaxIntegration(taxintegration);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTaxintigrationList")]
        public IActionResult GetTaxintigrationList()
        {
            try
            {
                var taxintigrationList = GLHelper.GetTaxIntegrationList();
                if (taxintigrationList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxintigrationList = taxintigrationList;
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
        }

        [HttpGet("GetTaxCodesList")]
        public IActionResult GetTaxCodesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.TaxcodesList = GLHelper.GetTaxMastersList().Select(x => new { ID = x.Code, TEXT = x.Description });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCompanysList")]
        public IActionResult GetCompanysList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CompanysList = GLHelper.GetCompanies().Select(x => new { ID = x.CompanyId, TEXT = x.CompanyName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBranchesList")]
        public IActionResult GetBranchesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BranchesList = GLHelper.GetBranches().Select(x => new { ID = x.BranchCode, TEXT = x.BranchName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGLTaxAccountList")]
        public IActionResult GetGLTaxAccountList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GLTaxAccountList = GLHelper.GetTaxAccounts().Select(x => new { ID = x.Glcode, TEXT = x.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateTaxIntegration")]
        public IActionResult UpdateTaxIntegration( [FromBody] TaxIntegration taxintegration)
        {
            if (taxintegration == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(taxintegration)} cannot be null" });

            try
            {
                TaxIntegration result = GLHelper.UpdateTaxIntegration(taxintegration);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteTaxIntegration/{code}")]
        public IActionResult DeleteTaxIntegration(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                TaxIntegration result = GLHelper.DeleteTaxIntegration(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("generalledger/taxintegration/glacclist")]
        //public async Task<IActionResult> GetAllGLAccounts()
        //{
        //    //var result = (from account in _unitOfWork.GLAccounts.GetAll()
        //    //              where account.Nactureofaccount == "Tax"
        //    //              select account).ToList<GLAccounts>();
        //    var result = (from account in GLHelper.GetGLAccountsList()
        //                        where account.Nactureofaccount == "Tax"
        //                        select account).ToList<Glaccounts>();
        //    return Ok(result);
        //}*/
    }
}
       
