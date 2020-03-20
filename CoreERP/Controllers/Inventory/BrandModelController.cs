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
using System.Dynamic;
using CoreERP.BussinessLogic.masterHlepers;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Inventory/BrandModel")]
    public class BrandModelController : ControllerBase
    {
        //[HttpPost("RegisterBrandModel")]
        //public async Task<IActionResult> RegisterBrandModel([FromBody]BrandModel brandModel)
        //{
        //    if (brandModel == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brandModel)} can not be null" });
        //    try
        //    {
        //        BrandModel result = BrandModelHelpers.RegisterBrandModel(brandModel);
        //        if (result != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = " Registration Failed" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
                
        //[HttpPut("UpdateBrandModel")]
        //[Produces(typeof(BrandModel))]
        //public async Task<IActionResult> UpdateBrandModel([FromBody] BrandModel brandModels)
        //{
        //    if (brandModels == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(brandModels)} cannot be null" });


        //    try
        //    {
        //        BrandModel result = BrandModelHelpers.UpdateBrandModelClass(brandModels);
        //        if (result != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = brandModels });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpDelete("DeleteBrandModel/{code}")]
        //[Produces(typeof(BrandModel))]
        //public async Task<IActionResult> DeleteBrandModel(string code)
        //{

        //    if (string.IsNullOrWhiteSpace(code))
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(code)} cannot be null" });

        //    try
        //    {
        //        BrandModel result = BrandModelHelpers.DeleteBrandModelClass(code);
        //        if (result !=null)
        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = code });
                
        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetBrandModelList")]
        //[Produces(typeof(List<BrandModel>))]
        //public async Task<IActionResult> GetBrandModelList()
        //{
        //    try
        //    {
        //        var modelLList= BrandModelHelpers.GetBrandModelList();
        //        if (modelLList.Count > 0)
        //        {
        //            dynamic expando = new ExpandoObject();
        //            expando.brandModelList = modelLList;
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //        }

        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "No Data Found." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetBrands")]
        //[Produces(typeof(List<BrandModel>))]
        //public async Task<IActionResult> GetBrands()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.BrandsList = BrandHelpers.GetBrands().Select(b => new { ID = b.Code, TEXT = b.BrandName });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetMaterialGroups")]
        //[Produces(typeof(List<BrandModel>))]
        //public async Task<IActionResult> GetMaterialGroups()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.MaterialGroupsList=MaterialGroupHelper.GetMaterialGroupList().Select(mtgrp => new { ID = mtgrp.Code, TEXT = mtgrp.GroupName });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetCompanies")]
        //[Produces(typeof(List<BrandModel>))]
        //public async Task<IActionResult> GetCompanies()
        //{
        //    try
        //    {
        //            dynamic expando = new ExpandoObject();
        //            expando.CompaniesList = BrandModelHelpers.GetCompanies().Select(comp=> new { ID=comp.CompanyCode,TEXT=comp.Name});
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetSizes")]
        //[Produces(typeof(List<BrandModel>))]
        //public async Task<IActionResult> GetSizes()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.SizesList = BrandModelHelpers.GetSizes().Select(s => new { ID = s.Code, TEXT = s.Description });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetInputTaxes")]
        //[Produces(typeof(List<BrandModel>))]
        //public async Task<IActionResult> GetInputTaxes()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.InputTaxesList = TaxmasterHelper.GetListOfTaxMasters(TAXTYPE.INPUT).Select(s => new { ID = s.Code, TEXT = s.Description });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetOutPutTaxes")]
        //[Produces(typeof(List<BrandModel>))]
        //public async Task<IActionResult> GetOutPutTaxes()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.OutPutTaxesList = TaxmasterHelper.GetListOfTaxMasters(TAXTYPE.OUTPUT).Select(s => new { ID = s.Code, TEXT = s.Description });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}