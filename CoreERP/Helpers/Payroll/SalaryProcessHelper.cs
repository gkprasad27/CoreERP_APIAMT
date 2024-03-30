using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using CoreERP.Models;

namespace CoreERP.BussinessLogic.Payroll
{
    public class SalaryProcessHelper
    {
        public static string SalaryProcess(string Year, string Month, string StructureName)
        {
            using var context = new ERPContext();
            var result = context.Database.ExecuteSqlRaw("EXEC Salary_Process_StructureWise @year, @month, @structure",
             new SqlParameter("@year", Year),
             new SqlParameter("@month", Month),
             new SqlParameter("@structure", StructureName));
            return result.ToString();
            //ScopeRepository scopeRepository = new ScopeRepository();
            //using DbCommand command = scopeRepository.CreateCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "Salary_Process_StructureWise";
            //#region Parameters
            //DbParameter year = command.CreateParameter();
            //DbParameter month = command.CreateParameter();
            //DbParameter structure = command.CreateParameter();
            ////DbParameter empCode = command.CreateParameter();
            ////DbParameter status = command.CreateParameter();
            //year.Direction = ParameterDirection.Input;
            //month.Direction = ParameterDirection.Input;
            //structure.Direction = ParameterDirection.Input;
            ////empCode.Direction = ParameterDirection.Input;
            ////status.Direction = ParameterDirection.Input;
            //year.Value = (object)Year ?? DBNull.Value;
            //month.Value = (object)Month ?? DBNull.Value;
            //structure.Value = (object)StructureName ?? DBNull.Value;
            ////empCode.Value = (object)EmpCode ?? DBNull.Value;
            ////status.Value = (object)Status ?? DBNull.Value;
            //year.ParameterName = "pYear";
            //month.ParameterName = "pMonth";
            //structure.ParameterName = "pstructureName";
            ////empCode.ParameterName = "pEmpCode";
            ////status.ParameterName = "pStatus";
            //#endregion
            //// Add parameter as specified in the store procedure
            //command.Parameters.Add(year);
            //command.Parameters.Add(month);
            //command.Parameters.Add(structure);
            ////command.Parameters.Add(empCode);
            ////command.Parameters.Add(status);
            //DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            //return null;
        }
    }
}
