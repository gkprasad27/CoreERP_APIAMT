using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.DataAccess;
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Inventory/AccountingClass")]
    public class AccountingClassController : ControllerBase
    {

        [HttpPost("RegisterAccountingClass")]
        public async Task<IActionResult> RegisterAccountingClass([FromBody]AccountingClass accountingClass)
        {
            if (accountingClass == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(accountingClass)} can not be null" });

            try
            {
                var result = AccountClassHelper.RegisterAccountingClass(accountingClass);
                if (result!=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =" Registration Failed" }); 
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }
        }

        [HttpGet("GetAllAccountingClass")]
        [Produces(typeof(List<AccountingClass>))]
        public async Task<IActionResult> GetAllAccountingClass()
        {
            try
            {
                var accountingClassList = AccountClassHelper.GetAccountingClassList();
                if (accountingClassList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.AccountingClassList = accountingClassList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAccountingClass")]
        [Produces(typeof(AccountingClass))]
        public async Task<IActionResult> UpdateAccountingClass([FromBody] AccountingClass accountingClasess)
        {
            if (accountingClasess == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(accountingClasess)} cannot be null" });

            try
            {
                AccountingClass result = AccountClassHelper.UpdateAccountingClass(accountingClasess);
                if (result != null)
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = accountingClasess });

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }
        }


        [HttpDelete("DeleteAccountingClass/{code}")]
        [Produces(typeof(AccountingClass))]
        public async Task<IActionResult> DeleteAccountingClass(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                AccountingClass result = AccountClassHelper.DeleteAccountingClass(code);
                if (result !=null)
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = code });
                
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }
        }
    }
}