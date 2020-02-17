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
    [ApiController]
    [Route("api/Inventory/ItemMaster")]
    public class ItemMasterController : ControllerBase
    {

        [HttpPost("RegisterItemMaster")]
        public async Task<IActionResult> RegisterItemMaster([FromBody]ItemMaster itemMaster)
        {
            try
            {
                if(ItemMasterHelper.GetItemMasterList(itemMaster.ItemNumber).Count > 0)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"Code ={itemMaster.ItemNumber} Already exists." });

                ItemMaster result = ItemMasterHelper.RegisterItemMaster(itemMaster);
                if (result !=null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
            }

        }

        [HttpGet("GetItemMasterList")]
        public async Task<IActionResult> GetItemMasterList()
        {
            try
            {
                var itemMasterList = ItemMasterHelper.GetItemMasterList();
                if (itemMasterList.Count > 0)
                {
                    dynamic expando = new ExpandoObject();
                    expando.itemMasterList = itemMasterList;
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }

                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "No Data Found." });
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

        [HttpGet("GetBrandsList")]
        public async Task<IActionResult> GetBrandsList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.BrandsList = BrandHelpers.GetBrands();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }


        [HttpGet("GetBrandModelsList")]
        public async Task<IActionResult> GetBrandModelsList()
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




        [HttpPut("UpdateItemMaster")]
        [Produces(typeof(ItemMaster))]
        public async Task<IActionResult> UpdateItemMaster([FromBody] ItemMaster itemMasters)
        {
            if (itemMasters == null)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(itemMasters)} cannot be null" });

            try
            {
                ItemMaster result =ItemMasterHelper.UpdateItemMaster(itemMasters);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });
                
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response =ex.Message });
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
                ItemMaster result = ItemMasterHelper.DeleteItemMaster(code);
                if (result != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = code });

                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }



        [HttpGet("GetCompanysList")]
        [Produces(typeof(List<Companies>))]
        public async Task<IActionResult> GetCompanysList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CompanysList = CompaniesHelper.GetListOfCompanies();
                return Ok(new APIResponse() { status=APIStatus.PASS.ToString(),response= expando });
            }
            catch(Exception ex)
            {
                return Ok(new APIResponse() { status=APIStatus.FAIL.ToString(),response= ex .Message});
            }
        }
    }
}