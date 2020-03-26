using System;
using System.Dynamic;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthenticationsController : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> ValidateUser([FromBody]Erpuser erpuser)
        {
            try
            {
                //Response.Headers.Add("Access-Control-Allow-Origin", "*");
                //Response.Headers.Add("Access-Control-Allow-Headers", "Accept");
                //Response.Headers.Add("Access-Control-Request-Headers", "origin,x-requested-with");
                //Response.Headers.Add("Access-Control-Allow-MethodsPOST, GET, OPTIONS, DELET", "Accept");
                Erpuser user = UserManagmentHelper.ValidateUser(erpuser);
                if (user != null)
                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= user });
                
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "User Name/ Password not valid." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
            }
        }

        [HttpGet("getMenu/{roleName}")]
        public async Task<IActionResult> GetMenus(string roleName)
        {
            try
            {
                var result = UserManagmentHelper.GetScreensListByUserRole(roleName);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  Menu found for user." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message: ex.InnerException.Message });
            }

        }

        [HttpGet("GetMenuList")]
        public async Task<IActionResult> GetMenuList()
        {
            try
            {
                var result = new UserManagmentHelper().GetMenus();
                if (result != null)
                {
                    dynamic expando = new ExpandoObject();
                    expando.MenusList = result;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  Menu found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
            }
        }
    }
}
       
