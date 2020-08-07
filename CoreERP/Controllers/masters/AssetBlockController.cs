using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AssetBlock")]
    public class AssetBlockController : ControllerBase
    {
        [HttpPost("RegisterAssetBlock")]
        public IActionResult RegisterAssetBlock([FromBody]TblAssetBlock assetblk)
        {
            if (assetblk == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (AssetBlockHelper.GetList(assetblk.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Depreciationareas Code {nameof(assetblk.Code)} is already exists ,Please Use Different Code " });

                var result = AssetBlockHelper.Register(assetblk);
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

        [HttpGet("GetAssetBlockList")]
        public IActionResult GetAssetBlockList()
        {
            try
            {
                var assetblockList = AssetBlockHelper.GetList();
                if (assetblockList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetblockList = assetblockList;
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

        [HttpPut("UpdateAssetBlock")]
        public IActionResult UpdateAssetBlock([FromBody] TblAssetBlock assetblock)
        {
            if (assetblock == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assetblock)} cannot be null" });

            try
            {
                var rs = AssetBlockHelper.Update(assetblock);
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


        [HttpDelete("DeleteAssetBlock/{code}")]
        public IActionResult DeleteAssetBlockbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = AssetBlockHelper.Delete(code);
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