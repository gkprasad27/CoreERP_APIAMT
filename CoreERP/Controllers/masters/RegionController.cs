using CoreERP.BussinessLogic.Common;
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
    [Route("api/Region")]
    public class RegionController : ControllerBase
    {
        private readonly IRepository<TblRegion> _regionRepository;
        public RegionController(IRepository<TblRegion> regionRepository)
        {
            _regionRepository = regionRepository;
        }

        [HttpPost("RegisterRegion")]
        public IActionResult RegisterRegion([FromBody]TblRegion region)
        {
            if (region == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                //if (RegionHelper.GetList(region.RegionCode).Count() > 0)
                //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"region Code {nameof(region.RegionCode)} is already exists ,Please Use Different Code " });

                APIResponse apiResponse;
                _regionRepository.Add(region);
                if (_regionRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = region };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetRegionList")]
        public IActionResult GetRegionList()
        {
            try
            {
                var regionList = CommonHelper.GetRegions();
                if (regionList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.regionList = regionList;
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

        [HttpPut("UpdateRegion")]
        public IActionResult UpdateRegion([FromBody] TblRegion region)
        {
            if (region == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(region)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _regionRepository.Update(region);
                if (_regionRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = region };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteRegion/{code}")]
        public IActionResult DeleteRegionByID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _regionRepository.GetSingleOrDefault(x => x.RegionCode.Equals(code));
                _regionRepository.Remove(record);
                if (_regionRepository.SaveChanges() > 0)
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