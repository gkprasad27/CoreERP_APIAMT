using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AssetBegningAccumulatedDepreciation")]
    public class AssetBegningAccumulatedDepreciationController : ControllerBase
    {
        private readonly IRepository<TblAssetBegningAccumulatedDepreciation> _assetBegningAccumulatedDepreciationRepository;
        public AssetBegningAccumulatedDepreciationController(IRepository<TblAssetBegningAccumulatedDepreciation> assetBegningAccumulatedDepreciationRepository)
        {
            _assetBegningAccumulatedDepreciationRepository = assetBegningAccumulatedDepreciationRepository;
        }

        [HttpPost("RegisterAssetBegningAccumulatedDepreciation")]
        public IActionResult RegisterAssetBegningAccumulatedDepreciation([FromBody]TblAssetBegningAccumulatedDepreciation assetbgacqanddec)
        {
            if (assetbgacqanddec == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _assetBegningAccumulatedDepreciationRepository.Add(assetbgacqanddec);
                if (_assetBegningAccumulatedDepreciationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assetbgacqanddec };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Asset Already Exist, Please use another key " + " " + (assetbgacqanddec.accumulatedDepreciation) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssetBegningAccumulatedDepreciationList")]
        public IActionResult GetAssetBegningAccumulatedDepreciationList()
        {
            try
            {
                var assetbgnaqsndecList = _assetBegningAccumulatedDepreciationRepository.GetAll();
                if (assetbgnaqsndecList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetbgnaqsndecList = assetbgnaqsndecList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAssetBegningAccumulatedDepreciation")]
        public IActionResult UpdateAssetBegningAccumulatedDepreciation([FromBody] TblAssetBegningAccumulatedDepreciation assetbgacqdec)
        {
            if (assetbgacqdec == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assetbgacqdec)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _assetBegningAccumulatedDepreciationRepository.Update(assetbgacqdec);
                if (_assetBegningAccumulatedDepreciationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assetbgacqdec };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                if (ex.HResult.ToString() == "-2146233088")
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Asset Already Exist, Please use another key " + " " + (assetbgacqdec.accumulatedDepreciation) });
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssetBegningAcqusition/{code}")]
        public IActionResult DeleteAssetBegningAcqusitionbyId(int code)
        {
            try
            {
                if (code == 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _assetBegningAccumulatedDepreciationRepository.GetSingleOrDefault(x => x.id.Equals(code));
                _assetBegningAccumulatedDepreciationRepository.Remove(record);
                if (_assetBegningAccumulatedDepreciationRepository.SaveChanges() > 0)
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