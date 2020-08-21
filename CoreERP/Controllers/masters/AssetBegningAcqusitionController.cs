using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AssetBegningAcqusition")]
    public class AssetBegningAcqusitionController : ControllerBase
    {
        private readonly IRepository<TblAssetBeginingAcquisition> _assetBeginingAcquisitionRepository;
        public AssetBegningAcqusitionController(IRepository<TblAssetBeginingAcquisition> assetBeginingAcquisitionRepository)
        {
            _assetBeginingAcquisitionRepository = assetBeginingAcquisitionRepository;
        }

        [HttpPost("RegisterAssetBegningAcqusition")]
        public IActionResult RegisterAssetBegningAcqusition([FromBody]TblAssetBeginingAcquisition assetbgacq)
        {
            if (assetbgacq == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _assetBeginingAcquisitionRepository.Add(assetbgacq);
                if (_assetBeginingAcquisitionRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = assetbgacq };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssetBegningAcqusitionList")]
        public IActionResult GetAssetBegningAcqusitionList()
        {
            try
            {
                var assetbgnaqsnList = _assetBeginingAcquisitionRepository.GetAll();
                if (assetbgnaqsnList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetbgnaqsnList = assetbgnaqsnList;
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
        public IActionResult DeleteAssetBegningAcqusitionbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _assetBeginingAcquisitionRepository.GetSingleOrDefault(x => x.MainAssetNo.Equals(code));
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
    }
}