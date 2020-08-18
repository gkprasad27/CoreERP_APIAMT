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
    [Route("api/AssetTransactionType")]
    public class AssetTransactionTypeController : ControllerBase
    {
        private readonly IRepository<TblAssetTransactiontype> _assetTransactiontypeRepository;
        public AssetTransactionTypeController(IRepository<TblAssetTransactiontype> assetTransactiontypeRepository)
        {
            _assetTransactiontypeRepository = assetTransactiontypeRepository;
        }
        [HttpGet("GetAssetTransactionTypeList")]
        public async Task<IActionResult> GetAssetTransactionTypeList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var transactionList = _assetTransactiontypeRepository.GetAll();
                    if (transactionList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.transactionList = transactionList;
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

        [HttpPost("RegisterAssetTransactionType")]
        public async Task<IActionResult> RegisterAssetTransactionType([FromBody]TblAssetTransactiontype transactiontype)
        {
            APIResponse apiResponse;
            if (transactiontype == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(transactiontype)} cannot be null" });
            else
            {
                try
                {
                    _assetTransactiontypeRepository.Add(transactiontype);
                    if (_assetTransactiontypeRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = transactiontype };
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

        [HttpPut("UpdateAssetTransactionType")]
        public async Task<IActionResult> UpdateAssetTransactionType([FromBody] TblAssetTransactiontype ttype)
        {
            APIResponse apiResponse = null;
            if (ttype == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _assetTransactiontypeRepository.Update(ttype);
                if (_assetTransactiontypeRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = ttype };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteAssetTransactionType/{code}")]
        public async Task<IActionResult> DeleteAssetTransactionType(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _assetTransactiontypeRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _assetTransactiontypeRepository.Remove(record);
                if (_assetTransactiontypeRepository.SaveChanges() > 0)
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