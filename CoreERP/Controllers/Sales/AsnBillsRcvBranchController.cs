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

        //[HttpGet("GetAsnBillsRcvBranchList")]
        //public IActionResult GetAsnBillsRcvBranchList()
        //{
        //    try
        //    {
        //        dynamic expanddo = new ExpandoObject();
        //        expanddo.asnbillsrcvbranch = AsnBillsRcvBranchHelper.GetAsnBillsRcvBranchList();
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expanddo });
        //    }
        //    catch (Exception ) { }
        //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Failed to Load Asn Bill Receivable Branches." });

        //}

        //[HttpGet("GetGLBillReceivableAccountsList")]
        //public IActionResult GetGLBillReceivableAccountsList()
        //{
        //    try
        //    {
        //        dynamic expanddo = new ExpandoObject();
        //        expanddo.accountsList = AsnBillsRcvBranchHelper.GetGLBillReceivableAccountsList().Select(x => new { ID = x.Glcode, Text = x.GlaccountName });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expanddo });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }

        //}

        //[HttpGet("GetBranchesList")]
        //public IActionResult GetBranchesList()
        //{
        //    try
        //    {
        //        dynamic expanddo = new ExpandoObject();
        //        expanddo.branchesList = AsnBillsRcvBranchHelper.GetBranchesList().Select(x => new { ID = x.BranchCode, Text = x.BranchName });
        //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expanddo });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }

        //}

        //[HttpPost("RegisterAsnBillsRcvBranch")]
        //public IActionResult RegisterAsnBillsRcvBranch([FromBody]AsnBillsRcvBranch asnbillsrcvbranch)
        //{

        //    if (asnbillsrcvbranch == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request object cannot be null" });
        //    try
        //    {
        //        var response = AsnBillsRcvBranchHelper.RegisterAsnBillsRcvBranch(asnbillsrcvbranch);
        //        if (response != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration Failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }

        //}

        //[HttpPut("UpdateAsnBillsRcvBranch")]
        //public IActionResult UpdateAsnBillsRcvBranch([FromBody] AsnBillsRcvBranch asnbillsrcvbranch)
        //{
        //    if (asnbillsrcvbranch == null)
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Request object cannot be null" });

        //    try
        //    {
        //        var response = AsnBillsRcvBranchHelper.UpdateAsnBillsRcvBranch(asnbillsrcvbranch);
        //        if (response != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Updation Failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}

        //[HttpDelete("DeleteAsnBillsRcvBranch/{code}")]
        //public IActionResult DeleteAsnBillsRcvBranch(string code)
        //{
        //    if (code == null)
        //        return BadRequest("Request object can not be null");

        //    try
        //    {

        //        var response = AsnBillsRcvBranchHelper.DelteAsnBillsRcvBranch(code);
        //        if (response != null)
        //            return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = response });

        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Deletion Failed." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
        //    }
        //}
    }
}