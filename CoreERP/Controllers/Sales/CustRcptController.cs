
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Controllers.Enums;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.BussinessLogic.masterHlepers;
using System.Dynamic;
using CoreERP.DataAccess;
using CoreERP.Models;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/custsrc")]
    public class CustRcptController : ControllerBase
    {

        //[HttpGet("GetCutomerRecgfgfgieptList")]
        //public async Task<IActionResult> GetCugfgfgtomerRecieptList()
        //{



        //    return Json(new
        //    {

        //        noSeriesMaster = _unitOfWork.NoSeries.GetAll(),
        //        voucherTypeArray = _unitOfWork.VoucherTypes.GetAll()

        //    });

        //}
        //[HttpGet("GetCutomerReceiptList")]
        //public IActionResult GetCutomerReceiptList()
        //{
        //    try
        //    {
        //        var customerReceiptList = BillingHelpers.GetCustomerReceiptList();
        //        if (customerReceiptList.Count > 0)
        //        {
        //            dynamic expnado = new ExpandoObject();
        //            expnado.CustomerReceiptList = BillingHelpers.GetCustomerReceiptList();
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expnado });
        //        }
        //        else
        //            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "No Data Found." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetCompanyList")]
        //public IActionResult GetCompanyList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.companysList = CompaniesHelper.GetListOfCompanies().Select(x => new { ID = x.CompanyId, TEXT = x.CompanyName });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpGet("GetBranchList")]
        //public IActionResult GetBranchList()
        //{
        //    try
        //    {
        //        dynamic expnado = new ExpandoObject();
        //        expnado.branchesList = BrancheHelper.GetBranches();
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expnado });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpGet("GetAsigCashAccBranches")]
        public IActionResult GetAsigCashAccBranches()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.AsigCashAccBranchesList = BillingHelpers.GetAsigCashAccBranches();
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetPartnerCreationList")]
        //public IActionResult GetPartnerCreationList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.partnerTypeList = PartnerCreationHelper.GetList();
        //        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpGet("GetAsigAcctobranchGlAcc")]
        public IActionResult GetAsigAcctobranchGlAcc()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.AsigAcctobranchGlAccList = BillingHelpers.GetAsigAcctobranchGlAcc();
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpGet("GetPartnerTypeList")]
        //public async Task<IActionResult> GetPartnerTypeList()
        //{
        //    try
        //    {
        //        dynamic expando = new ExpandoObject();
        //        expando.partnerTypeList = PartnerTypeHelper.GetPartnerTypeList();
        //        return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expando });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        [HttpGet("GetVoucherTypeList")]
        public IActionResult GetVoucherTypeList()
        {
            try
            {
                dynamic expando = new ExpandoObject();
                expando.VoucherTypesList = BillingHelpers.GetVoucherTypesList().Select(x => new { ID = x, TEXT = x });
                return Ok(new APIResponse { status = APIStatus.PASS.ToString(), response = expando });
            }
            catch (Exception ex)
            {
                return Ok(new APIResponse { status = APIStatus.FAIL.ToString(), response = ex.Message });
            }
        }

        //[HttpPost("RegisterCustomerReceipts")]
        //[Produces(typeof(CustomerReceipts))]
        //public IActionResult RegisterCustomerReceipts([FromBody]CustomerReceipts customerReceipts)
        //{
        //    if (customerReceipts == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(customerReceipts)} cannot be null" });
        //    try
        //    {
        //        var result = BillingHelpers.RegisterCustomerReceipt(customerReceipts);
        //        if (result != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpPut("UpdateCustomerReceipt")]
        //[Produces(typeof(CustomerReceipts))]
        //public IActionResult UpdateCustomerReceipt([FromBody] CustomerReceipts customerReceipts)
        //{
        //    if (customerReceipts == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = $"{nameof(customerReceipts)} cannot be null" });

        //    try
        //    {
        //        var result = BillingHelpers.UpdateCustomerReceipt(customerReceipts);
        //        if (result != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = " Updation Failed" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpDelete("DeleteCustomerReceipt/{seqID}")]
        //[Produces(typeof(CustomerReceipts))]
        //public IActionResult DeleteCustomerReceipt(string seqID)
        //{
        //    if (seqID == null)
        //        return BadRequest($"{nameof(seqID)}can not be null");

        //    try
        //    {
        //        var cardtype = BillingHelpers.DeleteCustomerReceipt(Convert.ToInt32(seqID));
        //        if (cardtype != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = cardtype });

        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = "Deletion Failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = ex.Message });
        //    }
        //}



        //[HttpGet("sales/custsrc/billRcbl/custlist")]
        //[Produces(typeof(Billing))]
        //public async Task<IActionResult> GetCustomerNames()
        //{
        //    return Ok(new { bill = new BIllingHelper(_unitOfWork).GetCustomerNamesByBillRecievableAmt()});
        //}

        //[HttpGet("sales/custsrc/billRcbl/{billNo}")]
        //[Produces(typeof(Billing))]
        //public async Task<IActionResult> getBillRecords(string billNo)
        //{

        //    try
        //    {              
        //        return Ok(new{bill = new BIllingHelper(_unitOfWork).GetBillTransactionsByBillNo(billNo)});
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.StackTrace);
        //    }
        //}



        //[HttpGet("sales/custsrc/ptc/customerlist")]
        //[Produces(typeof(PartnerCreation))]
        //public async Task<IActionResult> GetPartnerCreation()
        //{
        //    return Ok(new { partnercreation = this.GetPartnerCreationByAccountType(AccountType.TRADECUSTOMER) });
        //}


        //[HttpGet("sales/custsrc/ptc/trdevendorsist")]
        //[Produces(typeof(PartnerCreation))]
        //public async Task<IActionResult> GetPartnerCreationTradeVenodrs()
        //{
        //    return Ok( new { partnercreation = this.GetPartnerCreationByAccountType(AccountType.TRADEVENDORS) });
        //}

        //public IEnumerable<PartnerCreation> GetPartnerCreationByAccountType(AccountType accountType)
        //{
        //    return (from ptc in _unitOfWork.PartnerCreation.GetAll()
        //            join ptype in _unitOfWork.PartnerType.GetAll()
        //            on ptc.Partnertype equals ptype.Code
        //            where ptype.AccountType == accountType.ToString()
        //            select ptc).ToArray();
        //}

    }
}
