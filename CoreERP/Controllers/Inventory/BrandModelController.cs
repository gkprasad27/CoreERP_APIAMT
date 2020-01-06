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
    [Route("api/Inventory/BrandModel")]
    public class BrandModelController : ControllerBase
    {
        [HttpPost("RegisterBrandModel")]
        public async Task<IActionResult> RegisterBrandModel([FromBody]BrandModel brandModel)
        {
            if (brandModel == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brandModel)} can not be null" });
            try
            {
                int result = BrandModelHelper.RegisterBrandModel(brandModel);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brandModel });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }

        }



        [HttpGet("GetAllBrandModel")]
        [Produces(typeof(List<BrandModel>))]
        public async Task<IActionResult> GetAllBrandModel()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = BrandModelHelper.GetBrandModelList() });
        }

        [HttpPut("UpdateBrandModel/{code}")]
        [Produces(typeof(BrandModel))]
        public async Task<IActionResult> UpdateBrandModel(string code, [FromBody] BrandModel brandModels)
        {
            if (brandModels == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brandModels)} cannot be null" });

            if (!string.IsNullOrWhiteSpace(brandModels.Code) && code != brandModels.Code)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Conflicting role id in parameter and model data" });


            try
            {
                int rs = BrandModelHelper.UpdateBrandModelClass(brandModels);
                if (rs > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brandModels });
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brandModels)} Updation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brandModels)} Updation Failed" });
            }
        }


        [HttpDelete("DeleteBrandModel/{code}")]
        [Produces(typeof(BrandModel))]
        public async Task<IActionResult> DeleteBrandModel(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                int result = BrandModelHelper.DeleteBrandModelClass(code);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = code });
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