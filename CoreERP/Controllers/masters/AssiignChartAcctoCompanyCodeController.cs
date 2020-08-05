using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AssiignChartAcctoCompanyCode")]
    public class AssiignChartAcctoCompanyCodeController : ControllerBase
    {
        [HttpPost("RegisterAssiignChartAcctoCompanyCode")]
        public IActionResult RegisterAssiignChartAcctoCompanyCode([FromBody]TblAssignchartaccttoCompanycode coa)
        {
            if (coa == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (AssignmentofcoatocompcodeHelper.GetList(coa.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Assignmentofcoatocompcode Code {nameof(coa.Code)} is already exists ,Please Use Different Code " });

                var result = AssignmentofcoatocompcodeHelper.Register(coa);
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

        [HttpGet("GetAssiignChartAcctoCompanyCodeList")]
        public IActionResult GetAssiignChartAcctoCompanyCodeList()
        {
            try
            {
                var coaList = AssignmentofcoatocompcodeHelper.GetList();
                if (coaList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.coaList = coaList;
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

        [HttpPut("UpdateAssiignChartAcctoCompanyCode")]
        public IActionResult UpdateAssiignChartAcctoCompanyCode([FromBody] TblAssignchartaccttoCompanycode coa)
        {
            if (coa == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(coa)} cannot be null" });

            try
            {
                var rs = AssignmentofcoatocompcodeHelper.Update(coa);
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


        [HttpDelete("DeleteAssiignChartAcctoCompanyCode/{code}")]
        public IActionResult DeleteAssiignChartAcctoCompanyCodebyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = AssignmentofcoatocompcodeHelper.Delete(code);
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