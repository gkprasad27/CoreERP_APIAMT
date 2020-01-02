using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Models;

namespace CoreERP.Controllers
{

    [Route("api/AsnBillsRcvBranch")]
    public class AsnBillsRcvBranchController : Controller
    {

        [HttpGet("sales/recivablebranch")]
        public async Task<IActionResult> GetAsnBillsRcvBranchList()
        {
            return Ok(new { asnbillsrcvbranch = AsnBillsRcvBranchHelper.GetAsnBillsRcvBranchList()});
           
            //accounts = (from account in ( from glacc in _unitOfWork.GLAccounts.GetAll() where glacc.Nactureofaccount !=null select glacc)
            //            where account.Nactureofaccount.ToUpper() == "BILLSRECEIVABLES"
            //            select account).ToList(),
            // branches=_unitOfWork.Branches.GetAll()
        }

        [HttpGet("sales/recivablebranch/GetGLBillRcvAccList")]
        public async Task<IActionResult> GetGLBillReceivableAccountsList()
        {
            return Ok(new { accounts = AsnBillsRcvBranchHelper.GetGLBillReceivableAccountsList() });
        }

        [HttpGet("sales/recivablebranch/GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            return Ok(new { branches = AsnBillsRcvBranchHelper.GetBranchesList() });
        }

        [HttpPost("sales/recivablebranch/register")]
        public async Task<IActionResult> Register([FromBody]AsnBillsRcvBranch asnbillsrcvbranch)
        {
           
            if (asnbillsrcvbranch == null)
                return BadRequest($"Request object cannot be null");
            try
            {
                var response = AsnBillsRcvBranchHelper.RegisterAsnBillsRcvBranch(asnbillsrcvbranch);
                if (response != null)
                    return Ok(response);

                return BadRequest("Registration Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Registration Failed");
            }
        }

        [HttpPut("sales/recivablebranch/UpdateAsnBillsRcvBranch")]
        public async Task<IActionResult> Update([FromBody] AsnBillsRcvBranch asnbillsrcvbranch)
        {
            if (asnbillsrcvbranch == null)
                return BadRequest("Request object cannot be null");

            try
            {
                var respone = AsnBillsRcvBranchHelper.UpdateAsnBillsRcvBranch(asnbillsrcvbranch);
                if (respone != null)
                    return Ok(respone);

                return BadRequest("Updation Failed");
            }
            catch (Exception ex)
            {
                return BadRequest("Updation Failed");
            }
        }


       
        [HttpPut("sales/recivablebranch/DeleteAsnBillsRcvBranch")]
        public async Task<IActionResult> DeleteAsnBillsRcvBranch([FromBody]AsnBillsRcvBranch asnBillsRcvBranch)
        {
            if (asnBillsRcvBranch == null)
                return BadRequest("Request object can not be null");

            try
            {
                asnBillsRcvBranch.Active = "N";
                var response = AsnBillsRcvBranchHelper.UpdateAsnBillsRcvBranch(asnBillsRcvBranch);
                if(response !=null)
                return Ok(response);

                return BadRequest("Delete Operation Failed");
            }
            catch(Exception ex)
            {
                return BadRequest("Delete Operation Failed");
            }
            
        }
    }
}