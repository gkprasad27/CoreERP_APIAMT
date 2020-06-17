using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.transactionsHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.masters
{
    [ApiController]
    [Route("api/masters/Product")]
    public class ProductController : Controller
    {

        [HttpGet("GetProductList")]
        public IActionResult GetProductList()
        {
            try
            {
                var productList = new ProductHelper().GetProductList();
                if (productList.Count > 0)
                {
                    dynamic expdoObj = new ExpandoObject();
                    expdoObj.ProductList = productList;
                    return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expdoObj });
                }
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetProductGroupList")]
        public async Task<IActionResult> GetProductGroupList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.ProductGroupList = new ProductHelper().GetProductGroupList().Select(x => new { ID = x.GroupCode, TEXT = x.GroupName});
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetProductPackingList")]
        public async Task<IActionResult> GetProductPackingList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.ProductPackingList = new ProductHelper().GetProductPackingList().Select(x => new { ID = x.PackingCode, TEXT = x.PackingName});
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetSupplierGroupList")]
        public async Task<IActionResult> GetSupplierGroupList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.SupplierGroupList = new ProductHelper().GetSupplierGroupList().Select(x => new { ID = x.SupplierGroupCode, TEXT = x.SupplierGroupName});
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetUnitList")]
        public async Task<IActionResult> GetUnitList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.UnitList = new ProductHelper().GetUnitList().Select(x => new { ID = x.UnitId, TEXT = x.UnitName });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetTaxGrouplist/{productGroupCode}")]
        public IActionResult GetTaxGrouplist(decimal productGroupCode)
        {
            if (productGroupCode==0)
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Account group Can not be null/empty." });
            try
            {
                dynamic expando = new ExpandoObject();
                expando.TaxGroupList = new ProductHelper().GetTaxGroupList(productGroupCode).Select(a => new { ID = a.TaxGroupCode, TEXT = a.TaxGroupName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTaxApplicableList")]
        public async Task<IActionResult> GetTaxApplicableList()
        {
            var result = await Task.Run(() =>
            {
                try
                {
                    dynamic expando = new ExpandoObject();
                    expando.TaxApplicableList = new ProductHelper().GetTaxApplicableList().Select(x => new { ID = x.Id, TEXT = x.Name });
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpGet("GetTaxList/{taxStructureCode}")]
        public IActionResult GetTaxList(int taxStructureCode)
        {
            if (taxStructureCode == 0)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request is empty." });
            }
            try
            {
                dynamic expando = new ExpandoObject();
                expando.TaxList = new ProductHelper().GetTaxList(taxStructureCode).Select(x => new { x.Cgst, x.Sgst, x.Igst, x.TotalGst, x.TotalPercentageGst });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpGet("GetTaxStructure/{taxGroupCode}")]
        public IActionResult GetTaxStructure(string taxGroupCode)
        {
            if (string.IsNullOrEmpty(taxGroupCode))
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Tax group Can not be null/empty." });
            try
            {
                dynamic expando = new ExpandoObject();
                expando.TaxStructureCode = new ProductHelper().GetTaxStructureList(taxGroupCode).Select(a => new { ID = a.TaxStructureId, TEXT = a.TaxStructureCode});
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        [HttpPost("RegisterProduct")]
        public async Task<IActionResult> RegisterProduct([FromBody]TblProduct product)
        {
            var result = await Task.Run(() =>
            {
                if (product == null)
                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(product)} cannot be null" });
                try
                {
                    var reponse = new ProductHelper().Register(product);
                    if (reponse != null)
                        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = reponse });

                    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] TblProduct product)
        {
            var result = await Task.Run(() =>
            {
                if (product == null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(product)} cannot be null" });
                try
                {
                    APIResponse apiResponse = null;

                    TblProduct result = new ProductHelper().Update(product);
                    if (result != null)
                    {
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    }
                    else
                    {
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." };
                    }
                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
        [HttpDelete("DeleteProduct/{code}")]
        public async Task<IActionResult> DeleteProduct(int code)
        {
            var result = await Task.Run(() =>
            {
                APIResponse apiResponse = null;
                if (code == 0)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = $"{nameof(code)}can not be null" });

                try
                {
                    var result = new ProductHelper().Delete(code);
                    if (result != null)
                    {
                        apiResponse = new APIResponse() { status = APIStatus.PASS.ToString(), response = result };
                    }
                    else
                    {
                        apiResponse = new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." };
                    }
                    return Ok(apiResponse);
                }
                catch (Exception ex)
                {
                    return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
                }
            });
            return result;
        }
    }
}