using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Sizes")]
    public class SizesController : ControllerBase
    {
        [HttpPost("RegisterSizes")]
        public IActionResult RegisterSizes([FromBody]Sizes size)
        {
            if (size == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(size)} can not be null" });

            try
            {
                string errorMasg = string.Empty;

                var result = SizesHelper.RegisterSizes(size, out errorMasg);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                else
                {
                    if (string.IsNullOrEmpty(errorMasg))
                        errorMasg = " Registration Failed";

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = errorMasg });
                }
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAllSizes")]
        [Produces(typeof(List<Sizes>))]
        public IActionResult GetAllSizes()
        {
            try
            {
                var sizesList = SizesHelper.GetSizesList();
                if (sizesList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.sizesList = sizesList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateSize")]
        [Produces(typeof(Sizes))]
        public IActionResult UpdateSize([FromBody] Sizes sizes)
        {
            if (sizes == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(sizes)} cannot be null" });

            try
            {
                var result = SizesHelper.UpdateSizes(sizes);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteSize/{code}")]
        [Produces(typeof(Sizes))]
        public IActionResult DeleteSize(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                var result = SizesHelper.DeleteSizes(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}