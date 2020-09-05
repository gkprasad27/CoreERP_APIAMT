using CoreERP.DataAccess.Repositories;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PaymentTerms")]
    public class PaymentTermsController : ControllerBase
    {
        private readonly IRepository<TblPaymentTerms> _ptRepository;
        public PaymentTermsController(IRepository<TblPaymentTerms> ptRepository)
        {
            _ptRepository = ptRepository;
        }

        [HttpGet("GetPaymentTermsList")]
        public IActionResult GetPaymentTermsList()
        {
            try
            {
                var ptermsList = _ptRepository.GetAll();
                if (!ptermsList.Any())
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.ptermsList = ptermsList;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdatePaymentTerms")]
        public IActionResult UpdatePaymentTerms([FromBody] TblPaymentTerms paymentterms)
        {
            if (paymentterms == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(paymentterms)} cannot be null" });

            try
            {
                APIResponse apiResponse;
                _ptRepository.Update(paymentterms);
                if (_ptRepository.SaveChanges() > 0)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = paymentterms };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeletePaymentTerms/{code}")]
        public IActionResult DeletePaymentTermsbyID(string code)
        {
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                APIResponse apiResponse;
                var record = _ptRepository.GetSingleOrDefault(x => x.Code.Equals(code));
                _ptRepository.Remove(record);
                if (_ptRepository.SaveChanges() > 0)
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

        [HttpPost("RegisterPaymentTerms")]
        public IActionResult RegisterPaymentTerms([FromBody] JObject obj)
        {
            try
            {
                if (obj == null)
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "Request object canot be empty." });

                var ptems = obj["paymentstrmsHdr"].ToObject<TblPaymentTerms>();
                var ptrmDetail = obj["paymentstrmsDetail"].ToObject<List<TblPaymentTermDetails>>();

                if (!new CommonHelper().Paymentterms(ptems, ptrmDetail))
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.CashBankMaster = ptems;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPaymentTermsDetail/{assetNumber}")]
        public IActionResult GetPaymentTermsDetail(string assetNumber)
        {
            try
            {
                var common = new CommonHelper();
                TblPaymentTerms ptrms = common.GetpaymenttermsById(assetNumber);
                if (ptrms == null)
                    return Ok(new APIResponse {status = APIStatus.FAIL.ToString(), response = "No Data Found."});
                dynamic expdoObj = new ExpandoObject();
                expdoObj.PaymentTermMasters = ptrms;
                expdoObj.PaymentTermDetail = new CommonHelper().GetTblPaymentTermDetails(assetNumber); ;
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

    }
}