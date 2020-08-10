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
    [Route("api/MainAssetMaster")]
    public class MainAssetMasterController : ControllerBase
    {
        private readonly IRepository<TblMainAssetMaster> _mainAssetMasterRepository;
        public MainAssetMasterController(IRepository<TblMainAssetMaster> mainAssetMasterRepository)
        {
            _mainAssetMasterRepository = mainAssetMasterRepository;
        }
        [HttpGet("GetMainAssetMasterList")]
        public async Task<IActionResult> GetMainAssetMasterList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var mamList = _mainAssetMasterRepository.GetAll();
                    if (mamList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.mamList = mamList;
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

        [HttpPost("RegisterMainAssetMaster")]
        public async Task<IActionResult> RegisterMainAssetMaster([FromBody]TblMainAssetMaster mam)
        {
            APIResponse apiResponse;
            if (mam == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(mam)} cannot be null" });
            else
            {
                try
                {
                    _mainAssetMasterRepository.Add(mam);
                    if (_mainAssetMasterRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mam };
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

        [HttpPut("UpdateMainAssetMaster")]
        public async Task<IActionResult> UpdateMainAssetMaster([FromBody] TblMainAssetMaster mam)
        {
            APIResponse apiResponse = null;
            if (mam == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _mainAssetMasterRepository.Update(mam);
                if (_mainAssetMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = mam };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMainAssetMaster/{code}")]
        public async Task<IActionResult> DeleteMainAssetMaster(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _mainAssetMasterRepository.GetSingleOrDefault(x => x.AssetNumber.Equals(code));
                _mainAssetMasterRepository.Remove(record);
                if (_mainAssetMasterRepository.SaveChanges() > 0)
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