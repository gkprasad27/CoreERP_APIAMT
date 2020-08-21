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
    [Route("api/BankMaster")]
    public class BankMasterController : ControllerBase
    {
        private readonly IRepository<TblBankMaster> _bankMasterRepository;
        public BankMasterController(IRepository<TblBankMaster> bankMasterRepository)
        {
            _bankMasterRepository = bankMasterRepository;
        }
        [HttpGet("GetBankMasterList")]
        public async Task<IActionResult> GetBankMasterList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var bankList = CommonHelper.GetBankMaster();
                    if (bankList.Count() > 0)
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.bankList = bankList;
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

        [HttpPost("RegisterBankMaster")]
        public async Task<IActionResult> RegisterBankMaster([FromBody]TblBankMaster bank)
        {
            APIResponse apiResponse;
            if (bank == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(bank)} cannot be null" });
            else
            {
                try
                {
                    _bankMasterRepository.Add(bank);
                    if (_bankMasterRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bank };
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

        [HttpPut("UpdateBankMaster")]
        public async Task<IActionResult> UpdateBankMaster([FromBody] TblBankMaster bank)
        {
            APIResponse apiResponse = null;
            if (bank == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _bankMasterRepository.Update(bank);
                if (_bankMasterRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = bank };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteBankMaster/{code}")]
        public async Task<IActionResult> DeleteBankMaster(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _bankMasterRepository.GetSingleOrDefault(x => x.BankCode.Equals(code));
                _bankMasterRepository.Remove(record);
                if (_bankMasterRepository.SaveChanges() > 0)
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