using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.SettingsHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Authentications
{
    [Route("api/Settings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        [HttpGet("GetScreenNames")]
        public async Task<IActionResult> GetScreenNames()
        {
            try
            {
                var menusList = new SettingsHelper().GetMenusList();
                if (menusList.Count > 0) {
                    dynamic expando = new ExpandoObject();
                    expando.ScreenNames = menusList.Select(m=> new { ID=m.Code ,TEXT=m.DisplayName});

                    return Ok(new APIResponse() { status =APIStatus.PASS.ToString(),response= expando});
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Screen Found" });
            }
            catch(Exception ex)
            {
                string message = string.Empty;

                if(ex.InnerException == null)
                {
                    message = ex.Message;
                }
                else
                {
                    message = ex.InnerException.Message;
                }

                return Ok(new APIResponse() { status =APIStatus.FAIL.ToString(),response=message});
            }
        }

        [HttpGet("GetParentMenuNames")]
        public async Task<IActionResult> GetParentMenuNames()
        {
            try
            {
                var menusList = new SettingsHelper().GetMenusList();
                if (menusList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.ScreenNames = menusList.Select(m => new { ID = m.Code, TEXT = m.DisplayName });

                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Screen Found" });
            }
            catch (Exception ex)
            {
                string message = string.Empty;

                if (ex.InnerException == null)
                {
                    message = ex.Message;
                }
                else
                {
                    message = ex.InnerException.Message;
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
            }
        }

        [HttpGet("GetUsersList")]
        public async Task<IActionResult> GetUsersList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ScreenNames = UserManagmentHelper.GetErpusers().Select(m => new { ID = m.SeqId, TEXT = m.UserName });

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                string message = string.Empty;

                if (ex.InnerException == null)
                {
                    message = ex.Message;
                }
                else
                {
                    message = ex.InnerException.Message;
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = message });
            }
        }
    }
}