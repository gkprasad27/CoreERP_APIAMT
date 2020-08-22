using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using CoreERP.BussinessLogic.masterHlepers;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/SubAssets")]
    public class SubAssetsController : ControllerBase
    {
        private readonly IRepository<TblMainAssetMaster> _mainAssetMasterRepository;
        private readonly IRepository<TblSubAssetMaster> _subAssetMasterRepository;
        private readonly IRepository<TblSubAssetMasterTransaction> _subAssetMasterTransactionRepository;
        public SubAssetsController(IRepository<TblSubAssetMaster> subAssetMasterRepository,
            IRepository<TblMainAssetMaster> mainAssetMasterRepository,
            IRepository<TblSubAssetMasterTransaction> subAssetMasterTransactionRepository)
        {
            _subAssetMasterRepository = subAssetMasterRepository;
            _mainAssetMasterRepository = mainAssetMasterRepository;
            _subAssetMasterTransactionRepository = subAssetMasterTransactionRepository;
        }
        [HttpGet("GetSubAssetsList")]
        public async Task<IActionResult> GetSubAssetsList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var saList = CommonHelper.GetSubAssetMaster();
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

        [HttpGet("GetMainAsset/{Code}")]
        public async Task<IActionResult> GetOpStockreceiptDetailsection1(string code)
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var maList = _mainAssetMasterRepository.GetAll().Where(x => x.AssetNumber == code).FirstOrDefault();
                    if (maList!=null)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.maList = maList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = maList });
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

        [HttpPost("RegisterSubAssetsdatas")]
        public async Task<IActionResult> RegisterSubAssetsdatas([FromBody]JObject objData)
        {
            APIResponse apiResponse = null;
            if (objData == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty" });
            try
            {
                var _subasstHdrr = objData["subasstHdr"].ToObject<TblSubAssetMaster>();
                var _subassetDetail = objData["subassetDetail"].ToObject<TblSubAssetMasterTransaction[]>();
                foreach(var item in _subassetDetail)
                {
                    _subAssetMasterTransactionRepository.Add(item);
                    _subAssetMasterRepository.SaveChanges();
                }
                _subAssetMasterRepository.Add(_subasstHdrr);
                if (_subAssetMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = _subasstHdrr };
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
}