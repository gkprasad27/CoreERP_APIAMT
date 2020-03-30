using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.BussinessLogic.PurhaseHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/Purchase/VendorPayments")]
    public class VendorPaymentsController : ControllerBase
    {
        //[HttpPost("RegisterVendorPayments")]
        //public async Task<IActionResult> RegisterVendorPayments([FromBody]VendorPayments vendorpayment)
        //{
        //    if (vendorpayment == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });
        //    try
        //    {
        //        var result = PurchasesModelHelper.RegisterVendorPayments(vendorpayment);
        //        if (result != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpPut("UpdateVendorPayments")]
        //public async Task<IActionResult> UpdateVendorPayments(string code, [FromBody] VendorPayments vendorpayments)
        //{
        //    if (vendorpayments == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });
        //    try
        //    {
        //        var result = PurchasesModelHelper.UpdateVendorPayments(vendorpayments);
        //        if (result != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpDelete("DeleteVendorPayments/{code}")]
        //public async Task<IActionResult> DeleteVendorPayments(string code)
        //{
        //    if (code == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request cannot be null" });
        //    try
        //    {
        //        var result = PurchasesModelHelper.DeleteVendorPayments(code);
        //        if (result != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetVendorPaymentsList")]
        //public async Task<IActionResult> GetVendorPaymentsList()
        //{
        //    try
        //    {
        //        var vendorPayMentList = PurchasesModelHelper.GetVendorPaymentsList();
        //        if (vendorPayMentList.Count > 0)
        //        {
        //            dynamic expando = new ExpandoObject();
        //            expando.VendorNamesList = PurchasesModelHelper.GetVendorNames().Select(pc => new { ID = pc.Code, TEXT = pc.Name });
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //        }

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }

        //    //var rs = (from glacc in _unitOfWork.GLAccounts.GetAll()
        //    //          join pc in _unitOfWork.PartnerCreation.GetAll()
        //    //          on glacc.GLCode equals pc.GLControlAcc
        //    //          select glacc).Distinct();


        //    //return Json(new
        //    //{
        //    //    partnerCreationList = (from pc in _unitOfWork.PartnerCreation.GetAll()
        //    //                           where pc.Partnertype != null
        //    //                           select pc),
        //    //    noSeriesList = (from ns in _unitOfWork.NoSeries.GetAll()
        //    //                    select ns)
        //    //});


        //}
        ////no series APi pending

        [HttpGet("GetPartnerCreationList")]
        public IActionResult GetPartnerCreationList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.PartnerCreationList = PartnerCreationHelper.GetList().Select(gl => new { ID = gl.Code, TEXT = gl.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetPartnertypeList")]
        //public async Task<IActionResult> GetPartnertypeList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.PartnertypeList = PartnerTypeHelper.GetPartnerTypeList().Select(gl => new { ID = gl.Code, TEXT = gl.Description });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpGet("GetAsigCasNBankAcc")]
        public IActionResult GetAsigCasNBankAcc()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.AsigCasNBankAcc = PurchasesModelHelper.GetAsigCasNBankAcc().Select(gl => new { ID = gl.Glcode, TEXT = gl.GlaccountName });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetAsigCashAccBranchesList")]
        //public async Task<IActionResult> GetAsigCashAccBranchesList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.VendorNamesList = PurchasesModelHelper.GetAsignmentCashAccBranchesList().Select(pc => new { ID = pc.Code, TEXT = pc });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetVendorNamesList")]
        //public async Task<IActionResult> GetVendorNamesList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.VendorNamesList = PurchasesModelHelper.GetVendorNames().Select(pc => new { ID = pc.Code, TEXT = pc.Name });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetCutomerNamesList")]
        //public async Task<IActionResult> GetCutomerNamesList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.VendorNamesList = PurchasesModelHelper.GetCutomerNamesList().Select(pc => new { ID = pc.Code, TEXT = pc.Name });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpGet("GetCompanysList")]
        public IActionResult GetCompanysList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.CompaniesList = PurchasesModelHelper.GetCompanies().Select(pc => new { ID = pc.CompanyCode, TEXT = pc.Name });
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetBranchesList")]
        //public async Task<IActionResult> GetBranchesList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.BranchesList = PurchasesModelHelper.GetBranches().Select(pc => new { ID = pc.BranchCode, TEXT = pc.Name });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("vpayments/billsrcvl")]
        //public async Task<IActionResult> GetCustomerNamesFromPurchase()
        //{
        //    try
        //    {
        //        var list = new VendorPaymentHelper(_unitOfWork).GetVendorNames().Select(x => new { key = x.GoodsReceiptNo, value = x.VendorName });

        //        return Json(new { purchase = list });
        //    }
        //    catch
        //    {
        //        return BadRequest("Data Load Failed");
        //    }



        //[HttpPost("vpayments/op/register")]
        //[Produces(typeof(VendorPayments))]
        //public async Task<IActionResult> RegisterOp([FromBody]Balances balances)
        //{

        //    if (balances == null)
        //        return BadRequest($"{nameof(balances)} cannot be null");
        //    try
        //    {
        //        var lastrecord = _unitOfWork.Balances.GetAll().OrderByDescending(x => x.Code).FirstOrDefault();
        //        if (lastrecord != null)
        //            balances.Code = (lastrecord.Code + 1);
        //        else
        //            balances.Code = 1;

        //        lastrecord = null;



        //        _unitOfWork.Balances.Add(balances);

        //        if (_unitOfWork.SaveChanges() > 0)
        //            return Ok(balances);
        //        else
        //            return BadRequest($"{nameof(balances)} Registration Failed");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"{nameof(balances)} Registration Failed");
        //    }
        //}



        //[HttpPut("vpayments/op/{code}")]
        //[Produces(typeof(VendorPayments))]
        //public async Task<IActionResult> UpdateOp(string code, [FromBody] Balances balances)
        //{
        //    if (balances == null)
        //        return BadRequest($"{nameof(balances)} cannot be null");
        //    try
        //    {
        //        _unitOfWork.Balances.Update(balances);
        //        if (_unitOfWork.SaveChanges() > 0)
        //            return Ok(balances);
        //        else
        //            return BadRequest($"{nameof(balances)} Updation Failed");
        //    }
        //    catch
        //    {
        //        return BadRequest($"{nameof(balances)} Updation Failed");
        //    }

        //}




        //}

        //[HttpGet("vpayments/billsrcvl/{goodsReceiptNo}")]
        //public async Task<IActionResult> GetCustomerNamesFromPurchase(string goodsReceiptNo)
        //{
        //    try
        //    {
        //        if (goodsReceiptNo != null)
        //            return Ok(new VendorPaymentHelper(_unitOfWork).GetPurchaseRecordsByPurchaseCode(goodsReceiptNo));
        //    }
        //    catch { }

        //    return BadRequest("purchase code can not be null");
        //}


        //[HttpGet("vpayments/op")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Json(new
        //    {
        //       // op = _unitOfWork.Branches.GetAll(),
        //        companys = _unitOfWork.Companys.GetAll(),
        //        branches = _unitOfWork.Branches.GetAll(),
        //        //partnerCreationList = (from pc in _unitOfWork.PartnerCreation.GetAll()
        //        //                       where pc.Partnertype != null
        //        //                       select pc)
        //    });

        //}
    }
}
