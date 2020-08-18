using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/SubAssets")]
    public class SubAssetsController : ControllerBase
    {
        private readonly IRepository<TblSubAssetMaster> _subAssetMasterRepository;
        public SubAssetsController(IRepository<TblSubAssetMaster> subAssetMasterRepository)
        {
            _subAssetMasterRepository = subAssetMasterRepository;
        }
        [HttpGet("GetSubAssetsList")]
        public async Task<IActionResult> GetSubAssetsList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var saList = _subAssetMasterRepository.GetAll();
                    if (saList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.saList = saList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for SubAssets." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterSubAssets")]
        public async Task<IActionResult> RegisterSubAssets([FromBody]TblSubAssetMaster sam)
        {
            APIResponse apiResponse;
            if (sam == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(sam)} cannot be null" });
            else
            {
                try
                {
                    _subAssetMasterRepository.Add(sam);
                    if (_subAssetMasterRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = sam };
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

        [HttpPut("UpdateSubAssets")]
        public async Task<IActionResult> UpdateSubAssets([FromBody] TblSubAssetMaster sam)
        {
            APIResponse apiResponse = null;
            if (sam == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _subAssetMasterRepository.Update(sam);
                if (_subAssetMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = sam };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteSubAssets/{code}")]
        public async Task<IActionResult> DeleteSubAssets(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _subAssetMasterRepository.GetSingleOrDefault(x => x.SubAssetNumber.Equals(code));
                _subAssetMasterRepository.Remove(record);
                if (_subAssetMasterRepository.SaveChanges() > 0)
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