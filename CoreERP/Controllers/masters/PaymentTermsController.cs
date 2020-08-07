using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/PaymentTerms")]
    public class PaymentTermsController : ControllerBase
    {
        [HttpPost("RegisterPaymentTerms")]
        public IActionResult RegisterPaymentTerms([FromBody]TblPaymentTerms paymentterms)
        {
            if (paymentterms == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (PaymentHelper.GetList(paymentterms.Code).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"Payment Code {nameof(paymentterms.Code)} is already exists ,Please Use Different Code " });

                var result = PaymentHelper.Register(paymentterms);
                APIResponse apiResponse;
                if (result != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                else
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };

                return Ok(apiResponse);

            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetPaymentTermsList")]
        public IActionResult GetPaymentTermsList()
        {
            try
            {
                var ptermsList = PaymentHelper.GetList();
                if (ptermsList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ptermsList = ptermsList;
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

        [HttpPut("UpdatePaymentTerms")]
        public IActionResult UpdatePaymentTerms([FromBody] TblPaymentTerms paymentterms)
        {
            if (paymentterms == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(paymentterms)} cannot be null" });

            try
            {
                var rs = PaymentHelper.Update(paymentterms);
                APIResponse apiResponse;
                if (rs != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
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

                var rs = PaymentHelper.Delete(code);
                APIResponse apiResponse;
                if (rs != null)
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
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