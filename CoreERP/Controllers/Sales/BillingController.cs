using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreERP.DataAccess;
using System;
using System.Dynamic;
using CoreERP.BussinessLogic.SalesHelper;
using System.Threading.Tasks;
using System.Linq;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/Billing")]
    public class BillingController : ControllerBase
    {
       
        [HttpGet("GenerateBillNo/{branchCode}")]
        public async Task<IActionResult> GenerateBillNo(string branchCode)
        {
            try
            {
                string errorMessage = string.Empty;

                var billno = BillingHelpers.GenerateBillNo(branchCode, out errorMessage);
                if (billno != null)
                {
                    dynamic expando = new ExpandoObject();
                    expando.BillNo = billno;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMessage });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBillingList/{branchCode}")]
        public async Task<IActionResult> GetBillingList(string branchCode)
        {
            try
            {
                var billingList = BillingHelpers.GetBillings(branchCode);
                if (billingList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.BillingList = billingList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="No billing records Found." });
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
                expando.BranchesList = BillingHelpers.GetBranchesList().Select(x=> new { ID=x.BranchCode ,TEXT=x.Name});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetEmployesList/{branchCode}")]
        public async Task<IActionResult> GetEmployesList(string branchCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.EmployeeList = BillingHelpers.GetEmployee(branchCode).Select(e=>new { ID=e.Code,TEXT=e.Name});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetCardTypeList")]
        public async Task<IActionResult> GetCardTypeList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CardTypeList = BillingHelpers.GetCardTypeList().Select(e => new { ID = e.Code, TEXT = e.CardName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetGlaccountsList")]
        public async Task<IActionResult> GetGlaccountsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GlaccountsList = BillingHelpers.GetGlaccounts().Select(gl => new { ID = gl.Glcode, TEXT = gl.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetcashAcctobranchAccountsList/{branchCode}")]
        public async Task<IActionResult> GetcashAcctobranchAccountsList(string branchCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GlaccountsList = BillingHelpers.GetAsignmentCashAccBranchList(branchCode).Select(gl => new { ID = gl.Glcode, TEXT = gl.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetModelList/{modelName}")]
        public async Task<IActionResult> GetModelList(string modelName)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ModelListList = BillingHelpers.GetModelList(modelName);//.Select(m=>new { ID=m.Code,TEXT=m.Description}); 
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetModelDetails/{modelCode}")]
        public async Task<IActionResult> GetModelDetails(string modelCode)
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ModelListList = BillingHelpers.GetModelDetails(modelCode);
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetFinanceGlAccList")]
        public async Task<IActionResult> GetFinanceGlAccList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.FinanceGlAccList = BillingHelpers.GetFinancesCutomerGLAccounts().Select(gl=> new { ID=gl.Glcode,TEXT=gl.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterBilling")]
        public async Task<IActionResult> RegisterBilling([FromBody]Invoice[] billings)
        {

            if (billings == null  || billings?.Length ==0)
                return Ok(new APIResponse() { status=APIStatus.FAIL.ToString(),response= $"{nameof(billings)} cannot be null" });
            try
            {
                var result = BillingHelpers.RegisterBilling(billings);
                if (result.Count > 0)
                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

       
    }
}

