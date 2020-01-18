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
    [Route("api/Inventory/BrandModel")]
    public class BrandModelController : ControllerBase
    {
        [HttpPost("RegisterBrandModel")]
        public async Task<IActionResult> RegisterBrandModel([FromBody]BrandModel brandModel)
        {
            if (brandModel == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brandModel)} can not be null" });
            try
            {
                BrandModel result = BrandModelHelpers.RegisterBrandModel(brandModel);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brandModel });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAllBrandModel")]
        [Produces(typeof(List<BrandModel>))]
        public async Task<IActionResult> GetAllBrandModel()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.brandModelList = BrandModelHelpers.GetBrandModelList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateBrandModel")]
        [Produces(typeof(BrandModel))]
        public async Task<IActionResult> UpdateBrandModel([FromBody] BrandModel brandModels)
        {
            if (brandModels == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brandModels)} cannot be null" });


            try
            {
                BrandModel result = BrandModelHelpers.UpdateBrandModelClass(brandModels);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brandModels });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpDelete("DeleteBrandModel/{code}")]
        [Produces(typeof(BrandModel))]
        public async Task<IActionResult> DeleteBrandModel(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                BrandModel result = BrandModelHelpers.DeleteBrandModelClass(code);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = code });
                
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}