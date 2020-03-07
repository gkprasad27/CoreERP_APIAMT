using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CoreERP.BussinessLogic.GenerlLedger;
using CoreERP.BussinessLogic.SelfserviceHelpers;
using CoreERP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace CoreERP.Controllers.Selfservice
{
  [ApiController]
  [Route("api/Selfservice/LeaveApproval")]
  public class LeaveApprovalController : ControllerBase
  {
   // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconstr"].ToString());
    //[HttpGet("GetLeaveApplDetailsList")]
    //public async Task<IActionResult> GetLeaveApplDetailsList()
    //{
    //  try
    //  {
    //    dynamic expando = new ExpandoObject();
    //    expando.LeaveApplDetailsList = LeaveApprovalHelper.GetLeaveApplDetailsList().ToList();
    //    return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = expando });
    //  }
    //  catch (Exception ex)
    //  {
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //  }
    //}

    //[HttpPost("RegisterLeaveApprovalDetails")]
    //public async Task<IActionResult> RegisterLeaveApprovalDetails(List<LeaveApplDetails> leaveAprovalA)
    //{
    //  if (leaveAprovalA == null)
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Requst can not be empty." });
    //  try
    //  {
    //    string ApproveStatus = null;
    //    foreach (var item in leaveAprovalA)
    //    {
    //      var leaveapro = LeaveApprovalHelper.GetLeaveApplDetailsList().Where(x => x.Sno == item.Sno).FirstOrDefault();
    //      if (item.chkAcceptReject == "Yes")
    //      {
    //        if (leaveapro.RecommendedId != null && leaveapro.Status == "Applied" && leaveapro.RecommendedId != "")
    //        {
    //          leaveapro.Status = "Partially Approved";
    //          //LeaveApplDetails result = LeaveApprovalHelper.RegisterLeaveApprovalDetails(item);
    //          //if (result != null)
    //          //  return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

    //          //return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
    //        }
    //        if (leaveapro.RecommendedId != null && leaveapro.Status == "Cancelled" && leaveapro.RecommendedId != "")
    //        {
    //          leaveapro.Status = "Partially Cancelled Approved";
    //          //LeaveApplDetails result = LeaveApprovalHelper.RegisterLeaveApprovalDetails(item);
    //          //if (result != null)
    //          //  return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

    //          //return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
    //        }
    //        else
    //        {
    //          if ((leaveapro.Status == "Partially Approved" || leaveapro.Status == "Applied") && leaveapro.ApprovedId == "RAJA")
    //          {

    //            leaveapro.Status = "Approved";
    //            ApproveStatus = leaveapro.Status;
    //          }
    //          if ((leaveapro.Status == "Partially Cancelled Approved" || leaveapro.Status == "Cancelled") && leaveapro.ApprovedId == "RAJA")
    //          {

    //            leaveapro.Status = "Cancelled";
    //            ApproveStatus = leaveapro.Status;
    //          }
    //          if (leaveapro.ApprovedId == "RAJA" && (leaveapro.Status == "Applied" || ApproveStatus == "Approved" || ApproveStatus == "Cancelled"))
    //          {
    //            SqlCommand cmd = new SqlCommand("[dbo].[usp_updateleavebalance]", con);
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.AddWithValue("@pEmpCode", leaveapro.EmpCode);

    //            cmd.Parameters.AddWithValue("@pYear", DateTime.Now.Year.ToString());
    //            cmd.Parameters.AddWithValue("@pLeaveType", leaveapro.LeaveCode);
    //            cmd.Parameters.AddWithValue("@pCompanyCode", leaveapro.CompanyCode);
    //            cmd.Parameters.AddWithValue("@PNoofDats", leaveapro.LeaveDays);
    //            cmd.Parameters.AddWithValue("@pOldLeaveType", leaveapro.AcceptedRemarks == null ? " " : leaveapro.AcceptedRemarks);
    //            cmd.Parameters.AddWithValue("@pOldNoOfDays", leaveapro.CountofLeaves == null ? 0 : leaveapro.CountofLeaves);
    //            cmd.Parameters.AddWithValue("@Status", leaveapro.Status == null ? "" : leaveapro.Status);
    //            con.Open();
    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //          }

    //          if (leaveapro.Status == "Cancelled")
    //          {
    //           // repo.LeaveApplDetails.Remove(leaveapro);
    //            leaveapro.Status = "Cancelled";
    //          }

    //          if (leaveapro.Status == "Partially Approved")
    //          {
    //            leaveapro.Status = "Partially Approved";
    //          }
    //          if (leaveapro.Status == "Approved")
    //          {
    //            leaveapro.Status = "Approved";
    //          }
    //        }
    //        //LeaveApplDetails result = LeaveApprovalHelper.RegisterLeaveApprovalDetails(item);
    //        //if (result != null)
    //        //  return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

    //        //return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
    //      }
    //      else
    //      {
    //        leaveapro.Status = "Rejected";
    //        leaveapro.chkAcceptReject = "";
    //      }
    //      LeaveApplDetails result = LeaveApprovalHelper.RegisterLeaveApprovalDetails(item);
    //      if (result != null)
    //        return Ok(new APIResponse() { status = APIStatus.PASS.ToString(), response = result });

    //      return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
    //    }

    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = "Registration failed." });
    //  }
    //  catch (Exception ex)
    //  {
    //    return Ok(new APIResponse() { status = APIStatus.FAIL.ToString(), response = ex.Message });
    //  }
    //}
  }
}
