using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.InventoryHelpers;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.Models;
using CoreERP.DataAccess;
using System.Dynamic;

namespace CoreERP.Controllers.Inventory
{
    [ApiController]
    [Route("api/Inventory/ProductMaster")]
    public class ProductController : ControllerBase
    {
        [HttpGet("GetProductMasterList")]
        public async Task<IActionResult> GetProductMasterList()
        {
            try
            {
                var productMasterList = ProductMasterHelper.GetProductMasterList();
                if (productMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.productMasterList = productMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }

        }
    }
}