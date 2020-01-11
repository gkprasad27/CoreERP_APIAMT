using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/BillingReturns")]
    public class BillingReturnsController : ControllerBase
    {

        [HttpGet("GetBill/{id}")]
        public async Task<IActionResult> GetBill(string id)
        {
            try
            {
                var isBillReturn = BillingHelpers.IsBillExistsInBillReturns(id);
                if (isBillReturn)
                    return Ok(new APIResponse() { status=APIStatus.FAIL.ToString(),response=$"Bill no {id} Already return."});

                dynamic expando = new ExpandoObject();
                expando.billings = BillingHelpers.GetBilling(id);
                return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response=expando });
            }
            catch (Exception ex)
            { 
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to Load Bill.Please Try Agian." });
        }

/*
        [HttpPost("RegisterBilling")]
        public async Task<IActionResult> RegisterBilling([FromBody]Billing[] billing)
        {

            if (billing == null)
                return BadRequest($"{nameof(billing)} cannot be null");
            try
            {
                var lastreacord = _unitOfWork.Billing.GetAll().OrderByDescending(x => x.Code).FirstOrDefault();
                if (lastreacord != null)
                    billing[0].Code = (int.Parse(lastreacord.Code) + 1).ToString();
                else
                    billing[0].Code = "1";

                for (int i = 1; i < billing.Count(); i++)
                    billing[i].Code = (int.Parse(billing[i - 1].Code) + 1).ToString();

                _unitOfWork.Billing.AddRange(billing);

                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(billing);
                else
                    return BadRequest($"{nameof(billing)} Registration Failed");
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(billing)} Registration Failed");
            }
        }

        [HttpPut("sales/billing/{code}")]
        [Produces(typeof(Billing))]
        public async Task<IActionResult> Update(string code, [FromBody] Billing billing)
        {
            if (billing == null)
                return BadRequest($"{nameof(billing)} cannot be null");
           
            try
            {
                _unitOfWork.Billing.Update(billing);
                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(billing);
                else
                    return BadRequest($"{nameof(billing)} Updation Failed");
            }
            catch(Exception ex)
            {
                return BadRequest($"{nameof(billing)} Updation Failed");
            }
        }
 
        [HttpDelete("sales/billing/{code}")]
        [Produces(typeof(Billing))]
        public async Task<IActionResult> Delete(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var result = _unitOfWork.Billing.GetAll().SingleOrDefault(x=> x.Code == code);
                
                _unitOfWork.Billing.Remove(result);
                _unitOfWork.SaveChanges();
                return Ok(result);

            }
            catch(Exception ex)
            {
                return BadRequest($"Delete Operation Failed");
            }
            
        }
  */
    }
}