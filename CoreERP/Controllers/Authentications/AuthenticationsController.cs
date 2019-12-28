using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthenticationsController : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Register([FromBody]Erpuser erpuser)//
        {
            try
            {
                Erpuser user = UserManagmentHelper.ValidateUser(erpuser);
                if (user != null)
                    return Ok(user);

                return Ok("User Name/ Password not valid.");
            }
            catch (Exception ex)
            {
                return Ok("Login Failed");
            }
        }

        [HttpGet("getMenu/{roleName}")]
        public async Task<IActionResult> GetMenus(string roleName)
        {
            try {
                try 
                { 
                    var result=UserManagmentHelper.GetScreensListByUserRole(roleName);


                    return Ok(result);
                }
                catch(Exception e) {
                    return Ok(e.Message);
                }
                
            }
            catch(Exception ex)
            {
                return NoContent();
            }
        }

    }
}
       
