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
                //IList<Employees> empList = new List<Employees>() {
                //new Employees(){ Code="1", Name="Bill",Active="Y"}
                //new Employees(){ Code="2", Name="Steve",Active="Y"},
                //new Employees(){ Code="3", Name="Ram",Active="Y"},
                //new Employees(){ Code="4", Name="Moin",Active="Y"}
                //return empList.ToList();
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

        //Getting Names
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
                    var empdata = repo.TblEmployee.Where(x => x.EmployeeCode == leaveApplDetails.EmpCode).FirstOrDefault();
                    var LeaveAplysdata = repo.LeaveApplDetails.Where(x => x.Sno == leaveApplDetails.Sno).FirstOrDefault();
                    leaveApplDetails.Status = "Applied";
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
                    var LeaveAplysdata = repo.LeaveApplDetails.Where(x => x.Sno == leaveApplDetails.Sno).FirstOrDefault();
                    if (leaveApplDetails.Sno > 0)
                    {
                        if (LeaveAplysdata.Status == "Approved")
                        {
                            string[] stringSeparators = new string[] { "-" };
                            var result = LeaveAplysdata.LeaveCode.Split(stringSeparators, StringSplitOptions.None);
                            var code = result[0];
                            leaveApplDetails.CountofLeaves = Convert.ToInt32(LeaveAplysdata.LeaveDays);
                            leaveApplDetails.AcceptedRemarks = code;
                        }
                        else
                        {
                            leaveApplDetails.LeaveDays = Convert.ToDouble(leaveApplDetails.LeaveDays);
                        }
                        repo.Entry(LeaveAplysdata).State = EntityState.Detached;
                        //LeaveAplysdata.CountofLeaves = Convert.ToInt32(LeaveAplysdata.LeaveDays);
                        leaveApplDetails.Status = "Applied";
                        leaveApplDetails.ApplDate = DateTime.Now;
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
                                            join rm in repo.LeaveBalanceMaster on pm.LeaveCode equals rm.LeaveCode
                                            where rm.EmpCode == code
                                            select new LeaveBalanceMaster
                                            {
                                                EmpCode = pm.LeaveCode + "-" + rm.Balance
                                            });
                    return ProjectsGridData.ToList();
                }

                //var list = (from u in repo.LeaveTypes
                //                join c in repo.LeaveBalanceMaster on u.LeaveCode equals c.LeaveCode
                //                where c.EmpCode == "005"
                //                select new
                //                { 
                //                    u.LeaveCode + '-' + c.Balance
                //                }).ToList();

                //    return repo.LeaveBalanceMaster.ToList();
                //}
            }
            catch { throw; }
        }

    }
}
