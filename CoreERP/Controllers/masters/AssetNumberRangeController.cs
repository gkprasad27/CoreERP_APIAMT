using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/AssetNumberRange")]
    public class AssetNumberRangeController : ControllerBase
    {
        private readonly IRepository<TblAssetNumberRange> _assetNumberRangeRepository;
        public AssetNumberRangeController(IRepository<TblAssetNumberRange> assetNumberRangeRepository)
        {
            _assetNumberRangeRepository = assetNumberRangeRepository;
        }

        [HttpGet("GetAssetNumberRangeList")]
        public async Task<IActionResult> GetAssetNumberRangeList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var anrList = _assetNumberRangeRepository.GetAll();
                    if (anrList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.anrList = anrList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for branches." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterAssetNumberRange")]
        public async Task<IActionResult> RegisterAssetNumberRange([FromBody]TblAssetNumberRange asetnum)
        {
            APIResponse apiResponse;
            if (asetnum == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(asetnum)} cannot be null" });
            else
            {
                try
                {
                    _assetNumberRangeRepository.Add(asetnum);
                    if (_assetNumberRangeRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = asetnum };
                    else
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }

            }
        }

        [HttpPut("UpdateAssetNumberRange")]
        public async Task<IActionResult> UpdateAssetNumberRange([FromBody] TblAssetNumberRange asetnum)
        {
            APIResponse apiResponse = null;
            if (asetnum == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _assetNumberRangeRepository.Update(asetnum);
                if (_assetNumberRangeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = asetnum };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssetNumberRange/{code}")]
        public async Task<IActionResult> DeleteAssetNumberRange(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _assetNumberRangeRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _assetNumberRangeRepository.Remove(record);
                if (_assetNumberRangeRepository.SaveChanges() > 0)
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