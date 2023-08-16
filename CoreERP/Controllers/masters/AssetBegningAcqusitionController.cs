using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AssetBegningAcqusition")]
    public class AssetBegningAcqusitionController : ControllerBase
    {
        private readonly IRepository<TblAssetBeginingAcquisition> _assetBeginingAcquisitionRepository;
        private readonly IRepository<TblAssetBegningAccumulatedDepreciation> _assetBegningAccumulatedDepreciationRepository;
        public AssetBegningAcqusitionController(IRepository<TblAssetBeginingAcquisition> assetBeginingAcquisitionRepository,
            IRepository<TblAssetBegningAccumulatedDepreciation> assetBegningAccumulatedDepreciationRepository)
        {
            _assetBeginingAcquisitionRepository = assetBeginingAcquisitionRepository;
            _assetBegningAccumulatedDepreciationRepository = assetBegningAccumulatedDepreciationRepository;

        }

        [HttpGet("GetAssetBegningAcqusitionList")]
        public IActionResult GetAssetBegningAcqusitionList()
        {
            try
            {
                var assetbgnaqsnList = _assetBeginingAcquisitionRepository.GetAll();
                if (assetbgnaqsnList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetbgnaqsnList = assetbgnaqsnList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No AssetBegningAcqusitionList Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssetBegningAcqusitionDetailsList")]
        public IActionResult GetAssetBegningAcqusitionDetailsList()
        {
            try
            {
                var assetbgnaqsndetailsList = _assetBegningAccumulatedDepreciationRepository.GetAll();
                if (assetbgnaqsndetailsList.Any())
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetbgnaqsndetailsList = assetbgnaqsndetailsList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }

                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateAssetBegningAcqusition")]
        public IActionResult UpdateAssetBegningAcqusition([FromBody] TblAssetBeginingAcquisition assetbgacq)
        {
            if (assetbgacq == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(assetbgacq)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _assetBeginingAcquisitionRepository.Update(assetbgacq);
                if (_assetBeginingAcquisitionRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assetbgacq };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
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
                var record = _assetBeginingAcquisitionRepository.GetSingleOrDefault(x => x.Id.Equals(code));
                _assetBeginingAcquisitionRepository.Remove(record);
                if (_assetBeginingAcquisitionRepository.SaveChanges() > 0)
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

        [HttpPost("RegisterAssetBegningAcqusition")]
        public IActionResult RegisterAssetBegningAcqusition([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                var aqsnHdr = obj["mainaqsnHdr"].ToObject<TblAssetBeginingAcquisition>();
                var aqsnDetail = obj["mainaqsnDetail"].ToObject<List<TblAssetBegningAccumulatedDepreciation>>();

                if (!new CommonHelper().AssetBeingAquisition(aqsnHdr, aqsnDetail))
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.CashBankMaster = aqsnHdr;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssetBegningAcqusitionDetail/{code}")]
        public IActionResult GetAssetBegningAcqusitionDetail(int code)
        {
            try
            {
                var common = new CommonHelper();
                var mainAqsn = common.GetmainAqsnById(code);
                if (mainAqsn == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                dynamic expdoObj = new ExpandoObject();
                expdoObj.AqsnMasters = mainAqsn;
                expdoObj.AqsnDetail = new CommonHelper().GetAqsnDetailDetails(code);
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}