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

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;
        readonly IEmailer _emailer;

        public InventoryController(IUnitOfWork unitOfWork, ILogger<CardTypeController> logger, IEmailer emailer)
        {

            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailer = emailer;
        }

        [HttpGet("inventory")]
        public  IActionResult GetAllMasterData()
        {

            return Json(new {
                inventory = _unitOfWork.Inventory.GetAll(),
                companys = _unitOfWork.Companys.GetAll(),
                branches = _unitOfWork.Branches.GetAll(),
                accounts = _unitOfWork.GLAccounts.GetAll(),
                subaccounts = _unitOfWork.GLSubAccounts.GetAll()
            });

        }


        [HttpPost("inventory/register")]
        [Produces(typeof(Inventory))]
        public async Task<IActionResult> Register([FromBody]Inventory inventoryObj)
        {
            if (inventoryObj == null)
                return BadRequest($"{nameof(inventoryObj)} cannot be null");
           try
            {
                var lastrecord=_unitOfWork.VendorPayments.GetAll().OrderByDescending(x => x.Code).FirstOrDefault();
                if (lastrecord != null)
                    inventoryObj.Code = (Convert.ToInt32(inventoryObj.Code) + 1).ToString();
                else
                    inventoryObj.Code = "1";

                lastrecord = null;

                _unitOfWork.Inventory.Add(inventoryObj);

                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(inventoryObj);
                else  // otherwise return Bad Request
                    return BadRequest($"{nameof(inventoryObj)} Registration Failed");
            }
            catch(Exception ex)
            {
                return BadRequest($"{nameof(inventoryObj)} Registration Failed");
            }
        }



        [HttpPut("inventory/{code}")]
        [Produces(typeof(Inventory))]
        public async Task<IActionResult> UpdateBrach(string code, [FromBody] Inventory inventoryObj)
        {
            if (inventoryObj == null)
                return BadRequest($"{nameof(inventoryObj)} cannot be null");

            if (!string.IsNullOrWhiteSpace(inventoryObj.Code) && code != inventoryObj.Code)
                return BadRequest("Conflicting role id in parameter and model data");
            try
            {
                _unitOfWork.Inventory.Update(inventoryObj);
                if (_unitOfWork.SaveChanges() > 0)
                    return Ok(inventoryObj);
                else
                    return BadRequest($"{nameof(inventoryObj)} Updation Failed");
            }
            catch
            {
                return BadRequest($"{nameof(inventoryObj)} Updation Failed");
            }

        }


        // Delete 
        [HttpDelete("inventory/{code}")]
        [Produces(typeof(Inventory))]
        public async Task<IActionResult> Delete(string code)
        {
            if (code == null)
                return BadRequest($"{nameof(code)}can not be null");
            try
            {
                var result = _unitOfWork.Inventory.GetAll().ToList();
                var _inventory = (from b in result
                               where b.Code == code
                               select b).FirstOrDefault();
                _unitOfWork.Inventory.Remove(_inventory);
                _unitOfWork.SaveChanges();
                return Ok(_inventory);

            }
            catch
            {
                return BadRequest($"Delete Operation Failed");
            }
            
        }
    }
}