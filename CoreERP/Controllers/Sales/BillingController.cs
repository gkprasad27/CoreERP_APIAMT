﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BillingController : Controller
    {
     /*
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

      

        public BillingController(IUnitOfWork unitOfWork, ILogger<CardTypeController> logger, IEmailer emailer)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        [HttpGet("sales/billing")]
        public async Task<IActionResult> GetAllMasterData()
        {
            return Json(new {
                billings = _unitOfWork.Billing.GetAll(),
                companys = _unitOfWork.Companys.GetAll(),
               // companys =CompanyHelper.GetDistinctCompanyNames(this._unitOfWork),
                branches = _unitOfWork.Branches.GetAll(),
                employees = (from emp in _unitOfWork.Employees.GetAll()
                             join asiembranch in _unitOfWork.EmployeeInBrancs.GetAll()
                             on emp.Code equals asiembranch.EmpCode
                             select emp),
                empInBranch = _unitOfWork.EmployeeInBrancs.GetAll(),
                materialtrantype = (from mattranstype in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                                    where mattranstype.TransactionType.ToUpper() == MaterialTransationType.SALE.ToString() 
                                    select mattranstype),
                cardtype = (from cardtyp in _unitOfWork.CardType.GetAll() select cardtyp),
                glaccount = (from glacc in _unitOfWork.GLAccounts.GetAll() select new { key = glacc.GLCode, value = glacc.Description }),
                cashAcctobranchAccounts = (from asiacc in _unitOfWork.AsignmentCashAccBranch.GetAll() select new { key = asiacc.CashGLAcc, value = asiacc.CashGLAcc }),
                billsRcvBranchList = (from brcv in _unitOfWork.Asn_Bills_Rcv_Branch.GetAll() select new { key = brcv.GLAccount, value = brcv.GLAccount }),
                billingNoseries = (from billnosers in _unitOfWork.BillingNoSeries.GetAll()
                                   where billnosers.NumberSeries != null
                                   select billnosers),
                taxMaster = (from taxm in _unitOfWork.TaxMasters.GetAll()
                             where taxm.TaxType == "OUTPUT"
                             where taxm != null select taxm),
                models = (from mdl in _unitOfWork.BrandModel.GetAll()
                          select mdl),
                taxintg = (from taxi in _unitOfWork.TaxIntegration.GetAll() select taxi),
                financeAcc = (from acct in _unitOfWork.GLAccounts.GetAll().Where(x => x.Nactureofaccount != null)
                              where acct.Nactureofaccount.ToUpper() ==NatureOfAccounts.FINANCECUSTOMER.ToString() 
                              select acct),
                brandList = (from br in _unitOfWork.Brand.GetAll()
                             select br).Distinct(),
                salesreturnlist = _unitOfWork.BillingReturns.GetAll().Where(x => x.BillDate != null),
                branchCode = CoreERPSettings.ERPSETUP.BranchCode
                          
            }); 

        }

         [HttpGet("sales/billingReturn")]
        public async Task<IActionResult> GetAllMasterDataOfSalesReturn()
        {
            return Json(new {
                billings = _unitOfWork.Billing.GetAll(),
                companys = _unitOfWork.Companys.GetAll(),
                branches = _unitOfWork.Branches.GetAll(),
                employees = (from emp in _unitOfWork.Employees.GetAll()
                             join asiembranch in _unitOfWork.EmployeeInBrancs.GetAll()
                             on emp.Code equals asiembranch.EmpCode
                             select emp),
                empInBranch = _unitOfWork.EmployeeInBrancs.GetAll(),
                materialtrantype = (from mattranstype in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                                    where mattranstype.TransactionType.ToUpper() == MaterialTransationType.SALERETURN.ToString() 
                                    select mattranstype),
                cardtype = (from cardtyp in _unitOfWork.CardType.GetAll() select cardtyp),
                glaccount = (from glacc in _unitOfWork.GLAccounts.GetAll() select new { key = glacc.GLCode, value = glacc.Description }),
                cashAcctobranchAccounts = (from asiacc in _unitOfWork.AsignmentCashAccBranch.GetAll() select new { key = asiacc.CashGLAcc, value = asiacc.CashGLAcc }),
                billsRcvBranchList = (from brcv in _unitOfWork.Asn_Bills_Rcv_Branch.GetAll() select new { key = brcv.GLAccount, value = brcv.GLAccount }),
                billingNoseries = (from billnosers in _unitOfWork.BillingNoSeries.GetAll()
                                   where billnosers.NumberSeries != null
                                   select billnosers),
                taxMaster = (from taxm in _unitOfWork.TaxMasters.GetAll()
                             where taxm.TaxType == "OUTPUT"
                             where taxm != null select taxm),
                models = (from mdl in _unitOfWork.BrandModel.GetAll()
                          select mdl),
                taxintg = (from taxi in _unitOfWork.TaxIntegration.GetAll() select taxi),
                financeAcc = (from acct in _unitOfWork.GLAccounts.GetAll().Where(x => x.Nactureofaccount != null)
                              where acct.Nactureofaccount.ToUpper() ==NatureOfAccounts.FINANCECUSTOMER.ToString() 
                              select acct),
                brandList = (from br in _unitOfWork.Brand.GetAll()
                             select br).Distinct(),
                salesreturnlist = _unitOfWork.BillingReturns.GetAll().Where(x => x.BillDate != null),
                branchCode = "SMG" }); 

        }


        [HttpGet("sales/billing/{billno}")]  
        public async Task<IActionResult> GetAllMasterData(string billno)
        {
          

            return Json(new
            {
                billings = _unitOfWork.Billing.GetAll().Where(x=>x.BillNo == billno)
               

            });

        }


        [HttpPost("sales/billing/salesreturn/register")]
        [Produces(typeof(List<BillingReturns>))]
        public async Task<IActionResult> Register([FromBody]BillingReturns[] billingreturns)
        {

            if (billingreturns == null)
                return BadRequest($"{nameof(billingreturns)} cannot be null");
            try
            {
                if (billingreturns.Length > 0)
                {
                    for (int i = 0; i < billingreturns.Count(); i++)
                        billingreturns[i].AddDate = System.DateTime.Now;

                    for (int i = 0; i < billingreturns.Count(); i++)
                    {
                        _unitOfWork.BillingReturns.Add(billingreturns[i]);
                        _unitOfWork.SaveChanges();
                    }
                    return Ok(billingreturns);
                }
                else
                    return BadRequest($"Record Not Selected To Return");
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(billingreturns)} Registration Failed");
            }
        }


        [HttpPost("sales/billing/register")]
        [Produces(typeof(List<Billing>))]
        public async Task<IActionResult> Register([FromBody]Billing[] billing)//
        {
           
            if (billing == null)
                return BadRequest($"{nameof(billing)} cannot be null");
           try
            {
                var billCodesLIst = _unitOfWork.Billing.GetAll().Select(x => Convert.ToInt32(x.Code)).ToArray();
                var lastreacord = billCodesLIst.OrderByDescending(x => x).FirstOrDefault();//_unitOfWork.Billing.GetAll().OrderByDescending(x => Convert.ToInt32(x.Code)).FirstOrDefault();
                if (lastreacord > 0)
                {
                 //   billing[0].Code = (int.Parse(lastreacord.Code) + 1).ToString();
                    billing[0].Code = (lastreacord + 1).ToString();
                    billing[0].AddDate = DateTime.Now;
                    billing[0].EditDate = DateTime.Now;
                }
                else
                {
                    billing[0].Code = "1";
                    billing[0].AddDate = DateTime.Now;
                    billing[0].EditDate = DateTime.Now;
                }

                for (int i = 1; i < billing.Count(); i++)
                {
                    billing[i].Code = (int.Parse(billing[i - 1].Code) + 1).ToString();
                    billing[i].AddDate = DateTime.Now;
                    billing[i].EditDate = DateTime.Now;

                }

                for (int i = 0; i < billing.Count(); i++)
                {
                    _unitOfWork.Billing.Add(billing[i]);
                    _unitOfWork.SaveChanges();
                }

                    //foreach(var bill in billing)
                    //    bill.BillDate =Convert.ToDateTime(bill.BillDate.ToString("dd/MM/yyyy"));
              return Ok(billing);
                
            }
            catch(Exception ex)
            {
                return BadRequest($"{nameof(billing)} Registration Failed");
            }
        }



        [HttpPut("sales/billing/{code}")]
        [Produces(typeof(Billing))]
        public async Task<IActionResult> Update(string code, [FromBody] Billing billing)
        {
            if (billing == null)
                return BadRequest($"{nameof(billing)} cannot be null");
           
            try
            {
                billing.EditDate = DateTime.Now;

                _unitOfWork.Billing.Update(billing);
                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(billing);
                else
                    return BadRequest($"{nameof(billing)} Updation Failed");
            }
            catch(Exception ex)
            {
                return BadRequest($"{nameof(billing)} Updation Failed");
            }
        }


       
        [HttpDelete("sales/billing/{code}")]
        [Produces(typeof(Billing))]
        public async Task<IActionResult> Delete(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var result = _unitOfWork.Billing.GetAll().SingleOrDefault(x=> x.Code == code);
                
                _unitOfWork.Billing.Remove(result);
                _unitOfWork.SaveChanges();
                return Ok(result);

            }
            catch(Exception ex)
            {
                return BadRequest($"Delete Operation Failed");
            }
            
        }



        [HttpGet("sales/billing/gstNo/{companyCode}/{stateName}")]
        [Produces(typeof(string))]
        public async Task<IActionResult> GetCompanyGSTNumber(string companyCode,string stateName)
        {
            if (stateName == null )
                return BadRequest($"stateName cannot be null");
            if (companyCode == null )
                return BadRequest($"companyCode cannot be null");

            return Json(new { gstNo = CompanyHelper.GetCompanyGSTNo(this._unitOfWork, companyCode, stateName) });
           
        }


        
        [HttpPut("sales/billing/cancelbill/{billno}")]
        [Produces(typeof(Billing))]
        public async Task<IActionResult> CancelBill(string billno)
        {
            if (billno == null)
                return BadRequest($"{nameof(billno)} cannot be null");

            try
            {
                var bill = _unitOfWork.Billing.GetAll().Where(x => x.BillNo == billno).FirstOrDefault();

                var billreturn = new BillingReturns();
                billreturn.Code = bill.Code;
                billreturn.BillNo = bill.BillNo;

                var chkExistance = _unitOfWork.BillingReturns.GetAll().Where(x=>x.Code == bill.Code).FirstOrDefault();
                if (chkExistance != null)
                    return BadRequest($"Bill No={billno}  Already  Cancell ");

                _unitOfWork.BillingReturns.Add(billreturn);
                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(billreturn);
                else
                    return BadRequest($"{nameof(billreturn)} registration Failed");
            }
            catch (Exception ex)
            {
                return BadRequest($"registration  Failed");
            }
        }


        [HttpGet("sales/billing/counter/{branchCode}")]
        public async Task<IActionResult> CounterTableValue(string branchCode)
        {
            try
            {
                var counterObj = _unitOfWork.Counter.GetAll().Where(c => c.Description == "BILLING" && c.BranchCode == branchCode).FirstOrDefault();

                if(counterObj != null)
                {
                    counterObj.NumberRange = counterObj.NumberRange + 1;
                    _unitOfWork.Counter.Update(counterObj);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    counterObj = new DAL.Models.Settings.Counter();

                    //find Max Code
                    var code = 0;
                    try { code=_unitOfWork.Counter.GetAll().Max(x => x.Code); } catch { }

                    counterObj.Code = code == 0 ? 1 : code+1;
                    counterObj.NumberRange = 101;
                    counterObj.BranchCode = branchCode;
                    counterObj.Description = "BILLING";

                    _unitOfWork.Counter.Add(counterObj);
                    _unitOfWork.SaveChanges();
                }


                return Ok(counterObj);
            }
            catch(Exception ex)
            {
                return NoContent();
            }
        }
        */
    }
}

