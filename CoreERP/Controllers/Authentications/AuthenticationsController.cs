using System;
using System.Dynamic;
using System.Linq;
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
            var result = await Task.Run(() =>
            {
                try
                {
                    //Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    //Response.Headers.Add("Access-Control-Allow-Headers", "Accept");
                    //Response.Headers.Add("Access-Control-Request-Headers", "origin,x-requested-with");
                    //Response.Headers.Add("Access-Control-Allow-MethodsPOST, GET, OPTIONS, DELET", "Accept");
                    Erpuser user = UserManagmentHelper.ValidateUser(erpuser);

                    if (user != null)
                    {
                        var _branch = UserManagmentHelper.GetBranchesByUser(user.SeqId);
                        var shiftId = new UserManagmentHelper().GetShiftId(user.SeqId, _branch.FirstOrDefault());
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = user });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "User Name/ Password not valid." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }
        //get branches
        [HttpGet("GetBranchesForUser/{seqid}")]
        public async Task<IActionResult> GetBranchesForUser(string seqid)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    if (string.IsNullOrEmpty(seqid))
                    {
                        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
                    }

                    dynamic expando = new ExpandoObject();
                    expando.Branches = UserManagmentHelper.GetBranchesByUser(Convert.ToDecimal(seqid));
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

        [HttpGet("getMenu/{roleName}")]
        public async Task<IActionResult> GetMenus()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var result = UserManagmentHelper.GetScreensListByUserRole();
                    if (result != null)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  Menu found for user." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

        [HttpGet("GetMenuList")]
        public async Task<IActionResult> GetMenuList()
        {
            var result = await Task.Run(() =>
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
            });
            return result;
        }

        [HttpGet("logout/{userId}")]
        public async Task<IActionResult> GetMenuList(string userId)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    string errorMessage = string.Empty;
                    var result = new UserManagmentHelper().GetErpuser(Convert.ToDecimal(userId));
                    if (result != null)
                    {
                        var _branch = UserManagmentHelper.GetBranchesByUser(Convert.ToDecimal(userId));
                        foreach (var br in _branch)
                            new UserManagmentHelper().LogoutShiftId(Convert.ToDecimal(userId), br, out errorMessage);


                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Log out successfully." });
                    }

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No  Menu found." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.InnerException == null ? ex.Message : ex.InnerException.Message });
                }
            });
            return result;
        }

    }
}
       
