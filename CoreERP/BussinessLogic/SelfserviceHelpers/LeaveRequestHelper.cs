using CoreERP.BussinessLogic.masterHlepers;
using CoreERP.DataAccess;
using CoreERP.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        public static List<TblEmployee> GetEmployeesList()
        {
            try
            {
                using Repository<TblEmployee> repo = new Repository<TblEmployee>();
                return repo.TblEmployee.ToList();
            }
            catch { throw; }
        }


        public List<TblEmployee> GetEmpcodes(string Code, string Name)
        {
            try
            {
                using (Repository<TblEmployee> repo = new Repository<TblEmployee>())
                {
                    if (!string.IsNullOrEmpty(Code))
                    {
                        Code = Code.ToLower();

                        return repo.TblEmployee
                                   .Where(p => p.EmployeeCode.ToLower().Contains(Code))
                                   .ToList();
                    }
                    else
                    {
                        Name = Name.ToLower();
                        return repo.TblEmployee
                                  .Where(p => p.EmployeeName.ToLower().Contains(Name))
                                  .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static decimal Getnoofdayscount(string Code, string day2, string session1, string session2)
        {
            string date = Code;
            string date2 = day2;
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_tm_applyleavedatesunday";

            #region Parameters
            DbParameter leavefrom = command.CreateParameter();
            leavefrom.Direction = ParameterDirection.Input;
            leavefrom.Value = (object)date ?? DBNull.Value;
            leavefrom.ParameterName = "leavefrom";

            DbParameter leaveto = command.CreateParameter();
            leaveto.Direction = ParameterDirection.Input;
            leaveto.Value = (object)date2 ?? DBNull.Value;
            leaveto.ParameterName = "leaveto";

            DbParameter fromday = command.CreateParameter();
            fromday.Direction = ParameterDirection.Input;
            fromday.Value = (object)session1 ?? DBNull.Value;
            fromday.ParameterName = "fromday";

            DbParameter today = command.CreateParameter();
            today.Direction = ParameterDirection.Input;
            today.Value = (object)session2 ?? DBNull.Value;
            today.ParameterName = "today";

            DbParameter CntNoOfDays = command.CreateParameter();
            CntNoOfDays.Direction = ParameterDirection.Output;
            CntNoOfDays.Size = 50;
            CntNoOfDays.ParameterName = "CntNoOfDays";

            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(leavefrom);
            command.Parameters.Add(leaveto);
            command.Parameters.Add(fromday);
            command.Parameters.Add(today);
            command.Parameters.Add(CntNoOfDays);

            scopeRepository.ExecuteParamerizedCommand(command);
            if (CntNoOfDays.Value != DBNull.Value || CntNoOfDays != null)
                return Convert.ToDecimal(CntNoOfDays.Value);
            else return 0;

        }

        public string GetEmpName(string Code, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
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

        public static List<LeaveApplDetails> GetLeaveApplDetailsList(string code)
        {
            try
            {
                using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                {
                    if (code.ToLower() == "admin")
                    {
                        return repo.LeaveApplDetails.ToList();

                    }
                    else
                        return repo.LeaveApplDetails.Where(x => x.EmpCode == code).ToList();
                }
            }
            catch { throw; }
        }

        public static LeaveApplDetails RegisterLeaveApplDetails(LeaveApplDetails leaveApplDetails, LeaveBalanceMaster lbm, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                if (LeaveRequestHelper.GetList(leaveApplDetails.EmpCode) == null)
                {
                    errorMessage = $"No leave balance record found for Employee - {nameof(leaveApplDetails.EmpCode)}.";
                    return null;
                }

                var _leavebal = LeaveRequestHelper.GetList(leaveApplDetails.EmpCode);
                if (_leavebal != null)
                {
                    if (!(_leavebal.Balance >= leaveApplDetails.LeaveDays))
                    {
                        errorMessage = $"LeaveMaxLimit not found for correctly - {nameof(leaveApplDetails.EmpCode)}.";
                        return null;
                    }
                }

                var _leaveType = LeaveRequestHelper.GetLeaveTypes(leaveApplDetails.LeaveCode);
                if (_leaveType != null)
                {
                    if (!(Convert.ToDouble(_leaveType.LeaveMaxLimit) >= (leaveApplDetails.LeaveDays)/*&&Convert.ToDouble(_leaveType.LeaveMaxLimit)<= leaveApplDetails.LeaveDays*/))
                    {

                        errorMessage = $"LeaveMaxLimit not found for correctly - {nameof(leaveApplDetails.EmpCode)}.";
                        return null;
                    }
                    else
                    {
                        errorMessage = $"Exception failed. - {nameof(leaveApplDetails.EmpCode)}.";
                        return null;
                    }
                }


                using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                {
                    List<LeaveApplDetails> LeaveAply = new List<LeaveApplDetails>();
                    string[] stringSeparators = new string[] { "-" };
                    var result = leaveApplDetails.LeaveCode.Split(stringSeparators, StringSplitOptions.None);
                    var code1 = result[0]/* + "-" +result[1]*/;
                    var empdata = repo.TblEmployee.Where(x => x.EmployeeCode == leaveApplDetails.EmpCode).FirstOrDefault();
                    var LeaveAplysdata = repo.LeaveApplDetails.Where(x => x.Sno == leaveApplDetails.Sno).FirstOrDefault();
                    leaveApplDetails.Status = "Applied";
                    leaveApplDetails.LeaveCode = code1;
                    leaveApplDetails.ApplDate = DateTime.Now;
                    leaveApplDetails.CompanyCode = "6";
                    leaveApplDetails.ReportId = empdata.ReportedBy;
                    leaveApplDetails.ReportName = repo.TblEmployee.Where(x => x.EmployeeCode == leaveApplDetails.ReportId).SingleOrDefault()?.EmployeeName;
                    leaveApplDetails.ApprovedId = empdata.ApprovedBy;
                    leaveApplDetails.ApproveName = repo.TblEmployee.Where(x => x.EmployeeCode == leaveApplDetails.ApprovedId).SingleOrDefault()?.EmployeeName;
                    repo.LeaveApplDetails.Add(leaveApplDetails);

                    if (repo.SaveChanges() > 0)
                        return leaveApplDetails;
                    else
                        errorMessage = "Registration failed.";

                    return null;
                }
            }
            catch { throw; }
        }




        public static LeaveApplDetails UpdateLeaveapplying(LeaveApplDetails leaveApplDetails, out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                if (LeaveRequestHelper.GetList(leaveApplDetails.EmpCode) == null)
                {
                    errorMessage = $"No leave balance record found for Employee - {nameof(leaveApplDetails.EmpCode)}.";
                    return null;
                }

                var _leavebal = LeaveRequestHelper.GetList(leaveApplDetails.EmpCode);
                if (_leavebal != null)
                {
                    if (!(_leavebal.Balance >= leaveApplDetails.LeaveDays))
                    {
                        errorMessage = $"LeaveMaxLimit not found for correctly - {nameof(leaveApplDetails.EmpCode)}.";
                        return null;
                    }
                }

                var _leaveType = LeaveRequestHelper.GetLeaveTypes(leaveApplDetails.LeaveCode);
                if (_leaveType != null)
                {
                    if (!(Convert.ToDouble(_leaveType.LeaveMaxLimit) >= (leaveApplDetails.LeaveDays)/*&&Convert.ToDouble(_leaveType.LeaveMaxLimit)<= leaveApplDetails.LeaveDays*/))
                    {

                        errorMessage = $"LeaveMaxLimit not found for correctly - {nameof(leaveApplDetails.EmpCode)}.";
                        return null;
                    }
                    else
                    {
                        errorMessage = $"Exception failed. - {nameof(leaveApplDetails.EmpCode)}.";
                        return null;
                    }
                }
                using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                {
                    //Leave_Appl_Details requisition = new Leave_Appl_Details();
                    //requisition = db.Leave_Appl_Details.Where(x => x.Sno == leaveRequest.Sno).FirstOrDefault();
                    var LeaveAplysdata = repo.LeaveApplDetails.Where(x => x.Sno == leaveApplDetails.Sno).FirstOrDefault();
                    if (leaveApplDetails.Sno > 0)
                    {
                        string[] stringSeparators = new string[] { "-" };
                        var result = leaveApplDetails.LeaveCode.Split(stringSeparators, StringSplitOptions.None);
                        var code = result[0];
                        if (LeaveAplysdata.Status == "Approved")
                        {

                            //leaveApplDetails.CountofLeaves = Convert.ToInt32(LeaveAplysdata.LeaveDays);
                            leaveApplDetails.CountofLeaves = LeaveAplysdata.LeaveDays;
                            leaveApplDetails.AcceptedRemarks = code;
                        }
                        else
                        {
                            LeaveAplysdata.LeaveDays = Convert.ToDouble(leaveApplDetails.LeaveDays);
                        }
                        repo.Entry(LeaveAplysdata).State = EntityState.Detached;
                        //LeaveAplysdata.CountofLeaves = Convert.ToInt32(LeaveAplysdata.LeaveDays);
                        leaveApplDetails.Status = "Applied";
                        leaveApplDetails.ApplDate = DateTime.Now;
                        leaveApplDetails.LeaveCode = code;
                        //repo.Entry(LeaveAplysdata).State = EntityState.Modified;
                        //repo.LeaveApplDetails.Update(LeaveAplysdata);
                        repo.Entry(leaveApplDetails).State = EntityState.Modified;
                        repo.LeaveApplDetails.Update(leaveApplDetails);

                        if (repo.SaveChanges() > 0)
                            return leaveApplDetails;
                        else
                            errorMessage = "Registration failed.";
                        return null;
                    }

                }
                return leaveApplDetails;
            }

            catch { throw; }

        }

        public static LeaveBalanceMaster GetList(string code)
        {
            try
            {
                using (Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>())
                {
                    return repo.LeaveBalanceMaster.Where(x => x.EmpCode == code).FirstOrDefault();
                }
            }
            catch { throw; }
        }

        public static LeaveTypes GetLeaveTypes(string Leavecode)
        {
            try
            {
                using (Repository<LeaveTypes> repo = new Repository<LeaveTypes>())
                {

                    return repo.LeaveTypes.Where(x => x.LeaveCode == Leavecode).FirstOrDefault();

                }
            }
            catch { throw; }
        }

        public static List<LeaveApplDetails> GetLeaveForApproval(string empCode)
        {
            try
            {
                using (Repository<LeaveApplDetails> repo = new Repository<LeaveApplDetails>())
                {
                    return (from lvlapl in repo.LeaveApplDetails
                            join emp in repo.TblEmployee
                            on lvlapl.EmpCode equals emp.EmployeeCode
                            //where ((emp.app == empCode || emp.RecommendedBy == null) || (emp.RecommendedBy == empCode || emp.RecommendedBy != null))
                            select lvlapl).ToList();
                }
            }
            catch { throw; }
        }

        ////Leave type assign onload to dropdown code
        public List<LeaveBalanceMaster> GetListOfleavetypes(string code, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (Repository<LeaveBalanceMaster> repo = new Repository<LeaveBalanceMaster>())
                {

                    var ProjectsGridData = (from pm in repo.LeaveTypes
                                            join rm in repo.LeaveBalanceMaster on pm.LeaveCode /*+ "-" + pm.LeaveName*/ equals rm.LeaveCode
                                            where rm.EmpCode == code
                                            select new LeaveBalanceMaster
                                            {
                                                EmpCode = pm.LeaveCode/* + "-" + pm.LeaveName*/ + "-" + rm.Balance
                                            });
                    return ProjectsGridData.ToList();
                }
            }
            catch { throw; }
        }

    }
}
