using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.Helpers;
using DAL;
using DAL.Models.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.Purchase
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OpeningBalanceController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;



        public OpeningBalanceController(IUnitOfWork unitOfWork, ILogger<CardTypeController> logger, IEmailer emailer)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        // GET: api/OpeningBalance/5
        [HttpGet("op")]
        public async Task<IActionResult> GetOp()
        {
            //IList<Balances> balances = null;

            //_unitOfWork.Balances.RemoveRange(_unitOfWork.Balances.GetAll());
            //_unitOfWork.SaveChanges();

            return Json(
                new
                {
                    op =  _unitOfWork.Balances.GetAll(),
                    companyList = _unitOfWork.Companys.GetAll(),
                    branchList = _unitOfWork.Branches.GetAll()
                    //pt = _unitOfWork.PartnerType.GetAll()
                });

        }

       
        [HttpGet("PT/{accountType}")]
        public async Task<IActionResult> GetPT(string accountType)
        {
            return Json(new {
                pt=(from ptype in _unitOfWork.PartnerType.GetAll()
                     join pc in _unitOfWork.PartnerCreation.GetAll()
                     on ptype.Code equals pc.Partnertype
                   where ptype.AccountType == accountType
                   select pc).ToArray()});
        }

       
        [HttpPost("op/register")]
        public async Task<IActionResult> RegisterOpeningBalance([FromBody]Balances balances)
        {
            if (balances == null)
                return BadRequest("Registration  Failed");

            try
            {
                var balanceEntity = _unitOfWork.Balances.GetAll().OrderByDescending(b => b.Code).FirstOrDefault();
                if (balanceEntity == null)
                    balances.Code = 101;
                else
                    balances.Code = balanceEntity.Code + 1;

                _unitOfWork.Balances.Add(balances);
                _unitOfWork.SaveChanges();

                return Ok(balances);
            }
            catch
            {
                return BadRequest("Registration Failed");
            }
        }
        
        
        [HttpPut("op")]
        public async Task<IActionResult> UpdateOpeningBalance([FromBody]Balances balances)
        {
            if (balances == null)
                return BadRequest("Updation Failed");

            try
            {
                _unitOfWork.Balances.Update(balances);
                _unitOfWork.SaveChanges();
                return Ok(balances);
            }
            catch
            {
                return BadRequest("Updation Failed");
            }
        }
        
        
        [HttpDelete("{id}")]
        [Produces(typeof(string))]
        public async Task<IActionResult> RempveOpeningBalaceEntity(int id)
        {
           
            try
            {
                _unitOfWork.Balances.Update(_unitOfWork.Balances.Get(id));
                _unitOfWork.SaveChanges();
                return Ok(id);
            }
            catch
            {
                return BadRequest("Updation Failed");
            }
        }
    }
}
