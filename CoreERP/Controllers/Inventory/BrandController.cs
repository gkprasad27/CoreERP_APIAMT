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
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Inventory/Brand")]
    public class BrandController : ControllerBase
    {
        [HttpPost("RegisterBrand")]
        public async Task<IActionResult> RegisterBrand([FromBody]Brand brand)
        {
            try
            {
                Brand result = BrandHelpers.RegisterBrand(brand);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brand });
              
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetBbrandList")]
        public async Task<IActionResult> GetBbrandList()
        {
            try
            {
                var brandList = BrandHelpers.GetBrands();
                if (brandList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.BrandList = brandList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateBrand")]
        [Produces(typeof(Brand))]
        public async Task<IActionResult> UpdateBrand([FromBody] Brand brands)
        {
            if (brands == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brands)} cannot be null" });

            try
            {
                Brand result = BrandHelpers.UpdateBrand(brands);
                if (result!=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brands });
               
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response ="Updation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }
        }


        [HttpDelete("DeleteBrand/{code}")]
        [Produces(typeof(Brand))]
        public async Task<IActionResult> DeleteBrand(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                Brand result = BrandHelpers.DeleteBrand(code);
                if (result!=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = code });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}