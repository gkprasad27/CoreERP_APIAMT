using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;

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
            //var assetname = _assetClassRepository.Where(x => x.Code == mvm.code).FirstOrDefault();
            if (mam == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(mam)} cannot be null" });
            else
            {
                try
                {
                    _mainAssetMasterRepository.Add(mam);
                    TblAssetClass ac = new TblAssetClass();
                    ac.LastNumberRange = int.Parse(mam.AssetNumber);
                    ac.Code = mam.Assetclass;
                    ac.Description = mam.Description;
                    ac.NumberRange = mam.NumberRange;
                    ac.LowValueAssetClass = mam.LowValueAssetClass;
                    ac.AssetLowValue = mam.AssetLowValue;
                    ac.ClassType = mam.ClassType;
                    ac.Nature = mam.Nature;
                    _assetClassRepository.Update(ac);
                    _assetClassRepository.SaveChanges();
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

        [HttpGet("GetAssetNumber/{code}/{code1}")]
        public IActionResult GetGLUnderSubGroupList(string code, int code1)
        {
              try
                {
                    var Getassetlist = _assetClassRepository.Where(x => x.Code == code).FirstOrDefault();
                    var Getassetnumrangelist = _assetNumberRangeRepository.Where(x => x.Code == Getassetlist.NumberRange).FirstOrDefault();
                if (Enumerable.Range(Convert.ToInt32(Getassetnumrangelist.FromRange),Convert.ToInt32(Getassetnumrangelist.ToRange)).Contains(code1))
                {
                    if (code1 >= Convert.ToInt32(Getassetnumrangelist.FromRange) && code1 <= Convert.ToInt32(Getassetnumrangelist.ToRange))
                    {
                        return Ok();
                    }
                    else
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
                var Getassetlist = _assetClassRepository.Where(x => x.Code == code).FirstOrDefault();
                //var Getassetnumrangelist = _assetNumberRangeRepository.Where(x => x.Code == Getassetlist.NumberRange).FirstOrDefault();
                int num = Convert.ToInt32(_assetClassRepository.Where(x => x.Code == code).SingleOrDefault()?.LastNumberRange);
                var Getaccnolist = _assetNumberRangeRepository.Where(x => x.Code == Getassetlist.NumberRange).FirstOrDefault();
                var numrnglist = _assetNumberRangeRepository.Where(x => x.Code == Getaccnolist.Code.ToString()).FirstOrDefault();
                if (Enumerable.Range(Convert.ToInt32(numrnglist.FromRange), Convert.ToInt32(numrnglist.ToRange)).Contains(num))
                {
                    if (num >= Convert.ToInt32(numrnglist.FromRange) && num <= Convert.ToInt32(numrnglist.ToRange))
                    {
                        var astnum = num + 1;
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
