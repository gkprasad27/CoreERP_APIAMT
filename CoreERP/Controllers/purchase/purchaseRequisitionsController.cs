using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.Helpers;
using DAL;
using DAL.Enums;
using DAL.Models.Masters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.Purchase
{
    [Authorize]
    [Route("api/[controller]")]
    public class purchaseRequisitionsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;



        public purchaseRequisitionsController(IUnitOfWork unitOfWork, ILogger<CardTypeController> logger, IEmailer emailer)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }
      

        [HttpGet("pr")]
        public async Task<IActionResult> GetPurchaseRequisition()
        {


            return Json(
            new
            {
                companys = _unitOfWork.Companys.GetAll(),
                branches = _unitOfWork.Branches.GetAll(),
                brandList = _unitOfWork.Brand.GetAll(),
                purchaseRequisition = (from pr in _unitOfWork.PurchaseRequisitions.GetAll().ToArray()
                                       where pr.Status != ((int)PURCHASEREQUISITION.APPROVED).ToString()
                                          && pr.Status != ((int)PURCHASEREQUISITION.REJECTED).ToString()
                                       select pr),
                materialTranstp = (from mattran in _unitOfWork.Mat_Tran_Types.GetAll().Where(x => x.TransactionType != null)
                                   where mattran.TransactionType.ToUpper() == MaterialTransationType.PURCHASEREQUISITION.ToString()
                                   select mattran),
                models = _unitOfWork.BrandModel.GetAll(),
            });
        }

      
        [HttpPost("pr")]
        public async Task<IActionResult> Post([FromBody]PurchaseRequisition[] purchaseRequisition)
        {
            if (purchaseRequisition == null)
                return BadRequest("Object is NUll");

            try
            {

                if (purchaseRequisition.Length > 0)
                {
                    IList<Int32> code = _unitOfWork.PurchaseRequisitions.GetAll().OrderByDescending(x => x.Code != null).Select(p => Convert.ToInt32(p.Code)).ToArray();
                    var lastcode = code.OrderByDescending(x => x).FirstOrDefault();

                    if (lastcode > 0)
                        purchaseRequisition[0].Code = (lastcode + 1).ToString();
                    else
                        purchaseRequisition[0].Code = "1";

                    purchaseRequisition[0].AddDate = DateTime.Now;
                    purchaseRequisition[0].EditDate = DateTime.Now;

                    code = null;

                    for (int i = 1; i < purchaseRequisition.Count(); i++)
                    {
                        purchaseRequisition[i].Code = (Convert.ToInt32(purchaseRequisition[i - 1].Code) + 1).ToString();
                        purchaseRequisition[i].AddDate = DateTime.Now;
                        purchaseRequisition[i].EditDate = DateTime.Now;
                    }


                    _unitOfWork.PurchaseRequisitions.AddRange(purchaseRequisition);
                    _unitOfWork.SaveChanges();

                    return Ok(purchaseRequisition);
                }

            }
            catch (Exception ex) { }

          return BadRequest($"Registration Failed");
        }
        
        
        //[HttpPost("purchaserequiaproval")]
        //public async Task<IActionResult> GetPurchaseRequisitionByAuthorize([FromBody]bool isRecommandedRequest)
        //{
        //    IList<PurchaseRequisition> prlist = (from pr in _unitOfWork.PurchaseRequisitions.GetAll().ToArray()
        //                                         where pr.Status != ((int)PURCHASEREQUISITION.APPROVED).ToString()
        //                                            && pr.Status != ((int)PURCHASEREQUISITION.REJECTED).ToString()
        //                                         select pr).ToArray();
        //    return Json(new {
        //        purchaseRequisition=(from pr in _unitOfWork.PurchaseRequisitions.GetAll().ToArray()
        //                            where pr.Status != ((int)PURCHASEREQUISITION.APPROVED).ToString()
        //                               && pr.Status != ((int)PURCHASEREQUISITION.REJECTED).ToString()
        //                            select pr)});
        //}



        [HttpGet("pr/approvalstatges/{screenName}")]
        public async Task<IActionResult> CheckStagesOfAprrovalForScreen(string screenName)
        {
            if (screenName == null)
                return BadRequest("");
            try
            {
                var obj = _unitOfWork.ApprovalType.GetAll().Where(x => System.Text.RegularExpressions.Regex.Replace(x.ApprovalScreen.ToUpper(), @"\s+", "") == System.Text.RegularExpressions.Regex.Replace(screenName.ToUpper(), @"\s+", "")).FirstOrDefault();
                    return Ok(obj);

            }
            catch { }

            return BadRequest("");
        }


      


        [HttpGet("pr/listforapproval/{roleName}")]
        public async Task<IActionResult> GetPurchaseRequiaitionListForApproval(string roleName)
        {
            try
            {
                return Ok(_unitOfWork.PurchaseRequisitions.GetAll()
                    .Where(x=> 
                       x.Status != ((int)PURCHASEREQUISITION.APPROVED).ToString() 
                    && x.Status != ((int)PURCHASEREQUISITION.REJECTED).ToString()
                    && x.RecommendedBy == roleName)
                    );
            }
            catch { }

            return NoContent();
        }


        [HttpPost("pr/approval")] 
        public async Task<IActionResult> UpdateAprovalStatus([FromBody]PurchaseRequisition[] purchaseRequisitions)
        {
            if(purchaseRequisitions!=null)
                if(purchaseRequisitions.Length > 0)
                {
                    try
                    {
                        _unitOfWork.PurchaseRequisitions.UpdateRange(purchaseRequisitions);
                        _unitOfWork.SaveChanges();

                        return Ok(purchaseRequisitions);
                    }catch(Exception ex)
                    {

                    }
                }

            return BadRequest("");
        }
    }
}
