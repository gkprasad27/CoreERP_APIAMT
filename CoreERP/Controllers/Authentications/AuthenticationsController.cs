using System;
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
        public async Task<IActionResult> Register([FromBody]Erpuser erpuser)
        {
            try
            {
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                Erpuser user = UserManagmentHelper.ValidateUser(erpuser);
                if (user != null)
                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= user });
                
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "User Name/ Password not valid." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "User Name/ Password not valid." });
            }
        }

        [HttpGet("getMenu/{roleName}")]
        public async Task<IActionResult> GetMenus(string roleName)
        {
            try {
                try 
                { 
                    var result=UserManagmentHelper.GetScreensListByUserRole(roleName);
                    if(result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  Menu found for user." });
                }
                catch(Exception ex) 
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
                }
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status =APIStatus.FAIL.ToString(),response=ex.Message});
            }
        }
    }
}
       
