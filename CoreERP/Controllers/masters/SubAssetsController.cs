using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

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
                    if (saList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.saList = saList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }

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
        public IActionResult RegisterSubAssetsdatas([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                var cashBankMaster = obj["subasstHdr"].ToObject<TblSubAssetMaster>();
                var cashBankDetail = obj["subassetDetail"].ToObject<List<TblSubAssetMasterTransaction>>();

                if (new CommonHelper().SubAssetsdatas(cashBankMaster, cashBankDetail))
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CashBankMaster = cashBankMaster;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetSubAssetsDetail/{assetNumber}")]
        public IActionResult GetSubAssetsDetail(string assetNumber)
        {
            try
            {
                var transactions = new CommonHelper();
                var subMasters = transactions.GetsubassetMastersById(assetNumber);
                if (subMasters != null)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.SubassetMasters = subMasters;
                    expdoObj.SubassetDetail = new CommonHelper().GetSubAssetMasterTransactionDetails(assetNumber); 
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpPut("UpdateSubAssets")]
        public async Task<IActionResult> UpdateSubAssets([FromBody] TblSubAssetMaster sam)
        {
            if (sam == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _subAssetMasterRepository.Update(sam);
                APIResponse apiResponse;
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
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _subAssetMasterRepository.GetSingleOrDefault(x => x.SubAssetNumber.Equals(code));
                _subAssetMasterRepository.Remove(record);
                APIResponse apiResponse;
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
                    var maList = _mainAssetMasterRepository.GetAll().FirstOrDefault(x => x.AssetNumber == code);
                    if (maList!=null)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.maList = maList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = maList });
                    }

                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for SubAssets." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
       
            return result;
        }


    }
}