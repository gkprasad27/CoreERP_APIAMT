using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{

    [ApiController]
    [Route("api/masters/PartnerType")]
    public class PartnerTypeController : ControllerBase
    {

        [HttpPost("RegisterPartnerType")]
        public async Task<IActionResult> RegisterPartnerType([FromBody]PartnerType partnerType)
        {
            if (partnerType == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(partnerType)} can not be null" });
            try
            {
                var result = PartnerTypeHelper.RegistePartnerType(partnerType);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = partnerType });
            }
            catch
            {             
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
        }



        [HttpGet("GetPartnerTypesList")]
        public async Task<IActionResult> GetAllPartnerTypes()
        {
            try
            {
                var partnerTypeList = PartnerTypeHelper.GetPartnerTypeList();
                if(partnerTypeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.partnerTypeList = partnerTypeList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });

            }
            catch(Exception ex)
            {

            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load data." });
        }

        [HttpPut("UpdatePartnerType")]
        public async Task<IActionResult> UpdatePartnerType([FromBody] PartnerType partnerType)
        {
            try
            {
                if (partnerType == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(partnerType)} cannot be null" });
         
                var rs = PartnerTypeHelper.UpdatePartnerType(partnerType);
                if (rs != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = rs });

            }
            catch { throw; }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
        }


        [HttpDelete("DeletePartnerType/{code}")]
        public async Task<IActionResult> DeletePartnerTypeByID(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });
             

                var result =PartnerTypeHelper.DeletePartnerType(code);
                if(result!=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
            }
            catch { }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
        }
    }
}
