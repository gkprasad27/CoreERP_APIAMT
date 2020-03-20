using CoreERP.BussinessLogic.Common;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace CoreERP.BussinessLogic.SelfserviceHelpers
{
  public class LeaveApprovalHelper
  {
        // private static readonly SqlConnection con;

        //public static List<LeaveApplDetails> GetLeaveApplDetailsList()
        //{
        //    try
        //    {
        //        List<Employees> report = new List<Employees>();
        //        List<Employees> empList = new List<Employees>();
        //        List<Employees> empList1 = new List<Employees>();
        //        List<LeaveApplDetails> LeaveAplyDetails = new List<LeaveApplDetails>();
        //        List<LeaveApplDetails> LeaveAply = new List<LeaveApplDetails>();

        //        using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
        //        {
        //            List<Employees> empLists = new List<Employees>();
        //            foreach (var item in empList)
        //            {
        //                repo.LeaveApplDetails.AsEnumerable().Where(x => x.EmpCode == item.Code && x.ReportId == "RAMA").Where(x => x.Status.Trim() == "Applied" || x.Status.Trim() == "Cancelled").ToList();
        //                if (LeaveAplyDetails.Count != 0)
        //                {
        //                    foreach (var query in LeaveAplyDetails)
        //                    {
        //                        LeaveAply.Add(query);
        //                    }
        //                }
        //            }
        //            foreach (var item in empList1)
        //            {
        //                if (item.ReportingTo == null || item.ReportingTo == "")
        //                {
        //                    repo.LeaveApplDetails.AsEnumerable().Where(x => x.EmpCode == item.Code && x.ApprovedId == "RAJA").Where(x => (x.Status.Trim() == "Applied" || x.Status.Trim() == "Partially Approved") || (x.Status.Trim() == "Cancelled" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
        //                    if (LeaveAplyDetails.Count != 0)
        //                    {
        //                        foreach (var query in LeaveAplyDetails)
        //                        {
        //                            LeaveAply.Add(query);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    repo.LeaveApplDetails.AsEnumerable().Where(x => x.EmpCode == item.Code && (x.Status.Trim() == "Partially Approved" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
        //                    if (LeaveAplyDetails.Count != 0)
        //                    {
        //                        foreach (var query in LeaveAplyDetails)
        //                        {
        //                            LeaveAply.Add(query);
        //                        }
        //                    }
        //                }
        //            }
        //            //return LeaveAply.ToList();
        //            return repo.LeaveApplDetails.AsEnumerable().Where(m => m.Status == "Applied").ToList();
        //        }
        //    }
        //    catch { throw; }
        //}


        //public static List<LeaveApplDetails> RegisterLeaveApprovalDetails(LeaveApplDetails[] leaveapp)
        //{
        //    try
        //    {
        //        using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
        //        {
        //            string ApproveStatus = null;
        //            foreach (var item in leaveapp)
        //            {
        //                var leaveapro = LeaveApprovalHelper.GetLeaveApplDetailsList().Where(x => x.Sno == item.Sno).FirstOrDefault();
        //                if (item.chkAcceptReject == "Yes")
        //                {
        //                    if (leaveapro.ReportID != null && leaveapro.Status == "Applied" && leaveapro.ReportID != "")
        //                    {
        //                        leaveapro.Status = "Partially Approved";
        //                    }
        //                    if (leaveapro.ReportID != null && leaveapro.Status == "Cancelled" && leaveapro.ReportID != "")
        //                    {
        //                        leaveapro.Status = "Partially Cancelled Approved";
        //                    }
        //                    else
        //                    {
        //                        if ((leaveapro.Status == "Partially Approved" || leaveapro.Status == "Applied") && leaveapro.ApprovedID == "RAJA")
        //                        {

        //                            leaveapro.Status = "Approved";
        //                            ApproveStatus = leaveapro.Status;
        //                        }
        //                        if ((leaveapro.Status == "Partially Cancelled Approved" || leaveapro.Status == "Cancelled") && leaveapro.ApprovedID == "RAJA")
        //                        {

        //                            leaveapro.Status = "Cancelled";
        //                            ApproveStatus = leaveapro.Status;
        //                        }
        //                        if (leaveapro.ApprovedID == "RAJA" && (leaveapro.Status == "Applied" || ApproveStatus == "Approved" || ApproveStatus == "Cancelled"))
        //                        {
        //                            SqlConnection con = new SqlConnection();
        //                            con.ConnectionString = "Data Source=192.168.2.26;" + "Initial Catalog=ERP;" + "User id=sa;" + "Password=dotnet@!@#;";
        //                            SqlCommand cmd = new SqlCommand("[dbo].[usp_updateleavebalance]", con);
        //                            cmd.CommandType = CommandType.StoredProcedure;
        //                            cmd.Parameters.AddWithValue("@pEmpCode", leaveapro.EmpCode);

        //                            cmd.Parameters.AddWithValue("@pYear", DateTime.Now.Year.ToString());
        //                            cmd.Parameters.AddWithValue("@pLeaveType", leaveapro.LeaveCode);
        //                            cmd.Parameters.AddWithValue("@pCompanyCode", leaveapro.CompanyCode);
        //                            cmd.Parameters.AddWithValue("@PNoofDats", leaveapro.LeaveDays);
        //                            cmd.Parameters.AddWithValue("@pOldLeaveType", leaveapro.AcceptedRemarks == null ? " " : leaveapro.AcceptedRemarks);
        //                            cmd.Parameters.AddWithValue("@pOldNoOfDays", leaveapro.CountofLeaves == null ? 0 : leaveapro.CountofLeaves);
        //                            cmd.Parameters.AddWithValue("@Status", leaveapro.Status == null ? "" : leaveapro.Status);
        //                            con.Open();
        //                            cmd.ExecuteNonQuery();
        //                            con.Close();
        //                        }

        //                        if (leaveapro.Status == "Cancelled")
        //                        {
        //                            leaveapro.Status = "Cancelled";
        //                        }

        //                        if (leaveapro.Status == "Partially Approved")
        //                        {
        //                            leaveapro.Status = "Partially Approved";
        //                        }
        //                        if (leaveapro.Status == "Approved")
        //                        {
        //                            leaveapro.Status = "Approved";
        //                        }
        //                    }
        //                }
        //                else
                        
        //                {
        //                    leaveapro.Status = "Rejected";
        //                }
        //                repo.LeaveApplDetails.Update(leaveapro);
        //                if (repo.SaveChanges() > 0)
        //                    return leaveapp.ToList();
        //            }
        //            return null;
        //        }
        //    }
        //    catch { throw; }
        //}
    }
}
