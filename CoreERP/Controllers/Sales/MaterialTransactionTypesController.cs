using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CoreERP.BussinessLogic.SalesHelper;
using System.Dynamic;
using CoreERP.DataAccess;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/sales/MaterialTransTypes")]
    public class MaterialTransactionTypesController : ControllerBase
    {
       

        [HttpGet("GetMatTranTypesList")]
        public async Task<IActionResult> GetMatTranTypesList()
        {

            try
            {
                dynamic expando = new ExpandoObject();
                expando.materialtratypes = BillingHelpers.GetMatTranTypesList();
                return Ok(new APIResponse() {status=APIStatus.PASS.ToString(),response=expando });
            }
            catch(Exception ex)
            {

            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load mat trans types." });
        }

        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.branches = BillingHelpers.GetBranchesList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to load branches." });
        }


        [HttpPost("RegisterMatTransType")]
        public async Task<IActionResult> RegisterMatTransType([FromBody]MatTranTypes mattrantypes)
        {
           
            if (mattrantypes == null)
                return BadRequest($"{nameof(mattrantypes)} cannot be null");
           try
            {

                var response = BillingHelpers.RegisterMatTransType(mattrantypes);
              if(response != null)
                {
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
                }
            }
            catch(Exception ex)
            {
            }

            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Failed." });
        }



        [HttpPut("UpdateMatTranTypes")]
        public async Task<IActionResult> UpdateMatTranTypes(string code, [FromBody] MatTranTypes mattrantype)
        {
            if (mattrantype == null)
                return BadRequest($"{nameof(mattrantype)} cannot be null");
            try
            {
                var result = BillingHelpers.UpdateMatTransType(mattrantype);
                if (result != null)
                {
                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= result });
                }
            }
            catch(Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
        }


       
        [HttpDelete("sales/materialtrantypes/{code}")]
        [Produces(typeof(BillingNoSeries))]
        public async Task<IActionResult> Delete(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var result = BillingHelpers.DeleteMatTransType(code);
                if (result != null)
                {
                    return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response=result});
                }
            }
            catch(Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Deletion Failed." });
        }
    }
}