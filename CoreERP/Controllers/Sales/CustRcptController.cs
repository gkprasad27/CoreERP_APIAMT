
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.Controllers.Enums;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.BussinessLogic.masterHlepers;

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
        [HttpGet("GetCutomerReceiptList")]
        public async Task<IActionResult> GetCutomerReceiptList()
        {
            try
            {
                var response = BillingHelpers.GetCustomerReceiptList();
                return Ok(response);
            }
            catch { }

            return Ok("Record Not found");
        }

        [HttpGet("GetCompanyList")]
        public async Task<IActionResult> GetCompanyList()
        {
            try
            {
                var response = CompaniesHelper.GetListOfCompanies();
                return Ok(new { companyList= response });
            }
            catch { }

            return Ok("Record Not found");
        }

        [HttpGet("GetBranchList")]
        public async Task<IActionResult> GetBranchList()
        {
            try
            {
                var response = BrancheHelper.GetBranches();
                return Ok(new { branchList = response });
            }
            catch { }

            return Ok("Record Not found");
        }

        [HttpGet("GetAsigCashAccBranches")]
        public async Task<IActionResult> GetAsigCashAccBranches()
        {
            try
            {
                var response = BillingHelpers.GetAsigCashAccBranches(); 
                return Ok(new { AsigCashAccBranchesList = response });
            }
            catch { }

            return Ok("Record Not found");
        }

        [HttpGet("GetPartnerCreationList")]
        public async Task<IActionResult> GetPartnerCreationList()
        {
            try
            {
                var response = PartnerCreationHelper.GetList();
                return Ok(new { PartnerCreationList = response });
            }
            catch { }

            return Ok("Record Not found");
        }

        [HttpGet("GetAsigAcctobranchGlAcc")]
        public async Task<IActionResult> GetAsigAcctobranchGlAcc()
        {
            try
            {
                var response = BillingHelpers.GetAsigAcctobranchGlAcc();
                return Ok(new { AsigAcctobranchGlAccList = response });
            }
            catch { }

            return Ok("Record Not found");
        }

        [HttpGet("GetPartnerTypeList")]
        public async Task<IActionResult> GetPartnerTypeList()
        {
            try
            {
                var response = PartnerTypeHelper.GetPartnerTypeList();
                return Ok(new { PartnerTypeList = response });
            }
            catch { }

            return Ok("Record Not found");
        }

        //[HttpPost("RegisterCustomerReceipts")]
        //[Produces(typeof(CustomerReceipts))]
        //public async Task<IActionResult> RegisterCustomerReceipts([FromBody]CustomerReceipts customerReceipts)
        //{
        //    if (customerReceipts == null)
        //        return BadRequest($"{nameof(customerReceipts)} cannot be null");
        //   try
        //    {
        //        customerReceipts.AddDate = DateTime.Now;
        //        customerReceipts.EditDate = DateTime.Now;

        //        var lastreacord = _unitOfWork.CustomerReceipts.GetAll().Select(x => Convert.ToInt64(x.Code)).ToArray().OrderByDescending(x => x).FirstOrDefault();
        //        if (lastreacord != 0)
        //            customerReceipts.Code = (lastreacord + 1).ToString();
        //        else
        //           customerReceipts.Code = "1";

        //        _unitOfWork.CustomerReceipts.Add(customerReceipts);
        //        if (_unitOfWork.SaveChanges() > 0)
        //            return Ok(customerReceipts);
        //        else 
        //            return BadRequest($"{nameof(customerReceipts)} Registration Failed");
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest($"{nameof(customerReceipts)} Registration Failed");
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
        

        //[HttpPut("sales/custsrc/{code}")]
        //[Produces(typeof(CustomerReceipts))]
        //public async Task<IActionResult> Update(string code, [FromBody] CustomerReceipts customerReceipts)
        //{
        //    if (customerReceipts == null)
        //        return BadRequest($"{nameof(customerReceipts)} cannot be null");

        //    if (!string.IsNullOrWhiteSpace(customerReceipts.Code) && code != customerReceipts.Code)
        //        return BadRequest("Conflicting role id in parameter and model data");
        //    try
        //    {
        //        customerReceipts.EditDate = DateTime.Now;
        //        _unitOfWork.CustomerReceipts.Update(customerReceipts);
        //        if (_unitOfWork.SaveChanges() > 0)
        //            return Ok(customerReceipts);
        //        else
        //            return BadRequest($"{nameof(customerReceipts)} Updation Failed");
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest($"{nameof(customerReceipts)} Updation Failed");
        //    }
        //}


       
        //[HttpDelete("sales/custsrc/{code}")]
        //[Produces(typeof(CustomerReceipts))]
        //public async Task<IActionResult> Delete(string code)
        //{
        //    if (code == null)
        //        return BadRequest($"{nameof(code)}can not be null");

        //    try
        //    {
        //        var cardtype = _unitOfWork.CustomerReceipts.GetAll().SingleOrDefault(x=> x.Code == code);
                
        //        _unitOfWork.CustomerReceipts.Remove(cardtype);
        //        _unitOfWork.SaveChanges();
        //        return Ok(cardtype);

        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest($"Delete Operation Failed");
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
