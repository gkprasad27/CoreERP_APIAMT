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

            DataTable dt = GetMemberMasterReportDataTable(includeMobileNumberOrNot, userID);
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
            parametersClass parameters = new parametersClass
            {
                paramName = "IncludeMblNumber",
                paramValue = includeMobileNumberOrNot
            };
            dbParametersList.Add(parameters);
            parameters = new parametersClass
            {
                paramName = "userID",
                paramValue = userID
            };
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
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetShiftViewReportDataList(string userName, string userID, string branchCode, string shiftId, DateTime fromDate, DateTime toDate, int reportID)
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
        public static DataSet GetShiftViewReportDataTable(string userName, string userID, string branchCode, string shiftId, DateTime fromDate, DateTime toDate, int reportID)
        {
            string procedureName = "";
            List<parametersClass> dbParametersList = new List<parametersClass>();
            parametersClass parameters = new parametersClass();
            if (reportID == 1)
            {
                parameters = new parametersClass
                {
                    paramName = "userID",
                    paramValue = userID
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "userName",
                    paramValue = userName
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "branchCode",
                    paramValue = branchCode
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "shiftId",
                    paramValue = shiftId
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "fromDate",
                    paramValue = fromDate
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "toDate",
                    paramValue = toDate
                };
                dbParametersList.Add(parameters);
            }
            else if (reportID == 2)
            {
                parameters = new parametersClass
                {
                    paramName = "userID",
                    paramValue = userID
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "shiftId",
                    paramValue = shiftId
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "fromDate",
                    paramValue = fromDate
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "toDate",
                    paramValue = toDate
                };
                dbParametersList.Add(parameters);
            }
            else if (reportID == 3 || reportID == 6)
            {
                parameters = new parametersClass
                {
                    paramName = "shiftId",
                    paramValue = shiftId
                };
                dbParametersList.Add(parameters);
            }
            else if (reportID == 4 || reportID == 5)
            {
                parameters = new parametersClass
                {
                    paramName = "shiftId",
                    paramValue = shiftId
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "UserID",
                    paramValue = userID
                };
                dbParametersList.Add(parameters);

                parameters = new parametersClass
                {
                    paramName = "ReportType"
                };
                if (reportID == 4)
                    parameters.paramValue = "HDFC";
                else if (reportID == 5)
                    parameters.paramValue = "Fleet";
                dbParametersList.Add(parameters);
                procedureName = "Usp_ShiftWiseFleetOrHDFCreport";
            }
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
            using DbCommand command = scopeRepository.CreateCommand();
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
        #endregion
        #region AccountLedgerReport
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetAccountLedgerReportDataList(string UserID, string ledgerCode, DateTime fromDate, DateTime toDate)
        {
            DataSet dsResult = GetAccountLedgerReportDataSet(UserID, ledgerCode, fromDate, toDate);
            List<dynamic> accountLedger = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
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
            else return (null, null, null);
        }
        public static DataSet GetAccountLedgerReportDataSet(string UserID, string ledgerCode, DateTime fromDate, DateTime toDate)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
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
            pmfromDate.ParameterName = "FromDate";

            DbParameter pmtoDate = command.CreateParameter();
            pmtoDate.Direction = ParameterDirection.Input;
            pmtoDate.Value = (object)toDate ?? DBNull.Value;
            pmtoDate.ParameterName = "ToDate";

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
        public static List<TblAccountLedger> GetAccountLedgers()
        {
            try
            {
                using Repository<TblAccountLedger> repo = new Repository<TblAccountLedger>();
                return repo.TblAccountLedger.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<TblBranch> GetReportBranches()
        {
            try
            {
                using Repository<TblBranch> repo = new Repository<TblBranch>();
                return repo.TblBranch.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<TblProduct> GetProducts()
        {
            try
            {
                using Repository<TblProduct> repo = new Repository<TblProduct>();
                return repo.TblProduct.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region SaleValueReport
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetSaleValueReportDataList(string userID, string branchCode, DateTime fromDate, DateTime toDate)
        {
            DataSet dsResult = GetSaleValueReportDataTable(userID, branchCode, fromDate, toDate);
            List<dynamic> saleValue = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    saleValue = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (saleValue, headerList, footerList);
            }
            else return (null, null, null);
        }
        public static DataSet GetSaleValueReportDataTable(string userID, string branchCode, DateTime fromDate, DateTime toDate)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Usp_GetSaleValueReport";
            #region Parameters
            DbParameter UserID = command.CreateParameter();
            UserID.Direction = ParameterDirection.Input;
            UserID.Value = (object)userID ?? DBNull.Value;
            UserID.ParameterName = "UserID";
            DbParameter dbpBranchCode = command.CreateParameter();
            dbpBranchCode.Direction = ParameterDirection.Input;
            dbpBranchCode.Value = (object)branchCode ?? DBNull.Value;
            dbpBranchCode.ParameterName = "branchCode";
            DbParameter pmFromDate = command.CreateParameter();
            pmFromDate.Direction = ParameterDirection.Input;
            pmFromDate.Value = (object)fromDate ?? DBNull.Value;
            pmFromDate.ParameterName = "fromDate";
            DbParameter pmToDate = command.CreateParameter();
            pmToDate.Direction = ParameterDirection.Input;
            pmToDate.Value = (object)toDate ?? DBNull.Value;
            pmToDate.ParameterName = "toDate";
            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(UserID);
            command.Parameters.Add(dbpBranchCode);
            command.Parameters.Add(pmFromDate);
            command.Parameters.Add(pmToDate);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        #endregion
        #region VehicalReport
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetVehicalReportDataList(string userID, string vehicleRegNo, DateTime fromDate, DateTime toDate)
        {
            DataSet dsResult = GetVehicalReportDataSet(userID, vehicleRegNo, fromDate, toDate);
            List<dynamic> vehicalValue = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    vehicalValue = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (vehicalValue, headerList, footerList);
            }
            else return (null, null, null);
        }
        public static DataSet GetVehicalReportDataSet(string userID, string vehicleRegNo, DateTime fromDate, DateTime toDate)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Usp_GetVehicleReport";
            #region Parameters
            DbParameter UserID = command.CreateParameter();
            UserID.Direction = ParameterDirection.Input;
            UserID.Value = (object)userID ?? DBNull.Value;
            UserID.ParameterName = "UserID";
            DbParameter pmVehicleRegNo = command.CreateParameter();
            pmVehicleRegNo.Direction = ParameterDirection.Input;
            pmVehicleRegNo.Value = (object)vehicleRegNo ?? DBNull.Value;
            pmVehicleRegNo.ParameterName = "vehicleRegNo";
            DbParameter pmFromDate = command.CreateParameter();
            pmFromDate.Direction = ParameterDirection.Input;
            pmFromDate.Value = (object)fromDate ?? DBNull.Value;
            pmFromDate.ParameterName = "fromDate";
            DbParameter pmToDate = command.CreateParameter();
            pmToDate.Direction = ParameterDirection.Input;
            pmToDate.Value = (object)toDate ?? DBNull.Value;
            pmToDate.ParameterName = "toDate";
            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(pmVehicleRegNo);
            command.Parameters.Add(pmFromDate);
            command.Parameters.Add(pmToDate);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        #endregion
        #region IntimateSaleReport
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetIntimateSaleReportDataList(string ledgerCode, DateTime fromDate, DateTime toDate, string UserID)
        {
            DataSet dsResult = GetIntimateSaleReportDataSet(ledgerCode, fromDate, toDate, UserID);
            List<dynamic> saleValue = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    saleValue = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (saleValue, headerList, footerList);
            }
            else return (null, null, null);
        }

        public static DataSet GetIntimateSaleReportDataSet(string ledgerCode, DateTime fromDate, DateTime toDate, string UserID)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Usp_GetIntimateSaleReport";
            #region Parameters
            DbParameter pmledgerCode = command.CreateParameter();
            pmledgerCode.Direction = ParameterDirection.Input;
            pmledgerCode.Value = (object)ledgerCode ?? DBNull.Value;
            pmledgerCode.ParameterName = "ledgerCode";

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = (object)fromDate ?? DBNull.Value;
            pmfDate.ParameterName = "fromDate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = (object)toDate ?? DBNull.Value;
            pmtDate.ParameterName = "toDate";

            DbParameter pmuserName = command.CreateParameter();
            pmuserName.Direction = ParameterDirection.Input;
            pmuserName.Value = (object)UserID ?? DBNull.Value;
            pmuserName.ParameterName = "UserID";

            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(pmledgerCode);
            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(pmuserName);
            return scopeRepository.ExecuteParamerizedCommand(command);
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
            using DbCommand command = scopeRepository.CreateCommand();
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
            using DbCommand command = scopeRepository.CreateCommand();
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
        #endregion
        #region StockVerificationReport
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetStockVerificationReportDataList(string branchCode, string UserID, DateTime fromDate, DateTime toDate)
        {
            DataSet dsResult = GetStockVerificationReportDataSet(branchCode, UserID, fromDate, toDate);
            List<dynamic> saleValue = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    saleValue = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (saleValue, headerList, footerList);
            }
            else return (null, null, null);
        }

        public static DataSet GetStockVerificationReportDataSet(string branchCode, string UserID, DateTime fromDate, DateTime toDate)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Usp_GetStockVerificationReport";
            #region Parameters
            DbParameter pmbranchID = command.CreateParameter();
            pmbranchID.Direction = ParameterDirection.Input;
            pmbranchID.Value = (object)branchCode ?? DBNull.Value;
            pmbranchID.ParameterName = "branchCode";

            DbParameter pmuserName = command.CreateParameter();
            pmuserName.Direction = ParameterDirection.Input;
            pmuserName.Value = (object)UserID ?? DBNull.Value;
            pmuserName.ParameterName = "UserID";

            DbParameter pmFromDate = command.CreateParameter();
            pmFromDate.Direction = ParameterDirection.Input;
            pmFromDate.Value = (object)fromDate ?? DBNull.Value;
            pmFromDate.ParameterName = "fromDate";

            DbParameter pmToDate = command.CreateParameter();
            pmToDate.Direction = ParameterDirection.Input;
            pmToDate.Value = (object)toDate ?? DBNull.Value;
            pmToDate.ParameterName = "toDate";
            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(pmbranchID);
            command.Parameters.Add(pmFromDate);
            command.Parameters.Add(pmToDate);
            command.Parameters.Add(pmuserName);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        #endregion
        #region SalesGSTReport
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetStockLedgerReportDataList(string branchCode, string productCode, DateTime fromDate, DateTime toDate, string UserID)
        {
            DataSet dsResult = GetStockLedgerReportDataSet(branchCode, productCode, fromDate, toDate, UserID);
            List<dynamic> saleValue = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    saleValue = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (saleValue, headerList, footerList);
            }
            else return (null, null, null);
        }

        public static DataSet GetStockLedgerReportDataSet(string branchCode, string productCode, DateTime fromDate, DateTime toDate, string UserID)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Usp_StockLedgerReport";
            #region Parameters
            DbParameter pmbranchID = command.CreateParameter();
            pmbranchID.Direction = ParameterDirection.Input;
            pmbranchID.Value = (object)branchCode ?? DBNull.Value;
            pmbranchID.ParameterName = "branchCode";

            DbParameter pmProductCode = command.CreateParameter();
            pmProductCode.Direction = ParameterDirection.Input;
            pmProductCode.Value = (object)productCode ?? DBNull.Value;
            pmProductCode.ParameterName = "productCode";

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = (object)fromDate ?? DBNull.Value;
            pmfDate.ParameterName = "fromDate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = (object)toDate ?? DBNull.Value;
            pmtDate.ParameterName = "toDate";

            DbParameter pmuserName = command.CreateParameter();
            pmuserName.Direction = ParameterDirection.Input;
            pmuserName.Value = (object)UserID ?? DBNull.Value;
            pmuserName.ParameterName = "UserID";

            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(pmbranchID);
            command.Parameters.Add(pmProductCode);
            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(pmuserName);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        #endregion
        #region SalesAnalysisByBranch
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetSalesAnalysisByBranchReportDataList(string branchCode, DateTime fromDate, DateTime toDate,string userID)
        {
            DataSet dsResult = GetSalesAnalysisByBranchReportDataSet(branchCode,fromDate,toDate, userID);
            List<dynamic> saleValue = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    saleValue = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (saleValue, headerList, footerList);
            }
            else return (null, null, null);
        }

        public static DataSet GetSalesAnalysisByBranchReportDataSet(string branchCode,DateTime fromDate,DateTime toDate,string userID)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Usp_SalesAnalysisByBranch";
            #region Parameters
            DbParameter pmbranchID = command.CreateParameter();
            pmbranchID.Direction = ParameterDirection.Input;
            pmbranchID.Value = (object)branchCode ?? DBNull.Value;
            pmbranchID.ParameterName = "branchCode";

            DbParameter pmfDate = command.CreateParameter();
            pmfDate.Direction = ParameterDirection.Input;
            pmfDate.Value = (object)fromDate ?? DBNull.Value;
            pmfDate.ParameterName = "fromDate";

            DbParameter pmtDate = command.CreateParameter();
            pmtDate.Direction = ParameterDirection.Input;
            pmtDate.Value = (object)toDate ?? DBNull.Value;
            pmtDate.ParameterName = "toDate";

            DbParameter UserID = command.CreateParameter();
            UserID.Direction = ParameterDirection.Input;
            UserID.Value = (object)userID ?? DBNull.Value;
            UserID.ParameterName = "UserID";
            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(pmbranchID);
            command.Parameters.Add(pmfDate);
            command.Parameters.Add(pmtDate);
            command.Parameters.Add(UserID);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        #endregion
        #region 24hrs sales stock report
        public static (List<dynamic>, List<dynamic>, List<dynamic>) Get24hrsSalesStockReportDataList(string userID, DateTime fromDate, DateTime toDate, string branchCode)
        {
            DataSet dsResult = Get24hrsSalesStockReportDataTable(userID, fromDate, toDate, branchCode);
            List<dynamic> saleValue = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    saleValue = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (saleValue, headerList, footerList);
            }
            else return (null, null, null);
        }

        public static DataSet Get24hrsSalesStockReportDataTable(string userID, DateTime fromDate, DateTime toDate, string branchCode)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Usp_StockReport";

            #region Parameters
            DbParameter UserID = command.CreateParameter();
            UserID.Direction = ParameterDirection.Input;
            UserID.Value = (object)userID ?? DBNull.Value;
            UserID.ParameterName = "UserID";
            DbParameter dbpBranchCode = command.CreateParameter();
            dbpBranchCode.Direction = ParameterDirection.Input;
            dbpBranchCode.Value = (object)branchCode ?? DBNull.Value;
            dbpBranchCode.ParameterName = "branchCode";
            DbParameter pmFromDate = command.CreateParameter();
            pmFromDate.Direction = ParameterDirection.Input;
            pmFromDate.Value = (object)fromDate ?? DBNull.Value;
            pmFromDate.ParameterName = "fromDate";
            DbParameter pmToDate = command.CreateParameter();
            pmToDate.Direction = ParameterDirection.Input;
            pmToDate.Value = (object)toDate ?? DBNull.Value;
            pmToDate.ParameterName = "toDate";
            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(UserID);
            command.Parameters.Add(dbpBranchCode);
            command.Parameters.Add(pmFromDate);
            command.Parameters.Add(pmToDate);
            return scopeRepository.ExecuteParamerizedCommand(command);
        }
        #endregion
        #region ProductWiseMonthlyPurchaseReport
        public static (List<dynamic>, List<dynamic>, List<dynamic>) GetProductWiseMonthlyPurchaseReportDataList(string userID, DateTime fromDate, DateTime toDate)
        {
            DataSet dsResult = GetProductWiseMonthlyPurchaseReportDataSet(userID, fromDate,toDate);
            List<dynamic> saleValue = null;
            List<dynamic> headerList = null;
            List<dynamic> footerList = null;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
                {
                    saleValue = ToDynamic(dsResult.Tables[0]);
                }
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    headerList = ToDynamic(dsResult.Tables[1]);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    footerList = ToDynamic(dsResult.Tables[2]);
                }
                return (saleValue, headerList, footerList);
            }
            else return (null, null, null);
        }

        public static DataSet GetProductWiseMonthlyPurchaseReportDataSet(string userID, DateTime fromDate,DateTime toDate)
        {
            ScopeRepository scopeRepository = new ScopeRepository();
            // As we  cannot instantiate a DbCommand because it is an abstract base class created from the repository with context connection.
            using DbCommand command = scopeRepository.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Usp_ProductWiseMonthlyPurchaseReport";

            #region Parameters
            DbParameter UserID = command.CreateParameter();
            UserID.Direction = ParameterDirection.Input;
            UserID.Value = (object)userID ?? DBNull.Value;
            UserID.ParameterName = "UserID";

            DbParameter pmFromDate = command.CreateParameter();
            pmFromDate.Direction = ParameterDirection.Input;
            pmFromDate.Value = (object)fromDate ?? DBNull.Value;
            pmFromDate.ParameterName = "fromDate";

            DbParameter pmToDate = command.CreateParameter();
            pmToDate.Direction = ParameterDirection.Input;
            pmToDate.Value = (object)toDate ?? DBNull.Value;
            pmToDate.ParameterName = "toDate";

            #endregion
            // Add parameter as specified in the store procedure
            command.Parameters.Add(UserID);
            command.Parameters.Add(pmFromDate);
            command.Parameters.Add(pmToDate);
            return scopeRepository.ExecuteParamerizedCommand(command);
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
