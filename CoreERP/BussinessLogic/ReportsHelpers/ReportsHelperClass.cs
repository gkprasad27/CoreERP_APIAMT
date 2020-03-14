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
        #region MemberMasterReport
        public static List<dynamic> GetMemberMasterReportDataList(string includeMobileNumberOrNot, string userID)
        {
           
            DataTable dt = GetMemberMasterReportDataTable(includeMobileNumberOrNot,userID);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> memberMasters = ToDynamic(dt);
                return memberMasters;
            }
            else return null;
        }
        public static DataTable GetMemberMasterReportDataTable(string includeMobileNumberOrNot, string userID)
        {
            List<parametersClass> dbParametersList = new List<parametersClass>();
            parametersClass parameters = new parametersClass();
            parameters.paramName = "IncludeMblNumber";
            parameters.paramValue = includeMobileNumberOrNot;
            dbParametersList.Add(parameters);
            parameters = new parametersClass();
            parameters.paramName = "userID";
            parameters.paramValue = userID;
            dbParametersList.Add(parameters);
            string procedureName = "Usp_GetMemberMasterReport";
            DataTable dt = getDataFromDataBase(dbParametersList, procedureName).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else return null;
        }
        #endregion
        #region ShiftViewReport
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetShiftViewReportDataList(string userName, string userID,string branchCode,string shiftId,DateTime fromDate,DateTime toDate,int reportID)
        {
            DataSet dsResult = GetShiftViewReportDataTable(userName, userID, branchCode, shiftId, fromDate, toDate, reportID);
            List<dynamic> shiftViewLists = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    shiftViewLists = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    shiftViewLists = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    shiftViewLists = ToDynamic(dsResult.Tables[2]);
                }
                return (shiftViewLists, headerList, footerList);
            }
            else return (null, null, null);
        }
        public static DataSet GetShiftViewReportDataTable(string userName, string userID, string branchCode, string shiftId, DateTime fromDate, DateTime toDate, int reportID)
        {
            List<parametersClass> dbParametersList = new List<parametersClass>();
            parametersClass parameters = new parametersClass();
            if (reportID == 1)
            {
                parameters = new parametersClass();
                parameters.paramName = "userID";
                parameters.paramValue = userID;
                dbParametersList.Add(parameters);

                parameters = new parametersClass();
                parameters.paramName = "userName";
                parameters.paramValue = userName;
                dbParametersList.Add(parameters);

                parameters = new parametersClass();
                parameters.paramName = "branchCode";
                parameters.paramValue = branchCode;
                dbParametersList.Add(parameters);

                parameters = new parametersClass();
                parameters.paramName = "shiftId";
                parameters.paramValue = shiftId;
                dbParametersList.Add(parameters);

                parameters = new parametersClass();
                parameters.paramName = "fromDate";
                parameters.paramValue = fromDate;
                dbParametersList.Add(parameters);

                parameters = new parametersClass();
                parameters.paramName = "toDate";
                parameters.paramValue = toDate;
                dbParametersList.Add(parameters);
            }
            else if (reportID == 2)
            {
                parameters = new parametersClass();
                parameters.paramName = "userID";
                parameters.paramValue = userID;
                dbParametersList.Add(parameters);

                parameters = new parametersClass();
                parameters.paramName = "shiftId";
                parameters.paramValue = shiftId;
                dbParametersList.Add(parameters);

                parameters = new parametersClass();
                parameters.paramName = "fromDate";
                parameters.paramValue = fromDate;
                dbParametersList.Add(parameters);

                parameters = new parametersClass();
                parameters.paramName = "toDate";
                parameters.paramValue = toDate;
                dbParametersList.Add(parameters);
            }
            else if(reportID==3||reportID==6)
            {
                parameters = new parametersClass();
                parameters.paramName = "shiftId";
                parameters.paramValue = shiftId;
                dbParametersList.Add(parameters);
            }

            string procedureName = "";
            if (reportID == 1)
                procedureName = "Usp_ShifViewReport";
            else if (reportID == 2)
                procedureName = "Usp_ShiftSaleValueMeterReading";
            else if (reportID == 3)
                procedureName = "Usp_StockReportByShift";
            else if (reportID == 6)
                procedureName = "Usp_DailySalesReportByShift";
            return getDataFromDataBase(dbParametersList, procedureName);
        }
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetDefaultShiftReportDataTableList()
        {
            List<parametersClass> dbParametersList = new List<parametersClass>();
            DataSet dsResult = getDataFromDataBase(dbParametersList, "Usp_ShifViewReport");
            List<dynamic> shiftViewLists = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    shiftViewLists = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (shiftViewLists, headerList, footerList);
            }
            else return (null, null, null);
        }
        #endregion        
        #region EmployeeRegisterReport
        public static List<dynamic> GetEmployeeRegisterReportList(string userID)
        {
            DataTable dt = GetEmployeeRegisterReportDataTable(userID);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> employeeRegister = ToDynamic(dt);
                return employeeRegister;
            }
            else return null;
        }
        public static DataTable GetEmployeeRegisterReportDataTable(string userID)
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
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region AccountLedgerReport
        public static (List<dynamic>,List<dynamic>,List<dynamic>)GetAccountLedgerReportDataList(string UserID, string ledgerCode, DateTime fromDate, DateTime toDate)
        {
            DataSet dsResult= GetAccountLedgerReportDataSet(UserID, ledgerCode, fromDate, toDate);
            List<dynamic> accountLedger=null;
            List<dynamic> headerList=null;
            List<dynamic> footerList=null;
            if (dsResult!=null)
            {
                if(dsResult.Tables.Count>0 && dsResult.Tables[0].Rows.Count>0)
                {
                    accountLedger = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (accountLedger, headerList, footerList);
            }
            else return (null,null,null);
        }
        public static DataSet GetAccountLedgerReportDataSet(string UserID, string ledgerCode ,DateTime fromDate,DateTime toDate)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetAccountLedgerReport";
                #region Parameters
                DbParameter pmledgerCode = command.CreateParameter();
                pmledgerCode.Direction = ParameterDirection.Input;
                pmledgerCode.Value = (object)ledgerCode ?? DBNull.Value;
                pmledgerCode.ParameterName = "ledgerCode";

                DbParameter pmfromDate = command.CreateParameter();
                pmfromDate.Direction = ParameterDirection.Input;
                pmfromDate.Value = (object)fromDate ?? DBNull.Value;
                pmfromDate.ParameterName = "fDate";

                DbParameter pmtoDate = command.CreateParameter();
                pmtoDate.Direction = ParameterDirection.Input;
                pmtoDate.Value = (object)toDate ?? DBNull.Value;
                pmtoDate.ParameterName = "tDate";

                DbParameter pmUserID = command.CreateParameter();
                pmUserID.Direction = ParameterDirection.Input;
                pmUserID.Value = (object)UserID ?? DBNull.Value;
                pmUserID.ParameterName = "UserID";
                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmledgerCode);
                command.Parameters.Add(pmfromDate);
                command.Parameters.Add(pmtoDate);
                command.Parameters.Add(pmUserID);
                return scopeRepository.ExecuteParamerizedCommand(command);
            }
        }
        public static List<TblAccountLedger> GetAccountLedgers()
        {
            try
            {
                using (Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>())
                {
                    return repo.TblAccountLedger.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region SaleValueReport
        public static List<dynamic> GetSaleValueReportDataList(string userID)
        {
            DataTable dt = GetSaleValueReportDataTable(userID);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }
        public static DataTable GetSaleValueReportDataTable(string userID)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetSaleValueReport";
                #region Parameters
                DbParameter UserID = command.CreateParameter();
                UserID.Direction = ParameterDirection.Input;
                UserID.Value = (object)userID ?? DBNull.Value;
                UserID.ParameterName = "UserID";
                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(UserID);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region VehicalReport
        public static List<dynamic> GetVehicalReportDataList(string vehicleRegNo, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = GetVehicalReportDataTable(vehicleRegNo,fromDate,toDate);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> vehicalValue = ToDynamic(dt);
                return vehicalValue;
            }
            else return null;
        }
        public static DataTable GetVehicalReportDataTable(string vehicleRegNo,DateTime fromDate,DateTime toDate)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetVehicleReport";
                #region Parameters
                DbParameter pmVehicleRegNo = command.CreateParameter();
                pmVehicleRegNo.Direction = ParameterDirection.Input;
                pmVehicleRegNo.Value = (object)vehicleRegNo ?? DBNull.Value;
                pmVehicleRegNo.ParameterName = "vehicleRegNo";
                DbParameter pmFromDate = command.CreateParameter();
                pmFromDate.Direction = ParameterDirection.Input;
                pmFromDate.Value = (object)fromDate ?? DBNull.Value;
                pmFromDate.ParameterName = "fromDate";
                DbParameter pmToDate = command.CreateParameter();
                pmToDate.Direction = ParameterDirection.Output;
                pmToDate.Value = (object)toDate ?? DBNull.Value;
                pmToDate.ParameterName = "toDate";
                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmVehicleRegNo);
                command.Parameters.Add(pmFromDate);
                command.Parameters.Add(pmToDate);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region IntimateSaleReport
        public static List<dynamic> GetIntimateSaleReportDataList(string companyId, string branchID, string ledgerCode, string ledgerName, DateTime fDate, DateTime tDate, string userName)
        {
            DataTable dt = GetIntimateSaleReportDataTable(companyId, branchID, ledgerCode,ledgerName,fDate,tDate,userName);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }

        public static DataTable GetIntimateSaleReportDataTable(string companyId,string branchID,string ledgerCode,string ledgerName,DateTime fDate,DateTime tDate,string userName)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetIntimateSaleReport";
                #region Parameters
                DbParameter pmcompanyId = command.CreateParameter();
                pmcompanyId.Direction = ParameterDirection.Input;
                pmcompanyId.Value = (object)companyId ?? DBNull.Value;
                pmcompanyId.ParameterName = "companyId";

                DbParameter pmbranchID = command.CreateParameter();
                pmbranchID.Direction = ParameterDirection.Input;
                pmbranchID.Value = (object)branchID ?? DBNull.Value;
                pmbranchID.ParameterName = "branchID";

                DbParameter pmledgerCode = command.CreateParameter();
                pmledgerCode.Direction = ParameterDirection.Output;
                pmledgerCode.Value = (object)ledgerCode ?? DBNull.Value;
                pmledgerCode.ParameterName = "ledgerCode";

                DbParameter pmledgerName = command.CreateParameter();
                pmledgerName.Direction = ParameterDirection.Output;
                pmledgerName.Value = (object)ledgerName ?? DBNull.Value;
                pmledgerName.ParameterName = "ledgerName";

                DbParameter pmfDate = command.CreateParameter();
                pmfDate.Direction = ParameterDirection.Output;
                pmfDate.Value = (object)fDate ?? DBNull.Value;
                pmfDate.ParameterName = "fDate";

                DbParameter pmtDate = command.CreateParameter();
                pmtDate.Direction = ParameterDirection.Output;
                pmtDate.Value = (object)tDate ?? DBNull.Value;
                pmtDate.ParameterName = "tDate";

                DbParameter pmuserName = command.CreateParameter();
                pmuserName.Direction = ParameterDirection.Output;
                pmuserName.Value = (object)userName ?? DBNull.Value;
                pmuserName.ParameterName = "userName";

                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmcompanyId);
                command.Parameters.Add(pmbranchID);
                command.Parameters.Add(pmledgerCode);
                command.Parameters.Add(pmledgerName);
                command.Parameters.Add(pmfDate);
                command.Parameters.Add(pmtDate);
                command.Parameters.Add(pmuserName);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }            
        }
        #endregion
        #region SalesGSTReport
        public static List<dynamic> GetSalesGSTReportDataList(string companyId, string branchID, string userName)
        {
            DataTable dt = GetSalesGSTReportDataTable(companyId, branchID, userName);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }

        public static DataTable GetSalesGSTReportDataTable(string companyId, string branchName, string userName)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_SalesGSTReport";
                #region Parameters
                DbParameter pmcompanyId = command.CreateParameter();
                pmcompanyId.Direction = ParameterDirection.Input;
                pmcompanyId.Value = (object)companyId ?? DBNull.Value;
                pmcompanyId.ParameterName = "companyId";

                DbParameter pmbranchID = command.CreateParameter();
                pmbranchID.Direction = ParameterDirection.Input;
                pmbranchID.Value = (object)branchName ?? DBNull.Value;
                pmbranchID.ParameterName = "branchName";

                DbParameter pmfDate = command.CreateParameter();
                pmfDate.Direction = ParameterDirection.Input;
                pmfDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmfDate.ParameterName = "fDate";

                DbParameter pmtDate = command.CreateParameter();
                pmtDate.Direction = ParameterDirection.Input;
                pmtDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmtDate.ParameterName = "tDate";

                DbParameter pmuserName = command.CreateParameter();
                pmuserName.Direction = ParameterDirection.Input;
                pmuserName.Value = (object)userName ?? DBNull.Value;
                pmuserName.ParameterName = "userName";

                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmcompanyId);
                command.Parameters.Add(pmbranchID);
                command.Parameters.Add(pmfDate);
                command.Parameters.Add(pmtDate);
                command.Parameters.Add(pmuserName);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region DailySalesReport
        public static List<dynamic> GetDailySalesReportDataList(string companyId, string branchID, string userName)
        {
            DataTable dt = GetDailySalesReportDataTable(companyId, branchID, userName);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }

        public static DataTable GetDailySalesReportDataTable(string companyId, string branchName, string userName)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetDailySalesReport";
                #region Parameters
                DbParameter pmcompanyId = command.CreateParameter();
                pmcompanyId.Direction = ParameterDirection.Input;
                pmcompanyId.Value = (object)companyId ?? DBNull.Value;
                pmcompanyId.ParameterName = "companyId";

                DbParameter pmbranchID = command.CreateParameter();
                pmbranchID.Direction = ParameterDirection.Input;
                pmbranchID.Value = (object)branchName ?? DBNull.Value;
                pmbranchID.ParameterName = "branchCode";

                DbParameter pmuserName = command.CreateParameter();
                pmuserName.Direction = ParameterDirection.Input;
                pmuserName.Value = (object)userName ?? DBNull.Value;
                pmuserName.ParameterName = "userName";

                DbParameter pmfDate = command.CreateParameter();
                pmfDate.Direction = ParameterDirection.Input;
                pmfDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmfDate.ParameterName = "fDate";

                DbParameter pmtDate = command.CreateParameter();
                pmtDate.Direction = ParameterDirection.Input;
                pmtDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmtDate.ParameterName = "tDate";

                

                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmcompanyId);
                command.Parameters.Add(pmbranchID);
                command.Parameters.Add(pmfDate);
                command.Parameters.Add(pmtDate);
                command.Parameters.Add(pmuserName);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region StockVerificationReport
        public static List<dynamic> GetStockVerificationReportDataList(string companyId, string branchID, string userName)
        {
            DataTable dt = GetStockVerificationReportDataTable(companyId, branchID, userName);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }

        public static DataTable GetStockVerificationReportDataTable(string companyId, string branchName, string userName)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_GetStockVerificationReport";
                #region Parameters
                DbParameter pmcompanyId = command.CreateParameter();
                pmcompanyId.Direction = ParameterDirection.Input;
                pmcompanyId.Value = (object)companyId ?? DBNull.Value;
                pmcompanyId.ParameterName = "companyId";

                DbParameter pmbranchID = command.CreateParameter();
                pmbranchID.Direction = ParameterDirection.Input;
                pmbranchID.Value = (object)branchName ?? DBNull.Value;
                pmbranchID.ParameterName = "branchCode";

                DbParameter pmuserName = command.CreateParameter();
                pmuserName.Direction = ParameterDirection.Input;
                pmuserName.Value = (object)userName ?? DBNull.Value;
                pmuserName.ParameterName = "userName";

                DbParameter pmfDate = command.CreateParameter();
                pmfDate.Direction = ParameterDirection.Input;
                pmfDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmfDate.ParameterName = "fDate";

                DbParameter pmtDate = command.CreateParameter();
                pmtDate.Direction = ParameterDirection.Input;
                pmtDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmtDate.ParameterName = "tDate";



                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmcompanyId);
                command.Parameters.Add(pmbranchID);
                command.Parameters.Add(pmfDate);
                command.Parameters.Add(pmtDate);
                command.Parameters.Add(pmuserName);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region SalesGSTReport
        public static List<dynamic> GetStockLedgerReportDataList(string branchID, string productCode)
        {
            DataTable dt = GetStockLedgerReportDataTable(branchID, productCode);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }

        public static DataTable GetStockLedgerReportDataTable(string branchId, string productCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_StockLedgerReport";
                #region Parameters
                DbParameter pmbranchID = command.CreateParameter();
                pmbranchID.Direction = ParameterDirection.Input;
                pmbranchID.Value = (object)branchId ?? DBNull.Value;
                pmbranchID.ParameterName = "branchId";

                DbParameter pmfDate = command.CreateParameter();
                pmfDate.Direction = ParameterDirection.Input;
                pmfDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmfDate.ParameterName = "fromDate";

                DbParameter pmtDate = command.CreateParameter();
                pmtDate.Direction = ParameterDirection.Input;
                pmtDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmtDate.ParameterName = "toDate";

                DbParameter pmuserName = command.CreateParameter();
                pmuserName.Direction = ParameterDirection.Input;
                pmuserName.Value = (object)productCode ?? DBNull.Value;
                pmuserName.ParameterName = "productCode";

                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmbranchID);
                command.Parameters.Add(pmfDate);
                command.Parameters.Add(pmtDate);
                command.Parameters.Add(pmuserName);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region SalesAnalysisByBranch
        public static List<dynamic> GetSalesAnalysisByBranchReportDataList(string branchID)
        {
            DataTable dt = GetSalesAnalysisByBranchReportDataTable(branchID);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }

        public static DataTable GetSalesAnalysisByBranchReportDataTable(string branchId)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_SalesAnalysisByBranch";
                #region Parameters
                DbParameter pmbranchID = command.CreateParameter();
                pmbranchID.Direction = ParameterDirection.Input;
                pmbranchID.Value = (object)branchId ?? DBNull.Value;
                pmbranchID.ParameterName = "branchCode";

                DbParameter pmfDate = command.CreateParameter();
                pmfDate.Direction = ParameterDirection.Input;
                pmfDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmfDate.ParameterName = "fDate";

                DbParameter pmtDate = command.CreateParameter();
                pmtDate.Direction = ParameterDirection.Input;
                pmtDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmtDate.ParameterName = "tDate";

                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmbranchID);
                command.Parameters.Add(pmfDate);
                command.Parameters.Add(pmtDate);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region 24hrs sales stock report
        public static List<dynamic> Get24hrsSalesStockReportDataList(string companyID,string branchID)
        {
            DataTable dt = Get24hrsSalesStockReportDataTable(companyID, branchID);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }

        public static DataTable Get24hrsSalesStockReportDataTable(string companyId, string branchId)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_StockReport";

                #region Parameters
                DbParameter pmCompanyID = command.CreateParameter();
                pmCompanyID.Direction = ParameterDirection.Input;
                pmCompanyID.Value = (object)companyId ?? DBNull.Value;
                pmCompanyID.ParameterName = "companyId";

                DbParameter pmbranchID = command.CreateParameter();
                pmbranchID.Direction = ParameterDirection.Input;
                pmbranchID.Value = (object)branchId ?? DBNull.Value;
                pmbranchID.ParameterName = "branchCode";

                DbParameter pmfDate = command.CreateParameter();
                pmfDate.Direction = ParameterDirection.Input;
                pmfDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmfDate.ParameterName = "fromDate";

                DbParameter pmtDate = command.CreateParameter();
                pmtDate.Direction = ParameterDirection.Input;
                pmtDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmtDate.ParameterName = "toDate";

                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmCompanyID);
                command.Parameters.Add(pmbranchID);
                command.Parameters.Add(pmfDate);
                command.Parameters.Add(pmtDate);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion
        #region ProductWiseMonthlyPurchaseReport
        public static List<dynamic> GetProductWiseMonthlyPurchaseReportDataList(string companyID, string branchID)
        {
            DataTable dt = GetProductWiseMonthlyPurchaseReportDataTable(companyID, branchID);
            if (dt.Rows.Count > 0)
            {
                List<dynamic> saleValue = ToDynamic(dt);
                return saleValue;
            }
            else return null;
        }

        public static DataTable GetProductWiseMonthlyPurchaseReportDataTable(string companyId, string branchId)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using (DbCommand command = scopeRepository.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Usp_ProductWiseMonthlyPurchaseReport";

                #region Parameters
                DbParameter pmCompanyID = command.CreateParameter();
                pmCompanyID.Direction = ParameterDirection.Input;
                pmCompanyID.Value = (object)companyId ?? DBNull.Value;
                pmCompanyID.ParameterName = "companyId";

                DbParameter pmfDate = command.CreateParameter();
                pmfDate.Direction = ParameterDirection.Input;
                pmfDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmfDate.ParameterName = "fDate";

                DbParameter pmtDate = command.CreateParameter();
                pmtDate.Direction = ParameterDirection.Input;
                pmtDate.Value = (object)DateTime.Now ?? DBNull.Value;
                pmtDate.ParameterName = "tDate";

                DbParameter pmbranchID = command.CreateParameter();
                pmbranchID.Direction = ParameterDirection.Input;
                pmbranchID.Value = (object)branchId ?? DBNull.Value;
                pmbranchID.ParameterName = "branchCode";

                
                #endregion
                // Add parameter as specified in the store procedure
                command.Parameters.Add(pmCompanyID);
                command.Parameters.Add(pmbranchID);
                command.Parameters.Add(pmfDate);
                command.Parameters.Add(pmtDate);
                DataTable dt = scopeRepository.ExecuteParamerizedCommand(command).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else return null;
            }
        }
        #endregion

        #region CommonMethods
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
        #endregion
    }
    public class parametersClass
    {
        public object paramValue { get; set; }
        public string paramName { get; set; }
        //ParameterDirection paramDirection { get; set; }
    }
}
