using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/UOM")]
    public class UomController : ControllerBase
    {
        [HttpPost("RegisterSizes")]
        public IActionResult RegisterSizes([FromBody] TblUnit uoms)
        {
            if (uoms == null)
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "object can not be null" });

            try
            {
                if (UomHelper.GetSizesList(uoms.UnitId).Count() > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"sizes Code {nameof(uoms.UnitId)} is already exists ,Please Use Different Code " });

                var result = UomHelper.RegisterSizes(uoms);
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


        [HttpGet("GetAllSizes")]
        [Produces(typeof(List<TblUnit>))]
        public IActionResult GetAllSizes()
        {
            try
            {
                var sizesList = UomHelper.GetSizesList();
                //if (sizesList.Count > 0)
                //{
                    dynamic expando = new ExpandoObject();
                    expando.sizesList = sizesList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                //}
                //else
                //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPut("UpdateSize")]
        [Produces(typeof(TblUnit))]
        public IActionResult UpdateSize([FromBody] TblUnit uoms)
        {
            if (uoms == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(uoms)} cannot be null" });

            try
            {
                var result = UomHelper.UpdateSizes(uoms);
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
        [Produces(typeof(TblUnit))]
        public IActionResult DeleteSize(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                var result = UomHelper.DeleteSizes(code);
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