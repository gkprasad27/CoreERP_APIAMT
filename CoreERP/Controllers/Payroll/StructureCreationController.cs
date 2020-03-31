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
        public IActionResult GetStructuresList()
        {
            try
            {
                var structuresList = StructureCreationHelper.GetListOfStructures();
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

        [HttpPost("RegisterStructureCreation")]
        public IActionResult RegisterStructureCreation([FromBody]StructureCreation structureCreation)
        {

            if (structureCreation == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(structureCreation)} cannot be null" });
            else
            {
                if (StructureCreationHelper.GetStructures(structureCreation.StructureCode) != null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Code =" + structureCreation.StructureCode + " is already Exists,Please Use Another Code" });

                try
                {
                    APIResponse apiResponse = null;
                    var result = StructureCreationHelper.Register(structureCreation);
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

        [HttpPut("UpdateStructureCreation")]
        public IActionResult UpdateStructureCreation([FromBody] StructureCreation structureCreation)
        {

            if (structureCreation == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(structureCreation)} cannot be null" });
            try
            {
                APIResponse apiResponse = null;

                StructureCreation result = StructureCreationHelper.Update(structureCreation);
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

        [HttpDelete("DeleteStructureCreation/{code}")]
        public IActionResult DeleteStructureCreation(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var result = StructureCreationHelper.Delete(code);
                APIResponse apiResponse;
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