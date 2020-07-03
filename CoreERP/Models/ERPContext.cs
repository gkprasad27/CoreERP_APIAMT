using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreERP.Models
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountingClass> AccountingClass { get; set; }
        public virtual DbSet<ApplyOddata> ApplyOddata { get; set; }
        public virtual DbSet<AsignmentAcctoAccClass> AsignmentAcctoAccClass { get; set; }
        public virtual DbSet<AsignmentCashAccBranch> AsignmentCashAccBranch { get; set; }
        public virtual DbSet<AttendanceData> AttendanceData { get; set; }
        public virtual DbSet<AttendanceDataold> AttendanceDataold { get; set; }
        public virtual DbSet<CashInOutFlow1> CashInOutFlow1 { get; set; }
        public virtual DbSet<ComponentMaster> ComponentMaster { get; set; }
        public virtual DbSet<ConfigurationTable> ConfigurationTable { get; set; }
        public virtual DbSet<CostCenters> CostCenters { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Ctcbreakup> Ctcbreakup { get; set; }
        public virtual DbSet<DividentTest> DividentTest { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<EmployeeInBranches> EmployeeInBranches { get; set; }
        public virtual DbSet<ErpConfiguration> ErpConfiguration { get; set; }
        public virtual DbSet<Erpuser> Erpuser { get; set; }
        public virtual DbSet<FourCoulmnRoundOff> FourCoulmnRoundOff { get; set; }
        public virtual DbSet<GlaccGroup> GlaccGroup { get; set; }
        public virtual DbSet<Glaccounts> Glaccounts { get; set; }
        public virtual DbSet<Health559> Health559 { get; set; }
        public virtual DbSet<LeaveApplDetails> LeaveApplDetails { get; set; }
        public virtual DbSet<LeaveBalanceMaster> LeaveBalanceMaster { get; set; }
        public virtual DbSet<LeaveTypes> LeaveTypes { get; set; }
        public virtual DbSet<MatTranTypes> MatTranTypes { get; set; }
        public virtual DbSet<MenuAccesses> MenuAccesses { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<NoSeries> NoSeries { get; set; }
        public virtual DbSet<PartnerCreation> PartnerCreation { get; set; }
        public virtual DbSet<PartnerType> PartnerType { get; set; }
        public virtual DbSet<PayrollCycle> PayrollCycle { get; set; }
        public virtual DbSet<Pfmaster> Pfmaster { get; set; }
        public virtual DbSet<ProfitCenters> ProfitCenters { get; set; }
        public virtual DbSet<Ptmaster> Ptmaster { get; set; }
        public virtual DbSet<RebateSus558> RebateSus558 { get; set; }
        public virtual DbSet<Roundtest> Roundtest { get; set; }
        public virtual DbSet<SalaryEarnDedn> SalaryEarnDedn { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<Sheet1> Sheet1 { get; set; }
        public virtual DbSet<Sheet1Openig> Sheet1Openig { get; set; }
        public virtual DbSet<Sheet1Stock> Sheet1Stock { get; set; }
        public virtual DbSet<Smsstatus> Smsstatus { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<StructureComponents> StructureComponents { get; set; }
        public virtual DbSet<StructureCreation> StructureCreation { get; set; }
        public virtual DbSet<TaxIntegration> TaxIntegration { get; set; }
        public virtual DbSet<TaxMasters> TaxMasters { get; set; }
        public virtual DbSet<TblAccountGroup> TblAccountGroup { get; set; }
        public virtual DbSet<TblAccountGroupToCopy> TblAccountGroupToCopy { get; set; }
        public virtual DbSet<TblAccountLedger> TblAccountLedger { get; set; }
        public virtual DbSet<TblAccountLedgerToCopy> TblAccountLedgerToCopy { get; set; }
        public virtual DbSet<TblAccountLedgerTransactions> TblAccountLedgerTransactions { get; set; }
        public virtual DbSet<TblAccountType> TblAccountType { get; set; }
        public virtual DbSet<TblAdditionalCost> TblAdditionalCost { get; set; }
        public virtual DbSet<TblAdditionalShareTransfer> TblAdditionalShareTransfer { get; set; }
        public virtual DbSet<TblAdvance> TblAdvance { get; set; }
        public virtual DbSet<TblAdvancePayment> TblAdvancePayment { get; set; }
        public virtual DbSet<TblAdvanceType> TblAdvanceType { get; set; }
        public virtual DbSet<TblArea> TblArea { get; set; }
        public virtual DbSet<TblBankPaymentDetails> TblBankPaymentDetails { get; set; }
        public virtual DbSet<TblBankPaymentMaster> TblBankPaymentMaster { get; set; }
        public virtual DbSet<TblBankReceiptDetails> TblBankReceiptDetails { get; set; }
        public virtual DbSet<TblBankReceiptMaster> TblBankReceiptMaster { get; set; }
        public virtual DbSet<TblBankReconciliation> TblBankReconciliation { get; set; }
        public virtual DbSet<TblBarcodeSettings> TblBarcodeSettings { get; set; }
        public virtual DbSet<TblBatch> TblBatch { get; set; }
        public virtual DbSet<TblBom> TblBom { get; set; }
        public virtual DbSet<TblBonusDeduction> TblBonusDeduction { get; set; }
        public virtual DbSet<TblBranch> TblBranch { get; set; }
        public virtual DbSet<TblBrand> TblBrand { get; set; }
        public virtual DbSet<TblBudgetDetails> TblBudgetDetails { get; set; }
        public virtual DbSet<TblBudgetMaster> TblBudgetMaster { get; set; }
        public virtual DbSet<TblCashPaymentDetails> TblCashPaymentDetails { get; set; }
        public virtual DbSet<TblCashPaymentMaster> TblCashPaymentMaster { get; set; }
        public virtual DbSet<TblCashReceiptDetails> TblCashReceiptDetails { get; set; }
        public virtual DbSet<TblCashReceiptMaster> TblCashReceiptMaster { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblCompanyPath> TblCompanyPath { get; set; }
        public virtual DbSet<TblContraDetails> TblContraDetails { get; set; }
        public virtual DbSet<TblContraMaster> TblContraMaster { get; set; }
        public virtual DbSet<TblCounter> TblCounter { get; set; }
        public virtual DbSet<TblCreditNoteDetails> TblCreditNoteDetails { get; set; }
        public virtual DbSet<TblCreditNoteMaster> TblCreditNoteMaster { get; set; }
        public virtual DbSet<TblCurrency> TblCurrency { get; set; }
        public virtual DbSet<TblCurrencyToCopy> TblCurrencyToCopy { get; set; }
        public virtual DbSet<TblCurrentTransation> TblCurrentTransation { get; set; }
        public virtual DbSet<TblDailyAttendanceDetails> TblDailyAttendanceDetails { get; set; }
        public virtual DbSet<TblDailyAttendanceMaster> TblDailyAttendanceMaster { get; set; }
        public virtual DbSet<TblDailySalaryVoucherDetails> TblDailySalaryVoucherDetails { get; set; }
        public virtual DbSet<TblDailySalaryVoucherMaster> TblDailySalaryVoucherMaster { get; set; }
        public virtual DbSet<TblDebitNoteDetails> TblDebitNoteDetails { get; set; }
        public virtual DbSet<TblDebitNoteMaster> TblDebitNoteMaster { get; set; }
        public virtual DbSet<TblDeliveryNoteDetails> TblDeliveryNoteDetails { get; set; }
        public virtual DbSet<TblDeliveryNoteMaster> TblDeliveryNoteMaster { get; set; }
        public virtual DbSet<TblDesignation> TblDesignation { get; set; }
        public virtual DbSet<TblDetails> TblDetails { get; set; }
        public virtual DbSet<TblDetailsCopy> TblDetailsCopy { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEmployeeAttendance> TblEmployeeAttendance { get; set; }
        public virtual DbSet<TblEmployeeMaster> TblEmployeeMaster { get; set; }
        public virtual DbSet<TblExchangeRate> TblExchangeRate { get; set; }
        public virtual DbSet<TblFields> TblFields { get; set; }
        public virtual DbSet<TblFieldsCopy> TblFieldsCopy { get; set; }
        public virtual DbSet<TblFinancialYear> TblFinancialYear { get; set; }
        public virtual DbSet<TblForm> TblForm { get; set; }
        public virtual DbSet<TblFormCopy> TblFormCopy { get; set; }
        public virtual DbSet<TblFormMenuCollection> TblFormMenuCollection { get; set; }
        public virtual DbSet<TblGodown> TblGodown { get; set; }
        public virtual DbSet<TblHoliday> TblHoliday { get; set; }
        public virtual DbSet<TblInvoiceDetail> TblInvoiceDetail { get; set; }
        public virtual DbSet<TblInvoiceMaster> TblInvoiceMaster { get; set; }
        public virtual DbSet<TblInvoiceMasterReturn> TblInvoiceMasterReturn { get; set; }
        public virtual DbSet<TblInvoiceReturnDetail> TblInvoiceReturnDetail { get; set; }
        public virtual DbSet<TblJournalVoucherDetails> TblJournalVoucherDetails { get; set; }
        public virtual DbSet<TblJournalVoucherMaster> TblJournalVoucherMaster { get; set; }
        public virtual DbSet<TblLedgerPosting> TblLedgerPosting { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblMaster> TblMaster { get; set; }
        public virtual DbSet<TblMasterCopy> TblMasterCopy { get; set; }
        public virtual DbSet<TblMaterialReceiptDetails> TblMaterialReceiptDetails { get; set; }
        public virtual DbSet<TblMaterialReceiptMaster> TblMaterialReceiptMaster { get; set; }
        public virtual DbSet<TblMemberMaster> TblMemberMaster { get; set; }
        public virtual DbSet<TblMeterReading> TblMeterReading { get; set; }
        public virtual DbSet<TblModelNo> TblModelNo { get; set; }
        public virtual DbSet<TblMonthList> TblMonthList { get; set; }
        public virtual DbSet<TblMonthListForReports> TblMonthListForReports { get; set; }
        public virtual DbSet<TblMonthlySalary> TblMonthlySalary { get; set; }
        public virtual DbSet<TblMonthlySalaryDetails> TblMonthlySalaryDetails { get; set; }
        public virtual DbSet<TblMshsdrates> TblMshsdrates { get; set; }
        public virtual DbSet<TblOilConversionDetails> TblOilConversionDetails { get; set; }
        public virtual DbSet<TblOilConversionMaster> TblOilConversionMaster { get; set; }
        public virtual DbSet<TblOpeningBalance> TblOpeningBalance { get; set; }
        public virtual DbSet<TblOperatorStockIssues> TblOperatorStockIssues { get; set; }
        public virtual DbSet<TblOperatorStockIssuesDetail> TblOperatorStockIssuesDetail { get; set; }
        public virtual DbSet<TblOperatorStockReceipt> TblOperatorStockReceipt { get; set; }
        public virtual DbSet<TblOperatorStockReceiptDetail> TblOperatorStockReceiptDetail { get; set; }
        public virtual DbSet<TblPackageConversion> TblPackageConversion { get; set; }
        public virtual DbSet<TblPartyBalance> TblPartyBalance { get; set; }
        public virtual DbSet<TblPassbookStatus> TblPassbookStatus { get; set; }
        public virtual DbSet<TblPayHead> TblPayHead { get; set; }
        public virtual DbSet<TblPaymentDetails> TblPaymentDetails { get; set; }
        public virtual DbSet<TblPaymentMaster> TblPaymentMaster { get; set; }
        public virtual DbSet<TblPaymentType> TblPaymentType { get; set; }
        public virtual DbSet<TblPdcclearanceMaster> TblPdcclearanceMaster { get; set; }
        public virtual DbSet<TblPdcpayableMaster> TblPdcpayableMaster { get; set; }
        public virtual DbSet<TblPdcreceivableMaster> TblPdcreceivableMaster { get; set; }
        public virtual DbSet<TblPhysicalStockDetails> TblPhysicalStockDetails { get; set; }
        public virtual DbSet<TblPhysicalStockMaster> TblPhysicalStockMaster { get; set; }
        public virtual DbSet<TblPriceList> TblPriceList { get; set; }
        public virtual DbSet<TblPricingLevel> TblPricingLevel { get; set; }
        public virtual DbSet<TblPrivilege> TblPrivilege { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblProductGroup> TblProductGroup { get; set; }
        public virtual DbSet<TblProductPacking> TblProductPacking { get; set; }
        public virtual DbSet<TblPumps> TblPumps { get; set; }
        public virtual DbSet<TblPurchaseInvoice> TblPurchaseInvoice { get; set; }
        public virtual DbSet<TblPurchaseInvoiceDetail> TblPurchaseInvoiceDetail { get; set; }
        public virtual DbSet<TblPurchaseOrderDetails> TblPurchaseOrderDetails { get; set; }
        public virtual DbSet<TblPurchaseOrderMaster> TblPurchaseOrderMaster { get; set; }
        public virtual DbSet<TblPurchaseReturn> TblPurchaseReturn { get; set; }
        public virtual DbSet<TblPurchaseReturnDetails> TblPurchaseReturnDetails { get; set; }
        public virtual DbSet<TblQuickLaunchItems> TblQuickLaunchItems { get; set; }
        public virtual DbSet<TblQuickLaunchItemsToCopy> TblQuickLaunchItemsToCopy { get; set; }
        public virtual DbSet<TblRack> TblRack { get; set; }
        public virtual DbSet<TblRebateMaster> TblRebateMaster { get; set; }
        public virtual DbSet<TblRebateType> TblRebateType { get; set; }
        public virtual DbSet<TblReceiptDetails> TblReceiptDetails { get; set; }
        public virtual DbSet<TblReceiptMaster> TblReceiptMaster { get; set; }
        public virtual DbSet<TblRejectionInDetails> TblRejectionInDetails { get; set; }
        public virtual DbSet<TblRejectionInMaster> TblRejectionInMaster { get; set; }
        public virtual DbSet<TblRejectionOutDetails> TblRejectionOutDetails { get; set; }
        public virtual DbSet<TblRejectionOutMaster> TblRejectionOutMaster { get; set; }
        public virtual DbSet<TblRelation> TblRelation { get; set; }
        public virtual DbSet<TblReminder> TblReminder { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblRolePrivilegeForm> TblRolePrivilegeForm { get; set; }
        public virtual DbSet<TblRolePrivilegeMenu> TblRolePrivilegeMenu { get; set; }
        public virtual DbSet<TblRoute> TblRoute { get; set; }
        public virtual DbSet<TblSalaryPackage> TblSalaryPackage { get; set; }
        public virtual DbSet<TblSalaryPackageDetails> TblSalaryPackageDetails { get; set; }
        public virtual DbSet<TblSalaryParameters> TblSalaryParameters { get; set; }
        public virtual DbSet<TblSalaryProcessData> TblSalaryProcessData { get; set; }
        public virtual DbSet<TblSalaryVoucherDetails> TblSalaryVoucherDetails { get; set; }
        public virtual DbSet<TblSalaryVoucherMaster> TblSalaryVoucherMaster { get; set; }
        public virtual DbSet<TblSalesBillTax> TblSalesBillTax { get; set; }
        public virtual DbSet<TblSalesDetails> TblSalesDetails { get; set; }
        public virtual DbSet<TblSalesMaster> TblSalesMaster { get; set; }
        public virtual DbSet<TblSalesOrderDetails> TblSalesOrderDetails { get; set; }
        public virtual DbSet<TblSalesOrderMaster> TblSalesOrderMaster { get; set; }
        public virtual DbSet<TblSalesQuotationDetails> TblSalesQuotationDetails { get; set; }
        public virtual DbSet<TblSalesQuotationMaster> TblSalesQuotationMaster { get; set; }
        public virtual DbSet<TblSalesReturnBillTax> TblSalesReturnBillTax { get; set; }
        public virtual DbSet<TblSalesReturnDetails> TblSalesReturnDetails { get; set; }
        public virtual DbSet<TblSalesReturnMaster> TblSalesReturnMaster { get; set; }
        public virtual DbSet<TblService> TblService { get; set; }
        public virtual DbSet<TblServiceCategory> TblServiceCategory { get; set; }
        public virtual DbSet<TblServiceDetails> TblServiceDetails { get; set; }
        public virtual DbSet<TblServiceMaster> TblServiceMaster { get; set; }
        public virtual DbSet<TblSettings> TblSettings { get; set; }
        public virtual DbSet<TblSettingsToCopy> TblSettingsToCopy { get; set; }
        public virtual DbSet<TblShareTransfer> TblShareTransfer { get; set; }
        public virtual DbSet<TblShareValue> TblShareValue { get; set; }
        public virtual DbSet<TblShift> TblShift { get; set; }
        public virtual DbSet<TblShiftTimings> TblShiftTimings { get; set; }
        public virtual DbSet<TblSize> TblSize { get; set; }
        public virtual DbSet<TblStandardRate> TblStandardRate { get; set; }
        public virtual DbSet<TblStateWiseGst> TblStateWiseGst { get; set; }
        public virtual DbSet<TblStockEntry> TblStockEntry { get; set; }
        public virtual DbSet<TblStockEntryDetail> TblStockEntryDetail { get; set; }
        public virtual DbSet<TblStockEntryMaster> TblStockEntryMaster { get; set; }
        public virtual DbSet<TblStockExcessDetails> TblStockExcessDetails { get; set; }
        public virtual DbSet<TblStockExcessMaster> TblStockExcessMaster { get; set; }
        public virtual DbSet<TblStockInformation> TblStockInformation { get; set; }
        public virtual DbSet<TblStockJournalDetails> TblStockJournalDetails { get; set; }
        public virtual DbSet<TblStockJournalMaster> TblStockJournalMaster { get; set; }
        public virtual DbSet<TblStockPosting> TblStockPosting { get; set; }
        public virtual DbSet<TblStockTransfer> TblStockTransfer { get; set; }
        public virtual DbSet<TblStockTransferDetail> TblStockTransferDetail { get; set; }
        public virtual DbSet<TblStockTransferMaster> TblStockTransferMaster { get; set; }
        public virtual DbSet<TblStockshortDetails> TblStockshortDetails { get; set; }
        public virtual DbSet<TblStockshortMaster> TblStockshortMaster { get; set; }
        public virtual DbSet<TblSuffixPrefix> TblSuffixPrefix { get; set; }
        public virtual DbSet<TblSupplierGroup> TblSupplierGroup { get; set; }
        public virtual DbSet<TblTanks> TblTanks { get; set; }
        public virtual DbSet<TblTax> TblTax { get; set; }
        public virtual DbSet<TblTaxDetails> TblTaxDetails { get; set; }
        public virtual DbSet<TblTaxGroup> TblTaxGroup { get; set; }
        public virtual DbSet<TblTaxStructure> TblTaxStructure { get; set; }
        public virtual DbSet<TblTaxapplicableOn> TblTaxapplicableOn { get; set; }
        public virtual DbSet<TblTitle> TblTitle { get; set; }
        public virtual DbSet<TblUnit> TblUnit { get; set; }
        public virtual DbSet<TblUnitConvertion> TblUnitConvertion { get; set; }
        public virtual DbSet<TblUnitSample> TblUnitSample { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserBranch> TblUserBranch { get; set; }
        public virtual DbSet<TblUserNew> TblUserNew { get; set; }
        public virtual DbSet<TblUserProductBranch> TblUserProductBranch { get; set; }
        public virtual DbSet<TblUserRolePrivilege> TblUserRolePrivilege { get; set; }
        public virtual DbSet<TblUserTest> TblUserTest { get; set; }
        public virtual DbSet<TblVchType> TblVchType { get; set; }
        public virtual DbSet<TblVehicle> TblVehicle { get; set; }
        public virtual DbSet<TblVehicleType> TblVehicleType { get; set; }
        public virtual DbSet<TblVoucherDetail> TblVoucherDetail { get; set; }
        public virtual DbSet<TblVoucherMaster> TblVoucherMaster { get; set; }
        public virtual DbSet<TblVoucherType> TblVoucherType { get; set; }
        public virtual DbSet<TblVoucherTypeTax> TblVoucherTypeTax { get; set; }
        public virtual DbSet<TblVoucherTypeToCopy> TblVoucherTypeToCopy { get; set; }
        public virtual DbSet<TblVoucherTypes> TblVoucherTypes { get; set; }
        public virtual DbSet<Temp> Temp { get; set; }
        public virtual DbSet<Temp1> Temp1 { get; set; }
        public virtual DbSet<Temp81> Temp81 { get; set; }
        public virtual DbSet<VehicleDummy> VehicleDummy { get; set; }
        public virtual DbSet<View1> View1 { get; set; }
        public virtual DbSet<ViewCashBank> ViewCashBank { get; set; }
        public virtual DbSet<VoucherClass> VoucherClass { get; set; }
        public virtual DbSet<VoucherTypes> VoucherTypes { get; set; }
        public virtual DbSet<VwMaxRate> VwMaxRate { get; set; }
        public virtual DbSet<VwMinRate> VwMinRate { get; set; }
        public virtual DbSet<VwStockQuery> VwStockQuery { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.1.91;Database=ERP;User Id=sa; pwd=Kanchari#123; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountingClass>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Type).HasMaxLength(10);
            });

            modelBuilder.Entity<ApplyOddata>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("ApplyODData");

                entity.Property(e => e.AcceptedBy)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ApplDate)
                    .HasColumnName("Appl_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprBy)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ApprDate).HasColumnType("datetime");

                entity.Property(e => e.ApprStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApproveName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedId)
                    .HasColumnName("ApprovedID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate)
                    .HasColumnName("From_Date")
                    .HasColumnType("date");

                entity.Property(e => e.FromTime)
                    .HasColumnName("From_Time")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RecBy)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RecDate).HasColumnType("datetime");

                entity.Property(e => e.RecStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RejectedId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RejectedName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReportId)
                    .HasColumnName("ReportID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Skip)
                    .HasColumnName("skip")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.ToDate)
                    .HasColumnName("To_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ToTime)
                    .HasColumnName("To_Time")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VisitingPlace)
                    .HasColumnName("Visiting_Place")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VisitingPlacePurpus)
                    .HasColumnName("Visiting_PlacePurpus")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AsignmentAcctoAccClass>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.AccClass).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.InventoryAcc).HasMaxLength(50);

                entity.Property(e => e.PurchaseAcc).HasMaxLength(50);

                entity.Property(e => e.SaleAcc).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);
            });

            modelBuilder.Entity<AsignmentCashAccBranch>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BankGlacc)
                    .HasColumnName("BankGLAcc")
                    .HasMaxLength(8);

                entity.Property(e => e.BranchCode).HasMaxLength(30);

                entity.Property(e => e.CashGlacc)
                    .HasColumnName("CashGLAcc")
                    .HasMaxLength(8);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);
            });

            modelBuilder.Entity<AttendanceData>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.DeviceAddress)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.InAndOut)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Ouname)
                    .IsRequired()
                    .HasColumnName("OUName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PullStatus).HasMaxLength(50);

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AttendanceDataold>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.InAndOut)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.PullStatus).HasMaxLength(50);

                entity.Property(e => e.TerminalId)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CashInOutFlow1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CashInOutFlow1");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ComponentMaster>(entity =>
            {
                entity.HasKey(e => e.ComponentCode);

                entity.Property(e => e.ComponentCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpecificMonth)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConfigurationTable>(entity =>
            {
                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConfigurationType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CostCenters>(entity =>
            {
                entity.HasKey(e => new { e.Code, e.CompCode });

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Address1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address4)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsiblePerson)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Ctcbreakup>(entity =>
            {
                entity.ToTable("CTCBreakup");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ctc).HasColumnName("CTC");

                entity.Property(e => e.CycleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EarnDednCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EarnDednName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EffectFrom).HasColumnType("date");

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpGrp)
                    .HasColumnName("Emp_Grp")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.SpecificMonth)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StructureName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Upload)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usrid)
                    .HasColumnName("USRID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DividentTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DividentTest$");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Final).HasColumnName("final");

                entity.Property(e => e.PartyId)
                    .HasColumnName("party_id")
                    .HasMaxLength(255);

                entity.Property(e => e.PartyName)
                    .HasColumnName("party_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Payment)
                    .HasColumnName("payment")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Divisions>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(40);
            });

            modelBuilder.Entity<EmployeeInBranches>(entity =>
            {
                entity.HasKey(e => e.SeqId)
                    .HasName("PK_EmployeeInBranches_1");

                entity.Property(e => e.SeqId).HasColumnName("SeqID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);
            });

            modelBuilder.Entity<ErpConfiguration>(entity =>
            {
                entity.HasKey(e => e.SequenceId);

                entity.ToTable("ERP_Configuration");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.KeyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Module)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Screen)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Values).IsUnicode(false);
            });

            modelBuilder.Entity<Erpuser>(entity =>
            {
                entity.HasKey(e => e.SeqId);

                entity.ToTable("ERPUser");

                entity.Property(e => e.SeqId).HasColumnName("SeqID");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BranchCode).HasMaxLength(80);

                entity.Property(e => e.CanAdd).HasMaxLength(50);

                entity.Property(e => e.CanDelete).HasMaxLength(50);

                entity.Property(e => e.CanEdit).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(80);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(80);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<FourCoulmnRoundOff>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("FourCoulmnRoundOFF");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasColumnType("date");

                entity.Property(e => e.Roundoff)
                    .HasColumnName("ROUNDOFF")
                    .HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<GlaccGroup>(entity =>
            {
                entity.HasKey(e => e.GroupCode);

                entity.ToTable("GLAccGroup");

                entity.Property(e => e.GroupCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.NumberRange).HasMaxLength(40);
            });

            modelBuilder.Entity<Glaccounts>(entity =>
            {
                entity.HasKey(e => e.Glcode);

                entity.ToTable("GLAccounts");

                entity.Property(e => e.Glcode)
                    .HasColumnName("GLCode")
                    .HasMaxLength(20);

                entity.Property(e => e.AccGroup).HasMaxLength(4);

                entity.Property(e => e.AccountNumber).HasMaxLength(60);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BalanceType).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.GlaccountName)
                    .HasColumnName("GLAccountName")
                    .HasMaxLength(50);

                entity.Property(e => e.Nactureofaccount).HasMaxLength(40);

                entity.Property(e => e.OpeningBalance).HasMaxLength(50);

                entity.Property(e => e.StatementType).HasMaxLength(4);
            });

            modelBuilder.Entity<Health559>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HEALTH559$");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255);

                entity.Property(e => e.Final).HasColumnName("final");

                entity.Property(e => e.PartyId)
                    .HasColumnName("party_id")
                    .HasMaxLength(255);

                entity.Property(e => e.PartyName)
                    .HasColumnName("party_name")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<LeaveApplDetails>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_Leave_Appl_Details_1");

                entity.ToTable("Leave_Appl_Details");

                entity.Property(e => e.AccDate)
                    .HasColumnName("Acc_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcceptedRemarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AccptedId)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ApplDate)
                    .HasColumnName("Appl_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprDate)
                    .HasColumnName("appr_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApproveName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedId)
                    .HasColumnName("ApprovedID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AuthDate)
                    .HasColumnName("auth_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthorizedId)
                    .HasColumnName("AuthorizedID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorizedStatus)
                    .HasColumnName("Authorized_status")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ChkAcceptReject)
                    .HasColumnName("chkAcceptReject")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasColumnName("Emp_Code")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EmpName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Formno)
                    .HasColumnName("FORMNO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LeaveCode)
                    .HasColumnName("Leave_Code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveDays).HasColumnName("Leave_Days");

                entity.Property(e => e.LeaveFrom)
                    .HasColumnName("Leave_From")
                    .HasColumnType("date");

                entity.Property(e => e.LeaveRemarks)
                    .HasColumnName("Leave_Remarks")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveTo)
                    .HasColumnName("Leave_To")
                    .HasColumnType("date");

                entity.Property(e => e.Lopdays).HasColumnName("LOPdays");

                entity.Property(e => e.Reason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Recomendedby)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RejectedId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RejectedName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportId)
                    .HasColumnName("ReportID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Session1)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Session2)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Skip)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Trmno)
                    .HasColumnName("TRMNO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<LeaveBalanceMaster>(entity =>
            {
                entity.HasKey(e => new { e.EmpCode, e.Year, e.LeaveCode });

                entity.Property(e => e.EmpCode).HasMaxLength(50);

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Opbal).HasColumnName("OPBAL");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LeaveTypes>(entity =>
            {
                entity.Property(e => e.CompanyCode).HasMaxLength(40);

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.LeaveCode).HasMaxLength(40);

                entity.Property(e => e.LeaveMaxLimit).HasMaxLength(40);

                entity.Property(e => e.LeaveMinLimit).HasMaxLength(40);

                entity.Property(e => e.LeaveName).HasMaxLength(40);
            });

            modelBuilder.Entity<MatTranTypes>(entity =>
            {
                entity.HasKey(e => e.SeqId)
                    .HasName("PK_Mat_Tran_Types_1");

                entity.ToTable("Mat_Tran_Types");

                entity.Property(e => e.SeqId).HasColumnName("SeqID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DrCrIndicator).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.NoSeries).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<MenuAccesses>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate)
                    .HasColumnName("addDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("RoleID")
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasMaxLength(200);
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("displayName")
                    .HasMaxLength(500);

                entity.Property(e => e.Ext1)
                    .HasColumnName("ext1")
                    .HasMaxLength(50);

                entity.Property(e => e.IconName)
                    .HasColumnName("iconName")
                    .HasMaxLength(500);

                entity.Property(e => e.IsMasterScreen)
                    .HasColumnName("isMasterScreen")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(20);

                entity.Property(e => e.Route)
                    .HasColumnName("route")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<NoSeries>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.NoType).HasMaxLength(20);

                entity.Property(e => e.NumberSeries).HasMaxLength(50);

                entity.Property(e => e.PartnerType).HasMaxLength(50);
            });

            modelBuilder.Entity<PartnerCreation>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(400);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.Address3).HasMaxLength(40);

                entity.Property(e => e.Address4).HasMaxLength(40);

                entity.Property(e => e.Balance).HasMaxLength(50);

                entity.Property(e => e.BalanceType).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(20);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CompCode).HasMaxLength(20);

                entity.Property(e => e.ContactPerson).HasMaxLength(20);

                entity.Property(e => e.Country).HasMaxLength(30);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.GlcontrolAcc)
                    .HasColumnName("GLControlAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(20);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.Nacture).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Partnertype).HasMaxLength(50);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.PinCode).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(20);
            });

            modelBuilder.Entity<PartnerType>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.AccountType).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);
            });

            modelBuilder.Entity<PayrollCycle>(entity =>
            {
                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyCode).HasMaxLength(20);

                entity.Property(e => e.CycleDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CycleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentCode).HasMaxLength(20);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditWho)
                    .HasColumnName("EditWHo")
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiedDate).HasColumnType("date");

                entity.Property(e => e.EmployeeGroupId).HasMaxLength(20);
            });

            modelBuilder.Entity<Pfmaster>(entity =>
            {
                entity.ToTable("PFMaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContributionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Limit)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PftypeName)
                    .HasColumnName("PFTypeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProfitCenters>(entity =>
            {
                entity.HasKey(e => e.SeqId);

                entity.Property(e => e.SeqId).HasColumnName("seqID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Address1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address4)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PinCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsiblePerson)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ptmaster>(entity =>
            {
                entity.ToTable("PTMaster");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Month)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Ptamt).HasColumnName("PTAmt");

                entity.Property(e => e.PtlowerLimit).HasColumnName("PTLowerLimit");

                entity.Property(e => e.Ptslab)
                    .IsRequired()
                    .HasColumnName("PTSlab")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PtupperLimit).HasColumnName("PTUpperLimit");

                entity.Property(e => e.Year)
                    .HasMaxLength(4)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RebateSus558>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RebateSus558$");

                entity.Property(e => e.PartyCode)
                    .HasColumnName("partyCode")
                    .HasMaxLength(255);

                entity.Property(e => e.PartyId)
                    .HasColumnName("party_id")
                    .HasMaxLength(255);

                entity.Property(e => e.PartyName)
                    .HasColumnName("party_name")
                    .HasMaxLength(255);

                entity.Property(e => e.TotRebate).HasColumnName("tot_rebate");
            });

            modelBuilder.Entity<Roundtest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ROUNDTEST");

                entity.Property(e => e.BranchCode).HasColumnName("branchCode");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Ledgercode).HasColumnName("ledgercode");

                entity.Property(e => e.Roundoff)
                    .HasColumnName("ROUNDOFF")
                    .HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SalaryEarnDedn>(entity =>
            {
                entity.HasKey(e => new { e.SalMonth, e.SalYear, e.EmpCode, e.EarnDednCode });

                entity.ToTable("Salary_Earn_Dedn");

                entity.Property(e => e.SalMonth)
                    .HasColumnName("Sal_Month")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalYear)
                    .HasColumnName("Sal_Year")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpCode)
                    .HasColumnName("Emp_Code")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EarnDednCode)
                    .HasColumnName("Earn_Dedn_Code")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ArrearsAmount)
                    .HasColumnName("Arrears_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("Company_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EarnDednAmount)
                    .HasColumnName("Earn_Dedn_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.EmpGrp)
                    .HasColumnName("Emp_Grp")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpGrpId).HasMaxLength(5);

                entity.Property(e => e.Ext1)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.ProfitCenterCode)
                    .HasColumnName("ProfitCenter_Code")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Usrid)
                    .HasColumnName("USRID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.HasKey(e => e.SeqId);

                entity.Property(e => e.SeqId).HasColumnName("seqID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sheet1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet1$");

                entity.Property(e => e.BranchCode).HasColumnName("branchCode");

                entity.Property(e => e.BranchId).HasColumnName("branchID");

                entity.Property(e => e.F14).HasMaxLength(255);

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .HasMaxLength(255);

                entity.Property(e => e.InwardQty).HasColumnName("inwardQty");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .HasMaxLength(255);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .HasMaxLength(255);

                entity.Property(e => e.ShiftId).HasColumnName("shiftId");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VoucherNo).HasColumnName("voucherNo");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Sheet1Openig>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet1$_Openig");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(255);

                entity.Property(e => e.Credits).HasColumnName("credits");

                entity.Property(e => e.Debits).HasColumnName("debits");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.LedgerCode).HasColumnName("ledgerCode");

                entity.Property(e => e.LedgerId).HasColumnName("ledgerId");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .HasMaxLength(255);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(255);

                entity.Property(e => e.OpeningBalanceDate)
                    .HasColumnName("openingBalanceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentTypeId).HasColumnName("paymentTypeId");

                entity.Property(e => e.PaymentTypeName)
                    .HasColumnName("paymentTypeName")
                    .HasMaxLength(255);

                entity.Property(e => e.ShiftId).HasColumnName("shiftId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Sheet1Stock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sheet1$_Stock");

                entity.Property(e => e.BranchCode).HasColumnName("branchCode");

                entity.Property(e => e.BranchId).HasColumnName("branchID");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .HasMaxLength(255);

                entity.Property(e => e.InwardQty).HasColumnName("inwardQty");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .HasMaxLength(255);

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .HasMaxLength(255);

                entity.Property(e => e.ShiftId).HasColumnName("shiftId");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VoucherNo).HasColumnName("voucherNo");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Smsstatus>(entity =>
            {
                entity.ToTable("SMSStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasColumnName("branch")
                    .HasMaxLength(250);

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoiceDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasMaxLength(20);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SmsReturnId)
                    .HasColumnName("smsReturnID")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VehicleRegNo)
                    .HasColumnName("vehicleRegNo")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("States_Countries_fk");
            });

            modelBuilder.Entity<StructureComponents>(entity =>
            {
                entity.HasKey(e => e.StructureCode)
                    .HasName("PK_FixedEarningsDeductions");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AmountType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CalculateOn)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComponentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StructureName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StructureCreation>(entity =>
            {
                entity.HasKey(e => e.StructureCode);

                entity.Property(e => e.StructureCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StructureName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaxIntegration>(entity =>
            {
                entity.HasKey(e => e.TaxCode);

                entity.Property(e => e.TaxCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BranchCode).HasMaxLength(20);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(30);

                entity.Property(e => e.CompanyCode).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(30);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(30);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TaxMasters>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.Active).HasMaxLength(50);

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BaseAmountInPerCentage).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.BaseAmountIncludingTax)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxType).HasMaxLength(20);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblAccountGroup>(entity =>
            {
                entity.HasKey(e => e.AccountGroupId);

                entity.ToTable("tbl_AccountGroup");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountGroupName)
                    .HasColumnName("accountGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.AffectGrossProfit)
                    .HasColumnName("affectGrossProfit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GroupUnder)
                    .HasColumnName("groupUnder")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Nature)
                    .HasColumnName("nature")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAccountGroupToCopy>(entity =>
            {
                entity.HasKey(e => e.AccountGroupId);

                entity.ToTable("tbl_AccountGroupToCopy");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountGroupName)
                    .HasColumnName("accountGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.AffectGrossProfit).HasColumnName("affectGrossProfit");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GroupUnder)
                    .HasColumnName("groupUnder")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Nature)
                    .HasColumnName("nature")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAccountLedger>(entity =>
            {
                entity.HasKey(e => e.LedgerId)
                    .HasName("PK__tbl_Acco__298DF4D5C8F0CFBC");

                entity.ToTable("tbl_AccountLedger");

                entity.HasIndex(e => e.LedgerCode)
                    .HasName("NonClusteredIndex-20181226-173131");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountTypeId)
                    .HasColumnName("accountTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountTypeName)
                    .HasColumnName("accountTypeName")
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNumber)
                    .HasColumnName("bankAccountNumber")
                    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.CrOrDr)
                    .HasColumnName("crOrDr")
                    .IsUnicode(false);

                entity.Property(e => e.CreditLimit)
                    .HasColumnName("creditLimit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.CreditPeriod).HasColumnName("creditPeriod");

                entity.Property(e => e.Cst)
                    .HasColumnName("cst")
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceTaxAccountName)
                    .HasColumnName("invoiceTaxAccountName")
                    .HasMaxLength(250);

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.LedgerCode)
                    .HasColumnName("ledgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.MailingName)
                    .HasColumnName("mailingName")
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.OpeningBalance)
                    .HasColumnName("openingBalance")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Pan)
                    .HasColumnName("pan")
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .IsUnicode(false);

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Tin)
                    .HasColumnName("tin")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAccountLedgerToCopy>(entity =>
            {
                entity.HasKey(e => e.LedgerId);

                entity.ToTable("tbl_AccountLedgerToCopy");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BankAccountNumber)
                    .HasColumnName("bankAccountNumber")
                    .IsUnicode(false);

                entity.Property(e => e.BillByBill).HasColumnName("billByBill");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.CrOrDr)
                    .HasColumnName("crOrDr")
                    .IsUnicode(false);

                entity.Property(e => e.CreditLimit)
                    .HasColumnName("creditLimit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.CreditPeriod).HasColumnName("creditPeriod");

                entity.Property(e => e.Cst)
                    .HasColumnName("cst")
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.MailingName)
                    .HasColumnName("mailingName")
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.OpeningBalance)
                    .HasColumnName("openingBalance")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Pan)
                    .HasColumnName("pan")
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .IsUnicode(false);

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RouteId)
                    .HasColumnName("routeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .IsUnicode(false);

                entity.Property(e => e.Tin)
                    .HasColumnName("tin")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAccountLedgerTransactions>(entity =>
            {
                entity.HasKey(e => e.LedgerTransactionId);

                entity.ToTable("tbl_AccountLedgerTransactions");

                entity.Property(e => e.LedgerTransactionId)
                    .HasColumnName("ledgerTransactionId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.CreditAmount)
                    .HasColumnName("creditAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DebitAmount)
                    .HasColumnName("debitAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.LedgerCode)
                    .HasColumnName("ledgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transactionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("transactionType")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherAmount)
                    .HasColumnName("voucherAmount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.VoucherDetailId)
                    .HasColumnName("voucherDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblAccountType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("tbl_AccountType");

                entity.Property(e => e.TypeId)
                    .HasColumnName("typeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TblAdditionalCost>(entity =>
            {
                entity.HasKey(e => e.AdditionalCostId)
                    .HasName("PK__tbl_Addi__D89F761D24092D7A");

                entity.ToTable("tbl_AdditionalCost");

                entity.Property(e => e.AdditionalCostId)
                    .HasColumnName("additionalCostId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Debit)
                    .HasColumnName("debit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblAdditionalShareTransfer>(entity =>
            {
                entity.HasKey(e => e.AdditionalShareId)
                    .HasName("PK__tbl_AdditionalShareTransfer");

                entity.ToTable("tbl_AdditionalShareTransfer");

                entity.Property(e => e.AdditionalShareId)
                    .HasColumnName("additionalShareId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionalShareCode)
                    .HasColumnName("additionalShareCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AdditionalShareTransferCode)
                    .IsRequired()
                    .HasColumnName("additionalShareTransferCode")
                    .HasMaxLength(250);

                entity.Property(e => e.FromMemberCode)
                    .HasColumnName("fromMemberCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromMemberId)
                    .HasColumnName("fromMemberId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromMemberName)
                    .IsRequired()
                    .HasColumnName("fromMemberName")
                    .HasMaxLength(250);

                entity.Property(e => e.FromMemberSharesAfter).HasColumnName("fromMemberSharesAfter");

                entity.Property(e => e.FromMemberSharesBefore).HasColumnName("fromMemberSharesBefore");

                entity.Property(e => e.IsAdditionalSharesTransfered).HasColumnName("isAdditionalSharesTransfered");

                entity.Property(e => e.NoOfSharesToTransfer).HasColumnName("noOfSharesToTransfer");

                entity.Property(e => e.ToMemberCode)
                    .HasColumnName("toMemberCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToMemberId)
                    .HasColumnName("toMemberId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToMemberName)
                    .IsRequired()
                    .HasColumnName("toMemberName")
                    .HasMaxLength(250);

                entity.Property(e => e.ToMemberSharesAfter).HasColumnName("toMemberSharesAfter");

                entity.Property(e => e.ToMemberSharesBefore).HasColumnName("toMemberSharesBefore");

                entity.Property(e => e.TransferDate)
                    .HasColumnName("transferDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblAdvance>(entity =>
            {
                entity.ToTable("tbl_Advance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdvanceAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AdvanceType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApplyDate).HasColumnType("datetime");

                entity.Property(e => e.ApproveDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DeductedAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAdvancePayment>(entity =>
            {
                entity.HasKey(e => e.AdvancePaymentId)
                    .HasName("PK__tbl_Adva__1A7BF2355AB9788F");

                entity.ToTable("tbl_AdvancePayment");

                entity.Property(e => e.AdvancePaymentId)
                    .HasColumnName("advancePaymentId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(18, 5)");

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Chequenumber)
                    .HasColumnName("chequenumber")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SalaryMonth)
                    .HasColumnName("salaryMonth")
                    .HasColumnType("datetime");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblAdvanceType>(entity =>
            {
                entity.ToTable("tbl_AdvanceType");

                entity.Property(e => e.AdvanceTypeId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AdvanceTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblArea>(entity =>
            {
                entity.HasKey(e => e.AreaId);

                entity.ToTable("tbl_Area");

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AreaName)
                    .HasColumnName("areaName")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBankPaymentDetails>(entity =>
            {
                entity.HasKey(e => e.BankPaymentDetailsId)
                    .HasName("PK__tbl_BankPaymentDetails");

                entity.ToTable("tbl_BankPaymentDetails");

                entity.Property(e => e.BankPaymentDetailsId)
                    .HasColumnName("bankPaymentDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BankPaymentDetailsDate)
                    .HasColumnName("bankPaymentDetailsDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BankPaymentMasterId)
                    .HasColumnName("bankPaymentMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerCode)
                    .HasColumnName("toLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ToLedgerId)
                    .HasColumnName("toLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerName)
                    .HasColumnName("toLedgerName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBankPaymentMaster>(entity =>
            {
                entity.HasKey(e => e.BankPaymentMasterId);

                entity.ToTable("tbl_BankPaymentMaster");

                entity.Property(e => e.BankPaymentMasterId)
                    .HasColumnName("bankPaymentMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BankLedgerCode)
                    .HasColumnName("bankLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.BankLedgerId)
                    .HasColumnName("bankLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BankLedgerName)
                    .HasColumnName("bankLedgerName")
                    .IsUnicode(false);

                entity.Property(e => e.BankPaymentDate)
                    .HasColumnName("bankPaymentDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BankPaymentVchNo)
                    .HasColumnName("bankPaymentVchNo")
                    .HasMaxLength(250);

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .HasMaxLength(80);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.PostingDate)
                    .HasColumnName("postingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Realized)
                    .HasColumnName("realized")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBankReceiptDetails>(entity =>
            {
                entity.HasKey(e => e.BankReceiptDetailsId)
                    .HasName("PK__tbl_BankReceiptDetails");

                entity.ToTable("tbl_BankReceiptDetails");

                entity.Property(e => e.BankReceiptDetailsId)
                    .HasColumnName("bankReceiptDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BankReceiptDetailsDate)
                    .HasColumnName("bankReceiptDetailsDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BankReceiptMasterId)
                    .HasColumnName("bankReceiptMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerCode)
                    .HasColumnName("toLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ToLedgerId)
                    .HasColumnName("toLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerName)
                    .HasColumnName("toLedgerName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBankReceiptMaster>(entity =>
            {
                entity.HasKey(e => e.BankReceiptMasterId);

                entity.ToTable("tbl_BankReceiptMaster");

                entity.Property(e => e.BankReceiptMasterId)
                    .HasColumnName("bankReceiptMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BankLedgerCode)
                    .HasColumnName("bankLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.BankLedgerId)
                    .HasColumnName("bankLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BankLedgerName)
                    .HasColumnName("bankLedgerName")
                    .IsUnicode(false);

                entity.Property(e => e.BankReceiptDate)
                    .HasColumnName("bankReceiptDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BankReceiptVchNo)
                    .HasColumnName("bankReceiptVchNo")
                    .HasMaxLength(250);

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .HasMaxLength(80);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.PostingDate)
                    .HasColumnName("postingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Realized)
                    .HasColumnName("realized")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBankReconciliation>(entity =>
            {
                entity.HasKey(e => e.ReconcileId)
                    .HasName("PK__tbl_Bank__66CCE65DE704F1E8");

                entity.ToTable("tbl_BankReconciliation");

                entity.Property(e => e.ReconcileId)
                    .HasColumnName("reconcileId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LedgerPostingId)
                    .HasColumnName("ledgerPostingId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StatementDate)
                    .HasColumnName("statementDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblBarcodeSettings>(entity =>
            {
                entity.HasKey(e => e.BarcodeSettingsId)
                    .HasName("PK__tbl_Barc__1F1D76191C5DEA11");

                entity.ToTable("tbl_BarcodeSettings");

                entity.Property(e => e.BarcodeSettingsId)
                    .HasColumnName("barcodeSettingsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .IsUnicode(false);

                entity.Property(e => e.Eight)
                    .HasColumnName("eight")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Five)
                    .HasColumnName("five")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Four)
                    .HasColumnName("four")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nine)
                    .HasColumnName("nine")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.One)
                    .HasColumnName("one")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Point)
                    .HasColumnName("point")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Seven)
                    .HasColumnName("seven")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShowCompanyName).HasColumnName("showCompanyName");

                entity.Property(e => e.ShowMrp).HasColumnName("showMRP");

                entity.Property(e => e.ShowProductCode).HasColumnName("showProductCode");

                entity.Property(e => e.ShowPurchaseRate).HasColumnName("showPurchaseRate");

                entity.Property(e => e.Six)
                    .HasColumnName("six")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Three)
                    .HasColumnName("three")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Two)
                    .HasColumnName("two")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zero)
                    .HasColumnName("zero")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBatch>(entity =>
            {
                entity.HasKey(e => e.BatchId)
                    .HasName("PK__tbl_Batc__78CCD773147C05D0");

                entity.ToTable("tbl_Batch");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .IsUnicode(false);

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batchNo")
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("expiryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ManufacturingDate)
                    .HasColumnName("manufacturingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PartNo)
                    .HasColumnName("partNo")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblBom>(entity =>
            {
                entity.HasKey(e => e.BomId)
                    .HasName("PK__tbl_Bom__B6B08848184C96B4");

                entity.ToTable("tbl_Bom");

                entity.Property(e => e.BomId)
                    .HasColumnName("bomId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RowmaterialId)
                    .HasColumnName("rowmaterialId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblBonusDeduction>(entity =>
            {
                entity.HasKey(e => e.BonusDeductionId);

                entity.ToTable("tbl_BonusDeduction");

                entity.Property(e => e.BonusDeductionId)
                    .HasColumnName("bonusDeductionId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BonusAmount)
                    .HasColumnName("bonusAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeductionAmount)
                    .HasColumnName("deductionAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBranch>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK__tbl_Bran__751EBD3FB45374F0");

                entity.ToTable("tbl_Branch");

                entity.HasIndex(e => new { e.BranchName, e.SapCode, e.BranchCode })
                    .HasName("NonClusteredIndex-20181226-173932");

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(400);

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchImage)
                    .HasColumnName("branchImage")
                    .HasColumnType("image");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(250);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("companyId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(250);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(300);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(50);

                entity.Property(e => e.Gstin)
                    .IsRequired()
                    .HasColumnName("gstin")
                    .HasMaxLength(250);

                entity.Property(e => e.IsMainBranch)
                    .HasColumnName("isMainBranch")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.Property(e => e.PinCode)
                    .HasColumnName("pinCode")
                    .HasMaxLength(50);

                entity.Property(e => e.SapCode)
                    .HasColumnName("sapCode")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(250);

                entity.Property(e => e.SubBranchof)
                    .HasColumnName("subBranchof")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblBrand>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__tbl_Bran__06B7729946136164");

                entity.ToTable("tbl_Brand");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brandId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BrandName)
                    .HasColumnName("brandName")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Manufacturer)
                    .HasColumnName("manufacturer")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBudgetDetails>(entity =>
            {
                entity.HasKey(e => e.BudgetDetailsId)
                    .HasName("PK__tbl_Budg__C2BA2365004BBB48");

                entity.ToTable("tbl_BudgetDetails");

                entity.Property(e => e.BudgetDetailsId)
                    .HasColumnName("budgetDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BudgetMasterId)
                    .HasColumnName("budgetMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Debit)
                    .HasColumnName("debit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Particular)
                    .HasColumnName("particular")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBudgetMaster>(entity =>
            {
                entity.HasKey(e => e.BudgetMasterId)
                    .HasName("PK__tbl_Budg__060415BC7C7B2A64");

                entity.ToTable("tbl_BudgetMaster");

                entity.Property(e => e.BudgetMasterId)
                    .HasColumnName("budgetMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BudgetName)
                    .HasColumnName("budgetName")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalCr)
                    .HasColumnName("totalCr")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalDr)
                    .HasColumnName("totalDr")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCashPaymentDetails>(entity =>
            {
                entity.HasKey(e => e.CashPaymentDetailsId)
                    .HasName("PK__tbl_CashPaymentDetails");

                entity.ToTable("tbl_CashPaymentDetails");

                entity.Property(e => e.CashPaymentDetailsId)
                    .HasColumnName("cashPaymentDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashPaymentDetailsDate)
                    .HasColumnName("cashPaymentDetailsDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CashPaymentMasterId)
                    .HasColumnName("cashPaymentMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerCode)
                    .HasColumnName("toLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ToLedgerId)
                    .HasColumnName("toLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerName)
                    .HasColumnName("toLedgerName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCashPaymentMaster>(entity =>
            {
                entity.HasKey(e => e.CashPaymentMasterId);

                entity.ToTable("tbl_CashPaymentMaster");

                entity.Property(e => e.CashPaymentMasterId)
                    .HasColumnName("cashPaymentMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.CashPaymentDate)
                    .HasColumnName("cashPaymentDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CashPaymentVchNo)
                    .HasColumnName("cashPaymentVchNo")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromLedgerCode)
                    .HasColumnName("fromLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FromLedgerId)
                    .HasColumnName("fromLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromLedgerName)
                    .HasColumnName("fromLedgerName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCashReceiptDetails>(entity =>
            {
                entity.HasKey(e => e.CashReceiptDetailsId)
                    .HasName("PK__tbl_CashReceiptDetails");

                entity.ToTable("tbl_CashReceiptDetails");

                entity.Property(e => e.CashReceiptDetailsId)
                    .HasColumnName("cashReceiptDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashReceiptDetailsDate)
                    .HasColumnName("cashReceiptDetailsDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CashReceiptMasterId)
                    .HasColumnName("cashReceiptMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerCode)
                    .HasColumnName("toLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ToLedgerId)
                    .HasColumnName("toLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerName)
                    .HasColumnName("toLedgerName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCashReceiptMaster>(entity =>
            {
                entity.HasKey(e => e.CashReceiptMasterId);

                entity.ToTable("tbl_CashReceiptMaster");

                entity.Property(e => e.CashReceiptMasterId)
                    .HasColumnName("cashReceiptMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.CashReceiptDate)
                    .HasColumnName("cashReceiptDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CashReceiptVchNo)
                    .HasColumnName("cashReceiptVchNo")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromLedgerCode)
                    .HasColumnName("fromLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FromLedgerId)
                    .HasColumnName("fromLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromLedgerName)
                    .HasColumnName("fromLedgerName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__tbl_Comp__AD5459903E723F9C");

                entity.ToTable("tbl_Company");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("companyId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.BooksBeginingFrom)
                    .HasColumnName("booksBeginingFrom")
                    .HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .IsUnicode(false);

                entity.Property(e => e.Cst)
                    .HasColumnName("cst")
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currencyId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CurrentDate)
                    .HasColumnName("currentDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasColumnName("emailId")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearFrom)
                    .HasColumnName("financialYearFrom")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gstin)
                    .HasColumnName("gstin")
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("image");

                entity.Property(e => e.MailingName)
                    .HasColumnName("mailingName")
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .IsUnicode(false);

                entity.Property(e => e.Web)
                    .HasColumnName("web")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCompanyPath>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__tbl_Comp__AD5459903B36AB95");

                entity.ToTable("tbl_CompanyPath");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("companyId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyName)
                    .HasColumnName("companyName")
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPath)
                    .HasColumnName("companyPath")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");
            });

            modelBuilder.Entity<TblContraDetails>(entity =>
            {
                entity.HasKey(e => e.ContraDetailsId)
                    .HasName("PK__tbl_Cont__4D096E75632F8E56");

                entity.ToTable("tbl_ContraDetails");

                entity.Property(e => e.ContraDetailsId)
                    .HasColumnName("contraDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .IsUnicode(false);

                entity.Property(e => e.ContraMasterId)
                    .HasColumnName("contraMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblContraMaster>(entity =>
            {
                entity.HasKey(e => e.ContraMasterId)
                    .HasName("PK__tbl_Cont__0B964F325F5EFD72");

                entity.ToTable("tbl_ContraMaster");

                entity.Property(e => e.ContraMasterId)
                    .HasColumnName("contraMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblCounter>(entity =>
            {
                entity.HasKey(e => e.CounterId)
                    .HasName("PK__tbl_Coun__08A9D0236497E884");

                entity.ToTable("tbl_Counter");

                entity.Property(e => e.CounterId)
                    .HasColumnName("counterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CounterName)
                    .HasColumnName("counterName")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCreditNoteDetails>(entity =>
            {
                entity.HasKey(e => e.CreditNoteDetailsId)
                    .HasName("PK__tbl_Cred__3A8A913E10F65906");

                entity.ToTable("tbl_CreditNoteDetails");

                entity.Property(e => e.CreditNoteDetailsId)
                    .HasColumnName("creditNoteDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .IsUnicode(false);

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.CreditNoteMasterId)
                    .HasColumnName("creditNoteMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Debit)
                    .HasColumnName("debit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblCreditNoteMaster>(entity =>
            {
                entity.HasKey(e => e.CreditNoteMasterId)
                    .HasName("PK__tbl_Cred__DDC597880D25C822");

                entity.ToTable("tbl_CreditNoteMaster");

                entity.Property(e => e.CreditNoteMasterId)
                    .HasColumnName("creditNoteMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("PK__tbl_Curr__DAF0B20A592635D8");

                entity.ToTable("tbl_Currency");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currencyId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CurrencyName)
                    .HasColumnName("currencyName")
                    .IsUnicode(false);

                entity.Property(e => e.CurrencySymbol)
                    .HasColumnName("currencySymbol")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDecimalPlaces).HasColumnName("noOfDecimalPlaces");

                entity.Property(e => e.SubunitName)
                    .HasColumnName("subunitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCurrencyToCopy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_CurrencyToCopy");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currencyId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CurrencyName)
                    .HasColumnName("currencyName")
                    .IsUnicode(false);

                entity.Property(e => e.CurrencySymbol)
                    .HasColumnName("currencySymbol")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDecimalPlaces).HasColumnName("noOfDecimalPlaces");

                entity.Property(e => e.SubunitName)
                    .HasColumnName("subunitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCurrentTransation>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("tbl_CurrentTransation");

                entity.Property(e => e.FormId)
                    .HasColumnName("formId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransationStatus).HasColumnName("transationStatus");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDailyAttendanceDetails>(entity =>
            {
                entity.HasKey(e => e.DailyAttendanceDetailsId)
                    .HasName("PK__tbl_Dail__990F6D9656E8E7AB");

                entity.ToTable("tbl_DailyAttendanceDetails");

                entity.Property(e => e.DailyAttendanceDetailsId)
                    .HasColumnName("dailyAttendanceDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DailyAttendanceMasterId)
                    .HasColumnName("dailyAttendanceMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDailyAttendanceMaster>(entity =>
            {
                entity.HasKey(e => e.DailyAttendanceMasterId)
                    .HasName("PK__tbl_Dail__6FC4FA94531856C7");

                entity.ToTable("tbl_DailyAttendanceMaster");

                entity.Property(e => e.DailyAttendanceMasterId)
                    .HasColumnName("dailyAttendanceMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDailySalaryVoucherDetails>(entity =>
            {
                entity.HasKey(e => e.DailySalaryVoucherDetailsId)
                    .HasName("PK__tbl_Dail__031176C94F47C5E3");

                entity.ToTable("tbl_DailySalaryVoucherDetails");

                entity.Property(e => e.DailySalaryVoucherDetailsId)
                    .HasColumnName("dailySalaryVoucherDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DailySalaryVoucherMasterId)
                    .HasColumnName("dailySalaryVoucherMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsUnicode(false);

                entity.Property(e => e.Wage)
                    .HasColumnName("wage")
                    .HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<TblDailySalaryVoucherMaster>(entity =>
            {
                entity.HasKey(e => e.DailySalaryVoucherMasterId);

                entity.ToTable("tbl_DailySalaryVoucherMaster");

                entity.Property(e => e.DailySalaryVoucherMasterId)
                    .HasColumnName("dailySalaryVoucherMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SalaryDate)
                    .HasColumnName("salaryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblDebitNoteDetails>(entity =>
            {
                entity.HasKey(e => e.DebitNoteDetailsId)
                    .HasName("PK__tbl_Debi__42220582469E3CA0");

                entity.ToTable("tbl_DebitNoteDetails");

                entity.Property(e => e.DebitNoteDetailsId)
                    .HasColumnName("debitNoteDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .IsUnicode(false);

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Debit)
                    .HasColumnName("debit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.DebitNoteMasterId)
                    .HasColumnName("debitNoteMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblDebitNoteMaster>(entity =>
            {
                entity.HasKey(e => e.DebitNoteMasterId)
                    .HasName("PK__tbl_Debi__1229ABA914C6E9EA");

                entity.ToTable("tbl_DebitNoteMaster");

                entity.Property(e => e.DebitNoteMasterId)
                    .HasColumnName("debitNoteMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblDeliveryNoteDetails>(entity =>
            {
                entity.HasKey(e => e.DeliveryNoteDetailsId)
                    .HasName("PK__tbl_Deli__A9A4649E51CFF82A");

                entity.ToTable("tbl_DeliveryNoteDetails");

                entity.Property(e => e.DeliveryNoteDetailsId)
                    .HasColumnName("deliveryNoteDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DeliveryNoteMasterId)
                    .HasColumnName("deliveryNoteMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OrderDetails1Id)
                    .HasColumnName("orderDetails1Id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.QuotationDetails1Id)
                    .HasColumnName("quotationDetails1Id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.SlNo).HasColumnName("slNo");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblDeliveryNoteMaster>(entity =>
            {
                entity.HasKey(e => e.DeliveryNoteMasterId)
                    .HasName("PK__tbl_Deli__72FF880F4DFF6746");

                entity.ToTable("tbl_DeliveryNoteMaster");

                entity.Property(e => e.DeliveryNoteMasterId)
                    .HasColumnName("deliveryNoteMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LrNo)
                    .HasColumnName("lrNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.OrderMasterId)
                    .HasColumnName("orderMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.QuotationMasterId)
                    .HasColumnName("quotationMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TransportationCompany)
                    .HasColumnName("transportationCompany")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblDesignation>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .HasName("PK__tbl_Desi__197CE32A30C33EC3");

                entity.ToTable("tbl_Designation");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("designationId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdvanceAmount)
                    .HasColumnName("advanceAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.DesignationName)
                    .HasColumnName("designationName")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeaveDays)
                    .HasColumnName("leaveDays")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDetails>(entity =>
            {
                entity.HasKey(e => e.DetailsId);

                entity.ToTable("tbl_Details");

                entity.Property(e => e.DetailsId).HasColumnName("detailsId");

                entity.Property(e => e.Align)
                    .HasColumnName("align")
                    .IsUnicode(false);

                entity.Property(e => e.Columns).HasColumnName("columns");

                entity.Property(e => e.Dbf)
                    .HasColumnName("dbf")
                    .IsUnicode(false);

                entity.Property(e => e.DorH).IsUnicode(false);

                entity.Property(e => e.ExtraFieldName)
                    .HasColumnName("extraFieldName")
                    .IsUnicode(false);

                entity.Property(e => e.FieldsForExtra)
                    .HasColumnName("fieldsForExtra")
                    .IsUnicode(false);

                entity.Property(e => e.FooterRepeatAll)
                    .HasColumnName("footerRepeatAll")
                    .IsUnicode(false);

                entity.Property(e => e.MasterId).HasColumnName("masterId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.Repeat)
                    .HasColumnName("repeat")
                    .IsUnicode(false);

                entity.Property(e => e.RepeatAll)
                    .HasColumnName("repeatAll")
                    .IsUnicode(false);

                entity.Property(e => e.Row).HasColumnName("row");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .IsUnicode(false);

                entity.Property(e => e.TextWrap)
                    .HasColumnName("textWrap")
                    .IsUnicode(false);

                entity.Property(e => e.Width).HasColumnName("width");

                entity.Property(e => e.WrapLineCount).HasColumnName("wrapLineCount");
            });

            modelBuilder.Entity<TblDetailsCopy>(entity =>
            {
                entity.HasKey(e => e.DetailsId);

                entity.ToTable("tbl_DetailsCopy");

                entity.Property(e => e.DetailsId).HasColumnName("detailsId");

                entity.Property(e => e.Align)
                    .HasColumnName("align")
                    .IsUnicode(false);

                entity.Property(e => e.Columns).HasColumnName("columns");

                entity.Property(e => e.Dbf)
                    .HasColumnName("dbf")
                    .IsUnicode(false);

                entity.Property(e => e.DorH).IsUnicode(false);

                entity.Property(e => e.ExtraFieldName)
                    .HasColumnName("extraFieldName")
                    .IsUnicode(false);

                entity.Property(e => e.FieldsForExtra)
                    .HasColumnName("fieldsForExtra")
                    .IsUnicode(false);

                entity.Property(e => e.FooterRepeatAll)
                    .HasColumnName("footerRepeatAll")
                    .IsUnicode(false);

                entity.Property(e => e.MasterId).HasColumnName("masterId");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.Repeat)
                    .HasColumnName("repeat")
                    .IsUnicode(false);

                entity.Property(e => e.RepeatAll)
                    .HasColumnName("repeatAll")
                    .IsUnicode(false);

                entity.Property(e => e.Row).HasColumnName("row");

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .IsUnicode(false);

                entity.Property(e => e.TextWrap)
                    .HasColumnName("textWrap")
                    .IsUnicode(false);

                entity.Property(e => e.Width).HasColumnName("width");

                entity.Property(e => e.WrapLineCount).HasColumnName("wrapLineCount");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__tbl_Empl__C134C9C125518C17");

                entity.ToTable("tbl_Employee");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AadharNumber)
                    .HasColumnName("aadharNumber")
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedBy).IsUnicode(false);

                entity.Property(e => e.BankAccountNumber)
                    .HasColumnName("bankAccountNumber")
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasColumnName("bankName")
                    .IsUnicode(false);

                entity.Property(e => e.BankbranchCode)
                    .HasColumnName("bankbranchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BankbranchName)
                    .HasColumnName("bankbranchName")
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasColumnName("bloodGroup")
                    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.DefaultPackageId)
                    .HasColumnName("defaultPackageId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("designationId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("employeeCode")
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .IsUnicode(false);

                entity.Property(e => e.EsiNumber)
                    .HasColumnName("esiNumber")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("joiningDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabourCardExpiryDate)
                    .HasColumnName("labourCardExpiryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LabourCardNumber)
                    .HasColumnName("labourCardNumber")
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .HasColumnName("maritalStatus")
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobileNumber")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PanNumber)
                    .HasColumnName("panNumber")
                    .IsUnicode(false);

                entity.Property(e => e.PassportExpiryDate)
                    .HasColumnName("passportExpiryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PassportNo)
                    .HasColumnName("passportNo")
                    .IsUnicode(false);

                entity.Property(e => e.PfNumber)
                    .HasColumnName("pfNumber")
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .IsUnicode(false);

                entity.Property(e => e.RecomendedBy).IsUnicode(false);

                entity.Property(e => e.RecomendedId).IsUnicode(false);

                entity.Property(e => e.ReportedBy).IsUnicode(false);

                entity.Property(e => e.SalaryType)
                    .HasColumnName("salaryType")
                    .IsUnicode(false);

                entity.Property(e => e.TerminationDate)
                    .HasColumnName("terminationDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblEmployeeAttendance>(entity =>
            {
                entity.HasKey(e => e.EmployeeAttendanceId)
                    .HasName("PK__tbl__EmployeeAttendance");

                entity.ToTable("tbl_EmployeeAttendance");

                entity.Property(e => e.EmployeeAttendanceId)
                    .HasColumnName("employeeAttendanceID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CasualLeaves).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DOther1)
                    .HasColumnName("dOther1")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DOther2)
                    .HasColumnName("dOther2")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DOther3)
                    .HasColumnName("dOther3")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("designationId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DesignationName)
                    .HasColumnName("designationName")
                    .IsUnicode(false);

                entity.Property(e => e.EOther1)
                    .HasColumnName("eOther1")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EOther2)
                    .HasColumnName("eOther2")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EOther3)
                    .HasColumnName("eOther3")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("employeeCode")
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeMasterId)
                    .HasColumnName("employeeMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .IsUnicode(false);

                entity.Property(e => e.LossOfPayDays)
                    .HasColumnName("lossOfPayDays")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MonthId)
                    .HasColumnName("monthID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MonthName)
                    .HasColumnName("monthName")
                    .IsUnicode(false);

                entity.Property(e => e.PresentDays)
                    .HasColumnName("presentDays")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PrivilegeLeaves)
                    .HasColumnName("privilegeLeaves")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProcessDate)
                    .HasColumnName("processDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SickLeaves)
                    .HasColumnName("sickLeaves")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalPayDays)
                    .HasColumnName("totalPayDays")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalWorkingDays)
                    .HasColumnName("totalWorkingDays")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblEmployeeMaster>(entity =>
            {
                entity.HasKey(e => e.EmployeeMasterId)
                    .HasName("PK__tbl_EmployeeMaster");

                entity.ToTable("tbl_EmployeeMaster");

                entity.Property(e => e.EmployeeMasterId)
                    .HasColumnName("employeeMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AadharNumber)
                    .HasColumnName("aadharNumber")
                    .IsUnicode(false);

                entity.Property(e => e.AccountCode)
                    .HasColumnName("accountCode")
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.AppDate).HasColumnType("datetime");

                entity.Property(e => e.BankAccountNumber)
                    .HasColumnName("bankAccountNumber")
                    .IsUnicode(false);

                entity.Property(e => e.Basic)
                    .HasColumnName("basic")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.Ca)
                    .HasColumnName("ca")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Csli)
                    .HasColumnName("csli")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Da)
                    .HasColumnName("da")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DeductionOther1)
                    .HasColumnName("deductionOther1")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("designationId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.EarningOther1)
                    .HasColumnName("earningOther1")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("employeeCode")
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .IsUnicode(false);

                entity.Property(e => e.EsiNumber)
                    .HasColumnName("esiNumber")
                    .IsUnicode(false);

                entity.Property(e => e.EsiPercentage)
                    .HasColumnName("esiPercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.FatherName)
                    .HasColumnName("fatherName")
                    .IsUnicode(false);

                entity.Property(e => e.GrossSalary).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Gsli)
                    .HasColumnName("gsli")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Hra)
                    .HasColumnName("hra")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("joiningDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lic)
                    .HasColumnName("lic")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("mobileNumber")
                    .IsUnicode(false);

                entity.Property(e => e.PanNumber)
                    .HasColumnName("panNumber")
                    .IsUnicode(false);

                entity.Property(e => e.PfNumber)
                    .HasColumnName("pfNumber")
                    .IsUnicode(false);

                entity.Property(e => e.PfPercentage)
                    .HasColumnName("pfPercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProfTax)
                    .HasColumnName("profTax")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.SpecialPay)
                    .HasColumnName("specialPay")
                    .HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblExchangeRate>(entity =>
            {
                entity.HasKey(e => e.ExchangeRateId)
                    .HasName("PK__tbl_Exch__DE88B8415CF6C6BC");

                entity.ToTable("tbl_ExchangeRate");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currencyId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<TblFields>(entity =>
            {
                entity.HasKey(e => e.FieldId);

                entity.ToTable("tbl_Fields");

                entity.Property(e => e.FieldId).HasColumnName("fieldId");

                entity.Property(e => e.FieldName)
                    .HasColumnName("fieldName")
                    .IsUnicode(false);

                entity.Property(e => e.FormId).HasColumnName("formId");
            });

            modelBuilder.Entity<TblFieldsCopy>(entity =>
            {
                entity.HasKey(e => e.FieldId);

                entity.ToTable("tbl_FieldsCopy");

                entity.Property(e => e.FieldId).HasColumnName("fieldId");

                entity.Property(e => e.FieldName)
                    .HasColumnName("fieldName")
                    .IsUnicode(false);

                entity.Property(e => e.FormId).HasColumnName("formId");
            });

            modelBuilder.Entity<TblFinancialYear>(entity =>
            {
                entity.HasKey(e => e.FinancialYearId)
                    .HasName("PK__tbl_Fina__FE30A41137661AB1");

                entity.ToTable("tbl_FinancialYear");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblForm>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("tbl_Form");

                entity.Property(e => e.FormId).HasColumnName("formId");

                entity.Property(e => e.FormName)
                    .HasColumnName("formName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFormCopy>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("tbl_FormCopy");

                entity.Property(e => e.FormId).HasColumnName("formId");

                entity.Property(e => e.FormName)
                    .HasColumnName("formName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFormMenuCollection>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("tbl_formMenuCollection");

                entity.Property(e => e.FormId).HasColumnName("formId");

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FormName)
                    .HasColumnName("formName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MainMenu)
                    .HasColumnName("mainMenu")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MainMenuName)
                    .HasColumnName("mainMenuName")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SubMenu)
                    .HasColumnName("subMenu")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SubMenuName)
                    .HasColumnName("subMenuName")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGodown>(entity =>
            {
                entity.HasKey(e => e.GodownId)
                    .HasName("PK__tbl_Godo__14F1AFAB51851410");

                entity.ToTable("tbl_Godown");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownName)
                    .HasColumnName("godownName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblHoliday>(entity =>
            {
                entity.HasKey(e => e.HolidayId)
                    .HasName("PK__tbl_Holi__EB855CEF29221CFB");

                entity.ToTable("tbl_Holiday");

                entity.Property(e => e.HolidayId)
                    .HasColumnName("holidayId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.HolidayName)
                    .HasColumnName("holidayName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblInvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.InvoiceDetailId)
                    .HasName("PK__tbl_InvoiceDetail");

                entity.ToTable("tbl_InvoiceDetail");

                entity.Property(e => e.InvoiceDetailId)
                    .HasColumnName("invoiceDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AvailStock)
                    .HasColumnName("availStock")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FQty)
                    .HasColumnName("fQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoiceDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceMasterId)
                    .HasColumnName("invoiceMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasColumnName("productGroupCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupId)
                    .HasColumnName("productGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.PumpId).HasColumnName("pumpID");

                entity.Property(e => e.PumpNo)
                    .HasColumnName("pumpNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SlipNo)
                    .HasColumnName("slipNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((37))");

                entity.Property(e => e.TaxGroupCode)
                    .IsRequired()
                    .HasColumnName("taxGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxGroupName)
                    .IsRequired()
                    .HasColumnName("taxGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unitName")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblInvoiceMaster>(entity =>
            {
                entity.HasKey(e => e.InvoiceMasterId)
                    .HasName("PK__tbl_InvoiceMaster");

                entity.ToTable("tbl_InvoiceMaster");

                entity.Property(e => e.InvoiceMasterId)
                    .HasColumnName("invoiceMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountBalance)
                    .HasColumnName("accountBalance")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.AmountInWords).HasMaxLength(250);

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.CustomerGstin)
                    .HasColumnName("customerGSTIN")
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customerName")
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GeneralNo).HasMaxLength(250);

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grandTotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoiceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.IsManualEntry)
                    .HasColumnName("isManualEntry")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSalesReturned)
                    .HasColumnName("isSalesReturned")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LedgerCode)
                    .HasColumnName("ledgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.ManualInvoiceNo).IsUnicode(false);

                entity.Property(e => e.MemberCode)
                    .HasColumnName("memberCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MemberName)
                    .HasColumnName("memberName")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OtherAmount1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OtherAmount2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .HasColumnName("paymentMode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RoundOffMinus)
                    .HasColumnName("roundOffMinus")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.RoundOffPlus)
                    .HasColumnName("roundOffPlus")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StateCode).HasMaxLength(20);

                entity.Property(e => e.SuppliedTo).HasMaxLength(250);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalCgst)
                    .HasColumnName("totalCGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalIgst)
                    .HasColumnName("totalIGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalSgst)
                    .HasColumnName("totalSGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotaltaxAmount)
                    .HasColumnName("totaltaxAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId)
                    .HasColumnName("vehicleId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VehicleRegNo)
                    .HasColumnName("vehicleRegNo")
                    .HasMaxLength(250);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblInvoiceMasterReturn>(entity =>
            {
                entity.HasKey(e => e.InvoiceMasterReturnId)
                    .HasName("PK__tbl_InvoiceMasterReturn");

                entity.ToTable("tbl_InvoiceMasterReturn");

                entity.Property(e => e.InvoiceMasterReturnId)
                    .HasColumnName("invoiceMasterReturnId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountBalance)
                    .HasColumnName("accountBalance")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.AmountInWords).HasMaxLength(250);

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.CustomerGstin)
                    .HasColumnName("customerGSTIN")
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customerName")
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GeneralNo).HasMaxLength(250);

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grandTotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoiceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceMasterId)
                    .HasColumnName("invoiceMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceReturnDate)
                    .HasColumnName("invoiceReturnDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceReturnNo)
                    .HasColumnName("invoiceReturnNo")
                    .IsUnicode(false);

                entity.Property(e => e.IsManualEntry).HasColumnName("isManualEntry");

                entity.Property(e => e.LedgerCode)
                    .HasColumnName("ledgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.ManualInvoiceNo).IsUnicode(false);

                entity.Property(e => e.MemberCode)
                    .HasColumnName("memberCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MemberName)
                    .HasColumnName("memberName")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OtherAmount1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OtherAmount2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .HasColumnName("paymentMode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RoundOffMinus)
                    .HasColumnName("roundOffMinus")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.RoundOffPlus)
                    .HasColumnName("roundOffPlus")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StateCode).HasMaxLength(20);

                entity.Property(e => e.SuppliedTo).HasMaxLength(250);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalCgst)
                    .HasColumnName("totalCGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalIgst)
                    .HasColumnName("totalIGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalSgst)
                    .HasColumnName("totalSGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotaltaxAmount)
                    .HasColumnName("totaltaxAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId)
                    .HasColumnName("vehicleId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VehicleRegNo)
                    .HasColumnName("vehicleRegNo")
                    .HasMaxLength(250);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblInvoiceReturnDetail>(entity =>
            {
                entity.HasKey(e => e.InvoiceReturnDetailId)
                    .HasName("PK__tbl_InvoiceReturnDetail");

                entity.ToTable("tbl_InvoiceReturnDetail");

                entity.Property(e => e.InvoiceReturnDetailId)
                    .HasColumnName("invoiceReturnDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AvailStock)
                    .HasColumnName("availStock")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FQty)
                    .HasColumnName("fQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InvoiceMasterReturnId)
                    .HasColumnName("invoiceMasterReturnId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceReturnDate)
                    .HasColumnName("invoiceReturnDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceReturnNo)
                    .HasColumnName("invoiceReturnNo")
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasColumnName("productGroupCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupId)
                    .HasColumnName("productGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.PumpId).HasColumnName("pumpID");

                entity.Property(e => e.PumpNo)
                    .HasColumnName("pumpNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SlipNo)
                    .HasColumnName("slipNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((37))");

                entity.Property(e => e.TaxGroupCode)
                    .IsRequired()
                    .HasColumnName("taxGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxGroupName)
                    .IsRequired()
                    .HasColumnName("taxGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unitName")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblJournalVoucherDetails>(entity =>
            {
                entity.HasKey(e => e.JournalVoucherDetailsId)
                    .HasName("PK__tbl_JournalVoucherDetails");

                entity.ToTable("tbl_JournalVoucherDetails");

                entity.Property(e => e.JournalVoucherDetailsId)
                    .HasColumnName("journalVoucherDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.JournalVoucherDetailsDate)
                    .HasColumnName("journalVoucherDetailsDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.JournalVoucherMasterId)
                    .HasColumnName("journalVoucherMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerCode)
                    .HasColumnName("toLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ToLedgerId)
                    .HasColumnName("toLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerName)
                    .HasColumnName("toLedgerName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblJournalVoucherMaster>(entity =>
            {
                entity.HasKey(e => e.JournalVoucherMasterId);

                entity.ToTable("tbl_JournalVoucherMaster");

                entity.Property(e => e.JournalVoucherMasterId)
                    .HasColumnName("journalVoucherMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromLedgerCode)
                    .HasColumnName("fromLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FromLedgerId)
                    .HasColumnName("fromLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromLedgerName)
                    .HasColumnName("fromLedgerName")
                    .IsUnicode(false);

                entity.Property(e => e.JournalVchNo)
                    .HasColumnName("journalVchNo")
                    .HasMaxLength(250);

                entity.Property(e => e.JournalVoucherDate)
                    .HasColumnName("journalVoucherDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.ReferenceDate)
                    .HasColumnName("referenceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReferenceNo)
                    .HasColumnName("referenceNo")
                    .HasMaxLength(80);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("transactionType")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLedgerPosting>(entity =>
            {
                entity.HasKey(e => e.LedgerPostingId)
                    .HasName("PK__tbl_Ledg__730FE2D769FBBC1F");

                entity.ToTable("tbl_LedgerPosting");

                entity.Property(e => e.LedgerPostingId)
                    .HasColumnName("ledgerPostingId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .IsUnicode(false);

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Debit)
                    .HasColumnName("debit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.DetailsId)
                    .HasColumnName("detailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.YearId)
                    .HasColumnName("yearId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId);

                entity.ToTable("tbl_Login");

                entity.Property(e => e.LoginId)
                    .HasColumnName("loginId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StartDateTime)
                    .HasColumnName("startDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblMaster>(entity =>
            {
                entity.HasKey(e => e.MasterId);

                entity.ToTable("tbl_Master");

                entity.Property(e => e.MasterId).HasColumnName("masterId");

                entity.Property(e => e.BlankLneForFooter).HasColumnName("blankLneForFooter");

                entity.Property(e => e.Condensed)
                    .HasColumnName("condensed")
                    .IsUnicode(false);

                entity.Property(e => e.FooterLocation)
                    .HasColumnName("footerLocation")
                    .IsUnicode(false);

                entity.Property(e => e.FormName).HasColumnName("formName");

                entity.Property(e => e.IsTwoLineForDetails).HasColumnName("isTwoLineForDetails");

                entity.Property(e => e.IsTwoLineForHedder).HasColumnName("isTwoLineForHedder");

                entity.Property(e => e.LineCountAfterPrint).HasColumnName("lineCountAfterPrint");

                entity.Property(e => e.LineCountBetweenTwo).HasColumnName("lineCountBetweenTwo");

                entity.Property(e => e.PageSize1).HasColumnName("pageSize1");

                entity.Property(e => e.PageSizeOther).HasColumnName("pageSizeOther");

                entity.Property(e => e.Pitch)
                    .HasColumnName("pitch")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMasterCopy>(entity =>
            {
                entity.HasKey(e => e.MasterId);

                entity.ToTable("tbl_MasterCopy");

                entity.Property(e => e.MasterId)
                    .HasColumnName("masterId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BlankLneForFooter).HasColumnName("blankLneForFooter");

                entity.Property(e => e.Condensed)
                    .HasColumnName("condensed")
                    .IsUnicode(false);

                entity.Property(e => e.FooterLocation)
                    .HasColumnName("footerLocation")
                    .IsUnicode(false);

                entity.Property(e => e.FormName).HasColumnName("formName");

                entity.Property(e => e.IsTwoLineForDetails).HasColumnName("isTwoLineForDetails");

                entity.Property(e => e.IsTwoLineForHedder).HasColumnName("isTwoLineForHedder");

                entity.Property(e => e.LineCountAfterPrint).HasColumnName("lineCountAfterPrint");

                entity.Property(e => e.LineCountBetweenTwo).HasColumnName("lineCountBetweenTwo");

                entity.Property(e => e.PageSize1).HasColumnName("pageSize1");

                entity.Property(e => e.PageSizeOther).HasColumnName("pageSizeOther");

                entity.Property(e => e.Pitch)
                    .HasColumnName("pitch")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMaterialReceiptDetails>(entity =>
            {
                entity.HasKey(e => e.MaterialReceiptDetailsId)
                    .HasName("PK__tbl_Mate__320D49ED77F5A112");

                entity.ToTable("tbl_MaterialReceiptDetails");

                entity.Property(e => e.MaterialReceiptDetailsId)
                    .HasColumnName("materialReceiptDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Exta2)
                    .HasColumnName("exta2")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MaterialReceiptMasterId)
                    .HasColumnName("materialReceiptMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OrderDetailsId)
                    .HasColumnName("orderDetailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Slno).HasColumnName("slno");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblMaterialReceiptMaster>(entity =>
            {
                entity.HasKey(e => e.MaterialReceiptMasterId)
                    .HasName("PK__tbl_Mate__47E4E4697425102E");

                entity.ToTable("tbl_MaterialReceiptMaster");

                entity.Property(e => e.MaterialReceiptMasterId)
                    .HasColumnName("materialReceiptMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LrNo)
                    .HasColumnName("lrNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.OrderMasterId)
                    .HasColumnName("orderMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TransportationCompany)
                    .HasColumnName("transportationCompany")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblMemberMaster>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tbl_MemberMaster");

                entity.Property(e => e.MemberId)
                    .HasColumnName("memberId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AadharNumber)
                    .HasColumnName("aadharNumber")
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(400);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(250);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.FatherOrHusbandName)
                    .HasColumnName("fatherOrHusbandName")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(20);

                entity.Property(e => e.GiftIssued)
                    .HasColumnName("giftIssued")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.GiftIssuedDate)
                    .HasColumnName("giftIssuedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GovtIdentity)
                    .HasColumnName("govtIdentity")
                    .HasMaxLength(250);

                entity.Property(e => e.GovtIdentityType)
                    .HasColumnName("govtIdentityType")
                    .HasMaxLength(80);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IssuedShares)
                    .HasColumnName("issuedShares")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.JoinDate)
                    .HasColumnName("joinDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MemberAge).HasColumnName("memberAge");

                entity.Property(e => e.MemberCode)
                    .HasColumnName("memberCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MemberName)
                    .HasColumnName("memberName")
                    .HasMaxLength(250);

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nominee)
                    .HasColumnName("nominee")
                    .HasMaxLength(250);

                entity.Property(e => e.NoofShares)
                    .HasColumnName("noofShares")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Occupation)
                    .HasColumnName("occupation")
                    .HasMaxLength(250);

                entity.Property(e => e.PassBook)
                    .HasColumnName("passBook")
                    .HasColumnType("datetime");

                entity.Property(e => e.PassBookStatus)
                    .HasColumnName("passBookStatus")
                    .HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.Property(e => e.PinCode)
                    .HasColumnName("pinCode")
                    .HasMaxLength(50);

                entity.Property(e => e.ReceivedShares)
                    .HasColumnName("receivedShares")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Relation)
                    .HasColumnName("relation")
                    .HasMaxLength(250);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(250);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalShares)
                    .HasColumnName("totalShares")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblMeterReading>(entity =>
            {
                entity.HasKey(e => e.MeterReadingId);

                entity.ToTable("tbl_MeterReading");

                entity.Property(e => e.MeterReadingId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.Consumption)
                    .HasColumnName("consumption")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Density)
                    .HasColumnName("density")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InMeterReading)
                    .HasColumnName("inMeterReading")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.InvoiceSales)
                    .HasColumnName("invoiceSales")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.OutMeterReading)
                    .HasColumnName("outMeterReading")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PumpId)
                    .HasColumnName("pumpID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PumpNo)
                    .HasColumnName("pumpNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Testing)
                    .HasColumnName("testing")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalSales)
                    .HasColumnName("totalSales")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Variation)
                    .HasColumnName("variation")
                    .HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblModelNo>(entity =>
            {
                entity.HasKey(e => e.ModelNoId)
                    .HasName("PK__tbl_Mode__8458D8C94DB4832C");

                entity.ToTable("tbl_ModelNo");

                entity.Property(e => e.ModelNoId)
                    .HasColumnName("modelNoId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModelNo)
                    .HasColumnName("modelNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMonthList>(entity =>
            {
                entity.HasKey(e => e.MonthId)
                    .HasName("PK__tbl__MonthList");

                entity.ToTable("tbl_MonthList");

                entity.Property(e => e.MonthId)
                    .HasColumnName("monthID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MonthName)
                    .HasColumnName("monthName")
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDays)
                    .HasColumnName("noOfDays")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblMonthListForReports>(entity =>
            {
                entity.HasKey(e => e.MonthId)
                    .HasName("PK__tbl__MonthListForReports");

                entity.ToTable("tbl_MonthListForReports");

                entity.Property(e => e.MonthId)
                    .HasColumnName("monthID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Fromdt)
                    .HasColumnName("FROMDt")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonthName)
                    .HasColumnName("monthName")
                    .IsUnicode(false);

                entity.Property(e => e.Todt)
                    .HasColumnName("TODt")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMonthlySalary>(entity =>
            {
                entity.HasKey(e => e.MonthlySalaryId)
                    .HasName("PK__tbl_Mont__DD79B8643C34F16F");

                entity.ToTable("tbl_MonthlySalary");

                entity.Property(e => e.MonthlySalaryId)
                    .HasColumnName("monthlySalaryId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SalaryMonth)
                    .HasColumnName("salaryMonth")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMonthlySalaryDetails>(entity =>
            {
                entity.HasKey(e => e.MonthlySalaryDetailsId)
                    .HasName("PK__tbl_Mont__04252B5040058253");

                entity.ToTable("tbl_MonthlySalaryDetails");

                entity.Property(e => e.MonthlySalaryDetailsId)
                    .HasColumnName("monthlySalaryDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonthlySalaryId)
                    .HasColumnName("monthlySalaryId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalaryPackageId)
                    .HasColumnName("salaryPackageId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblMshsdrates>(entity =>
            {
                entity.ToTable("tbl_MSHSDRates");

                entity.Property(e => e.ID)
                    .HasColumnName("iD")
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblOilConversionDetails>(entity =>
            {
                entity.HasKey(e => e.OilConversionDetailId)
                    .HasName("PK__tbl_OilConversionDetails");

                entity.ToTable("tbl_OilConversionDetails");

                entity.Property(e => e.OilConversionDetailId)
                    .HasColumnName("oilConversionDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batchNo")
                    .IsUnicode(false);

                entity.Property(e => e.DamageQty)
                    .HasColumnName("damageQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NewQty)
                    .HasColumnName("newQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.OilConversionDetailsDate)
                    .HasColumnName("oilConversionDetailsDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OilConversionMasterId)
                    .HasColumnName("oilConversionMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOilConversionMaster>(entity =>
            {
                entity.HasKey(e => e.OilConversionMasterId);

                entity.ToTable("tbl_OilConversionMaster");

                entity.Property(e => e.OilConversionMasterId)
                    .HasColumnName("oilConversionMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.OilConversionDate)
                    .HasColumnName("oilConversionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OilConversionVchNo)
                    .HasColumnName("oilConversionVchNo")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblOpeningBalance>(entity =>
            {
                entity.HasKey(e => e.OpeningBalanceId)
                    .HasName("PK__tbl_Open__5E1AFE196CCE70E6");

                entity.ToTable("tbl_OpeningBalance");

                entity.Property(e => e.OpeningBalanceId)
                    .HasColumnName("openingBalanceId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LedgerCode)
                    .HasColumnName("ledgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.OpeningBalanceDate)
                    .HasColumnName("openingBalanceDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentTypeId)
                    .HasColumnName("paymentTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PaymentTypeName)
                    .HasColumnName("paymentTypeName")
                    .IsUnicode(false);

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TblOperatorStockIssues>(entity =>
            {
                entity.HasKey(e => e.OperatorStockIssueId)
                    .HasName("PK__tbl_OperatorStockIssues");

                entity.ToTable("tbl_OperatorStockIssues");

                entity.Property(e => e.OperatorStockIssueId)
                    .HasColumnName("operatorStockIssueId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromBranchCode)
                    .IsRequired()
                    .HasColumnName("fromBranchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.FromBranchName)
                    .IsRequired()
                    .HasColumnName("fromBranchName")
                    .HasMaxLength(250);

                entity.Property(e => e.IssueDate)
                    .HasColumnName("issueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IssueNo)
                    .HasColumnName("issueNo")
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToBranchCode)
                    .IsRequired()
                    .HasColumnName("toBranchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.ToBranchName)
                    .IsRequired()
                    .HasColumnName("toBranchName")
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOperatorStockIssuesDetail>(entity =>
            {
                entity.HasKey(e => e.OperatorStockIssueDetailId)
                    .HasName("PK__tbl_OperatorStockIssuesDetail");

                entity.ToTable("tbl_OperatorStockIssuesDetail");

                entity.Property(e => e.OperatorStockIssueDetailId)
                    .HasColumnName("operatorStockIssueDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AvailStock)
                    .HasColumnName("availStock")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batchNo")
                    .IsUnicode(false);

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IssueDate)
                    .HasColumnName("issueDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IssueNo)
                    .HasColumnName("issueNo")
                    .IsUnicode(false);

                entity.Property(e => e.OperatorStockIssueId)
                    .HasColumnName("operatorStockIssueId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasColumnName("productGroupCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupId)
                    .HasColumnName("productGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxGroupCode)
                    .IsRequired()
                    .HasColumnName("taxGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxGroupName)
                    .IsRequired()
                    .HasColumnName("taxGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOperatorStockReceipt>(entity =>
            {
                entity.HasKey(e => e.OperatorStockReceiptId)
                    .HasName("PK__tbl_OperatorStockReceipt");

                entity.ToTable("tbl_OperatorStockReceipt");

                entity.Property(e => e.OperatorStockReceiptId)
                    .HasColumnName("operatorStockReceiptId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromBranchCode)
                    .IsRequired()
                    .HasColumnName("fromBranchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.FromBranchName)
                    .IsRequired()
                    .HasColumnName("fromBranchName")
                    .HasMaxLength(250);

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receiptDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReceiptNo)
                    .HasColumnName("receiptNo")
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToBranchCode)
                    .IsRequired()
                    .HasColumnName("toBranchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.ToBranchName)
                    .IsRequired()
                    .HasColumnName("toBranchName")
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOperatorStockReceiptDetail>(entity =>
            {
                entity.HasKey(e => e.OperatorStockReceiptDetailId)
                    .HasName("PK__tbl_OperatorStockReceiptDetail");

                entity.ToTable("tbl_OperatorStockReceiptDetail");

                entity.Property(e => e.OperatorStockReceiptDetailId)
                    .HasColumnName("operatorStockReceiptDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AvailStock)
                    .HasColumnName("availStock")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batchNo")
                    .IsUnicode(false);

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.OperatorStockReceiptId)
                    .HasColumnName("operatorStockReceiptId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasColumnName("productGroupCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupId)
                    .HasColumnName("productGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receiptDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReceiptNo)
                    .HasColumnName("receiptNo")
                    .IsUnicode(false);

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxGroupCode)
                    .IsRequired()
                    .HasColumnName("taxGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxGroupName)
                    .IsRequired()
                    .HasColumnName("taxGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPackageConversion>(entity =>
            {
                entity.HasKey(e => e.PackingConversionId);

                entity.ToTable("tbl_PackageConversion");

                entity.Property(e => e.PackingConversionId)
                    .HasColumnName("packingConversionID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InputProductId)
                    .HasColumnName("inputProductId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InputQty)
                    .HasColumnName("inputQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.InputproductCode)
                    .IsRequired()
                    .HasColumnName("inputproductCode")
                    .IsUnicode(false);

                entity.Property(e => e.InputproductName)
                    .IsRequired()
                    .HasColumnName("inputproductName")
                    .IsUnicode(false);

                entity.Property(e => e.OutputProductId)
                    .HasColumnName("outputProductId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OutputQty)
                    .HasColumnName("outputQty")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.OutputproductCode)
                    .IsRequired()
                    .HasColumnName("outputproductCode")
                    .IsUnicode(false);

                entity.Property(e => e.OutputproductName)
                    .IsRequired()
                    .HasColumnName("outputproductName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPartyBalance>(entity =>
            {
                entity.HasKey(e => e.PartyBalanceId)
                    .HasName("PK__tbl_Part__69824BB71C680BB2");

                entity.ToTable("tbl_PartyBalance");

                entity.Property(e => e.PartyBalanceId)
                    .HasColumnName("partyBalanceId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AgainstInvoiceNo)
                    .HasColumnName("againstInvoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.AgainstVoucherNo)
                    .HasColumnName("againstVoucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.AgainstVoucherTypeId)
                    .HasColumnName("againstVoucherTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.CreditPeriod).HasColumnName("creditPeriod");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Debit)
                    .HasColumnName("debit")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ReferenceType)
                    .HasColumnName("referenceType")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPassbookStatus>(entity =>
            {
                entity.HasKey(e => e.PassbookStatusId)
                    .HasName("PK__tbl_PassbookStatus");

                entity.ToTable("tbl_PassbookStatus");

                entity.Property(e => e.PassbookStatusId)
                    .HasColumnName("passbookStatusId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PassbookStatusName)
                    .IsRequired()
                    .HasColumnName("passbookStatusName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPayHead>(entity =>
            {
                entity.HasKey(e => e.PayHeadId)
                    .HasName("PK__tbl_PayH__1BAC6FBD2CF2ADDF");

                entity.ToTable("tbl_PayHead");

                entity.Property(e => e.PayHeadId)
                    .HasColumnName("payHeadId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PayHeadName)
                    .HasColumnName("payHeadName")
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPaymentDetails>(entity =>
            {
                entity.HasKey(e => e.PaymentDetailsId)
                    .HasName("PK__tbl_Paym__2549CB8A6AD0B01E");

                entity.ToTable("tbl_PaymentDetails");

                entity.Property(e => e.PaymentDetailsId)
                    .HasColumnName("paymentDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PaymentMasterId)
                    .HasColumnName("paymentMasterId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPaymentMaster>(entity =>
            {
                entity.HasKey(e => e.PaymentMasterId)
                    .HasName("PK__tbl_Paym__F6D0847167001F3A");

                entity.ToTable("tbl_PaymentMaster");

                entity.Property(e => e.PaymentMasterId)
                    .HasColumnName("paymentMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId);

                entity.ToTable("tbl_PaymentType");

                entity.Property(e => e.PaymentTypeId)
                    .HasColumnName("paymentTypeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PaymentTypeName)
                    .HasColumnName("paymentTypeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPdcclearanceMaster>(entity =>
            {
                entity.HasKey(e => e.PdcclearanceMasterId)
                    .HasName("PK__tbl_PDCC__D88D38E00955373E");

                entity.ToTable("tbl_PDCClearanceMaster");

                entity.Property(e => e.PdcclearanceMasterId)
                    .HasColumnName("PDCClearanceMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AgainstId)
                    .HasColumnName("againstId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPdcpayableMaster>(entity =>
            {
                entity.HasKey(e => e.PdcPayableMasterId)
                    .HasName("PK__tbl_PDCP__D5E696DE01B41576");

                entity.ToTable("tbl_PDCPayableMaster");

                entity.Property(e => e.PdcPayableMasterId)
                    .HasColumnName("pdcPayableMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BankId)
                    .HasColumnName("bankId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPdcreceivableMaster>(entity =>
            {
                entity.HasKey(e => e.PdcReceivableMasterId)
                    .HasName("PK__tbl_PDCR__A14C5E250584A65A");

                entity.ToTable("tbl_PDCReceivableMaster");

                entity.Property(e => e.PdcReceivableMasterId)
                    .HasColumnName("pdcReceivableMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BankId)
                    .HasColumnName("bankId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPhysicalStockDetails>(entity =>
            {
                entity.HasKey(e => e.PhysicalStockDetailsId)
                    .HasName("PK__tbl_Phys__A94165330ED9066A");

                entity.ToTable("tbl_PhysicalStockDetails");

                entity.Property(e => e.PhysicalStockDetailsId)
                    .HasColumnName("physicalStockDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PhysicalStockMasterId)
                    .HasColumnName("physicalStockMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Slno).HasColumnName("slno");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPhysicalStockMaster>(entity =>
            {
                entity.HasKey(e => e.PhysicalStockMasterId)
                    .HasName("PK__tbl_Phys__7367DF7A0B087586");

                entity.ToTable("tbl_PhysicalStockMaster");

                entity.Property(e => e.PhysicalStockMasterId)
                    .HasColumnName("physicalStockMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPriceList>(entity =>
            {
                entity.HasKey(e => e.PricelistId)
                    .HasName("PK__tbl_Pric__81BD4B85278EDA44");

                entity.ToTable("tbl_PriceList");

                entity.Property(e => e.PricelistId)
                    .HasColumnName("pricelistId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPricingLevel>(entity =>
            {
                entity.HasKey(e => e.PricinglevelId)
                    .HasName("PK__tbl_Pric__84E896EA23BE4960");

                entity.ToTable("tbl_PricingLevel");

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PricinglevelName)
                    .HasColumnName("pricinglevelName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPrivilege>(entity =>
            {
                entity.HasKey(e => e.PrivilegeId);

                entity.ToTable("tbl_Privilege");

                entity.Property(e => e.PrivilegeId)
                    .HasColumnName("privilegeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .IsUnicode(false);

                entity.Property(e => e.Exatra1)
                    .HasColumnName("exatra1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FormName)
                    .HasColumnName("formName")
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tbl_Product");

                entity.HasIndex(e => new { e.ProductCode, e.ProductName, e.HsnNo })
                    .HasName("NonClusteredIndex-20181226-173757");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Mrp)
                    .HasColumnName("mrp")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PackingCode)
                    .HasColumnName("packingCode")
                    .HasMaxLength(250);

                entity.Property(e => e.PackingId)
                    .HasColumnName("packingID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PackingName)
                    .HasColumnName("packingName")
                    .HasMaxLength(250);

                entity.Property(e => e.PackingSize)
                    .HasColumnName("packingSize")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.ProductGroupCode)
                    .HasColumnName("productGroupCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupId)
                    .HasColumnName("productGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupName)
                    .HasColumnName("productGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.PurchaseRate)
                    .HasColumnName("purchaseRate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.SalesRate)
                    .HasColumnName("salesRate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("supplierCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("supplierId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SupplierName)
                    .HasColumnName("supplierName")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupCode)
                    .HasColumnName("taxGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxGroupName)
                    .HasColumnName("taxGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxapplicableOn)
                    .HasColumnName("taxapplicableOn")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxapplicableOnId)
                    .HasColumnName("taxapplicableOnId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalPercentageGst)
                    .HasColumnName("totalPercentageGST")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProductGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("tbl_ProductGroup_groupId");

                entity.ToTable("tbl_ProductGroup");

                entity.Property(e => e.GroupId)
                    .HasColumnName("groupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GroupCode)
                    .HasColumnName("groupCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GroupName)
                    .HasColumnName("groupName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProductPacking>(entity =>
            {
                entity.HasKey(e => e.PackingId)
                    .HasName("PK__tbl_Prod__8084521F98046940");

                entity.ToTable("tbl_ProductPacking");

                entity.Property(e => e.PackingId)
                    .HasColumnName("packingID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BarrelVerify).HasColumnName("barrelVerify");

                entity.Property(e => e.BatchVerify).HasColumnName("batchVerify");

                entity.Property(e => e.PackingCode)
                    .IsRequired()
                    .HasColumnName("packingCode")
                    .HasMaxLength(250);

                entity.Property(e => e.PackingName)
                    .IsRequired()
                    .HasColumnName("packingName")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TblPumps>(entity =>
            {
                entity.HasKey(e => e.PumpId)
                    .HasName("PK__tbl__Pumps");

                entity.ToTable("tbl_Pumps");

                entity.Property(e => e.PumpId)
                    .HasColumnName("pumpID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.IsWorking).HasColumnName("isWorking");

                entity.Property(e => e.MeterReading)
                    .HasColumnName("meterReading")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.PumpCapacityinLtrs)
                    .HasColumnName("pumpCapacityinLtrs")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PumpNo)
                    .HasColumnName("pumpNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TankId)
                    .HasColumnName("tankID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TankNo)
                    .HasColumnName("tankNo")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPurchaseInvoice>(entity =>
            {
                entity.HasKey(e => e.PurchaseInvId)
                    .HasName("PK__tbl_purchaseInvoice");

                entity.ToTable("tbl_PurchaseInvoice");

                entity.Property(e => e.PurchaseInvId)
                    .HasColumnName("purchaseInvId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AmountInWords).HasMaxLength(250);

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grandTotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .IsUnicode(false);

                entity.Property(e => e.IsPurchaseReturned)
                    .HasColumnName("isPurchaseReturned")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LedgerCode)
                    .HasColumnName("ledgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.OtherAmount1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OtherAmount2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .HasColumnName("paymentMode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PurchaseInvDate)
                    .HasColumnName("purchaseInvDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PurchaseInvNo)
                    .HasColumnName("purchaseInvNo")
                    .IsUnicode(false);

                entity.Property(e => e.RoundOffMinus)
                    .HasColumnName("roundOffMinus")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.RoundOffPlus)
                    .HasColumnName("roundOffPlus")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StateCode).HasMaxLength(20);

                entity.Property(e => e.SupplierInvNo)
                    .HasColumnName("supplierInvNo")
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalCgst)
                    .HasColumnName("totalCGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalIgst)
                    .HasColumnName("totalIGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalSgst)
                    .HasColumnName("totalSGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotaltaxAmount)
                    .HasColumnName("totaltaxAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPurchaseInvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.PurchaseInvDetailId)
                    .HasName("PK__tbl_purchaseInvoiceDetail");

                entity.ToTable("tbl_PurchaseInvoiceDetail");

                entity.Property(e => e.PurchaseInvDetailId)
                    .HasColumnName("purchaseInvDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Barrel)
                    .HasColumnName("barrel")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BatchNo).HasColumnName("batchNo");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FQty)
                    .HasColumnName("fQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("purchaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PurchaseInvId)
                    .HasColumnName("purchaseInvId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PurchaseNo)
                    .HasColumnName("purchaseNo")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((37))");

                entity.Property(e => e.TankId)
                    .HasColumnName("tankID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TankNo)
                    .HasColumnName("tankNo")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxGroupCode)
                    .HasColumnName("taxGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalLiters)
                    .HasColumnName("totalLiters")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPurchaseOrderDetails>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderDetailsId)
                    .HasName("PK__tbl_Purc__BDE1867C70547F4A");

                entity.ToTable("tbl_PurchaseOrderDetails");

                entity.Property(e => e.PurchaseOrderDetailsId)
                    .HasColumnName("purchaseOrderDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.PurchaseOrderMasterId)
                    .HasColumnName("purchaseOrderMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.SlNo).HasColumnName("slNo");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPurchaseOrderMaster>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderMasterId)
                    .HasName("PK__tbl_Purc__DAD68F806C83EE66");

                entity.ToTable("tbl_PurchaseOrderMaster");

                entity.Property(e => e.PurchaseOrderMasterId)
                    .HasColumnName("purchaseOrderMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cancelled).HasColumnName("cancelled");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDate)
                    .HasColumnName("dueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPurchaseReturn>(entity =>
            {
                entity.HasKey(e => e.PurchaseReturnId)
                    .HasName("PK__tbl_PurchaseReturn");

                entity.ToTable("tbl_PurchaseReturn");

                entity.Property(e => e.PurchaseReturnId)
                    .HasColumnName("purchaseReturnId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AmountInWords).HasMaxLength(250);

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grandTotal")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerCode)
                    .HasColumnName("ledgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.OtherAmount1).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OtherAmount2).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .HasColumnName("paymentMode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PurchaseInvDate)
                    .HasColumnName("purchaseInvDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PurchaseInvNo)
                    .HasColumnName("purchaseInvNo")
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseMasterInvId)
                    .HasColumnName("purchaseMasterInvId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PurchaseReturnInvDate)
                    .HasColumnName("purchaseReturnInvDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PurchaseReturnInvNo)
                    .HasColumnName("purchaseReturnInvNo")
                    .IsUnicode(false);

                entity.Property(e => e.RoundOffMinus)
                    .HasColumnName("roundOffMinus")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.RoundOffPlus)
                    .HasColumnName("roundOffPlus")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StateCode).HasMaxLength(20);

                entity.Property(e => e.SupplierInvNo)
                    .HasColumnName("supplierInvNo")
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalCgst)
                    .HasColumnName("totalCGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalIgst)
                    .HasColumnName("totalIGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalSgst)
                    .HasColumnName("totalSGST")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotaltaxAmount)
                    .HasColumnName("totaltaxAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblPurchaseReturnDetails>(entity =>
            {
                entity.HasKey(e => e.PurchaseReturnDetailsId)
                    .HasName("PK__tbl_PurchaseReturnDetails");

                entity.ToTable("tbl_PurchaseReturnDetails");

                entity.Property(e => e.PurchaseReturnDetailsId)
                    .HasColumnName("purchaseReturnDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Barrel)
                    .HasColumnName("barrel")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batchNo")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FQty)
                    .HasColumnName("fQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseReturnDate)
                    .HasColumnName("purchaseReturnDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PurchaseReturnId)
                    .HasColumnName("purchaseReturnId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PurchaseReturnNo)
                    .HasColumnName("purchaseReturnNo")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((37))");

                entity.Property(e => e.TankId)
                    .HasColumnName("tankID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TankNo)
                    .HasColumnName("tankNo")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxGroupCode)
                    .HasColumnName("taxGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalLiters)
                    .HasColumnName("totalLiters")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblQuickLaunchItems>(entity =>
            {
                entity.HasKey(e => e.QuickLaunchItemsId);

                entity.ToTable("tbl_QuickLaunchItems");

                entity.Property(e => e.QuickLaunchItemsId)
                    .HasColumnName("quickLaunchItemsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemsName)
                    .HasColumnName("itemsName")
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblQuickLaunchItemsToCopy>(entity =>
            {
                entity.HasKey(e => e.QuickLaunchItemsId);

                entity.ToTable("tbl_QuickLaunchItemsToCopy");

                entity.Property(e => e.QuickLaunchItemsId)
                    .HasColumnName("quickLaunchItemsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemsName)
                    .HasColumnName("itemsName")
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TblRack>(entity =>
            {
                entity.HasKey(e => e.RackId)
                    .HasName("PK__tbl_Rack__B34912495555A4F4");

                entity.ToTable("tbl_Rack");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.RackName)
                    .HasColumnName("rackName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRebateMaster>(entity =>
            {
                entity.HasKey(e => e.RebateMasterId)
                    .HasName("PK__tbl__RebateMaster");

                entity.ToTable("tbl_RebateMaster");

                entity.Property(e => e.RebateMasterId)
                    .HasColumnName("rebateMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DieselQty)
                    .HasColumnName("dieselQty")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FineAmount)
                    .HasColumnName("fineAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MemberCretiria)
                    .HasColumnName("memberCretiria")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RebateId)
                    .HasColumnName("rebateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RebateName)
                    .IsRequired()
                    .HasColumnName("rebateName")
                    .IsUnicode(false);

                entity.Property(e => e.RebatePerLtr)
                    .HasColumnName("rebatePerLtr")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SparesPercentage)
                    .HasColumnName("sparesPercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.Rebate)
                    .WithMany(p => p.TblRebateMaster)
                    .HasForeignKey(d => d.RebateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RebateMaster_Rebate_fk");
            });

            modelBuilder.Entity<TblRebateType>(entity =>
            {
                entity.HasKey(e => e.RebateId)
                    .HasName("PK__tbl_Rebate");

                entity.ToTable("tbl_RebateType");

                entity.Property(e => e.RebateId)
                    .HasColumnName("rebateId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RebateName)
                    .IsRequired()
                    .HasColumnName("rebateName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblReceiptDetails>(entity =>
            {
                entity.HasKey(e => e.ReceiptDetailsId)
                    .HasName("PK__tbl_Rece__C0FF33FB6EA14102");

                entity.ToTable("tbl_ReceiptDetails");

                entity.Property(e => e.ReceiptDetailsId)
                    .HasColumnName("receiptDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ChequeDate)
                    .HasColumnName("chequeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ReceiptMasterId)
                    .HasColumnName("receiptMasterId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblReceiptMaster>(entity =>
            {
                entity.HasKey(e => e.ReceiptMasterId)
                    .HasName("PK__tbl_Rece__B974C2984925A390");

                entity.ToTable("tbl_ReceiptMaster");

                entity.Property(e => e.ReceiptMasterId)
                    .HasColumnName("receiptMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblRejectionInDetails>(entity =>
            {
                entity.HasKey(e => e.RejectionInDetailsId)
                    .HasName("PK__tbl_Reje__1B0C62F44A2ED662");

                entity.ToTable("tbl_RejectionInDetails");

                entity.Property(e => e.RejectionInDetailsId)
                    .HasColumnName("rejectionInDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DeliveryNoteDetailsId)
                    .HasColumnName("deliveryNoteDetailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RejectionInMasterId)
                    .HasColumnName("rejectionInMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SlNo).HasColumnName("slNo");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblRejectionInMaster>(entity =>
            {
                entity.HasKey(e => e.RejectionInMasterId)
                    .HasName("PK__tbl_Reje__9C0B04FD465E457E");

                entity.ToTable("tbl_RejectionInMaster");

                entity.Property(e => e.RejectionInMasterId)
                    .HasColumnName("rejectionInMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliveryNoteMasterId)
                    .HasColumnName("deliveryNoteMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LrNo)
                    .HasColumnName("lrNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TransportationCompany)
                    .HasColumnName("transportationCompany")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblRejectionOutDetails>(entity =>
            {
                entity.HasKey(e => e.RejectionOutDetailsId)
                    .HasName("PK__tbl_Reje__4B87F6607F96C2DA");

                entity.ToTable("tbl_RejectionOutDetails");

                entity.Property(e => e.RejectionOutDetailsId)
                    .HasColumnName("rejectionOutDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MaterialReceiptDetailsId)
                    .HasColumnName("materialReceiptDetailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RejectionOutMasterId)
                    .HasColumnName("rejectionOutMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Slno).HasColumnName("slno");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblRejectionOutMaster>(entity =>
            {
                entity.HasKey(e => e.RejectionOutMasterId)
                    .HasName("PK__tbl_Reje__236B422C7BC631F6");

                entity.ToTable("tbl_RejectionOutMaster");

                entity.Property(e => e.RejectionOutMasterId)
                    .HasColumnName("rejectionOutMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LrNo)
                    .HasColumnName("lrNo")
                    .IsUnicode(false);

                entity.Property(e => e.MaterialReceiptMasterId)
                    .HasColumnName("materialReceiptMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TransportationCompany)
                    .HasColumnName("transportationCompany")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblRelation>(entity =>
            {
                entity.HasKey(e => e.RelationId)
                    .HasName("PK__tbl_Relation");

                entity.ToTable("tbl_Relation");

                entity.Property(e => e.RelationId)
                    .HasColumnName("relationId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RelationName)
                    .IsRequired()
                    .HasColumnName("relationName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblReminder>(entity =>
            {
                entity.HasKey(e => e.ReminderId);

                entity.ToTable("tbl_Reminder");

                entity.Property(e => e.ReminderId)
                    .HasColumnName("reminderId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RemindAbout)
                    .HasColumnName("remindAbout")
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("tPK_tbl_Role");

                entity.ToTable("tbl_Role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRolePrivilegeForm>(entity =>
            {
                entity.HasKey(e => e.PrivilegeId);

                entity.ToTable("tbl_RolePrivilegeForm");

                entity.Property(e => e.PrivilegeId)
                    .HasColumnName("privilegeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Add)
                    .HasColumnName("add")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FormId)
                    .HasColumnName("formId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FormName)
                    .HasColumnName("formName")
                    .IsUnicode(false);

                entity.Property(e => e.IsFormActive)
                    .HasColumnName("isFormActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMenuActive)
                    .HasColumnName("isMenuActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MainMenuId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Update)
                    .HasColumnName("update")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.View)
                    .HasColumnName("view")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblRolePrivilegeMenu>(entity =>
            {
                entity.ToTable("tbl_RolePrivilegeMenu");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MenuId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId);

                entity.ToTable("tbl_Route");

                entity.Property(e => e.RouteId)
                    .HasColumnName("routeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AreaId)
                    .HasColumnName("areaId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.RouteName)
                    .HasColumnName("routeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSalaryPackage>(entity =>
            {
                entity.HasKey(e => e.SalaryPackageId)
                    .HasName("PK__tbl_Sala__B78BCF693493CFA7");

                entity.ToTable("tbl_SalaryPackage");

                entity.Property(e => e.SalaryPackageId)
                    .HasColumnName("salaryPackageId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SalaryPackageName)
                    .HasColumnName("salaryPackageName")
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<TblSalaryPackageDetails>(entity =>
            {
                entity.HasKey(e => e.SalaryPackageDetailsId)
                    .HasName("PK__tbl_Sala__993415083864608B");

                entity.ToTable("tbl_SalaryPackageDetails");

                entity.Property(e => e.SalaryPackageDetailsId)
                    .HasColumnName("salaryPackageDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(18, 5)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PayHeadId)
                    .HasColumnName("payHeadId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalaryPackageId)
                    .HasColumnName("salaryPackageId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalaryParameters>(entity =>
            {
                entity.HasKey(e => e.SalaryParameterId)
                    .HasName("PK__tbl__SalaryParameters");

                entity.ToTable("tbl_SalaryParameters");

                entity.Property(e => e.SalaryParameterId)
                    .HasColumnName("salaryParameterID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BonusRange)
                    .HasColumnName("bonusRange")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DaAmount)
                    .HasColumnName("daAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DaPercentage)
                    .HasColumnName("daPercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DaysInMonth)
                    .HasColumnName("daysInMonth")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EpfPercentage)
                    .HasColumnName("epfPercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.EsiArears)
                    .HasColumnName("esiArears")
                    .IsUnicode(false);

                entity.Property(e => e.EsiPercentage)
                    .HasColumnName("esiPercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.EsiRange)
                    .HasColumnName("esiRange")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.FpfPercentage)
                    .HasColumnName("fpfPercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.HraAmount)
                    .HasColumnName("hraAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.HraPercentage)
                    .HasColumnName("hraPercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.MonthId)
                    .HasColumnName("monthID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MonthName)
                    .HasColumnName("monthName")
                    .IsUnicode(false);

                entity.Property(e => e.PfRange)
                    .HasColumnName("pfRange")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProfitTax)
                    .HasColumnName("profitTax")
                    .HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblSalaryProcessData>(entity =>
            {
                entity.HasKey(e => e.SalaryProcessDataId);

                entity.ToTable("tbl_SalaryProcessData");

                entity.Property(e => e.SalaryProcessDataId)
                    .HasColumnName("salaryProcessDataID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Advance)
                    .HasColumnName("advance")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Areas)
                    .HasColumnName("areas")
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNo)
                    .HasColumnName("bankAccountNo")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Basic)
                    .HasColumnName("basic")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Ca)
                    .HasColumnName("ca")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Csli)
                    .HasColumnName("csli")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Da)
                    .HasColumnName("da")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DeductionRemarks)
                    .HasColumnName("deductionRemarks")
                    .IsUnicode(false);

                entity.Property(e => e.EarnedBasic)
                    .HasColumnName("earnedBasic")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("employeeCode")
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeMasterId)
                    .HasColumnName("employeeMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .IsUnicode(false);

                entity.Property(e => e.Esi)
                    .HasColumnName("esi")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Fpf)
                    .HasColumnName("fpf")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Gsli)
                    .HasColumnName("gsli")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Hra)
                    .HasColumnName("hra")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Lic)
                    .HasColumnName("lic")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Loan1)
                    .HasColumnName("loan1")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Loan2)
                    .HasColumnName("loan2")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Loan3)
                    .HasColumnName("loan3")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Loan4)
                    .HasColumnName("loan4")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.LossOfPay)
                    .HasColumnName("lossOfPay")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.McLoan)
                    .HasColumnName("mcLoan")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MessAllowance)
                    .HasColumnName("messAllowance")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MonthId)
                    .HasColumnName("monthID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MonthName)
                    .HasColumnName("monthName")
                    .IsUnicode(false);

                entity.Property(e => e.NetSalary)
                    .HasColumnName("netSalary")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Other1)
                    .HasColumnName("other1")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Other2)
                    .HasColumnName("other2")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Other3)
                    .HasColumnName("other3")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.OtherDeductions)
                    .HasColumnName("otherDeductions")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.OtherEarings)
                    .HasColumnName("otherEarings")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PTax)
                    .HasColumnName("pTax")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Pf)
                    .HasColumnName("pf")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Pp)
                    .HasColumnName("pp")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ProcessDate)
                    .HasColumnName("processDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProfitTax)
                    .HasColumnName("profitTax")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.SalaryParameterId)
                    .HasColumnName("salaryParameterID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalaryProcessDataVoucherNo)
                    .IsRequired()
                    .HasColumnName("salaryProcessDataVoucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.SpecialAllowance)
                    .HasColumnName("specialAllowance")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Tds)
                    .HasColumnName("tds")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalDeductions)
                    .HasColumnName("totalDeductions")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalEarnings)
                    .HasColumnName("totalEarnings")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalPayDays)
                    .HasColumnName("totalPayDays")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.WorkingDays)
                    .HasColumnName("workingDays")
                    .HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblSalaryVoucherDetails>(entity =>
            {
                entity.HasKey(e => e.SalaryVoucherDetailsId)
                    .HasName("PK__tbl_Sala__054D02EE47A6A41B");

                entity.ToTable("tbl_SalaryVoucherDetails");

                entity.Property(e => e.SalaryVoucherDetailsId)
                    .HasColumnName("salaryVoucherDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Advance)
                    .HasColumnName("advance")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Deduction)
                    .HasColumnName("deduction")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lop)
                    .HasColumnName("lop")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.SalaryVoucherMasterId)
                    .HasColumnName("salaryVoucherMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSalaryVoucherMaster>(entity =>
            {
                entity.HasKey(e => e.SalaryVoucherMasterId)
                    .HasName("PK__tbl_Sala__B363606243D61337");

                entity.ToTable("tbl_SalaryVoucherMaster");

                entity.Property(e => e.SalaryVoucherMasterId)
                    .HasColumnName("salaryVoucherMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesBillTax>(entity =>
            {
                entity.HasKey(e => e.SalesBillTaxId)
                    .HasName("PK__tbl_Sale__3E4B1B27334B710A");

                entity.ToTable("tbl_SalesBillTax");

                entity.Property(e => e.SalesBillTaxId)
                    .HasColumnName("salesBillTaxId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SalesMasterId)
                    .HasColumnName("salesMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("taxAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TaxId)
                    .HasColumnName("taxId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesDetails>(entity =>
            {
                entity.HasKey(e => e.SalesDetailsId)
                    .HasName("PK__tbl_Sale__541370DA371C01EE");

                entity.ToTable("tbl_SalesDetails");

                entity.Property(e => e.SalesDetailsId)
                    .HasColumnName("salesDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DeliveryNoteDetailsId)
                    .HasColumnName("deliveryNoteDetailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.NetAmount)
                    .HasColumnName("netAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.OrderDetailsId)
                    .HasColumnName("orderDetailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.QuotationDetailsId)
                    .HasColumnName("quotationDetailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.SalesMasterId)
                    .HasColumnName("salesMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SlNo).HasColumnName("slNo");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("taxAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TaxId)
                    .HasColumnName("taxId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesMaster>(entity =>
            {
                entity.HasKey(e => e.SalesMasterId)
                    .HasName("PK__tbl_Sale__036BDC222F7AE026");

                entity.ToTable("tbl_SalesMaster");

                entity.Property(e => e.SalesMasterId)
                    .HasColumnName("salesMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionalCost)
                    .HasColumnName("additionalCost")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BillDiscount)
                    .HasColumnName("billDiscount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.CounterId)
                    .HasColumnName("counterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreditPeriod).HasColumnName("creditPeriod");

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customerName")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliveryNoteMasterId)
                    .HasColumnName("deliveryNoteMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grandTotal")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LrNo)
                    .HasColumnName("lrNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.OrderMasterId)
                    .HasColumnName("orderMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Pos).HasColumnName("POS");

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.QuotationMasterId)
                    .HasColumnName("quotationMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalesAccount)
                    .HasColumnName("salesAccount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("taxAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TransportationCompany)
                    .HasColumnName("transportationCompany")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesOrderDetails>(entity =>
            {
                entity.HasKey(e => e.SalesOrderDetailsId)
                    .HasName("PK__tbl_Sale__45789749597119F2");

                entity.ToTable("tbl_SalesOrderDetails");

                entity.Property(e => e.SalesOrderDetailsId)
                    .HasColumnName("salesOrderDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.QuotationDetailsId)
                    .HasColumnName("quotationDetailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.SalesOrderMasterId)
                    .HasColumnName("salesOrderMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SlNo).HasColumnName("slNo");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesOrderMaster>(entity =>
            {
                entity.HasKey(e => e.SalesOrderMasterId)
                    .HasName("PK__tbl_Sale__9D8A0C5455A0890E");

                entity.ToTable("tbl_SalesOrderMaster");

                entity.Property(e => e.SalesOrderMasterId)
                    .HasColumnName("salesOrderMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cancelled).HasColumnName("cancelled");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueDate)
                    .HasColumnName("dueDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.QuotationMasterId)
                    .HasColumnName("quotationMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesQuotationDetails>(entity =>
            {
                entity.HasKey(e => e.QuotationDetailsId)
                    .HasName("PK__tbl_Sale__5875C12861123BBA");

                entity.ToTable("tbl_SalesQuotationDetails");

                entity.Property(e => e.QuotationDetailsId)
                    .HasColumnName("quotationDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.QuotationMasterId)
                    .HasColumnName("quotationMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Slno).HasColumnName("slno");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesQuotationMaster>(entity =>
            {
                entity.HasKey(e => e.QuotationMasterId)
                    .HasName("PK__tbl_Sale__8D6FDEBD5D41AAD6");

                entity.ToTable("tbl_SalesQuotationMaster");

                entity.Property(e => e.QuotationMasterId)
                    .HasColumnName("quotationMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesReturnBillTax>(entity =>
            {
                entity.HasKey(e => e.SalesReturnBillTaxId)
                    .HasName("PK__tbl_Sale__5BD749863EBD23B6");

                entity.ToTable("tbl_SalesReturnBillTax");

                entity.Property(e => e.SalesReturnBillTaxId)
                    .HasColumnName("salesReturnBillTaxId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SalesReturnMasterId)
                    .HasColumnName("salesReturnMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("taxAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TaxId)
                    .HasColumnName("taxId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesReturnDetails>(entity =>
            {
                entity.HasKey(e => e.SalesReturnDetailsId)
                    .HasName("PK__tbl_Sale__0C252C0D428DB49A");

                entity.ToTable("tbl_SalesReturnDetails");

                entity.Property(e => e.SalesReturnDetailsId)
                    .HasColumnName("salesReturnDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.NetAmount)
                    .HasColumnName("netAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.SalesDetailsId)
                    .HasColumnName("salesDetailsId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalesReturnMasterId)
                    .HasColumnName("salesReturnMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SlNo).HasColumnName("slNo");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("taxAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TaxId)
                    .HasColumnName("taxId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSalesReturnMaster>(entity =>
            {
                entity.HasKey(e => e.SalesReturnMasterId)
                    .HasName("PK__tbl_Sale__DB499E433AEC92D2");

                entity.ToTable("tbl_SalesReturnMaster");

                entity.Property(e => e.SalesReturnMasterId)
                    .HasColumnName("salesReturnMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grandTotal")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LrNo)
                    .HasColumnName("lrNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PricinglevelId)
                    .HasColumnName("pricinglevelId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalesAccount)
                    .HasColumnName("salesAccount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalesMasterId)
                    .HasColumnName("salesMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxAmount)
                    .HasColumnName("taxAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TransportationCompany)
                    .HasColumnName("transportationCompany")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblService>(entity =>
            {
                entity.HasKey(e => e.ServiceId)
                    .HasName("PK__tbl_Serv__455070DF70099B30");

                entity.ToTable("tbl_Service");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("serviceId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ServiceCategoryId)
                    .HasColumnName("serviceCategoryId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ServiceName)
                    .HasColumnName("serviceName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblServiceCategory>(entity =>
            {
                entity.HasKey(e => e.ServiceCategoryId)
                    .HasName("PK__tbl_Serv__77EC43563AA1AEB8");

                entity.ToTable("tbl_ServiceCategory");

                entity.Property(e => e.ServiceCategoryId)
                    .HasColumnName("serviceCategoryId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryName)
                    .HasColumnName("categoryName")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblServiceDetails>(entity =>
            {
                entity.HasKey(e => e.ServiceDetailsId)
                    .HasName("PK__tbl_Serv__E8F292C47DE38492");

                entity.ToTable("tbl_ServiceDetails");

                entity.Property(e => e.ServiceDetailsId)
                    .HasColumnName("serviceDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Measure)
                    .HasColumnName("measure")
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId)
                    .HasColumnName("serviceId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ServiceMasterId)
                    .HasColumnName("serviceMasterId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblServiceMaster>(entity =>
            {
                entity.HasKey(e => e.ServiceMasterId)
                    .HasName("PK__tbl_Serv__BF261C547A12F3AE");

                entity.ToTable("tbl_ServiceMaster");

                entity.Property(e => e.ServiceMasterId)
                    .HasColumnName("serviceMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreditPeriod).HasColumnName("creditPeriod");

                entity.Property(e => e.Customer)
                    .HasColumnName("customer")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GrandTotal)
                    .HasColumnName("grandTotal")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.ServiceAccount)
                    .HasColumnName("serviceAccount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblSettings>(entity =>
            {
                entity.HasKey(e => e.SettingsId);

                entity.ToTable("tbl_Settings");

                entity.Property(e => e.SettingsId)
                    .HasColumnName("settingsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SettingsName)
                    .HasColumnName("settingsName")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSettingsToCopy>(entity =>
            {
                entity.HasKey(e => e.SettingsId);

                entity.ToTable("tbl_SettingsToCopy");

                entity.Property(e => e.SettingsId)
                    .HasColumnName("settingsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SettingsName)
                    .HasColumnName("settingsName")
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblShareTransfer>(entity =>
            {
                entity.HasKey(e => e.ShareId)
                    .HasName("PK__tbl_ShareTransfer");

                entity.ToTable("tbl_ShareTransfer");

                entity.Property(e => e.ShareId)
                    .HasColumnName("shareId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FromMemberCode)
                    .HasColumnName("fromMemberCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromMemberId)
                    .HasColumnName("fromMemberId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromMemberName)
                    .IsRequired()
                    .HasColumnName("fromMemberName")
                    .HasMaxLength(250);

                entity.Property(e => e.FromMemberSharesAfter).HasColumnName("fromMemberSharesAfter");

                entity.Property(e => e.FromMemberSharesBefore).HasColumnName("fromMemberSharesBefore");

                entity.Property(e => e.IsSharesTransfered).HasColumnName("isSharesTransfered");

                entity.Property(e => e.ShareCode)
                    .HasColumnName("shareCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ShareTransferCode)
                    .IsRequired()
                    .HasColumnName("shareTransferCode")
                    .HasMaxLength(250);

                entity.Property(e => e.ToMemberCode)
                    .HasColumnName("toMemberCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToMemberId)
                    .HasColumnName("toMemberId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToMemberName)
                    .IsRequired()
                    .HasColumnName("toMemberName")
                    .HasMaxLength(250);

                entity.Property(e => e.ToMemberSharesAfter).HasColumnName("toMemberSharesAfter");

                entity.Property(e => e.ToMemberSharesBefore).HasColumnName("toMemberSharesBefore");

                entity.Property(e => e.TransferDate)
                    .HasColumnName("transferDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblShareValue>(entity =>
            {
                entity.HasKey(e => e.ShareValueId);

                entity.ToTable("tbl_ShareValue");

                entity.Property(e => e.ShareValueId)
                    .HasColumnName("shareValueID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SharePercentage)
                    .HasColumnName("sharePercentage")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ValueOfSingleShare)
                    .HasColumnName("valueOfSingleShare")
                    .HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblShift>(entity =>
            {
                entity.HasKey(e => e.ShiftId);

                entity.ToTable("tbl_Shift");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .IsUnicode(false);

                entity.Property(e => e.InTime)
                    .HasColumnName("inTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.OutTime)
                    .HasColumnName("outTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblShiftTimings>(entity =>
            {
                entity.HasKey(e => e.ShiftTimeId);

                entity.ToTable("tbl_ShiftTimings");

                entity.Property(e => e.ShiftTimeId)
                    .HasColumnName("shiftTimeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.ShiftDescription)
                    .HasColumnName("shiftDescription")
                    .HasMaxLength(250);

                entity.Property(e => e.ShiftEnd)
                    .HasColumnName("shiftEnd")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShiftStart)
                    .HasColumnName("shiftStart")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblSize>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PK__tbl_Size__55B1E55749E3F248");

                entity.ToTable("tbl_Size");

                entity.Property(e => e.SizeId)
                    .HasColumnName("sizeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStandardRate>(entity =>
            {
                entity.HasKey(e => e.StandardRateId)
                    .HasName("PK__tbl_Stan__F75A1E8460C757A0");

                entity.ToTable("tbl_StandardRate");

                entity.Property(e => e.StandardRateId)
                    .HasColumnName("standardRateId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApplicableFrom)
                    .HasColumnName("applicableFrom")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApplicableTo)
                    .HasColumnName("applicableTo")
                    .HasColumnType("datetime");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblStateWiseGst>(entity =>
            {
                entity.ToTable("tbl_StateWiseGst");

                entity.HasIndex(e => e.StateId)
                    .HasName("UQ__tbl_Stat__C3BA3B5B7162FF08")
                    .IsUnique();

                entity.HasIndex(e => e.StateName)
                    .HasName("UQ__tbl_Stat__554763153DD2A723")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cgst).HasColumnName("CGST");

                entity.Property(e => e.Igst).HasColumnName("IGST");

                entity.Property(e => e.Sgst).HasColumnName("SGST");

                entity.Property(e => e.StateCode).HasMaxLength(20);

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.State)
                    .WithOne(p => p.TblStateWiseGst)
                    .HasForeignKey<TblStateWiseGst>(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StateWiseGst_StateID_fk");
            });

            modelBuilder.Entity<TblStockEntry>(entity =>
            {
                entity.HasKey(e => e.StockEntryId);

                entity.ToTable("tbl_StockEntry");

                entity.Property(e => e.StockEntryId)
                    .HasColumnName("stockEntryId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VocherNo)
                    .HasColumnName("vocherNo")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TblStockEntryDetail>(entity =>
            {
                entity.HasKey(e => e.StockEntryDetailId)
                    .HasName("PK__tbl_StockEntryDetail");

                entity.ToTable("tbl_StockEntryDetail");

                entity.Property(e => e.StockEntryDetailId)
                    .HasColumnName("stockEntryDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BatchNo).HasColumnName("batchNo");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StockEntryDate)
                    .HasColumnName("stockEntryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StockEntryMasterId)
                    .HasColumnName("stockEntryMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StockEntryNo)
                    .HasColumnName("stockEntryNo")
                    .IsUnicode(false);

                entity.Property(e => e.StockValue)
                    .HasColumnName("stockValue")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblStockEntryMaster>(entity =>
            {
                entity.HasKey(e => e.StockEntryMasterId);

                entity.ToTable("tbl_StockEntryMaster");

                entity.Property(e => e.StockEntryMasterId)
                    .HasColumnName("stockEntryMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StockEntryDate)
                    .HasColumnName("stockEntryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StockEntryNo)
                    .HasColumnName("stockEntryNo")
                    .IsUnicode(false);

                entity.Property(e => e.TotalStockValue)
                    .HasColumnName("totalStockValue")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblStockExcessDetails>(entity =>
            {
                entity.HasKey(e => e.StockExcessDetailId)
                    .HasName("PK__tbl_StockExcessDetails");

                entity.ToTable("tbl_StockExcessDetails");

                entity.Property(e => e.StockExcessDetailId)
                    .HasColumnName("stockExcessDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batchNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StockExcessDetailsDate)
                    .HasColumnName("stockExcessDetailsDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockExcessMasterId)
                    .HasColumnName("stockExcessMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStockExcessMaster>(entity =>
            {
                entity.HasKey(e => e.StockExcessMasterId);

                entity.ToTable("tbl_StockExcessMaster");

                entity.Property(e => e.StockExcessMasterId)
                    .HasColumnName("stockExcessMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.CostCenter)
                    .HasColumnName("costCenter")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StockExcessDate)
                    .HasColumnName("stockExcessDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockExcessNo)
                    .HasColumnName("stockExcessNo")
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStockInformation>(entity =>
            {
                entity.HasKey(e => e.StockId);

                entity.ToTable("tbl_StockInformation");

                entity.Property(e => e.StockId)
                    .HasColumnName("stockId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.InwardQty)
                    .HasColumnName("inwardQty")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OutwardQty)
                    .HasColumnName("outwardQty")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblStockJournalDetails>(entity =>
            {
                entity.HasKey(e => e.StockJournalDetailsId)
                    .HasName("PK__tbl_Stoc__3224B9A70737E4A2");

                entity.ToTable("tbl_StockJournalDetails");

                entity.Property(e => e.StockJournalDetailsId)
                    .HasColumnName("stockJournalDetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ConsumptionOrProduction)
                    .HasColumnName("consumptionOrProduction")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Slno).HasColumnName("slno");

                entity.Property(e => e.StockJournalMasterId)
                    .HasColumnName("stockJournalMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitConversionId)
                    .HasColumnName("unitConversionId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblStockJournalMaster>(entity =>
            {
                entity.HasKey(e => e.StockJournalMasterId)
                    .HasName("PK__tbl_Stoc__8B1D7000036753BE");

                entity.ToTable("tbl_StockJournalMaster");

                entity.Property(e => e.StockJournalMasterId)
                    .HasColumnName("stockJournalMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionalCost)
                    .HasColumnName("additionalCost")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExchangeRateId)
                    .HasColumnName("exchangeRateId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.SuffixPrefixId)
                    .HasColumnName("suffixPrefixId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblStockPosting>(entity =>
            {
                entity.HasKey(e => e.StockPostingId)
                    .HasName("PK__tbl_Stoc__CAEC17F7158603F9");

                entity.ToTable("tbl_StockPosting");

                entity.Property(e => e.StockPostingId)
                    .HasColumnName("stockPostingId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AgainstInvoiceNo)
                    .HasColumnName("againstInvoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.AgainstVoucherNo)
                    .HasColumnName("againstVoucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.AgainstVoucherTypeId)
                    .HasColumnName("againstVoucherTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BatchId)
                    .HasColumnName("batchId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FinancialYearId)
                    .HasColumnName("financialYearId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.GodownId)
                    .HasColumnName("godownId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.InwardQty)
                    .HasColumnName("inwardQty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.OutwardQty)
                    .HasColumnName("outwardQty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RackId)
                    .HasColumnName("rackId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblStockTransfer>(entity =>
            {
                entity.HasKey(e => e.StockTransferId);

                entity.ToTable("tbl_StockTransfer");

                entity.Property(e => e.StockTransferId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FromBranch)
                    .HasColumnName("fromBranch")
                    .HasMaxLength(250);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.ToBranch)
                    .HasColumnName("toBranch")
                    .HasMaxLength(250);

                entity.Property(e => e.TransferNo).HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStockTransferDetail>(entity =>
            {
                entity.HasKey(e => e.StockTransferDetailId)
                    .HasName("PK__tbl_StockTransferDetail");

                entity.ToTable("tbl_StockTransferDetail");

                entity.Property(e => e.StockTransferDetailId)
                    .HasColumnName("stockTransferDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AvailStock)
                    .HasColumnName("availStock")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batchNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FQty)
                    .HasColumnName("fQty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasColumnName("productGroupCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupId)
                    .HasColumnName("productGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StockTransferDetailsDate)
                    .HasColumnName("stockTransferDetailsDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockTransferMasterId)
                    .HasColumnName("stockTransferMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStockTransferMaster>(entity =>
            {
                entity.HasKey(e => e.StockTransferMasterId)
                    .HasName("PK__tbl_StockTransferMaster");

                entity.ToTable("tbl_StockTransferMaster");

                entity.Property(e => e.StockTransferMasterId)
                    .HasColumnName("stockTransferMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromBranchCode)
                    .IsRequired()
                    .HasColumnName("fromBranchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.FromBranchName)
                    .IsRequired()
                    .HasColumnName("fromBranchName")
                    .HasMaxLength(250);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StockTransferDate)
                    .HasColumnName("stockTransferDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockTransferNo)
                    .HasColumnName("stockTransferNo")
                    .IsUnicode(false);

                entity.Property(e => e.ToBranchCode)
                    .IsRequired()
                    .HasColumnName("toBranchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.ToBranchName)
                    .IsRequired()
                    .HasColumnName("toBranchName")
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStockshortDetails>(entity =>
            {
                entity.HasKey(e => e.StockshortDetailId)
                    .HasName("PK__tbl_StockshortDetails");

                entity.ToTable("tbl_StockshortDetails");

                entity.Property(e => e.StockshortDetailId)
                    .HasColumnName("stockshortDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batchNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StockshortDetailsDate)
                    .HasColumnName("stockshortDetailsDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockshortMasterId)
                    .HasColumnName("stockshortMasterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStockshortMaster>(entity =>
            {
                entity.HasKey(e => e.StockshortMasterId);

                entity.ToTable("tbl_StockshortMaster");

                entity.Property(e => e.StockshortMasterId)
                    .HasColumnName("stockshortMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.CostCenter)
                    .HasColumnName("costCenter")
                    .HasMaxLength(250);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(250);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StockshortDate)
                    .HasColumnName("stockshortDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StockshortNo)
                    .HasColumnName("stockshortNo")
                    .HasMaxLength(250);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSuffixPrefix>(entity =>
            {
                entity.HasKey(e => e.SuffixprefixId)
                    .HasName("PK__tbl_Suff__5876721373DA2C14");

                entity.ToTable("tbl_SuffixPrefix");

                entity.Property(e => e.SuffixprefixId)
                    .HasColumnName("suffixprefixId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode");

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PrefillWithZero).HasColumnName("prefillWithZero");

                entity.Property(e => e.Prefix)
                    .HasColumnName("prefix")
                    .IsUnicode(false);

                entity.Property(e => e.StartIndex)
                    .HasColumnName("startIndex")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Suffix)
                    .HasColumnName("suffix")
                    .IsUnicode(false);

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.WidthOfNumericalPart).HasColumnName("widthOfNumericalPart");
            });

            modelBuilder.Entity<TblSupplierGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_SupplierGroup");

                entity.Property(e => e.SupplierGroupCode)
                    .IsRequired()
                    .HasColumnName("supplierGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.SupplierGroupId)
                    .HasColumnName("supplierGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SupplierGroupName)
                    .HasColumnName("supplierGroupName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTanks>(entity =>
            {
                entity.HasKey(e => e.TankId)
                    .HasName("PK__tbl__Tanks");

                entity.ToTable("tbl_Tanks");

                entity.Property(e => e.TankId).HasColumnName("tankID");

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.IsWorking).HasColumnName("isWorking");

                entity.Property(e => e.ItemCode)
                    .HasColumnName("itemCode")
                    .IsUnicode(false);

                entity.Property(e => e.NoofPumps)
                    .HasColumnName("noofPumps")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.TankCapacityinLtrs)
                    .HasColumnName("tankCapacityinLtrs")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TankNo)
                    .IsRequired()
                    .HasColumnName("tankNo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTax>(entity =>
            {
                entity.HasKey(e => e.TaxId)
                    .HasName("PK__tbl_Tax__24D2883933008CF0");

                entity.ToTable("tbl_Tax");

                entity.Property(e => e.TaxId)
                    .HasColumnName("taxId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ApplicableOn)
                    .HasColumnName("applicableOn")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CalculatingMode)
                    .HasColumnName("calculatingMode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TaxName)
                    .HasColumnName("taxName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTaxDetails>(entity =>
            {
                entity.HasKey(e => e.TaxdetailsId)
                    .HasName("PK__tbl_TaxD__B3B4F7A536D11DD4");

                entity.ToTable("tbl_TaxDetails");

                entity.Property(e => e.TaxdetailsId)
                    .HasColumnName("taxdetailsId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SelectedtaxId)
                    .HasColumnName("selectedtaxId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxId)
                    .HasColumnName("taxId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblTaxGroup>(entity =>
            {
                entity.HasKey(e => e.TaxGroupId)
                    .HasName("PK__tbl_TaxGroup");

                entity.ToTable("tbl_TaxGroup");

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasColumnName("productGroupCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupId)
                    .HasColumnName("productGroupID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductGroupName)
                    .HasColumnName("productGroupName")
                    .HasMaxLength(250);

                entity.Property(e => e.ProductLedgerId)
                    .HasColumnName("productLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductLedgerName)
                    .HasColumnName("productLedgerName")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupCode)
                    .IsRequired()
                    .HasColumnName("taxGroupCode")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupName)
                    .IsRequired()
                    .HasColumnName("taxGroupName")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTaxStructure>(entity =>
            {
                entity.HasKey(e => e.TaxStructureId)
                    .HasName("PK__tbl_TaxStructure");

                entity.ToTable("tbl_TaxStructure");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(300);

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseAccount)
                    .HasColumnName("purchaseAccount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalesAccount)
                    .HasColumnName("salesAccount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TaxGroupCode)
                    .IsRequired()
                    .HasColumnName("taxGroupCode")
                    .HasMaxLength(250);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxGroupName)
                    .IsRequired()
                    .HasColumnName("taxGroupName")
                    .HasMaxLength(250);

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalPercentageGst)
                    .HasColumnName("totalPercentageGST")
                    .HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblTaxapplicableOn>(entity =>
            {
                entity.ToTable("tbl_TaxapplicableOn");

                entity.Property(e => e.Id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTitle>(entity =>
            {
                entity.HasKey(e => e.TitleId)
                    .HasName("PK__tbl_Title");

                entity.ToTable("tbl_Title");

                entity.Property(e => e.TitleId)
                    .HasColumnName("titleId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasColumnName("titleName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__tbl_Unit__55D792354242D080");

                entity.ToTable("tbl_Unit");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FormalName)
                    .HasColumnName("formalName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDecimalplaces).HasColumnName("noOfDecimalplaces");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUnitConvertion>(entity =>
            {
                entity.HasKey(e => e.UnitconversionId)
                    .HasName("PK__tbl_Unit__07076F271C1D2798");

                entity.ToTable("tbl_UnitConvertion");

                entity.Property(e => e.UnitconversionId)
                    .HasColumnName("unitconversionId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConversionRate)
                    .HasColumnName("conversionRate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Quantities)
                    .HasColumnName("quantities")
                    .IsUnicode(false);

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblUnitSample>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__tbl_UnitSample");

                entity.ToTable("tbl_UnitSample");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FormalName)
                    .HasColumnName("formalName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDecimalplaces).HasColumnName("noOfDecimalplaces");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tbl_User");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("employeeCode")
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserBranch>(entity =>
            {
                entity.ToTable("tbl_UserBranch");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblUserNew>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("tbl_UserNew_userId");

                entity.ToTable("tbl_UserNew");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnName("employeeCode")
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserProductBranch>(entity =>
            {
                entity.HasKey(e => e.UserProductBranchId)
                    .HasName("PK__tbl__UserProductBranch");

                entity.ToTable("tbl_UserProductBranch");

                entity.Property(e => e.UserProductBranchId)
                    .HasColumnName("userProductBranchId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserRolePrivilege>(entity =>
            {
                entity.HasKey(e => e.PrivilegeId);

                entity.ToTable("tbl_UserRolePrivilege");

                entity.Property(e => e.PrivilegeId)
                    .HasColumnName("privilegeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Add)
                    .HasColumnName("add")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .HasMaxLength(80);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .HasMaxLength(250);

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeName)
                    .HasColumnName("employeeName")
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .HasColumnName("formId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FormName)
                    .HasColumnName("formName")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMenuActive)
                    .HasColumnName("isMenuActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Update)
                    .HasColumnName("update")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ValidFrom)
                    .HasColumnName("validFrom")
                    .HasColumnType("datetime");

                entity.Property(e => e.ValidTo)
                    .HasColumnName("validTo")
                    .HasColumnType("datetime");

                entity.Property(e => e.View)
                    .HasColumnName("view")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblUserTest>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("tbl_user_test_id");

                entity.ToTable("tbl_User_Test");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVchType>(entity =>
            {
                entity.HasKey(e => e.VoucherTypeId);

                entity.ToTable("tbl_VchType");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CashBank)
                    .HasColumnName("cash_bank")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Parent)
                    .HasColumnName("parent")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SplType)
                    .HasColumnName("spl_type")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherTypeName)
                    .HasColumnName("voucherTypeName")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TblVehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .HasName("PK__tbl_Vehicle");

                entity.ToTable("tbl_Vehicle");

                entity.Property(e => e.VehicleId)
                    .HasColumnName("vehicleId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FromDate)
                    .HasColumnName("fromDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsValid).HasColumnName("isValid");

                entity.Property(e => e.MemberCode)
                    .HasColumnName("memberCode")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MemberId)
                    .HasColumnName("memberId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MemberShares).HasColumnName("memberShares");

                entity.Property(e => e.ToDate)
                    .HasColumnName("toDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VehicleModel)
                    .HasColumnName("vehicleModel")
                    .IsUnicode(false);

                entity.Property(e => e.VehicleRegNo)
                    .HasColumnName("vehicleRegNo")
                    .HasMaxLength(250);

                entity.Property(e => e.VehicleTypeId)
                    .HasColumnName("vehicleTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VehicleTypeName)
                    .HasColumnName("vehicleTypeName")
                    .HasMaxLength(250);

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.TblVehicle)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .HasConstraintName("Vehicle_VEHICLETYPE_fk");
            });

            modelBuilder.Entity<TblVehicleType>(entity =>
            {
                entity.HasKey(e => e.VehicleTypeId)
                    .HasName("PK__tbl_VehicleType");

                entity.ToTable("tbl_VehicleType");

                entity.Property(e => e.VehicleTypeId)
                    .HasColumnName("vehicleTypeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VehicleTypeName)
                    .IsRequired()
                    .HasColumnName("vehicleTypeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVoucherDetail>(entity =>
            {
                entity.HasKey(e => e.VoucherDetailId);

                entity.ToTable("tbl_VoucherDetail");

                entity.Property(e => e.VoucherDetailId)
                    .HasColumnName("voucherDetailId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.CostCenter)
                    .HasColumnName("costCenter")
                    .IsUnicode(false);

                entity.Property(e => e.FromLedgerCode)
                    .HasColumnName("fromLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.FromLedgerId)
                    .HasColumnName("fromLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromLedgerName)
                    .HasColumnName("fromLedgerName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ToLedgerCode)
                    .HasColumnName("toLedgerCode")
                    .HasMaxLength(100);

                entity.Property(e => e.ToLedgerId)
                    .HasColumnName("toLedgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ToLedgerName)
                    .HasColumnName("toLedgerName")
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .HasColumnName("transactionType")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherDetailDate)
                    .HasColumnName("voucherDetailDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VoucherMasterId)
                    .HasColumnName("voucherMasterId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblVoucherMaster>(entity =>
            {
                entity.HasKey(e => e.VoucherMasterId);

                entity.ToTable("tbl_VoucherMaster");

                entity.Property(e => e.VoucherMasterId)
                    .HasColumnName("voucherMasterId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.BranchCode)
                    .HasColumnName("branchCode")
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasColumnName("branchName")
                    .IsUnicode(false);

                entity.Property(e => e.ChequeNo)
                    .HasColumnName("chequeNo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .HasColumnName("paymentType")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ServerDate)
                    .HasColumnName("serverDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherDate)
                    .HasColumnName("voucherDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeIdMain)
                    .HasColumnName("voucherTypeIdMain")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherTypeIdSub)
                    .HasColumnName("voucherTypeIdSub")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblVoucherType>(entity =>
            {
                entity.HasKey(e => e.VoucherTypeId)
                    .HasName("PK__tbl_Vouc__96246DEA68687968");

                entity.ToTable("tbl_VoucherType");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Declaration)
                    .HasColumnName("declaration")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Heading1)
                    .HasColumnName("heading1")
                    .IsUnicode(false);

                entity.Property(e => e.Heading2)
                    .HasColumnName("heading2")
                    .IsUnicode(false);

                entity.Property(e => e.Heading3)
                    .HasColumnName("heading3")
                    .IsUnicode(false);

                entity.Property(e => e.Heading4)
                    .HasColumnName("heading4")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.IsTaxApplicable).HasColumnName("isTaxApplicable");

                entity.Property(e => e.MasterId).HasColumnName("masterId");

                entity.Property(e => e.MethodOfVoucherNumbering)
                    .HasColumnName("methodOfVoucherNumbering")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfVoucher)
                    .HasColumnName("typeOfVoucher")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeName)
                    .HasColumnName("voucherTypeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVoucherTypeTax>(entity =>
            {
                entity.HasKey(e => e.VoucherTypeTaxId)
                    .HasName("PK__tbl_Vouc__BD57380E6C390A4C");

                entity.ToTable("tbl_VoucherTypeTax");

                entity.Property(e => e.VoucherTypeTaxId)
                    .HasColumnName("voucherTypeTaxId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaxId)
                    .HasColumnName("taxId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblVoucherTypeToCopy>(entity =>
            {
                entity.HasKey(e => e.VoucherTypeId);

                entity.ToTable("tbl_VoucherTypeToCopy");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Declaration)
                    .HasColumnName("declaration")
                    .IsUnicode(false);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Heading1)
                    .HasColumnName("heading1")
                    .IsUnicode(false);

                entity.Property(e => e.Heading2)
                    .HasColumnName("heading2")
                    .IsUnicode(false);

                entity.Property(e => e.Heading3)
                    .HasColumnName("heading3")
                    .IsUnicode(false);

                entity.Property(e => e.Heading4)
                    .HasColumnName("heading4")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.IsTaxApplicable).HasColumnName("isTaxApplicable");

                entity.Property(e => e.MasterId).HasColumnName("masterId");

                entity.Property(e => e.MethodOfVoucherNumbering)
                    .HasColumnName("methodOfVoucherNumbering")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfVoucher)
                    .HasColumnName("typeOfVoucher")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeName)
                    .HasColumnName("voucherTypeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVoucherTypes>(entity =>
            {
                entity.HasKey(e => e.VoucherTypeId)
                    .HasName("PK__tbl_VoucherTypes");

                entity.ToTable("tbl_VoucherTypes");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfVoucher)
                    .HasColumnName("typeOfVoucher")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeName)
                    .HasColumnName("voucherTypeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Temp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TEMP");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountGroupName)
                    .HasColumnName("accountGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.GroupUnder)
                    .HasColumnName("groupUnder")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Temp1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TEMP1");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountGroupName)
                    .HasColumnName("accountGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.GroupUnder)
                    .HasColumnName("groupUnder")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Temp81>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TEMP81");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AccountGroupName)
                    .HasColumnName("accountGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.GroupUnder)
                    .HasColumnName("groupUnder")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<VehicleDummy>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AccCode)
                    .HasColumnName("acc_code")
                    .HasMaxLength(255);

                entity.Property(e => e.RegdNo)
                    .HasColumnName("regd_no")
                    .HasMaxLength(255);

                entity.Property(e => e.ValidFrom)
                    .HasColumnName("valid_from")
                    .HasMaxLength(255);

                entity.Property(e => e.YesNo)
                    .HasColumnName("yes_no")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View1");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Expr1).IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnName("groupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InwardQty)
                    .HasColumnName("inwardQty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OutwardQty)
                    .HasColumnName("outwardQty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.VoucherNo)
                    .HasColumnName("voucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherTypeName)
                    .HasColumnName("voucherTypeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewCashBank>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCashBank");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VoucherClass>(entity =>
            {
                entity.HasKey(e => e.VoucherCode);

                entity.Property(e => e.VoucherCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.VouchrType).HasMaxLength(50);
            });

            modelBuilder.Entity<VoucherTypes>(entity =>
            {
                entity.HasKey(e => e.VoucherCode);

                entity.Property(e => e.VoucherCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(20);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.NoSeries).HasMaxLength(50);

                entity.Property(e => e.Period).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.Property(e => e.Transaction).HasMaxLength(50);

                entity.Property(e => e.VoucherType).HasMaxLength(50);
            });

            modelBuilder.Entity<VwMaxRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwMaxRate");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Max)
                    .HasColumnName("max")
                    .HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<VwMinRate>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwMinRate");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Min)
                    .HasColumnName("min")
                    .HasColumnType("decimal(18, 5)");
            });

            modelBuilder.Entity<VwStockQuery>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwStockQuery");

                entity.Property(e => e.AgainstInvoiceNo)
                    .HasColumnName("againstInvoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.AgainstVoucherNo)
                    .HasColumnName("againstVoucherNo")
                    .IsUnicode(false);

                entity.Property(e => e.AgainstVoucherTypeId)
                    .HasColumnName("againstVoucherTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.GroupId)
                    .HasColumnName("groupId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InwardQty)
                    .HasColumnName("inwardQty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.LedgerId)
                    .HasColumnName("ledgerId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MasterId)
                    .HasColumnName("masterId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OutwardQty)
                    .HasColumnName("outwardQty")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TypeOfVoucher)
                    .HasColumnName("typeOfVoucher")
                    .IsUnicode(false);

                entity.Property(e => e.VoucherNo).IsUnicode(false);

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("voucherTypeId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherTypeName)
                    .HasColumnName("voucherTypeName")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
