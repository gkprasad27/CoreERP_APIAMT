using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.Models;
using CoreERP.DataAccess;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/Inventory/Sizes")]
    public class SizesController : ControllerBase
    {
        [HttpPost("RegisterSizes")]
        public async Task<IActionResult> RegisterSizes([FromBody]Sizes size)
        {
            if (size == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(size)} can not be null" });

            try
            {
                int result = SizesHelper.RegisterSizes(size);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = size });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }

        }

        [HttpGet("GetAllSizes")]
        [Produces(typeof(List<Sizes>))]
        public async Task<IActionResult> GetAllSizes()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = SizesHelper.GetSizesList() });
        }

        [HttpPut("UpdateSize/{code}")]
        [Produces(typeof(Sizes))]
        public async Task<IActionResult> UpdateSize(string code, [FromBody] Sizes sizes)
        {
            if (sizes == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(sizes)} cannot be null" });

            if (!string.IsNullOrWhiteSpace(sizes.Code) && code != sizes.Code)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Conflicting role id in parameter and model data" });


            try
            {
                int rs = SizesHelper.UpdateSizes(sizes);
                if (rs > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = sizes });
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(sizes)} Updation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(sizes)} Updation Failed" });
            }
        }


        [HttpDelete("DeleteSize/{code}")]
        [Produces(typeof(Sizes))]
        public async Task<IActionResult> DeleteSize(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                int result = SizesHelper.DeleteSizes(code);
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