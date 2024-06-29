using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using CoreERP.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CoreERP.BussinessLogic.Payroll
{
    public class SalaryProcessHelper
    {
        public static string SalaryProcess(string Year, string Month, string company, string employee)
        {
            using var context = new ERPContext();
            string storedProcedure = company == "1000" ? "Salary_Process_All_AMT" : "Salary_Process_All";

            var result = context.Database.ExecuteSqlRaw(
                $"EXEC {storedProcedure} @year, @month, @compcode, @empcode",
                new SqlParameter("@year", Year),
                new SqlParameter("@month", Month),
                new SqlParameter("@compcode", company),
                new SqlParameter("@empcode", employee)
            );

            return result.ToString();
        }

        //public static string SalaryProcess(string Year, string Month, string company, string employee)
        //{
        //    using var context = new ERPContext();
        //    var result = context.Database.ExecuteSqlRaw("EXEC Salary_Process_All @year, @month, @compcode, @empcode",
        //     new SqlParameter("@year", Year),
        //     new SqlParameter("@month", Month),
        //     new SqlParameter("@compcode", company),
        //     new SqlParameter("@empcode", employee));

        //    return result.ToString();

        //}
    }
}
