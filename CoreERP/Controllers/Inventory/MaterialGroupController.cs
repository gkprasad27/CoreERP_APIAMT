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
using System.Dynamic;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Inventory/MaterialGroup")]
    public class MaterialGroupController : ControllerBase
    {
        [HttpPost("RegisterMaterialGroup")]
        public async Task<IActionResult> RegisterMaterialGroup([FromBody]MaterialGroup materialGroup)
        {
            if (materialGroup == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(materialGroup)} can not be null" });

            try
            {
                MaterialGroup result = MaterialGroupHelper.RegisterMaterialGroup(materialGroup);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAllMaterialGroup")]
        [Produces(typeof(List<MaterialGroup>))]
        public async Task<IActionResult> GetAllMaterialGroup()
        {
            try
            {
                var materialGroupList = MaterialGroupHelper.GetMaterialGroupList();
                if (materialGroupList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.materialGroupList = MaterialGroupHelper.GetMaterialGroupList();
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

        [HttpPut("UpdateMaterialGroup")]
        [Produces(typeof(MaterialGroup))]
        public async Task<IActionResult> UpdateMaterialGroup([FromBody] MaterialGroup materialGroups)
        {
            if (materialGroups == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(materialGroups)} cannot be null" });

            try
            {
                MaterialGroup result = MaterialGroupHelper.UpdateMaterialGroup(materialGroups);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(materialGroups)} Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpDelete("DeleteMaterialGroup/{code}")]
        [Produces(typeof(MaterialGroup))]
        public async Task<IActionResult> DeleteMaterialGroup(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                MaterialGroup result = MaterialGroupHelper.DeleteMaterialGroup(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = code });
                else
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAccountingClassList")]
        [Produces(typeof(List<MaterialGroup>))]
        public async Task<IActionResult> GetAccountingClassList()
        {
            try
            {
                var accountingClassList = MaterialGroupHelper.GetAccountingClassList();
                dynamic expando = new ExpandoObject();
                expando.accountingClassList = accountingClassList.Select(x => new { ID = x, TEXT = x });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }
    }
}