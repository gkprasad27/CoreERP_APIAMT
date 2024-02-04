using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using CoreERP.DataAccess;
using System.Text;
using System.IO;
//using OfficeOpenXml;
using CoreERP.Models;

namespace CoreERP.BussinessLogic.ReportsHelpers
{
    public class ReportsHelperClass
    {

        #region Sales Report

        //public static (List<dynamic>, List<dynamic>, List<dynamic>) GetSalesReport(string company, DateTime fromDate, DateTime toDate)
        //{
        //    DataSet dsResult = GetSalesReportDataSet(company, fromDate, toDate);
        //    List<dynamic> dailySalesValue = null;
        //    List<dynamic> headerList = null;
        //    List<dynamic> footerList = null;
        //    if (dsResult != null)
        //    {
        //        if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
        //        {
        //            dailySalesValue = ToDynamic(dsResult.Tables[0]);
        //        }
        //        if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
        //        {
        //            headerList = ToDynamic(dsResult.Tables[1]);
        //        }
        //        if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
        //        {
        //            footerList = ToDynamic(dsResult.Tables[2]);
        //        }
        //        return (dailySalesValue, headerList, footerList);
        //    }
        //    else return (null, null, null);
        //}
        //public static DataSet GetSalesReportDataSet(string company, DateTime fromDate, DateTime toDate)
        //{
        //    ScopeRepository scopeRepository = new ScopeRepository();
        //    // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
        //    using DbCommand command = scopeRepository.CreateCommand();
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.CommandText = "rpt_DailySales";
        //    #region Parameters
        //    DbParameter companyid = command.CreateParameter();
        //    companyid.Direction = ParameterDirection.Input;
        //    companyid.Value = (object)company ?? DBNull.Value;
        //    companyid.ParameterName = "company";
        //    DbParameter pmfDate = command.CreateParameter();
        //    pmfDate.Direction = ParameterDirection.Input;
        //    pmfDate.Value = (object)fromDate ?? DBNull.Value;
        //    pmfDate.ParameterName = "fDate";
        //    DbParameter pmtDate = command.CreateParameter();
        //    pmtDate.Direction = ParameterDirection.Input;
        //    pmtDate.Value = (object)toDate ?? DBNull.Value;
        //    pmtDate.ParameterName = "tDate";
        //    #endregion
        //    // Add parameter as specified in the store procedure
        //    command.Parameters.Add(companyid);
        //    command.Parameters.Add(pmfDate);
        //    command.Parameters.Add(pmtDate);
        //    return scopeRepository.ExecuteParamerizedCommand(command);
        //}

        public static DataTable GetSalesReport( DateTime fromDate, DateTime toDate, string company)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_DailySales";
            #region Parameters
            
            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = (object)fromDate.ToShortDateString() ?? DBNull.Value;
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = (object)toDate.ToShortDateString() ?? DBNull.Value;
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else return null;
        }
        #endregion

        public static DataTable GetGoodsReceiptsReport(DateTime fromDate, DateTime toDate, string company)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_GoodsReceipts";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = (object)fromDate.ToShortDateString() ?? DBNull.Value;
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = (object)toDate.ToShortDateString() ?? DBNull.Value;
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else return null;
        }

        public static DataTable GetPurchaseReport(DateTime fromDate, DateTime toDate, string company)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_DailyPurchases";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = (object)fromDate.ToShortDateString() ?? DBNull.Value;
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = (object)toDate.ToShortDateString() ?? DBNull.Value;
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else return null;
        }

        public static DataTable GetStockValuation( string company)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_stockvaluation";
            #region Parameters

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(companyid);
            DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else return null;
        }

        public static DataSet getDataFromDataBase(List<parametersClass> dbParametersList, string procedureName)
        {
            DataSet ds = null;
            ScopeRepository scopeRepository = new ScopeRepository();
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                #region Parameters
                foreach (parametersClass dbPar in dbParametersList)
                {
                    DbParameter dbParameter = command.CreateParameter();
                    dbParameter.Direction = ParameterDirection.Input;
                    dbParameter.Value = (object)dbPar.paramValue ?? DBNull.Value;
                    dbParameter.ParameterName = dbPar.paramName;
                    command.Parameters.Add(dbParameter);
                }
                #endregion
                ds = scopeRepository.ExecuteParamerizedCommand(command);

            }
            return ds;

        }
        public static List<dynamic> ToDynamic(DataTable dt)
        {
            var dynamicDt = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new System.Dynamic.ExpandoObject();
                dynamicDt.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }
            return dynamicDt;
        }
      
    }
    public class parametersClass
    {
        public object paramValue { get; set; }
        public string paramName { get; set; }
        //ParameterDirection paramDirection { get; set; }
    }
}
