using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/AseetClassToAssetBlock")]
    public class AseetClassToAssetBlockController : ControllerBase
    {
        private readonly IRepository<TblAssignAssetClasstoBlockAsset> _assignAssetClasstoBlockAssetRepository;
        public AseetClassToAssetBlockController(IRepository<TblAssignAssetClasstoBlockAsset> assignAssetClasstoBlockAssetRepository)
        {
            _assignAssetClasstoBlockAssetRepository = assignAssetClasstoBlockAssetRepository;
        }

        [HttpGet("GetAseetClassToAssetBlockList")]
        public async Task<IActionResult> GetAseetClassToAssetBlockList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var acabList = _assignAssetClasstoBlockAssetRepository.GetAll();
                    if (acabList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.acabList = acabList;
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

        [HttpPost("RegisterAseetClassToAssetBlock")]
        public async Task<IActionResult> RegisterAseetClassToAssetBlock([FromBody]TblAssignAssetClasstoBlockAsset acab)
        {
            APIResponse apiResponse;
            if (acab == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(acab)} cannot be null" });
            else
            {
                try
                {
                    _assignAssetClasstoBlockAssetRepository.Add(acab);
                    if (_assignAssetClasstoBlockAssetRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = acab };
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

        [HttpPut("UpdateAseetClassToAssetBlock")]
        public async Task<IActionResult> UpdateAseetClassToAssetBlock([FromBody] TblAssignAssetClasstoBlockAsset acab)
        {
            APIResponse apiResponse = null;
            if (acab == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _assignAssetClasstoBlockAssetRepository.Update(acab);
                if (_assignAssetClasstoBlockAssetRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = acab };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAseetClassToAssetBlock/{code}")]
        public async Task<IActionResult> DeleteAseetClassToAssetBlock(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _assignAssetClasstoBlockAssetRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _assignAssetClasstoBlockAssetRepository.Remove(record);
                if (_assignAssetClasstoBlockAssetRepository.SaveChanges() > 0)
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