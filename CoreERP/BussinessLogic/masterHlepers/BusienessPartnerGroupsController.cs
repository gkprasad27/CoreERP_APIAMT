using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/BusienessPartnerGroups")]
    public class BusienessPartnerGroupsController : ControllerBase
    {
        [HttpPost("RegisterBusienessPartnerGroups")]
        public IActionResult RegisterBusienessPartnerGroups([FromBody]TblBpgroup bpgroup)
        {
            if (bpgroup == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (BusienessPartnerGroupsHelper.GetList(bpgroup.Bpgroup).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Bpgroup Code {nameof(bpgroup.Bpgroup)} is already exists ,Please Use Different Code " });

                var result = BusienessPartnerGroupsHelper.Register(bpgroup);
                APIResponse apiResponse;
                if (result != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBusienessPartnerGroupsList")]
        public IActionResult GetBusienessPartnerGroupsList()
        {
            try
            {
                var bpgList = BusienessPartnerGroupsHelper.GetList();
                if (bpgList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.bpgList = bpgList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateBusienessPartnerGroups")]
        public IActionResult UpdateBusienessPartnerGroups([FromBody] TblBpgroup bpgroup)
        {
            if (bpgroup == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(bpgroup)} cannot be null" });

            try
            {
                var rs = BusienessPartnerGroupsHelper.Update(bpgroup);
                APIResponse apiResponse;
                if (rs != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteBusienessPartnerGroups/{code}")]
        public IActionResult DeleteBusienessPartnerGroupsbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = BusienessPartnerGroupsHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}