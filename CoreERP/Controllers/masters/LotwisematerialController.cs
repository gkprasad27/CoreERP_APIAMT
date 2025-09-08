using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/Lot")]
    public class LotwisematerialController : Controller
    {
        private readonly IRepository<tbllotwisematerial> _lotwiseRepository;
        public LotwisematerialController(IRepository<tbllotwisematerial> LotwiseRepository)
        {
            _lotwiseRepository = LotwiseRepository;
        }

        [HttpPost("RegisterLot")]
        public IActionResult RegisterLot([FromBody] tbllotwisematerial Lot)
        {
            if (Lot == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                APIResponse apiResponse;
                _lotwiseRepository.Add(Lot);
                if (_lotwiseRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = Lot };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetLotList")]
        public IActionResult GetLotList()
        {
            try
            {
                var LotList = _lotwiseRepository.GetAll().Where(x=>x.ReceivedQty>0);
                if (LotList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.LotList = LotList;
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

        [HttpPut("UpdateLot")]
        public IActionResult UpdateLot([FromBody] tbllotwisematerial Lot)
        {
            if (Lot == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(Lot)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _lotwiseRepository.Update(Lot);
                if (_lotwiseRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = Lot };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteLot/{code}")]
        public IActionResult DeleteLot(string code)
        {
            try
            {
                APIResponse apiResponse;
                if (code == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

                var record = _lotwiseRepository.GetSingleOrDefault(x => x.Id.Equals(code));
                _lotwiseRepository.Remove(record);
                if (_lotwiseRepository.SaveChanges() > 0)
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