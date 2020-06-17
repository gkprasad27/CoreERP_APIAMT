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

        public static List<LeaveApplDetails> GetLeaveApplDetailsList(string code)
        {
            using (ERPContext context = new ERPContext())
            {

                try
                {
                    List<TblEmployee> report = new List<TblEmployee>();
                    List<LeaveApplDetails> LeaveAplyDetails = new List<LeaveApplDetails>();
                    List<LeaveApplDetails> LeaveAply = new List<LeaveApplDetails>();

                    using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                    {
                        //List<TblEmployee> empList = repo.TblEmployee.ToList();
                        List<TblEmployee> empList1 = repo.TblEmployee.ToList();
                        List<TblEmployee> empLists = new List<TblEmployee>();
                        foreach (var item in empList1)
                        {
                            LeaveAplyDetails = context.LeaveApplDetails.Where(x => x.EmpCode == item.EmployeeCode && x.ReportId == code &&
                               (x.Status == "Applied" || x.Status == "Cancelled")).ToList();
                            if (LeaveAplyDetails.Count != 0)
                            {
                                foreach (var query in LeaveAplyDetails)
                                {
                                    LeaveAply.Add(query);
                                }
                            }
                        }
                        foreach (var item in empList1)
                        {
                            if (item.ReportedBy == null || item.ReportedBy == "")
                            {
                                LeaveAplyDetails = context.LeaveApplDetails.Where(x => x.EmpCode == item.EmployeeCode
                                && x.ApprovedId == code).Where(x => (x.Status.Trim() == "Applied"
                                || x.Status.Trim() == "Partially Approved") || (x.Status.Trim() == "Cancelled"
                                || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                                if (LeaveAplyDetails.Count != 0)
                                {
                                    foreach (var query in LeaveAplyDetails)
                                    {
                                        LeaveAply.Add(query);
                                    }
                                }
                                return LeaveAply.Distinct().ToList();
                            }
                            else
                            {
                                if (item.ApprovedBy == code)
                                {
                                    LeaveAplyDetails = context.LeaveApplDetails.Where(x => x.EmpCode == item.EmployeeCode &&
                                    x.ApprovedId == code
                                    && x.Status == "Partially Approved" || x.Status == "Applied" || x.Status == "Partially Cancelled Approved").ToList();
                                }

                                if (item.ReportedBy == code)
                                {
                                    LeaveAplyDetails = context.LeaveApplDetails.Where(x => x.EmpCode == item.EmployeeCode && x.ReportId == code
                                   && x.Status == "Applied" || x.Status == "Partially Cancelled Approved").ToList();
                                }
                                //repo.LeaveApplDetails.AsEnumerable().Where(x => x.EmpCode == item.EmployeeCode && (x.Status.Trim() == "Partially Approved" || x.Status.Trim() == "Partially Cancelled Approved")).ToList();
                                if (LeaveAplyDetails.Count != 0)
                                {
                                    foreach (var query in LeaveAplyDetails)
                                    {
                                        LeaveAply.Add(query);
                                    }
                                }
                                return LeaveAply.Distinct().ToList();
                            }
                        }
                        return LeaveAply.Distinct().ToList();
                        // return repo.LeaveApplDetails.AsEnumerable().Where(m => m.Status == "Applied").ToList();
                    }
                }
                catch { throw; }
            }
        }

        public string getemployee(string Code)
        {
            try
            {
                //errorMessage = string.Empty;
                string Name = null;
                using (Repository<TblEmployee> _repo = new Repository<TblEmployee>())
                {
                    Name = _repo.TblEmployee.Where(x => x.EmployeeCode == Code).SingleOrDefault()?.EmployeeName;
                }

                return Name;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<LeaveApplDetails> GetLeaveApplDetailsList()
        {
            try
            {
                using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                {
                    return repo.LeaveApplDetails.AsEnumerable().ToList();
                }
            }
            catch { throw; }
        }
        public List<LeaveApplDetails> RegisterLeaveApprovalDetails(string code, LeaveApplDetails lop, List<LeaveApplDetails> leaveapp)
        {
            try
            {
                using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                {
                    string ApproveStatus = null;
                    foreach (var item in leaveapp)
                    {

                        var leaveapro = LeaveApprovalHelper.GetLeaveApplDetailsList().Where(x => x.Id == item.Id).FirstOrDefault();
                        if (lop.ChkAcceptReject == "True")
                        {
                            if (leaveapro.ReportId != null && leaveapro.Status == "Applied" && leaveapro.ReportId != "")
                            {
                                leaveapro.Status = "Partially Approved";
                            }
                            if (leaveapro.ReportId != null && leaveapro.Status == "Cancelled" && leaveapro.ReportId != "")
                            {
                                leaveapro.Status = "Partially Cancelled Approved";
                            }
                            else
                            {
                                if ((leaveapro.Status == "Partially Approved" || leaveapro.Status == "Applied") && leaveapro.ApprovedId == code)
                                {

                                    leaveapro.Status = "Approved";
                                    ApproveStatus = leaveapro.Status;
                                }
                                if ((leaveapro.Status == "Partially Cancelled Approved" || leaveapro.Status == "Cancelled") && leaveapro.ApprovedId == "RAJA")
                                {

                                    leaveapro.Status = "Cancelled";
                                    ApproveStatus = leaveapro.Status;
                                }
                                if (leaveapro.ApprovedId == code && (leaveapro.Status == "Applied" || ApproveStatus == "Approved" || ApproveStatus == "Cancelled"))
                                {
                                    string[] stringSeparators = new string[] { "-" };
                                    var result = leaveapro.LeaveCode.Split(stringSeparators, StringSplitOptions.None);
                                    var code1 = result[0];
                                    ScopeRepository scopeRepository = new ScopeRepository();
                                    // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
                                    using DbCommand command = scopeRepository.CreateCommand();
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.CommandText = "usp_updateleavebalance";
                                    #region Parameters
                                    DbParameter EmpCode = command.CreateParameter();
                                    EmpCode.Direction = ParameterDirection.Input;
                                    EmpCode.Value = (object)leaveapro.EmpCode ?? DBNull.Value;
                                    EmpCode.ParameterName = "pEmpCode";

                                    DbParameter year = command.CreateParameter();
                                    year.Direction = ParameterDirection.Input;
                                    year.Value = (object)DateTime.Now.Year.ToString() ?? DBNull.Value;
                                    year.ParameterName = "pYear";

                                    DbParameter leavecode = command.CreateParameter();
                                    leavecode.Direction = ParameterDirection.Input;
                                    leavecode.Value = (object)code1 ?? DBNull.Value;
                                    leavecode.ParameterName = "pLeaveType";

                                    DbParameter compcode = command.CreateParameter();
                                    compcode.Direction = ParameterDirection.Input;
                                    compcode.Value = (object)leaveapro.CompanyCode ?? DBNull.Value;
                                    compcode.ParameterName = "pCompanyCode";

                                    DbParameter leavedays = command.CreateParameter();
                                    leavedays.Direction = ParameterDirection.Input;
                                    leavedays.Value = (object)leaveapro.LeaveDays ?? DBNull.Value;
                                    leavedays.ParameterName = "pNoofDats";

                                    DbParameter OldLeaveType = command.CreateParameter();
                                    OldLeaveType.Direction = ParameterDirection.Input;
                                    OldLeaveType.Value = (object)leaveapro.AcceptedRemarks ?? DBNull.Value;
                                    OldLeaveType.ParameterName = "pOldLeaveType";

                                    DbParameter OldNoOfDays = command.CreateParameter();
                                    OldNoOfDays.Direction = ParameterDirection.Input;
                                    OldNoOfDays.Value = (object)leaveapro.CountofLeaves ?? DBNull.Value;
                                    OldNoOfDays.ParameterName = "pOldNoOfDays";

                                    DbParameter Status = command.CreateParameter();
                                    Status.Direction = ParameterDirection.Input;
                                    Status.Value = (object)leaveapro.Status ?? DBNull.Value;
                                    Status.ParameterName = "pStatus";
                                    #endregion
                                    // Add parameter as specified in the store procedure
                                    command.Parameters.Add(EmpCode);
                                    command.Parameters.Add(year);
                                    command.Parameters.Add(leavecode);
                                    command.Parameters.Add(compcode);
                                    command.Parameters.Add(leavedays);
                                    command.Parameters.Add(OldLeaveType);
                                    command.Parameters.Add(OldNoOfDays);
                                    scopeRepository.ExecuteParamerizedCommand(command);
                                }

                                if (leaveapro.Status == "Cancelled")
                                {
                                    leaveapro.Status = "Cancelled";
                                }

                                if (leaveapro.Status == "Partially Approved")
                                {
                                    leaveapro.Status = "Partially Approved";
                                }
                                if (leaveapro.Status == "Approved")
                                {
                                    leaveapro.Status = "Approved";
                                }
                            }
                        }
                        else

                        {
                            leaveapro.Status = "Rejected";
                            leaveapro.RejectedId = code;
                            leaveapro.RejectedName = repo.TblEmployee.Where(x => x.EmployeeCode == code).SingleOrDefault()?.EmployeeName;

                        }
                        repo.LeaveApplDetails.Update(leaveapro);
                        //repo.LeaveApplDetails.Update(leaveapro);
                        //if (repo.SaveChanges() > 0)
                        //return leaveapp.ToList();
                    }

                    if (repo.SaveChanges() > 0)
                        return leaveapp.ToList();
                    return leaveapp.ToList(); ;
                }
            }
            catch { throw; }
        }
    }
}
