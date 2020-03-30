using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/masters/Productpacking")]
    public class ProductpackingController : ControllerBase
    {
        [HttpPost("RegisterProductpacking")]
        public async Task<IActionResult> RegisterProductpacking([FromBody]TblProductPacking productpacking)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (productpacking == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

                try
                {
                    if (new ProductpackingHelpers().GetList(productpacking.PackingCode).Count() > 0)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"productpacking Code {nameof(productpacking.PackingCode)} is already exists ,Please Use Different Code " });

                    var result = new ProductpackingHelpers().Register(productpacking);
                    if (result != null)
                    {
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    }
                    else
                    {
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." };
                    }

                    return Ok(apiResponse);

                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;

        }


        [HttpGet("GetProductpackingList")]
        public IActionResult GetProductpackingList()
        {
            try
            {
                var ProductpackingList = new ProductpackingHelpers().GetList();
                if (ProductpackingList.Count() > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ProductpackingList = ProductpackingList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                else
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateProductpacking")]
        public IActionResult UpdateProductpacking([FromBody] TblProductPacking productpack)
        {
            APIResponse apiResponse = null;
            if (productpack == null)
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = $"{nameof(productpack)} cannot be null" });

            try
            {
                var rs = new ProductpackingHelpers().Update(productpack);
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteProductpacking/{code}")]
        public IActionResult DeleteProductpacking(string code)
        {
            APIResponse apiResponse = null;
            try
            {
                if (code == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "code can not be null" });

                var rs = new ProductpackingHelpers().Delete(code);
                if (rs != null)
                {
                    apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = rs };
                }
                else
                {
                    apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                }
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}