using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.Helpers;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAL.Models.Masters;
using Microsoft.AspNetCore.Authorization;
using DAL.Enums;
using CoreERP.Controllers.Enums;
using DAL.Models.Settings;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class VendorPaymentsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        

        public VendorPaymentsController(IUnitOfWork unitOfWork, ILogger<CardTypeController> logger, IEmailer emailer)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        [HttpGet("vpayments")]
        [Produces(typeof(object))]
        public async Task<IActionResult> GetAllvpayments()
        {
            var rs = (from glacc in _unitOfWork.GLAccounts.GetAll()
                      join pc in _unitOfWork.PartnerCreation.GetAll()
                      on glacc.GLCode equals pc.GLControlAcc
                      select  glacc).Distinct();
            

            return Json(new {
                vendorpayment = _unitOfWork.VendorPayments.GetAll(),
                companys = _unitOfWork.Companys.GetAll(),
                //companys = CompanyHelper.GetDistinctCompanyNames(this._unitOfWork),
                branches = _unitOfWork.Branches.GetAll(),
                asigmentaccounts = _unitOfWork.AsignmentCashAccBranch.GetAll(),
                accounts = (from glacc in _unitOfWork.GLAccounts.GetAll()
                            join asigccashacc in _unitOfWork.AsignmentCashAccBranch.GetAll()
                            on glacc.GLCode equals asigccashacc.CashGLAcc
                            select glacc).Union(from glacc in _unitOfWork.GLAccounts.GetAll()
                                                join asigccashacc in _unitOfWork.AsignmentCashAccBranch.GetAll()
                                                on glacc.GLCode equals asigccashacc.BankGLAcc
                                                select glacc).ToList(),
                partnertype =(from ptype  in _unitOfWork.PartnerType.GetAll()
                              select ptype),
               partnerCreationList =  (from  pc in _unitOfWork.PartnerCreation.GetAll()
                                       where pc.Partnertype != null
                                       select pc),
                noSeriesList =(from ns in _unitOfWork.NoSeries.GetAll()
                               select ns)
            });

        }


        [HttpPost("vpayments/register")]
        [Produces(typeof(VendorPayments))]
        public async Task<IActionResult> Register([FromBody]VendorPayments vendorpayment)
        {

            if (vendorpayment == null)
                return BadRequest($"{nameof(vendorpayment)} cannot be null");
           try
            {
                var lastrecord=(_unitOfWork.VendorPayments.GetAll().Where(v=> v.Code!=null).OrderByDescending(x => Convert.ToInt32(x.Code))).FirstOrDefault();
                if (lastrecord != null)
                    vendorpayment.Code = (Convert.ToInt32(lastrecord.Code) + 1).ToString();
                else
                    vendorpayment.Code = "1";

                lastrecord = null;

                vendorpayment.AddDate = System.DateTime.Now;
                vendorpayment.EditDate = System.DateTime.Now;

                _unitOfWork.VendorPayments.Add(vendorpayment);

                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(vendorpayment);
                else  
                    return BadRequest($"{nameof(vendorpayment)} Registration Failed");
            }
            catch(Exception ex)
            {
                return BadRequest($"{nameof(vendorpayment)} Registration Failed");
            }
        }



        [HttpPut("vpayments/{code}")]
        [Produces(typeof(VendorPayments))]
        public async Task<IActionResult> UpdateBrach(string code, [FromBody] VendorPayments vendorpayments)
        {
            if (vendorpayments == null)
                return BadRequest($"{nameof(vendorpayments)} cannot be null");

            if (!string.IsNullOrWhiteSpace(vendorpayments.Code) && code != vendorpayments.Code)
                return BadRequest("Conflicting role id in parameter and model data");
            try
            {
                _unitOfWork.VendorPayments.Update(vendorpayments);
                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(vendorpayments);
                else
                    return BadRequest($"{nameof(vendorpayments)} Updation Failed");
            }
            catch
            {
                return BadRequest($"{nameof(vendorpayments)} Updation Failed");
            }

        }


        // Delete Branch
        [HttpDelete("vpayments/{code}")]
        [Produces(typeof(VendorPayments))]
        public async Task<IActionResult> Delete(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");
            try
            {
                var result = _unitOfWork.VendorPayments.GetAll().ToList();
                var _branch = (from b in result
                               where b.Code == code
                               select b).FirstOrDefault();
                _unitOfWork.VendorPayments.Remove(_branch);
                _unitOfWork.SaveChanges();
                return Ok(result);

            }
            catch
            {
                return BadRequest($"Delete Operation Failed");
            }
            
        }

        [HttpGet("vpayments/vendornames")]
        public async Task<IActionResult> GetVendorNames()
        {
           
            return Json(new { purchase = this.GetVendorNamesFromPatnerCreation() });

        }

        [HttpGet("vpayments/cutomernames")]
        public async Task<IActionResult> GetCustomerNames()
        {
           
            return Json(new{ purchase= this.GetCutomerNamesFromPatnerCreation() });

        }

        [HttpGet("vpayments/billsrcvl")]
        public async Task<IActionResult> GetCustomerNamesFromPurchase()
        {
            try
            {
                var list = new VendorPaymentHelper(_unitOfWork).GetVendorNames().Select(x => new { key = x.GoodsReceiptNo, value = x.VendorName });

                return Json(new { purchase = list });
            }
            catch
            {
                return BadRequest("Data Load Failed");
            }
            

        }

        [HttpGet("vpayments/billsrcvl/{goodsReceiptNo}")]
        public async Task<IActionResult> GetCustomerNamesFromPurchase(string goodsReceiptNo)
        {
            try
            {
                if (goodsReceiptNo != null)
                    return Ok(new VendorPaymentHelper(_unitOfWork).GetPurchaseRecordsByPurchaseCode(goodsReceiptNo));
            }
            catch { }

            return BadRequest("purchase code can not be null");
        }



        private Array GetCutomerNamesFromPatnerCreation()
        {
            return (from pc in _unitOfWork.PartnerCreation.GetAll()
                     join ptype in _unitOfWork.PartnerType.GetAll()
                     on pc.Partnertype equals ptype.Code
                      where ptype.AccountType == AccountType.TRADECUSTOMER.ToString()
                      select new { key = pc.Code, value = pc.Name }).ToArray();

        }

         private Array GetVendorNamesFromPatnerCreation()
        {
            return (from pc in _unitOfWork.PartnerCreation.GetAll()
                     join ptype in _unitOfWork.PartnerType.GetAll()
                     on pc.Partnertype equals ptype.Code
                     where ptype.AccountType == AccountType.TRADEVENDORS.ToString()
                      select new { key = pc.Code, value = pc.Name }).ToArray();

        }



        [HttpGet("vpayments/op")]
        public async Task<IActionResult> GetAll()
        {
            return Json(new
            {
               // op = _unitOfWork.Branches.GetAll(),
                companys = _unitOfWork.Companys.GetAll(),
                branches = _unitOfWork.Branches.GetAll(),
                //partnerCreationList = (from pc in _unitOfWork.PartnerCreation.GetAll()
                //                       where pc.Partnertype != null
                //                       select pc)
            });

        }


        [HttpPost("vpayments/op/register")]
        [Produces(typeof(VendorPayments))]
        public async Task<IActionResult> RegisterOp([FromBody]Balances balances)
        {

            if (balances == null)
                return BadRequest($"{nameof(balances)} cannot be null");
            try
            {
                var lastrecord = _unitOfWork.Balances.GetAll().OrderByDescending(x => x.Code).FirstOrDefault();
                if (lastrecord !=null)
                    balances.Code = (lastrecord.Code + 1);
                else
                    balances.Code = 1;

                lastrecord = null;

               

                _unitOfWork.Balances.Add(balances);

                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(balances);
                else
                    return BadRequest($"{nameof(balances)} Registration Failed");
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(balances)} Registration Failed");
            }
        }



        [HttpPut("vpayments/op/{code}")]
        [Produces(typeof(VendorPayments))]
        public async Task<IActionResult> UpdateOp(string code, [FromBody] Balances balances)
        {
            if (balances == null)
                return BadRequest($"{nameof(balances)} cannot be null");

           
            try
            {
                _unitOfWork.Balances.Update(balances);
                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(balances);
                else
                    return BadRequest($"{nameof(balances)} Updation Failed");
            }
            catch
            {
                return BadRequest($"{nameof(balances)} Updation Failed");
            }

        }


        // Delete Branch
        [HttpDelete("vpayments/op/{code}")]
        [Produces(typeof(VendorPayments))]
        public async Task<IActionResult> DeleteOp(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");
            try
            {
                var result = _unitOfWork.VendorPayments.GetAll().ToList();
                var _branch = (from b in result
                               where b.Code == code
                               select b).FirstOrDefault();
                _unitOfWork.VendorPayments.Remove(_branch);
                _unitOfWork.SaveChanges();
                return Ok(result);

            }
            catch
            {
                return BadRequest($"Delete Operation Failed");
            }

        }

    }
}
