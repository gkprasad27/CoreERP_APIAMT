using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/AssetClass")]
    public class AssetClassController : ControllerBase
    {
        private readonly IRepository<TblAssetClass> _acRepository;
        public AssetClassController(IRepository<TblAssetClass> acpRepository)
        {
            _acRepository = acpRepository;
        }

        [HttpPost("RegisterAssetClass")]
        public IActionResult RegisterAssetClass([FromBody]TblAssetClass asset)
        {
            if (asset == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (AssetClassHelper.GetList(asset.Code).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Depreciationareas Code {nameof(asset.Code)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _acRepository.Add(asset);
                if (_acRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = asset };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAssetClassList")]
        public IActionResult GetAssetClassList()
        {
            try
            {
                var assetList = _acRepository.GetAll();
                if (assetList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.assetList = assetList;
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

        [HttpPut("UpdateAssetClass")]
        public IActionResult UpdateAssetClass([FromBody] TblAssetClass asset)
        {
            if (asset == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(asset)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _acRepository.Update(asset);
                if (_acRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = asset };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssetClass/{code}")]
        public IActionResult DeleteAssetClassbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _acRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _acRepository.Remove(record);
                if (_acRepository.SaveChanges() > 0)
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