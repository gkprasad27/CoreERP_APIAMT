using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.GeneralLedger
{
    [ApiController]
    [Route("api/gl/AccountLedger")]
    public class AccountLedgerController : Controller
    {
        [HttpGet("GetTblAccountLedgerList")]
        public IActionResult GetTblAccountLedgerList()
        {
            try
            {
                var tblAccountLedgerList = new GLHelper().GetTblAccountLedgerList();
                if (tblAccountLedgerList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.AccountLedgerList = tblAccountLedgerList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountGrouplist")]
        public IActionResult GetAccountGrouplist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GetAccountGrouplist = new GLHelper().GetTblAccountGroupList().Select(a => new { ID = a.AccountGroupId, TEXT = a.AccountGroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountTypelist")]
        public IActionResult GetAccountTypelist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GetAccountTypelist = new GLHelper().GetTblAccountTypeList().Select(a => new { ID = a.TypeId, TEXT = a.TypeName});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPaymentTypelist")]
        public IActionResult GetPaymentTypelist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GetPaymentTypelist = new GLHelper().GetTblPaymentTypeList().Select(a => new { ID = a.PaymentTypeId, TEXT = a.PaymentTypeName});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPricingLevellist")]
        public IActionResult GetPricingLevellist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.GetPricingLevellist = new GLHelper().GetTblPricingLevelList().Select(a => new { ID = a.PricinglevelId, TEXT = a.PricinglevelName});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterTblAccLedger")]
        public IActionResult RegisterTblAccLedger([FromBody]TblAccountLedger tblAccLedger)
        {
            if (tblAccLedger == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(tblAccLedger)} can not be null" });

            try
            {
                TblAccountLedger result = new GLHelper().RegisterTblAccLedger(tblAccLedger);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateTblAccountLedger")]
        public IActionResult UpdateTblAccountLedger([FromBody] TblAccountLedger tblAccLedger)
        {
            if (tblAccLedger == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(tblAccLedger)} cannot be null" });

            try
            {
                TblAccountLedger result = new GLHelper().UpdateTblAccountLedger(tblAccLedger);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteTblAccountLedger/{code}")]
        public IActionResult DeleteTblAccountLedger(int code)
        {
            try
            {
                TblAccountLedger result = new GLHelper().DeleteTblAccountLedger(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}