using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.Helpers.SharedModels;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Extensions.Logging.Abstractions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreERP
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
        public async Task<IActionResult> RegisterStructureCreation([FromBody] JObject obj)
        {

            var result = await Task.Run(() =>
            {
                try
                {
                    if (obj == null)
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                    var stMaster = obj["stHdr"].ToObject<StructureCreation>();
                    var stdetails = obj["stDtl"].ToObject<List<StructureComponents>>();
                    ///var username = User.Identities.ToList();

                    if (!new StructureCreationHelper().Register(stMaster, stdetails))
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.invoi = stMaster;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
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