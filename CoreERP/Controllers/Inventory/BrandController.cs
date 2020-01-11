using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.DataAccess;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/Inventory/Brand")]
    public class BrandController : ControllerBase
    {
        [HttpPost("RegisterBrand")]
        public async Task<IActionResult> RegisterBrand([FromBody]Brand brand)
        {
            try
            {
                int result = BrandHelpers.RegisterBrand(brand);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brand });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }
            catch
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }

        }

        [HttpGet("GetAllBrand")]
        [Produces(typeof(List<Brand>))]
        public async Task<IActionResult> GetAllBrand()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = BrandHelpers.GetBrands() });
        }

        [HttpPut("UpdateBrand/{code}")]
        [Produces(typeof(Brand))]
        public async Task<IActionResult> UpdateBrand(string code, [FromBody] Brand brands)
        {
            if (brands == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brands)} cannot be null" });

            if (!string.IsNullOrWhiteSpace(brands.Code) && code != brands.Code)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Conflicting role id in parameter and model data" });

            try
            {
                int rs = BrandHelpers.UpdateBrand(brands);
                if (rs > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brands });
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brands)} Updation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brands)} Updation Failed" });
            }
        }


        [HttpDelete("DeleteBrand/{code}")]
        [Produces(typeof(Brand))]
        public async Task<IActionResult> DeleteBrand(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                int result = BrandHelpers.DeleteBrand(code);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = code });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Delete Operation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Delete Operation Failed" });
            }
        }
    }
}