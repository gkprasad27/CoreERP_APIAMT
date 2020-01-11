using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.Models;
using CoreERP.DataAccess;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/Inventory/MaterialGroup")]
    public class MaterialGroupController : ControllerBase
    {
        [HttpPost("RegisterMaterialGroup")]
        public async Task<IActionResult> RegisterMaterialGroup([FromBody]MaterialGroup materialGroup)
        {
            if (materialGroup == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(materialGroup)} can not be null" });

            try
            {
                int result =MaterialGroupHelper.RegisterMaterialGroup(materialGroup);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = materialGroup });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }

        }



        [HttpGet("GetAllMaterialGroup")]
        [Produces(typeof(List<MaterialGroup>))]
        public async Task<IActionResult> GetAllMaterialGroup()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = MaterialGroupHelper.GetMaterialGroupList() });
        }

        [HttpPut("UpdateMaterialGroup/{code}")]
        [Produces(typeof(MaterialGroup))]
        public async Task<IActionResult> UpdateMaterialGroup(string code, [FromBody] MaterialGroup materialGroups)
        {
            if (materialGroups == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(materialGroups)} cannot be null" });

            if (!string.IsNullOrWhiteSpace(materialGroups.Code) && code != materialGroups.Code)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Conflicting role id in parameter and model data" });


            try
            {
                int rs = MaterialGroupHelper.UpdateMaterialGroup(materialGroups);
                if (rs > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = materialGroups });
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(materialGroups)} Updation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(materialGroups)} Updation Failed" });
            }
        }


        [HttpDelete("DeleteMaterialGroup/{code}")]
        [Produces(typeof(MaterialGroup))]
        public async Task<IActionResult> DeleteMaterialGroup(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                int result = MaterialGroupHelper.DeleteMaterialGroup(code);
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