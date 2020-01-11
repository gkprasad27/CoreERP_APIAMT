using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BranchTransferController : Controller
    {
      /*  private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

      

        public BranchTransferController(IUnitOfWork unitOfWork, ILogger<CardTypeController> logger, IEmailer emailer)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        [HttpGet("sales/branchtransfer")]
        public async Task<IActionResult> GetAllMasterData()
        {
            try
            {                               
                var queryresult = ((from bill in _unitOfWork.Billing.GetAll()
                                    where bill.BillDate != null
                                      && bill.BranchCode== CoreERPSettings.ERPSETUP.BranchCode
                                    select bill))
                                   .Where(x => x.BillDate.Year == DateTime.Now.Year).ToArray();

               

                //var aa = (from itmmaster in _unitOfWork.ItemMaster.GetAll() where itmmaster.ItemNumber != 0 select itmmaster);

                //(from mattranstype in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                // where mattranstype.TransactionType.ToUpper() == "SALE"
                // select mattranstype).ToList();


            }
            catch(Exception ex) { }

            return Json(
                new
                {
                    branchTransfer = _unitOfWork.BranchTransfer.GetAll().Where(x => x.BranchCode == CoreERPSettings.ERPSETUP.BranchCode),
                    companys = _unitOfWork.Companys.GetAll(),
                    branches = _unitOfWork.Branches.GetAll(),
                    employees = (from emp in _unitOfWork.Employees.GetAll()
                                 join asiembranch in _unitOfWork.EmployeeInBrancs.GetAll()
                                 on emp.Code equals asiembranch.EmpCode
                                 select emp),
                    empInBranch = _unitOfWork.EmployeeInBrancs.GetAll(),
                    materialtrantype = (from mattranstype in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                                        where mattranstype.TransactionType.ToUpper() =="SALE"
                                        select mattranstype),
                    cardtype = (from cardtyp in _unitOfWork.CardType.GetAll() select cardtyp),
                    glaccount = (from glacc in _unitOfWork.GLAccounts.GetAll() select new { key = glacc.GLCode, value = glacc.Description }),
                    cashAcctobranchAccounts = (from asiacc in _unitOfWork.AsignmentCashAccBranch.GetAll() select new { key = asiacc.CashGLAcc, value = asiacc.CashGLAcc }),
                    billsRcvBranchList = (from brcv in _unitOfWork.Asn_Bills_Rcv_Branch.GetAll() select new { key = brcv.GLAccount, value = brcv.GLAccount }),
                    billingNoseries = (from billnosers in _unitOfWork.BillingNoSeries.GetAll()
                                       where billnosers.NumberSeries != null
                                       select billnosers),
                    itemMasterList = (from itmmaster in _unitOfWork.ItemMaster.GetAll() where itmmaster.ItemNumber != 0 select itmmaster),
                    taxMaster = (from taxm in _unitOfWork.TaxMasters.GetAll()
                                 join taxi in _unitOfWork.TaxIntegration.GetAll()
                                 on taxm.Code equals taxi.TaxCode
                                 where taxm.TaxType == "OUTPUT"
                                 where taxm != null
                                 select taxm),
                    models = (from mdl in _unitOfWork.BrandModel.GetAll()
                              join itemmast in _unitOfWork.ItemMaster.GetAll()
                              on mdl.Code equals itemmast.Model
                              select mdl),
                    taxintg = (from taxi in _unitOfWork.TaxIntegration.GetAll() select taxi),
                    financeAcc = (from acct in _unitOfWork.GLAccounts.GetAll().Where(x => x.Nactureofaccount != null)
                                  where acct.Nactureofaccount.ToUpper() == NatureOfAccounts.FINANCECUSTOMER.ToString() // "FINANCECUSTOMER"
                                  select acct),
                    brandList = (from br in _unitOfWork.Brand.GetAll()
                                 select br).Distinct(),
                    salesreturnlist = _unitOfWork.BillingReturns.GetAll().Where(x => x.BillDate != null),


                }); 

        }




        [HttpGet("sales/branchtransfer/{billno}")]
        public async Task<IActionResult> GetAllMasterData(string billno)
        {
          

            return Json(new
            {
                billings = _unitOfWork.BranchTransfer.GetAll().Where(x=>x.BillNo == billno )
               

            });

        }



        [HttpPost("sales/branchtransfer/register")]
        [Produces(typeof(List<BranchTransfer>))]
        public async Task<IActionResult> Register([FromBody]BranchTransfer[] branchTransfers)
        {
           
            if (branchTransfers == null)
                return BadRequest($"{nameof(branchTransfers)} cannot be null");
           try
            {
                var lastreacord = _unitOfWork.BranchTransfer.GetAll().OrderByDescending(x => x.Code).FirstOrDefault();
                if (lastreacord != null)
                {
                    branchTransfers[0].Code = (int.Parse(lastreacord.Code) + 1).ToString();
                    branchTransfers[0].AddDate = DateTime.Now;
                    branchTransfers[0].EditDate = DateTime.Now;
                }
                else
                {
                    branchTransfers[0].Code = "1";
                    branchTransfers[0].AddDate = DateTime.Now;
                    branchTransfers[0].EditDate = DateTime.Now;
                }

                for (int i = 1; i < branchTransfers.Count(); i++)
                {
                    branchTransfers[i].Code = (int.Parse(branchTransfers[i - 1].Code) + 1).ToString();
                    branchTransfers[i].AddDate = DateTime.Now;
                    branchTransfers[i].EditDate = DateTime.Now;
                }
                _unitOfWork.BranchTransfer.AddRange(branchTransfers);

                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(branchTransfers);
                else  
                    return BadRequest($"{nameof(branchTransfers)} Registration Failed");
            }
            catch(Exception ex)
            {
                return BadRequest($"{nameof(branchTransfers)} Registration Failed");
            }
        }



        [HttpPut("sales/branchtransfer/{code}")]
        [Produces(typeof(BranchTransfer))]
        public async Task<IActionResult> Update(string code, [FromBody] BranchTransfer billing)
        {
            if (billing == null)
                return BadRequest($"{nameof(billing)} cannot be null");
           
            try
            {
                _unitOfWork.BranchTransfer.Update(billing);
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


       
        [HttpDelete("sales/branchtransfer/{code}")]
        [Produces(typeof(BranchTransfer))]
        public async Task<IActionResult> Delete(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");

            try
            {
                var result = _unitOfWork.BranchTransfer.GetAll().SingleOrDefault(x=> x.Code == code);
                
                _unitOfWork.BranchTransfer.Remove(result);
                _unitOfWork.SaveChanges();
                return Ok(result);

            }
            catch(Exception ex)
            {
                return BadRequest($"Delete Operation Failed");
            }
            
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


        #region Branch Confirmation

        [HttpGet("sales/branchConfirmation")]
        public async Task<IActionResult> GetAllMasterDataForBranchConfirmation()
        {
            try
            {
                return Json(new
                {
                    branchTransfer = _unitOfWork.BranchTransfer.GetAll().Where(b => b.Ext7 != "1" && b.BranchCode == CoreERPSettings.ERPSETUP.BranchCode).ToArray(),
                    confirmRecords = _unitOfWork.BranchTransfer.GetAll().Where(b => b.Ext7 == "1" && b.BranchCode == CoreERPSettings.ERPSETUP.BranchCode).ToArray(),
                    branches = _unitOfWork.Branches.GetAll(),
                });
            }
            catch
            {
                return NoContent();
            }

        }


        [HttpPost("sales/branchConfirmation/update")]
        public async Task<IActionResult> updateBranchTransferFromBranchConfirm([FromBody]BranchTransfer[] branchTransfers)
        {

            if(branchTransfers.Count() ==0)
                return BadRequest("No Records To confirm");

            if (branchTransfers == null)
                return BadRequest("request cannot be null");
            try
            {
                _unitOfWork.BranchTransfer.UpdateRange(branchTransfers);
                _unitOfWork.SaveChanges();
                return Ok(branchTransfers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }

        }

       
        #endregion
        */
    }
}
