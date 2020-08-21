using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
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
        private readonly IRepository<TblAssetBlock> _abRepository;
        public AssetBlockController(IRepository<TblAssetBlock> abpRepository)
        {
            _abRepository = abpRepository;
        }

        [HttpPost("RegisterAssetBlock")]
        public IActionResult RegisterAssetBlock([FromBody]TblAssetBlock assetblk)
        {
            if (assetblk == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (AssetBlockHelper.GetList(assetblk.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Depreciationareas Code {nameof(assetblk.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _abRepository.Add(assetblk);
                if (_abRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assetblk };
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
                var assetblockList = CommonHelper.GetAssetBlock();
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
                APIResponse apiResponse;
                _abRepository.Update(assetblock);
                if (_abRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assetblock };
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

                APIResponse apiResponse;
                var record = _abRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _abRepository.Remove(record);
                if (_abRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = record };
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