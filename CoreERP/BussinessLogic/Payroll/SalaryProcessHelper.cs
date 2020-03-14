using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using CoreERP.DataAccess;
using System.Text;


namespace CoreERP.BussinessLogic.Payroll
{
    public class SalaryProcessHelper
    {
        public static string SalaryProcess(string Year, string Month, string CompanyCode, string EmpCode, string Status)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Salary_Process_EmpWise";
                #region Parameters
                DbParameter year = command.CreateParameter();
                DbParameter month = command.CreateParameter();
                DbParameter companycode = command.CreateParameter();
                DbParameter empCode = command.CreateParameter();
                DbParameter status = command.CreateParameter();
                year.Direction = ParameterDirection.Input;
                month.Direction = ParameterDirection.Input;
                companycode.Direction = ParameterDirection.Input;
                empCode.Direction = ParameterDirection.Input;
                status.Direction = ParameterDirection.Input;
                year.Value = (object)Year ?? DBNull.Value;
                month.Value = (object)Month ?? DBNull.Value;
                companycode.Value = (object)CompanyCode ?? DBNull.Value;
                empCode.Value = (object)EmpCode ?? DBNull.Value;
                status.Value = (object)Status ?? DBNull.Value;
                year.ParameterName = "pYear";
                month.ParameterName = "pMonth";
                companycode.ParameterName = "pCompanyCode";
                empCode.ParameterName = "pEmpCode";
                status.ParameterName = "pStatus";
                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(year);
                command.Parameters.Add(month);
                command.Parameters.Add(companycode);
                command.Parameters.Add(empCode);
                command.Parameters.Add(status);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                 return null;

            }
        }
    }
}
