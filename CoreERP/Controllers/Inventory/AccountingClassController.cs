using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.DataAccess;
namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/Inventory/AccountingClass")]
    public class AccountingClassController : ControllerBase
    {

        [HttpPost("RegisterAccountingClass")]
        public async Task<IActionResult> RegisterAccountingClass([FromBody]AccountingClass accountingClass)
        {
            if (accountingClass == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(accountingClass)} can not be null" });

            try
            {
                var result = AccountClassHelper.RegisterAccountingClass(accountingClass);
                if (result!=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response =" Registration Operation Failed" }); 
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }

        }



        [HttpGet("GetAllAccountingClass")]
        [Produces(typeof(List<AccountingClass>))]
        public async Task<IActionResult> GetAllAccountingClass()
        {
            try
            {
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = AccountClassHelper.GetAccountingClassList() });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Failed to load Accounting Class" });
            }
        }

        [HttpPut("UpdateAccountingClass/{code}")]
        [Produces(typeof(AccountingClass))]
        public async Task<IActionResult> UpdateAccountingClass(string code, [FromBody] AccountingClass accountingClasess)
        {
            if (accountingClasess == null)
                return BadRequest(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(accountingClasess)} cannot be null" });

            if (!string.IsNullOrWhiteSpace(accountingClasess.Code) && code != accountingClasess.Code)
                return BadRequest(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Conflicting role id in parameter and model data" });

            try
            {
                AccountingClass result = AccountClassHelper.UpdateAccountingClass(accountingClasess);
                if (result !=null)
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = accountingClasess });
                else
                    return BadRequest(new APIResponse { status=APIStatus.FAIL.ToString(),response= $"{nameof(accountingClasess)} Updation Failed"});
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(accountingClasess)} Updation Failed" });
            }
        }


        [HttpDelete("DeleteAccountingClass/{code}")]
        [Produces(typeof(AccountingClass))]
        public async Task<IActionResult> DeleteAccountingClass(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                AccountingClass result = AccountClassHelper.DeleteAccountingClass(code);
                if (result !=null)
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = code });
                else
                    return BadRequest(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Delete Operation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Delete Operation Failed" });
            }
        }
    }
}