using System;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

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
                    if (dpList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.dpList = dpList;
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

        [HttpPost("RegisterDepreciationcode")]
        public async Task<IActionResult> RegisterDepreciationcode([FromBody]TblDepreciation dprcn)
        {
            APIResponse apiResponse;
            if (dprcn == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(dprcn)} cannot be null" });
            else
            {
                try
                {
                    _depreciationRepository.Add(dprcn);
                    if (_depreciationRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = dprcn };
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

        [HttpPut("UpdateDepreciationcode")]
        public async Task<IActionResult> UpdateDepreciationcode([FromBody] TblDepreciation dprcn)
        {
            APIResponse apiResponse = null;
            if (dprcn == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _depreciationRepository.Update(dprcn);
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
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _depreciationRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _depreciationRepository.Remove(record);
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

    }
}