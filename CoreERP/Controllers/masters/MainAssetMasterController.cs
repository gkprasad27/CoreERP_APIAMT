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
    [Route("api/MainAssetMaster")]
    public class MainAssetMasterController : ControllerBase
    {
        private readonly IRepository<TblAssetClass> _assetClassRepository;
        private readonly IRepository<TblAssetNumberRange> _assetNumberRangeRepository;
        private readonly IRepository<TblMainAssetMaster> _mainAssetMasterRepository;
        public MainAssetMasterController(IRepository<TblMainAssetMaster> mainAssetMasterRepository,
         IRepository<TblAssetClass> assetClassRepository, IRepository<TblAssetNumberRange> assetNumberRangeRepository)
        {
            _mainAssetMasterRepository = mainAssetMasterRepository;
            _assetClassRepository = assetClassRepository;
            _assetNumberRangeRepository = assetNumberRangeRepository;
        }
        [HttpGet("GetMainAssetMasterList")]
        public async Task<IActionResult> GetMainAssetMasterList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var mamList = CommonHelper.GetMainAssetMaster();
                    if (mamList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.mamList = mamList;
                        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for Main Assets." });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPost("RegisterMainAssetMaster")]
        public IActionResult RegisterMainAssetMaster([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                var mainassetkMaster = obj["mainasstHdr"].ToObject<TblMainAssetMaster>();
                var mainassetDetail = obj["mainassetDetail"].ToObject<List<TblMainAssetMasterTransaction>>();

                if (new CommonHelper().MainAssetsdatas(mainassetkMaster, mainassetDetail))
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.CashBankMaster = mainassetkMaster;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetMainAssetsDetail/{assetNumber}")]
        public IActionResult GetMainAssetsDetail(string assetNumber)
        {
            try
            {
                var common = new CommonHelper();
                var mainMasters = common.GetmainassetMastersById(assetNumber);
                if (mainMasters == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.MainassetMasters = mainMasters;
                expdoObj.MainassetDetail = new CommonHelper().GetMainAssetMasterTransactionDetails(assetNumber);
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
        [HttpPut("UpdateMainAssetMaster")]
        public async Task<IActionResult> UpdateMainAssetMaster([FromBody] TblMainAssetMaster mam)
        {
            if (mam == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _mainAssetMasterRepository.Update(mam);
                APIResponse apiResponse;
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
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _mainAssetMasterRepository.GetSingleOrDefault(x => x.AssetNumber.Equals(code));
                _mainAssetMasterRepository.Remove(record);
                APIResponse apiResponse;
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

        [HttpGet("GetAssetNumber/{code}/{code1}")]
        public IActionResult GetGlUnderSubGroupList(string code, int code1)
        {
            try
            {
                var getassetlist = _assetClassRepository.Where(x => x.Code == code).FirstOrDefault();
                var getassetnumrangelist = _assetNumberRangeRepository.Where(x => x.Code == getassetlist.NumberRange).FirstOrDefault();
                if (Enumerable.Range(Convert.ToInt32(getassetnumrangelist.FromRange), Convert.ToInt32(getassetnumrangelist.ToRange)).Contains(code1))
                {
                    if (code1 >= Convert.ToInt32(getassetnumrangelist.FromRange) && code1 <= Convert.ToInt32(getassetnumrangelist.ToRange))
                    {
                        return Ok();
                    }

                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
            }

            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GettingAssetNumber/{code}")]
        public IActionResult GettingAssetNumber(string code)
        {
            try
            {
                var getassetlist = _assetClassRepository.Where(x => x.Code == code).FirstOrDefault();
                int i = Convert.ToInt32(_assetClassRepository.Where(x => x.Code == code).SingleOrDefault()?.LastNumberRange);
                var getaccnolist = _assetNumberRangeRepository.Where(x => x.Code == getassetlist.NumberRange).FirstOrDefault();
                var numrnglist = _assetNumberRangeRepository.Where(x => x.Code == getaccnolist.Code).FirstOrDefault();
                if (i == 0 && getassetlist.Code == code)
                {
                    var x = numrnglist.FromRange;

                    if (Enumerable.Range(Convert.ToInt32(numrnglist.FromRange), Convert.ToInt32(numrnglist.ToRange)).Contains(Convert.ToInt32(x)))
                    {
                        if (x >= Convert.ToInt32(numrnglist.FromRange) && x <= Convert.ToInt32(numrnglist.ToRange))
                        {
                            var astnum = x + 1;
                            if (astnum != null)
                            {
                                dynamic expdoObj = new ExpandoObject();
                                expdoObj.astnum = astnum;
                                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                            }
                        }
                        else
                            return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                    }
                }
                else
                if (Enumerable.Range(Convert.ToInt32(numrnglist.FromRange), Convert.ToInt32(numrnglist.ToRange)).Contains(i))
                {
                    if (i >= Convert.ToInt32(numrnglist.FromRange) && i <= Convert.ToInt32(numrnglist.ToRange))
                    {
                        var astnum = i + 1;
                        if (astnum != null)
                        {
                            dynamic expdoObj = new ExpandoObject();
                            expdoObj.astnum = astnum;
                            return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                        }
                    }
                    else
                        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data." });
                }

                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "incorrect data.." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
            return Ok();

        }

        [HttpGet("GettingAssetName/{code}")]
        public IActionResult GettingAssetNameList(string code)
        {
            try
            {
                var assetname = _assetClassRepository.Where(x => x.Code == code).FirstOrDefault();
                //var bpname = _bpgrouprepository.Where(x => x.Bpgroup == code).FirstOrDefault();
                if (assetname != null)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetname = assetname;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found for BusienessPartnerAccount." });
            }

            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



    }
}
