using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreERP.BussinessLogic.SalesHelper;
using CoreERP.Models;
using System.Dynamic;
using CoreERP.DataAccess;

namespace CoreERP.Controllers
{
    [ApiController]
    [Route("api/sales/AsnBillsRcvBranch")]
    public class AsnBillsRcvBranchController : ControllerBase
    {

        [HttpGet("GetAsnBillsRcvBranchList")]
        public async Task<IActionResult> GetAsnBillsRcvBranchList()
        {
            try
            {
                dynamic expanddo = new ExpandoObject();
                expanddo.asnbillsrcvbranch = AsnBillsRcvBranchHelper.GetAsnBillsRcvBranchList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expanddo });
            }
            catch(Exception ex){ }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to Load Asn Bill Receivable Branches." });

        }

        [HttpGet("GetGLBillReceivableAccountsList")]
        public async Task<IActionResult> GetGLBillReceivableAccountsList()
        {
            try
            {
                dynamic expanddo = new ExpandoObject();
                expanddo.accounts = AsnBillsRcvBranchHelper.GetGLBillReceivableAccountsList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expanddo });
            }
            catch (Exception ex) { }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to Load Asn Bill Receivable GL Accounts." });
        }

        [HttpGet("GetBranchesList")]
        public async Task<IActionResult> GetBranchesList()
        {
            try
            {
                dynamic expanddo = new ExpandoObject();
                expanddo.branches = AsnBillsRcvBranchHelper.GetBranchesList();
                return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expanddo });
            }
            catch (Exception ex) { }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to Load Branches." });
        }

        [HttpPost("RegisterAsnBillsRcvBranch")]
        public async Task<IActionResult> RegisterAsnBillsRcvBranch([FromBody]AsnBillsRcvBranch asnbillsrcvbranch)
        {
           
            if (asnbillsrcvbranch == null)
                return BadRequest($"Request object cannot be null");
            try
            {
                var response = AsnBillsRcvBranchHelper.RegisterAsnBillsRcvBranch(asnbillsrcvbranch);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch (Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
        }

        [HttpPut("UpdateAsnBillsRcvBranch")]
        public async Task<IActionResult> UpdateAsnBillsRcvBranch([FromBody] AsnBillsRcvBranch asnbillsrcvbranch)
        {
            if (asnbillsrcvbranch == null)
                return BadRequest("Request object cannot be null");

            try
            {
                var response = AsnBillsRcvBranchHelper.UpdateAsnBillsRcvBranch(asnbillsrcvbranch);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });
            }
            catch (Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
        }

        [HttpDelete("DeleteAsnBillsRcvBranch/{code}")]
        public async Task<IActionResult> DeleteAsnBillsRcvBranch(string code)
        {
            if (code == null)
                return BadRequest("Request object can not be null");

            try
            {
                var asnBiLLRCvobject = AsnBillsRcvBranchHelper.GetAsnBillsRcvBranchList(code);
                asnBiLLRCvobject.Active = "N";
                var response = AsnBillsRcvBranchHelper.UpdateAsnBillsRcvBranch(asnBiLLRCvobject);
                if (response != null)
                    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });

            }
            catch (Exception ex)
            {
            }
            return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Delete Operation Failed." });
        }
    }
}