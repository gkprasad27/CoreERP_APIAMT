using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using CoreERP.DataAccess;
using System.Text;

namespace CoreERP.BussinessLogic.ReportsHelpers
{
    public class ReportsHelperClass
    {
        public static string GetMemberMasterReportData(string includeMobileNumberOrNot, string userID)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetMemberMasterReport";
                #region Parameters
                DbParameter includeMblNumber = command.CreateParameter();
                DbParameter UserID = command.CreateParameter();
                includeMblNumber.Direction = ParameterDirection.Input;
                UserID.Direction = ParameterDirection.Input;
                includeMblNumber.Value = (object)includeMobileNumberOrNot ?? DBNull.Value;
                UserID.Value = (object)userID ?? DBNull.Value;
                includeMblNumber.ParameterName = "IncludeMblNumber";
                UserID.ParameterName = "UserID";
                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(includeMblNumber);
                command.Parameters.Add(UserID);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command);
                if (dt.Rows.Count > 0)
                    return DataTableToJSONWithStringBuilder(dt);
                else return null;
            }
        }
        public static string GetEmployeeRegisterReportData(string userID)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetEmployeeRegisterReport";
                #region Parameters
                DbParameter UserID = command.CreateParameter();
                UserID.Direction = ParameterDirection.Input;
                UserID.Value = (object)userID ?? DBNull.Value;
                UserID.ParameterName = "UserID";
                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(UserID);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command);
                if (dt.Rows.Count > 0)
                    return DataTableToJSONWithStringBuilder(dt);
                else return null;
            }
        }
        public static string GetAccountLedgerReportData(string userID)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetAccountLedgerReport";
                #region Parameters
                DbParameter UserID = command.CreateParameter();
                UserID.Direction = ParameterDirection.Input;
                UserID.Value = (object)userID ?? DBNull.Value;
                UserID.ParameterName = "UserID";
                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(UserID);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command);
                if (dt.Rows.Count > 0)
                    return DataTableToJSONWithStringBuilder(dt);
                else return null;
            }
        }
        
        public static string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }
    }
}
