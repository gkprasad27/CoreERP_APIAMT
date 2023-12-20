using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.DataAccess.Repositories;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/UserCreation")]
    public class UserCreationController : Controller
    {
        private readonly IRepository<Erpuser> _epruserRepository;
        public UserCreationController(IRepository<Erpuser> ErpuserRepository)
        {
            _epruserRepository = ErpuserRepository;
        }
        [HttpPost("RegisterUserCreation")]
        public IActionResult RegisterUserCreation([FromBody] Erpuser user)
        {
            if (user == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (UserHelper.GetList(user.UserName).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Usercreation Code {nameof(user.UserName)} is already exists ,Please Use Different Code " });

                var result = UserHelper.Register(user);
                APIResponse apiResponse;
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                }

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetRoleList")]
        public IActionResult GetRoleList()
        {
            try
            {
                var roleList = UserHelper.GetRoleList();
                if (roleList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.roleList = roleList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetUserCreation")]
        public IActionResult GetUserCreation()
        {
            try
            {
                var userList = UserHelper.GetList();
                if (userList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.userList = userList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateUserCreation")]
        public IActionResult UpdateUserCreation([FromBody] Erpuser user)
        {
            if (user == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(user)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _epruserRepository.Update(user);
                if (_epruserRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = user };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteUserCreation/{code}")]
        public IActionResult DeleteUserCreationByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = UserHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}