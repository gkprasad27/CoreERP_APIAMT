using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.Payroll;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Payroll
{
    [ApiController]
    [Route("api/payroll/ComponentMaster")]
    public class ComponentMasterController : ControllerBase
    {
        [HttpGet("GetComponentsList")]
        public async Task<IActionResult> GetComponentsList()
        {
            try
            {
                var componentsList = ComponentMasterHelper.GetListOfComponents();
                if (componentsList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.componentsList = componentsList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterComponent")]
        public async Task<IActionResult> RegisterComponent([FromBody]ComponentMaster componentMaster)
        {

            if (componentMaster == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(componentMaster)} cannot be null" });
            else
            {
                if (ComponentMasterHelper.GetComponents(componentMaster.ComponentCode) != null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + componentMaster.ComponentCode + " is already Exists,Please Use Another Code" });

                try
                {
                    APIResponse apiResponse = null;
                    var result = ComponentMasterHelper.Register(componentMaster);
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
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            }
        }

        [HttpPut("UpdateComponent")]
        public async Task<IActionResult> UpdateComponent([FromBody] ComponentMaster componentMaster)
        {

            if (componentMaster == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(componentMaster)} cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                ComponentMaster result = ComponentMasterHelper.Update(componentMaster);
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteComponent/{code}")]
        public async Task<IActionResult> DeleteComponent(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = ComponentMasterHelper.DeleteComponents(code);
                if (result != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}