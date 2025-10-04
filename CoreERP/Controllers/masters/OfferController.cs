using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Offer")]
    public class OfferController : ControllerBase
    {
        private readonly IRepository<TblOffer> _offerRepository;
        public OfferController(IRepository<TblOffer> offerRepository)
        {
            _offerRepository = offerRepository;
        }

        [HttpGet("GetOfferList")]

        public async Task<IActionResult> GetOfferList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    var employeesList = _offerRepository.GetAll();
                    if (employeesList.Any())
                    {
                        dynamic expdoObj = new ExpandoObject();
                        expdoObj.offerList = employeesList;
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



        [HttpPost("RegisterOffer")]

        public async Task<IActionResult> RegisterOffer([FromBody] TblOffer offer)
        {
            APIResponse apiResponse;
            if (offer == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(offer)} cannot be null" });
            else
            {
                try
                {
                    _offerRepository.Add(offer);
                    if (_offerRepository.SaveChanges() > 0)
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = offer };
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


        [HttpPut("UpdateOffer")]

        public async Task<IActionResult> UpdateOffer([FromBody] TblOffer offer)
        {
            APIResponse apiResponse = null;
            if (offer == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });

            try
            {
                _offerRepository.Update(offer);
                if (_offerRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = offer };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteOffer/{code}")]

        public async Task<IActionResult> DeleteOffer(string code)
        {
            APIResponse apiResponse = null;
            if (code == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)}can not be null" });

            try
            {
                var record = _offerRepository.GetSingleOrDefault(x => x.EmpCode.Equals(code));
                _offerRepository.Remove(record);
                if (_offerRepository.SaveChanges() > 0)
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