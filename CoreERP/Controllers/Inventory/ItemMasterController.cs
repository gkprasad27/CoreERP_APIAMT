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

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/Inventory/ItemMaster")]
    public class ItemMasterController : ControllerBase
    {

        [HttpPost("RegisterItemMaster")]
        public async Task<IActionResult> RegisterItemMaster([FromBody]ItemMaster itemMaster)
        {
            try
            {
                int result = ItemMasterHelper.RegisterItemMaster(itemMaster);
                if (result > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = itemMaster });
                else
                    return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Operation Failed" });
            }

        }

        [HttpGet("GetAllItemMasterList")]
        [Produces(typeof(List<ItemMaster>))]
        public async Task<IActionResult> GetAllItemMasterList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.itemMasterList = ItemMasterHelper.GetItemMasterList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAllMaterialGroup")]
        [Produces(typeof(List<Brand>))]
        public async Task<IActionResult> GetAllMaterialGroup()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.materialGroupList =MaterialGroupHelper.GetMaterialGroupList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetAllBrand")]
        [Produces(typeof(List<Brand>))]
        public async Task<IActionResult> GetAllBrand()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.brandsList = BrandHelpers.GetBrands();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetAllBrandModel")]
        [Produces(typeof(List<BrandModel>))]
        public async Task<IActionResult> GetAllBrandModel()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.brandModelsList = BrandModelHelpers.GetBrandModelList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetSizesList")]
        [Produces(typeof(List<Sizes>))]
        public async Task<IActionResult> GetSizesList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.sizesList = SizesHelper.GetSizesList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpGet("GetAccoundingClasslist")]
        [Produces(typeof(List<AccountingClass>))]
        public async Task<IActionResult> GetAccoundingClasslist()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.accountingClassList = AccountClassHelper.GetAccountingClassList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }




        [HttpPut("UpdateItemMaster/{code}")]
        [Produces(typeof(ItemMaster))]
        public async Task<IActionResult> UpdateItemMaster(string code, [FromBody] ItemMaster itemMasters)
        {
            if (itemMasters == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(itemMasters)} cannot be null" });

            try
            {
                int rs =ItemMasterHelper.UpdateItemMaster(itemMasters);
                if (rs > 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = itemMasters });
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(itemMasters)} Updation Failed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(itemMasters)} Updation Failed" });
            }
        }


        [HttpDelete("DeleteItemMaster/{code}")]
        [Produces(typeof(ItemMaster))]
        public async Task<IActionResult> DeleteItemMaster(string code)
        {

            if (string.IsNullOrWhiteSpace(code))
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

            try
            {
                int result = ItemMasterHelper.DeleteItemMaster(code);
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



        [HttpGet("GetAllCompanys")]
        [Produces(typeof(List<Companies>))]
        public async Task<IActionResult> GetAllCompanys()
        {
            return Ok(CompaniesHelper.GetListOfCompanies());
        }
    }
}