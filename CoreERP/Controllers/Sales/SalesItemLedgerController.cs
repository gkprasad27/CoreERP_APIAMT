using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers.Purchase
{
    [Authorize]
    [Route("api/[controller]")]
    public class SalesItemLedgerController : Controller
    {
/*
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;



        public SalesItemLedgerController(IUnitOfWork unitOfWork, ILogger<CardTypeController> logger, IEmailer emailer)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }


        [HttpGet("SalesItemLedger")]
        public async Task<IActionResult> GetPurchaseRecordsByParams()
        {
            return Json(
                new {
                    companys = _unitOfWork.Companys.GetAll(),
                    branches = _unitOfWork.Branches.GetAll(),
                    models = (from md in _unitOfWork.BrandModel.GetAll()
                              join bill in _unitOfWork.Billing.GetAll()
                               on md.Code equals bill.Model
                              select md).Distinct(),
                    itemmaster = _unitOfWork.ItemMaster.GetAll(),
                    brandList = (from  brd in _unitOfWork.Brand.GetAll()
                                 join bill in _unitOfWork.Billing.GetAll()
                                 on brd.Code equals bill.BrandCode
                                 select brd).Distinct(),
                   materialTranstp = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                                       where mattran.TransactionType.ToUpper() == MaterialTransactionType.SALE.ToString()
                                      select mattran),
                });
        }

        [HttpPost("SalesItemLedger/getrecords")]
        public async Task<IActionResult> GetPurchaseRecordsByParams([FromBody] ReportSearchCriteria reportSearchCriteria)
        {


            if (reportSearchCriteria != null)
            {
                try
                {

                    if (reportSearchCriteria.FromDate == null)
                        reportSearchCriteria.FromDate = DateTime.Today;

                    if (reportSearchCriteria.ToDate == null)
                        reportSearchCriteria.ToDate = DateTime.Today;


                    var result = (from bill in _unitOfWork.Billing.GetAll().ToArray()
                                  where Convert.ToDateTime(bill.AddDate.ToShortDateString()) >= Convert.ToDateTime(reportSearchCriteria.FromDate.ToShortDateString())
                                  && Convert.ToDateTime(bill.AddDate.ToShortDateString()) <= Convert.ToDateTime(reportSearchCriteria.ToDate.ToShortDateString())
                                  select bill).ToArray();

                    if (reportSearchCriteria.Company != null)
                    {
                        if (reportSearchCriteria.Company.ToUpper() != "ALL")
                            result = result.Where(b => b.CompCode == reportSearchCriteria.Company).ToArray();

                    }
                    if (reportSearchCriteria.Branch != null)
                    {

                        if (reportSearchCriteria.Branch.ToUpper() != "ALL")
                            result = result.Where(b => b.BranchCode == reportSearchCriteria.Branch).ToArray();

                    }
                    if (reportSearchCriteria.Model != null)
                    {
                        if (reportSearchCriteria.Model.ToUpper() != "ALL")
                            result = result.Where(b => b.Model == reportSearchCriteria.Model).ToArray();

                    }
                    if (reportSearchCriteria.Brand != null)
                    {
                        if (reportSearchCriteria.Brand.ToUpper() != "ALL")
                            result = result.Where(b => b.BrandCode == reportSearchCriteria.Brand).ToArray();
                    }


                    if (result != null)
                    {
                        result = (from r in result orderby r.BillDate ascending select r).ToArray();
                        return Ok(result);
                    }
                    else
                        return NoContent();
                }
               
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            return BadRequest();
        }


    */

    }
}