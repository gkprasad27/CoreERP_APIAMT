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

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
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

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
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

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountTypesList")]
        public async Task<IActionResult> GetAccountTypesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.partnerTypeList = PartnerTypeHelper.GetAccountTypesList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPartnerTypeList")]
        public async Task<IActionResult> GetPartnerTypeList()
        {
            try
            {
                var partnerTypeList = PartnerTypeHelper.GetPartnerTypeList();
                if (partnerTypeList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.partnerTypeList = partnerTypeList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}
