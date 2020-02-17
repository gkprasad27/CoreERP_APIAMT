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
    [Route("api/payroll/StructureCreation")]
    public class StructureCreationController : ControllerBase
    {
        [HttpGet("GetStructuresList")]
        public async Task<IActionResult> GetStructuresList()
        {
            try
            {
                var structuresList = StructureHelper.GetListOfStructures();
                if (structuresList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.structuresList = structuresList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetComponentsList")]
        public async Task<IActionResult> GetComponentsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.ComponentsList = StructureHelper.GetComponentList().Select(x => new { ID = x.ComponentCode, TEXT = x.ComponentName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPFList")]
        public async Task<IActionResult> GetPFList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.PFList = StructureHelper.GetPFList().Select(x => new { ID = x.PftypeName, TEXT = x.PftypeName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterStructure")]
        public async Task<IActionResult> RegisterStructure([FromBody]StructureCreation structureCreation)
        {

            if (structureCreation == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Request can not be null" });
            else
            {
                if (StructureHelper.GetStrucutures(structureCreation.ComponentCode) != null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + structureCreation.ComponentCode + " is already Exists,Please Use Another Code" });

                try
                {
                    APIResponse apiResponse = null;
                    var result = StructureHelper.Register(structureCreation);
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

        [HttpPut("UpdateStructure")]
        public async Task<IActionResult> UpdateStructure([FromBody] StructureCreation structureCreation)
        {

            if (structureCreation == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Request cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                StructureCreation result = StructureHelper.Update(structureCreation);
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

        [HttpDelete("DeleteStructure/{code}")]
        public async Task<IActionResult> DeleteStructure(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Request can not be null" });

            try
            {
                var result = StructureHelper.DeleteStructures(code);
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