using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace CoreERP.BussinessLogic.SelfserviceHelpers
{
    public class LeaveRequestHelper
    {
        public static List<Employees> GetEmployeesList()
        {
            try
            {
                IList<Employees> empList = new List<Employees>() {
                new Employees(){ Code="1", Name="Bill",Active="Y"}
                //new Employees(){ Code="2", Name="Steve",Active="Y"},
                //new Employees(){ Code="3", Name="Ram",Active="Y"},
                //new Employees(){ Code="4", Name="Moin",Active="Y"}
            };
                return empList.ToList();
            }
            catch { throw; }
        }


        //public static List<LeaveApplDetails> GetLeaveApplDetailsList()
        //{
        //    try
        //    {
        //        using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
        //        {
        //            return repo.LeaveApplDetails.AsEnumerable().ToList();
        //        }
        //    }
        //    catch { throw; }
        //}

        //public static string GetNoDays(string fromdate, string todate)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = "Data Source=192.168.2.26;" + "Initial Catalog=ERP;" + "User id=sa;" + "Password=dotnet@!@#;";
        //    SqlCommand cmd = new SqlCommand("[dbo].[usp_tm_applynewleavedatesunday]", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@leavefrom", fromdate);
        //    cmd.Parameters.AddWithValue("@leaveto", todate);
        //    SqlParameter CntLeaveDays = new SqlParameter();
        //    CntLeaveDays.ParameterName = "@CntNoOfDays";
        //    CntLeaveDays.DbType = DbType.Double;
        //    CntLeaveDays.Direction = ParameterDirection.Output;
        //    cmd.Parameters.Add(CntLeaveDays);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    string LeaveDays = cmd.Parameters["@CntNoOfDays"].Value.ToString();
        //    return LeaveDays;
        //}
        //public static LeaveApplDetails RegisterLeaveApplDetails(LeaveApplDetails leaveApplDetails, out string errorMessage)
        //{
        //    try
        //    {
        //        errorMessage = string.Empty;
        //        if (LeaveRequestHelper.GetList(leaveApplDetails.EmpCode) == null)
        //        {
        //            errorMessage = $"No leave balance record found for Employee - {nameof(leaveApplDetails.EmpCode)}.";
        //            return null;
        //        }

        //        var _leavebal = LeaveRequestHelper.GetList(leaveApplDetails.EmpCode);
        //        if(_leavebal!=null)
        //        {
        //            if (!(_leavebal.Balance >= leaveApplDetails.LeaveDays))
        //            {
        //                errorMessage = $"LeaveMaxLimit not found for correctly - {nameof(leaveApplDetails.EmpCode)}.";
        //                return null;
        //            }
        //        }

        //        var _leaveType = LeaveRequestHelper.GetLeaveTypes(leaveApplDetails.LeaveCode);
        //        if (_leaveType != null)
        //        {
        //            if (!(_leaveType.LeaveMaxLimit >= leaveApplDetails.LeaveDays && _leaveType.LeaveMinLimit <= leaveApplDetails.LeaveDays))
        //            {

        //                errorMessage = $"LeaveMaxLimit not found for correctly - {nameof(leaveApplDetails.EmpCode)}.";
        //                return null;
        //            }
        //            else
        //            {
        //                errorMessage = $"Exception failed. - {nameof(leaveApplDetails.EmpCode)}.";
        //                return null;
        //            }
        //        }

                
        //        using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
        //        {
                    
        //            leaveApplDetails.Status = "Applied";
        //            leaveApplDetails.ApplDate = DateTime.Now;
        //            repo.LeaveApplDetails.Add(leaveApplDetails);
        //            int c=Convert.ToInt32(((_leavebal.Balance) - (leaveApplDetails.LeaveDays)));
        //            _leavebal.Balance = ((_leavebal.Balance)-(leaveApplDetails.LeaveDays));
        //            _leavebal.LeaveCode = leaveApplDetails.LeaveCode;
        //            _leavebal.Year = DateTime.Now.Year.ToString();
        //            repo.LeaveBalanceMaster.UpdateRange();
        //            if (repo.SaveChanges() > 0)
        //                return leaveApplDetails;
        //            else
        //                errorMessage = "Registration failed.";

        //            return null;
        //        }
        //    }
        //    catch { throw; }
        //}

        //public static LeaveBalanceMaster GetList(string code)
        //{
        //    try
        //    {
        //        using (Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>())
        //        {
        //            return repo.LeaveBalanceMaster.Where(x => x.EmpCode == code).FirstOrDefault();
        //        }
        //    }
        //    catch { throw; }
        //}

        //public static LeaveTypes GetLeaveTypes(string Leavecode)
        //{
        //    try
        //    {
        //        using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
        //        {

        //            return repo.LeaveTypes.Where(x => x.LeaveCode == Leavecode).FirstOrDefault();

        //        }
        //    }
        //    catch { throw; }
        //}

        //public static List<LeaveApplDetails> GetLeaveForApproval(string empCode)
        //{
        //    try
        //    {
        //        using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
        //        {
        //            return (from lvlapl in repo.LeaveApplDetails
        //                    join emp in repo.Employees
        //                    on lvlapl.EmpCode equals emp.Code
        //                    where ((emp.ApprovedBy == empCode || emp.RecommendedBy == null) || (emp.RecommendedBy == empCode || emp.RecommendedBy != null))
        //                    select lvlapl).ToList();
        //        }
        //    }
        //    catch { throw; }
        //}

        ////Leave type assign onload to dropdown code
        //public static List<LeaveBalanceMaster> GetListOfleavetypes()
        //{
        //    try
        //    {
        //        using (Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>())
        //        {
        //            return repo.LeaveBalanceMaster.ToList();
        //        }
        //    }
        //    catch { throw; }
        //}

    }
}
