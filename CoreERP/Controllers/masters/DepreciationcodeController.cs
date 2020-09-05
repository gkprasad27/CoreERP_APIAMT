using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Depreciationcode")]
    public class DepreciationcodeController : ControllerBase
    {
        private readonly IRepository<TblDepreciation> _depreciationRepository;
        public DepreciationcodeController(IRepository<TblDepreciation> depreciationRepository)
        {
            _depreciationRepository = depreciationRepository;
        }
        [HttpGet("GetDepreciationcodeList")]
        public async Task<IActionResult> GetDepreciationcodeList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var dpList = _depreciationRepository.GetAll();
                    if (!dpList.Any())
                        return Ok(new APIResponse
                            {status = APIStatus.FAIL.ToString(), response = "No Data Found for branches."});
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.dpList = dpList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPut("UpdateDepreciationcode")]
        public async Task<IActionResult> UpdateDepreciationcode([FromBody] TblDepreciation dprcn)
        {
            if (dprcn == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _depreciationRepository.Update(dprcn);
                APIResponse apiResponse;
                if (_depreciationRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dprcn };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteDepreciationcode/{code}")]
        public async Task<IActionResult> DeleteDepreciationcode(string code)
        {
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _depreciationRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _depreciationRepository.Remove(record);
                APIResponse apiResponse;
                if (_depreciationRepository.SaveChanges() > 0)
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

        [HttpPost("RegisterDepreciationcode")]
        public IActionResult RegisterDepreciationcode([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                var dc = obj["depreciationcodeHdr"].ToObject<TblDepreciation>();
                var dcDetail = obj["depreciationcodeDetail"].ToObject<List<TblDepreciationcodeDetails>>();

                if (!new CommonHelper().Depreciationcode(dc, dcDetail))
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.CashBankMaster = dc;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetDepreciationcodeDetail/{code}")]
        public IActionResult GetDepreciationcodeDetail(string code)
        {
            try
            {
                var common = new CommonHelper();
                TblDepreciation dp = common.GetDepreciationById(code);
                if (dp == null)
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.DepreciationcodeMasters = dp;
                expdoObj.DepreciationcodeDetail = new CommonHelper().GetTblDepreciationcodeDetails(code); ;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}