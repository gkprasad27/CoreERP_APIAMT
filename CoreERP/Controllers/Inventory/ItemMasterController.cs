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
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = ItemMasterHelper.GetItemMasterList() });
        }

        [HttpGet("GetAllMaterialGroup")]
        [Produces(typeof(List<Brand>))]
        public async Task<IActionResult> GetAllMaterialGroup()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = MaterialGroupHelper.GetMaterialGroupList() });
        }

        [HttpGet("GetAllBrand")]
        [Produces(typeof(List<Brand>))]
        public async Task<IActionResult> GetAllBrand()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = BrandHelpers.GetBrands() });
        }


        [HttpGet("GetAllBrandModel")]
        [Produces(typeof(List<BrandModel>))]
        public async Task<IActionResult> GetAllBrandModel()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = BrandModelHelper.GetBrandModelList() });
        }


        [HttpGet("SizesList")]
        [Produces(typeof(List<Sizes>))]
        public async Task<IActionResult> GetAllSize()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = SizesHelper.GetSizesList() });
        }



        [HttpGet("AccoundingClasslist")]
        [Produces(typeof(List<AccountingClass>))]
        public async Task<IActionResult> GetAllAccountingClass()
        {
            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = AccountClassHelper.GetAccountingClassList() });
        }




        [HttpPut("UpdateItemMaster/{code}")]
        [Produces(typeof(ItemMaster))]
        public async Task<IActionResult> UpdateItemMaster(string code, [FromBody] ItemMaster itemMasters)
        {
            if (itemMasters == null)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(itemMasters)} cannot be null" });

            if (!string.IsNullOrWhiteSpace(itemMasters.Code) && code != itemMasters.Code)
                return BadRequest(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Conflicting role id in parameter and model data" });


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