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

        public static DataSet GetSalesReport( DateTime fromDate, DateTime toDate, string company,string CustomerCode, string MaterialCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_DailySales";
            #region Parameters
            
            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter Customerid = command.CreateParameter();
            Customerid.Direction = ParameterDirection.Input;
            Customerid.Value = (object)CustomerCode ?? DBNull.Value;
            Customerid.ParameterName = "CustomerCode";

            DbParameter Materialid = command.CreateParameter();
            Materialid.Direction = ParameterDirection.Input;
            Materialid.Value = (object)MaterialCode ?? DBNull.Value;
            Materialid.ParameterName = "MaterialCode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(Customerid);
            command.Parameters.Add(Materialid);

            return scopeRepository.ExecuteParamerizedCommand(command);
        }

        public static DataSet GetCPReport(DateTime fromDate)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetConsolidatedSalaryReport";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";
            
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            

            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        public static DataSet GetSalesGSTReport(DateTime fromDate, DateTime toDate, string company, string customerCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_SalesGST";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";


            DbParameter customerParam = command.CreateParameter();
            customerParam.Direction = ParameterDirection.Input;
            customerParam.Value = (object)customerCode ?? DBNull.Value;
            customerParam.ParameterName = "customercode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(customerParam);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }

        public static DataSet GetPurchaseGSTReport(DateTime fromDate, DateTime toDate, string company,string vendorCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_PurchaseGST";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter vendorParam = command.CreateParameter();
            vendorParam.Direction = ParameterDirection.Input;
            vendorParam.Value = (object)vendorCode ?? DBNull.Value;
            vendorParam.ParameterName = "VendorCode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(vendorParam);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        #endregion

        public static DataSet GetGoodsReceiptsReport(DateTime fromDate, DateTime toDate, string company, string CustomerCode, string MaterialCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_GoodsReceipts";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter Customerid = command.CreateParameter();
            Customerid.Direction = ParameterDirection.Input;
            Customerid.Value = (object)CustomerCode ?? DBNull.Value;
            Customerid.ParameterName = "CustomerCode";


            DbParameter Materialid = command.CreateParameter();
            Materialid.Direction = ParameterDirection.Input;
            Materialid.Value = (object)MaterialCode ?? DBNull.Value;
            Materialid.ParameterName = "MaterialCode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(Customerid);
            command.Parameters.Add(Materialid);
            return scopeRepository.ExecuteParamerizedCommand(command);
            //DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    return dt;
            //}
            //else return null;
        }

        public static DataSet GetPurchaseReport(DateTime fromDate, DateTime toDate, string company,string customerCode,string MaterialCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_DailyPurchases";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter Customerid = command.CreateParameter();
            Customerid.Direction = ParameterDirection.Input;
            Customerid.Value = (object)customerCode ?? DBNull.Value;
            Customerid.ParameterName = "CustomerCode";

            DbParameter Materialid = command.CreateParameter();
            Materialid.Direction = ParameterDirection.Input;
            Materialid.Value = (object)MaterialCode ?? DBNull.Value;
            Materialid.ParameterName = "MaterialCode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(Customerid);
            command.Parameters.Add(Materialid);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }

        public static DataSet GetOrdersvsSales(DateTime fromDate, DateTime toDate, string company)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_OrdersVsSales";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
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
            return scopeRepository.ExecuteParamerizedCommand(command);
        }

        public static DataTable GetStockValuation( string company,string materialCode)
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

            DbParameter Materialid = command.CreateParameter();
            Materialid.Direction = ParameterDirection.Input;
            Materialid.Value = (object)materialCode ?? DBNull.Value;
            Materialid.ParameterName = "MaterialCode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(companyid);
            command.Parameters.Add(Materialid);
            DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else return null;
        }

        public static DataSet GetPayslip(string year, string month, string company, string employee)
        {
            var scopeRepository = new ScopeRepository();

            using var command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = company == "1000" ? "GetSalaryDetailsPivot_AMT" : "GetSalaryDetailsPivot";

            #region Parameters

            var yearParam = command.CreateParameter();
            yearParam.Direction = ParameterDirection.Input;
            yearParam.Value = (object)year ?? DBNull.Value;
            yearParam.ParameterName = "year";

            var monthParam = command.CreateParameter();
            monthParam.Direction = ParameterDirection.Input;
            monthParam.Value = (object)month ?? DBNull.Value;
            monthParam.ParameterName = "month";

            var companyParam = command.CreateParameter();
            companyParam.Direction = ParameterDirection.Input;
            companyParam.Value = (object)company ?? DBNull.Value;
            companyParam.ParameterName = "compcode";

            var empParam = command.CreateParameter();
            empParam.Direction = ParameterDirection.Input;
            empParam.Value = (object)employee ?? DBNull.Value;
            empParam.ParameterName = "empcode";

            #endregion

            // Add parameters to the command
            command.Parameters.Add(yearParam);
            command.Parameters.Add(monthParam);
            command.Parameters.Add(companyParam);
            command.Parameters.Add(empParam);

            // Execute the command and return the result as a DataSet
            return scopeRepository.ExecuteParamerizedCommand(command);
        }

        public static DataTable GetEmpPresent(string company)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_EmpPresent";
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

        public static DataSet GetPendingSales(string company,string CustomerCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_PendingSaleOrders";
            #region Parameters

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter customerParam = command.CreateParameter();
            customerParam.Direction = ParameterDirection.Input;
            customerParam.Value = (object)CustomerCode ?? DBNull.Value;
            customerParam.ParameterName = "CustomerCode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(companyid);
            command.Parameters.Add(customerParam);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }

        public static DataSet GetPendingJO(string company,string vendorCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_PendingJobwork";
            #region Parameters

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter vendorParam = command.CreateParameter();
            vendorParam.Direction = ParameterDirection.Input;
            vendorParam.Value = (object)vendorCode ?? DBNull.Value;
            vendorParam.ParameterName = "VendorCode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(companyid);
            command.Parameters.Add(vendorParam);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        public static DataSet GetPendingPOs(string company, string vendorCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_PendingPOS";
            #region Parameters

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter vendorParam = command.CreateParameter();
            vendorParam.Direction = ParameterDirection.Input;
            vendorParam.Value = (object)vendorCode ?? DBNull.Value;
            vendorParam.ParameterName = "VendorCode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(companyid);
            command.Parameters.Add(vendorParam);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }

        public static DataSet GetSuppliedVsRejected(DateTime fromDate, DateTime toDate, string company)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_SuppliedVsRejected";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
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
            return scopeRepository.ExecuteParamerizedCommand(command);
        }

        public static DataSet VendorPaymentsReport(DateTime fromDate, DateTime toDate, string company, string Status, string BPType, string Customer)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_VendorPayments";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter statusid = command.CreateParameter();
            statusid.Direction = ParameterDirection.Input;
            statusid.Value = (object)Status ?? DBNull.Value;
            statusid.ParameterName = "Status";


            DbParameter BPTypeid = command.CreateParameter();
            BPTypeid.Direction = ParameterDirection.Input;
            BPTypeid.Value = (object)BPType ?? DBNull.Value;
            BPTypeid.ParameterName = "BPType";

            DbParameter Customerid = command.CreateParameter();
            Customerid.Direction = ParameterDirection.Input;
            Customerid.Value = (object)Customer ?? DBNull.Value;
            Customerid.ParameterName = "Customer";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(statusid);
            command.Parameters.Add(BPTypeid);
            command.Parameters.Add(Customerid);
            return scopeRepository.ExecuteParamerizedCommand(command);
            //DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    return dt;
            //}
            //else return null;
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

        public static DataSet GetemployeeotreportReport(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_EmpMonthlyOverTime";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter empid = command.CreateParameter();
            empid.Direction = ParameterDirection.Input;
            empid.Value = (object)EmployeeCode ?? DBNull.Value;
            empid.ParameterName = "empcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(empid);
            return scopeRepository.ExecuteParamerizedCommand(command);
            //DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    return dt;
            //}
            //else return null;
        }

        public static DataSet Employeeattendance(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_EemployeeAttendance";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter empid = command.CreateParameter();
            empid.Direction = ParameterDirection.Input;
            empid.Value = (object)EmployeeCode ?? DBNull.Value;
            empid.ParameterName = "empcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(empid);
            return scopeRepository.ExecuteParamerizedCommand(command);
            //DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    return dt;
            //}
            //else return null;
        }

        public static DataSet EemployeeAttendanceChange(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_EemployeeAttendanceChange";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter empid = command.CreateParameter();
            empid.Direction = ParameterDirection.Input;
            empid.Value = (object)EmployeeCode ?? DBNull.Value;
            empid.ParameterName = "empcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(empid);
            return scopeRepository.ExecuteParamerizedCommand(command);
            //DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    return dt;
            //}
            //else return null;
        }

        public static DataSet GetemployeeattendanceReport(DateTime fromDate, DateTime toDate, string company, string EmployeeCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_EemployeeAttendance";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter empid = command.CreateParameter();
            empid.Direction = ParameterDirection.Input;
            empid.Value = (object)EmployeeCode ?? DBNull.Value;
            empid.ParameterName = "empcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(empid);
            return scopeRepository.ExecuteParamerizedCommand(command);
            //DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    return dt;
            //}
            //else return null;
        }

        public static DataSet GetAttendanceProcess(DateTime fromDate, DateTime toDate, string company, string empcode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "rpt_AttendanceProcess";
            #region Parameters

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = String.Format("{0:MM/dd/yyyy}", fromDate);
            pmfDate.ParameterName = "fromdate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = String.Format("{0:MM/dd/yyyy}", toDate);
            pmtDate.ParameterName = "todate";

            DbParameter companyid = command.CreateParameter();
            companyid.Direction = ParameterDirection.Input;
            companyid.Value = (object)company ?? DBNull.Value;
            companyid.ParameterName = "compcode";

            DbParameter employeeid = command.CreateParameter();
            employeeid.Direction = ParameterDirection.Input;
            employeeid.Value = (object)empcode ?? DBNull.Value;
            employeeid.ParameterName = "empcode";
            #endregion
            // Add parameter as specified in the store procedure

            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(companyid);
            command.Parameters.Add(employeeid);
            return scopeRepository.ExecuteParamerizedCommand(command);
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
