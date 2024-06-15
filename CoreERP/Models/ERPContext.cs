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

        public virtual DbSet<AppConfig> AppConfig { get; set; }
        public virtual DbSet<AsignmentAcctoAccClass> AsignmentAcctoAccClass { get; set; }
        public virtual DbSet<AsignmentCashAccBranch> AsignmentCashAccBranch { get; set; }
        public virtual DbSet<AssignmentSubaccounttoGl> AssignmentSubaccounttoGl { get; set; }
        public virtual DbSet<CashInOutFlow1> CashInOutFlow1 { get; set; }
        public virtual DbSet<ConfigurationTable> ConfigurationTable { get; set; }
        public virtual DbSet<CostCenters> CostCenter { get; set; }
        public virtual DbSet<Ctcbreakup> Ctcbreakup { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<EmployeeInBranches> EmployeeInBranches { get; set; }
        public virtual DbSet<ErpConfiguration> ErpConfiguration { get; set; }
        public virtual DbSet<Erpuser> Erpuser { get; set; }
        public virtual DbSet<ApprovalType> ApprovalType { get; set; }
        public virtual DbSet<FourCoulmnRoundOff> FourCoulmnRoundOff { get; set; }
        public virtual DbSet<GeneralLedgerAccounts> GeneralLedgerAccounts { get; set; }
        public virtual DbSet<GlaccGroup> GlaccGroup { get; set; }
        public virtual DbSet<Glaccounts> Glaccounts { get; set; }
        public virtual DbSet<Ledger> Ledger { get; set; }
        public virtual DbSet<LedgerType> LedgerType { get; set; }
        public virtual DbSet<MenuAccesses> MenuAccesses { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<NoAssignment> NoAssignment { get; set; }
        public virtual DbSet<NoSeries> NoSeries { get; set; }
        public virtual DbSet<PartnerCreation> PartnerCreation { get; set; }
        public virtual DbSet<PartnerType> PartnerType { get; set; }
        public virtual DbSet<ProfitCenters> ProfitCenters { get; set; }
        public virtual DbSet<SalesDepartment> SalesDepartment { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<Smsstatus> Smsstatus { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<TaxIntegration> TaxIntegration { get; set; }
        public virtual DbSet<TaxMasters> TaxMasters { get; set; }
        public virtual DbSet<TbBommaster> TbBommaster { get; set; }
        public virtual DbSet<TblAccountGroup> TblAccountGroup { get; set; }
        public virtual DbSet<TblAccountLedger> TblAccountLedger { get; set; }
        public virtual DbSet<TblAccountLedgerTransactions> TblAccountLedgerTransactions { get; set; }
        public virtual DbSet<TblAlternateControlAccTrans> TblAlternateControlAccTrans { get; set; }
        public virtual DbSet<TblAssetAccountkey> TblAssetAccountkey { get; set; }
        public virtual DbSet<TblAssetBeginingAcquisition> TblAssetBeginingAcquisition { get; set; }
        public virtual DbSet<TblAssetBeginingAcquisitionDetail> TblAssetBeginingAcquisitionDetail { get; set; }
        public virtual DbSet<TblAssetBegningAccumulatedDepreciation> TblAssetBegningAccumulatedDepreciation { get; set; }
        public virtual DbSet<TblAssetBlock> TblAssetBlock { get; set; }
        public virtual DbSet<TblAssetClass> TblAssetClass { get; set; }
        public virtual DbSet<TblAssetDetails> TblAssetDetails { get; set; }
        public virtual DbSet<TblAssetNumberRange> TblAssetNumberRange { get; set; }
        public virtual DbSet<TblAssetTransactiontype> TblAssetTransactiontype { get; set; }
        public virtual DbSet<TblAssetTransfer> TblAssetTransfer { get; set; }
        public virtual DbSet<TblAssetTransferDetails> TblAssetTransferDetails { get; set; }
        public virtual DbSet<TblAssignAccountkeytoAsset> TblAssignAccountkeytoAsset { get; set; }
        public virtual DbSet<TblAssignAssetClasstoBlockAsset> TblAssignAssetClasstoBlockAsset { get; set; }
        public virtual DbSet<TblAssignTaxacctoTaxcode> TblAssignTaxacctoTaxcode { get; set; }
        public virtual DbSet<TblAssignchartaccttoCompanycode> TblAssignchartaccttoCompanycode { get; set; }
        public virtual DbSet<TblAssignment> TblAssignment { get; set; }
        public virtual DbSet<TblAssignmentVoucherSeriestoVoucherType> TblAssignmentVoucherSeriestoVoucherType { get; set; }
        public virtual DbSet<TblBankMaster> TblBankMaster { get; set; }
        public virtual DbSet<TblBatchMaster> TblBatchMaster { get; set; }
        public virtual DbSet<TblBinsCreation> TblBinsCreation { get; set; }
        public virtual DbSet<TblBomDetails> TblBomDetails { get; set; }
        public virtual DbSet<TblBpgroup> TblBpgroup { get; set; }
        public virtual DbSet<TblBranch> TblBranch { get; set; }
        public virtual DbSet<TblBusinessPartnerAccount> TblBusinessPartnerAccount { get; set; }
        public virtual DbSet<TblBusinessTransactionTypes> TblBusinessTransactionTypes { get; set; }
        public virtual DbSet<TblCashBankDetails> TblCashBankDetails { get; set; }
        public virtual DbSet<TblCashBankMaster> TblCashBankMaster { get; set; }
        public virtual DbSet<TblChartAccount> TblChartAccount { get; set; }
        public virtual DbSet<TblCommitmentItem> TblCommitmentItem { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblCostingActivity> TblCostingActivity { get; set; }
        public virtual DbSet<TblCostingKeyFigures> TblCostingKeyFigures { get; set; }
        public virtual DbSet<TblCostingNumberSeries> TblCostingNumberSeries { get; set; }
        public virtual DbSet<TblCostingObjectTypes> TblCostingObjectTypes { get; set; }
        public virtual DbSet<TblCostingUnitsCreation> TblCostingUnitsCreation { get; set; }
        public virtual DbSet<TblCostingnumberAssigntoObject> TblCostingnumberAssigntoObject { get; set; }
        public virtual DbSet<TblCurrency> TblCurrency { get; set; }
        public virtual DbSet<TblDepreciation> TblDepreciation { get; set; }
        public virtual DbSet<TblDepreciationAreas> TblDepreciationAreas { get; set; }
        public virtual DbSet<TblDepreciationDetails> TblDepreciationDetails { get; set; }
        public virtual DbSet<TblDepreciationcodeDetails> TblDepreciationcodeDetails { get; set; }
        public virtual DbSet<TblDesignation> TblDesignation { get; set; }
        public virtual DbSet<TblHoliday> TblHoliday { get; set; }
        public virtual DbSet<TblDistributionChannel> TblDistributionChannel { get; set; }
        public virtual DbSet<TblDownTimeReasons> TblDownTimeReasons { get; set; }
        public virtual DbSet<TblDynamicPages> TblDynamicPages { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEmployeeMaster> TblEmployeeMaster { get; set; }
        public virtual DbSet<TblFieldsConfiguration> TblFieldsConfiguration { get; set; }
        public virtual DbSet<TblFormMenuCollection> TblFormMenuCollection { get; set; }
        public virtual DbSet<TblFormula> TblFormula { get; set; }
        public virtual DbSet<TblFunctionalDepartment> TblFunctionalDepartment { get; set; }
        public virtual DbSet<TblFundCenter> TblFundCenter { get; set; }
        public virtual DbSet<TblGinnoSeries> TblGinnoSeries { get; set; }
        public virtual DbSet<TblGinseriesAssignment> TblGinseriesAssignment { get; set; }
        public virtual DbSet<TblGlsubAccount> TblGlsubAccount { get; set; }
        public virtual DbSet<TblGoodsIssueDetails> TblGoodsIssueDetails { get; set; }
        public virtual DbSet<TblGoodsIssueMaster> TblGoodsIssueMaster { get; set; }
        public virtual DbSet<TblProductionMaster> TblProductionMaster { get; set; }

        public virtual DbSet<TblApi_Error_Log> TblApi_Error_Log { get; set; }
        public virtual DbSet<TblProductionDetails> TblProductionDetails { get; set; }
        public virtual DbSet<TblProductionStatus> TblProductionStatus { get; set; }
        public virtual DbSet<TblGoodsReceiptDetails> TblGoodsReceiptDetails { get; set; }
        public virtual DbSet<TblGoodsReceiptMaster> TblGoodsReceiptMaster { get; set; }
        public virtual DbSet<TblGrnassignment> TblGrnassignment { get; set; }
        public virtual DbSet<TblGrnnoSeries> TblGrnnoSeries { get; set; }
        public virtual DbSet<TblHideTableColumns> TblHideTableColumns { get; set; }
        public virtual DbSet<TblHsnsac> TblHsnsac { get; set; }
        public virtual DbSet<TblIncomeTypes> TblIncomeTypes { get; set; }
        public virtual DbSet<TblInspectionCheckMaster> TblInspectionCheckMaster { get; set; }
        public virtual DbSet<TblInspectionCheckDetails> TblInspectionCheckDetails { get; set; }
        public virtual DbSet<TblRejectionMaster> TblRejectionMaster { get; set; }
        public virtual DbSet<TblDispatch> TblDispatch { get; set; }

        public virtual DbSet<TblQCParamConfig> TblQCParamConfig { get; set; }
        public virtual DbSet<TblCAPA> TblCAPA { get; set; }
        public virtual DbSet<TblAttendanceDetails> TblAttendanceDetails { get; set; }
        public virtual DbSet<TblInvoiceMemoDetails> TblInvoiceMemoDetails { get; set; }
        public virtual DbSet<TblForm> TblForm { get; set; }
        public virtual DbSet<TblInvoiceMemoHeader> TblInvoiceMemoHeader { get; set; }
        public virtual DbSet<TblInvoiceVerificationDetails> TblInvoiceVerificationDetails { get; set; }
        public virtual DbSet<TblInvoiceVerificationMaster> TblInvoiceVerificationMaster { get; set; }
        public virtual DbSet<TblInvoiceVerificationOtherExpenses> TblInvoiceVerificationOtherExpenses { get; set; }
        public virtual DbSet<TblJvdetails> TblJvdetails { get; set; }
        public virtual DbSet<TblJvmaster> TblJvmaster { get; set; }
        public virtual DbSet<TblLanguage> TblLanguage { get; set; }
        public virtual DbSet<TblLocation> TblLocation { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblLotAssignment> TblLotAssignment { get; set; }
        public virtual DbSet<TblLotSeries> TblLotSeries { get; set; }
        public virtual DbSet<TblMainAssetMaster> TblMainAssetMaster { get; set; }
        public virtual DbSet<TblMainAssetMasterTransaction> TblMainAssetMasterTransaction { get; set; }
        public virtual DbSet<TblMaintenancearea> TblMaintenancearea { get; set; }
        public virtual DbSet<TblMaterialGroups> TblMaterialGroups { get; set; }
        public virtual DbSet<TblMaterialMaster> TblMaterialMaster { get; set; }
        public virtual DbSet<TblMaterialNoAssignment> TblMaterialNoAssignment { get; set; }
        public virtual DbSet<TblMaterialNoSeries> TblMaterialNoSeries { get; set; }
        public virtual DbSet<TblMaterialPurchasePrice> TblMaterialPurchasePrice { get; set; }
        public virtual DbSet<TblMaterialRequisitionDetails> TblMaterialRequisitionDetails { get; set; }
        public virtual DbSet<TblMaterialRequisitionMaster> TblMaterialRequisitionMaster { get; set; }
        public virtual DbSet<TblMaterialSize> TblMaterialSize { get; set; }
        public virtual DbSet<TblMaterialSupplierDetails> TblMaterialSupplierDetails { get; set; }
        public virtual DbSet<TblMaterialSupplierMaster> TblMaterialSupplierMaster { get; set; }
        public virtual DbSet<TblMaterialTypes> TblMaterialTypes { get; set; }
        public virtual DbSet<TblModelPattern> TblModelPattern { get; set; }
        public virtual DbSet<TblMonthList> TblMonthList { get; set; }
        public virtual DbSet<TblMonthListForReports> TblMonthListForReports { get; set; }
        public virtual DbSet<TblMovementType> TblMovementType { get; set; }
        public virtual DbSet<TblMrnnoAssignment> TblMrnnoAssignment { get; set; }
        public virtual DbSet<TblMrnnoSeries> TblMrnnoSeries { get; set; }
        public virtual DbSet<TblNumberAssignment> TblNumberAssignment { get; set; }
        public virtual DbSet<TblNumberRange> TblNumberRange { get; set; }
        public virtual DbSet<TblOpenLedger> TblOpenLedger { get; set; }
        public virtual DbSet<TblOrderType> TblOrderType { get; set; }
        public virtual DbSet<TblPartyCashBankMaster> TblPartyCashBankMaster { get; set; }
        public virtual DbSet<TblParyCashBankDetails> TblParyCashBankDetails { get; set; }
        public virtual DbSet<TblOrderSwap> TblOrderSwap { get; set; }
        public virtual DbSet<TblOrderSwapDetails> TblOrderSwapDetails { get; set; }
        public virtual DbSet<TblPaymentTermDetails> TblPaymentTermDetails { get; set; }
        public virtual DbSet<TblPaymentTerms> TblPaymentTerms { get; set; }
        public virtual DbSet<TblPermissions> TblPermissions { get; set; }
        public virtual DbSet<TblPlant> TblPlant { get; set; }
        public virtual DbSet<TblPosaleAssetInvoiceMemoDetails> TblPosaleAssetInvoiceMemoDetails { get; set; }
        public virtual DbSet<TblPosaleAssetInvoiceMemoHeader> TblPosaleAssetInvoiceMemoHeader { get; set; }
        public virtual DbSet<TblPosting> TblPosting { get; set; }
        public virtual DbSet<TblPriceList> TblPriceList { get; set; }
        public virtual DbSet<TblPrimaryCostElement> TblPrimaryCostElement { get; set; }
        //public virtual DbSet<TblPrnoRange> TblPrnoRange { get; set; }
        public virtual DbSet<TblProcess> TblProcess { get; set; }
        public virtual DbSet<TblPurchaseDepartment> TblPurchaseDepartment { get; set; }
        public virtual DbSet<TblPurchaseGroup> TblPurchaseGroup { get; set; }
        public virtual DbSet<TblPurchaseNoRange> TblPurchaseNoRange { get; set; }
        public virtual DbSet<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual DbSet<TblPurchaseOrderDetails> TblPurchaseOrderDetails { get; set; }
        public virtual DbSet<TblPurchaseOrderNoAssignment> TblPurchaseOrderNoAssignment { get; set; }
        public virtual DbSet<TblPurchaseOrderNoAssignmentst> TblPurchaseOrderNoAssignmentst { get; set; }
        public virtual DbSet<TblPurchaseOrderType> TblPurchaseOrderType { get; set; }
        public virtual DbSet<TblPurchasePerson> TblPurchasePerson { get; set; }
        public virtual DbSet<TblPurchaseRequisitionDetails> TblPurchaseRequisitionDetails { get; set; }
        public virtual DbSet<TblPurchaseRequisitionMaster> TblPurchaseRequisitionMaster { get; set; }
        public virtual DbSet<TblPurchaseType> TblPurchaseType { get; set; }
        public virtual DbSet<TblQuotationAnalysis> TblQuotationAnalysis { get; set; }
        public virtual DbSet<TblQuotationAnalysisDetails> TblQuotationAnalysisDetails { get; set; }
        public virtual DbSet<TblQuotationNoAssignment> TblQuotationNoAssignment { get; set; }
        public virtual DbSet<TblQuotationNoRange> TblQuotationNoRange { get; set; }
        public virtual DbSet<TblRegion> TblRegion { get; set; }
        public virtual DbSet<TblRejectionReason> TblRejectionReason { get; set; }
        public virtual DbSet<TblRelation> TblRelation { get; set; }
        public virtual DbSet<TblReminder> TblReminder { get; set; }
        public virtual DbSet<TblReqNoAssignment> TblReqNoAssignment { get; set; }
        public virtual DbSet<TblRequisitionNoRange> TblRequisitionNoRange { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblRoute> TblRoute { get; set; }
        public virtual DbSet<TblRoutingActiitiesAssignment> TblRoutingActiitiesAssignment { get; set; }
        public virtual DbSet<TblRoutingBasicData> TblRoutingBasicData { get; set; }
        public virtual DbSet<TblRoutingMasterData> TblRoutingMasterData { get; set; }
        public virtual DbSet<TblRoutingMaterialAssignment> TblRoutingMaterialAssignment { get; set; }
        public virtual DbSet<TblRoutingToolsEqupments> TblRoutingToolsEqupments { get; set; }
        public virtual DbSet<TblSalesGroup> TblSalesGroup { get; set; }
        public virtual DbSet<TblSalesOffice> TblSalesOffice { get; set; }
        public virtual DbSet<TblSecondaryCostElement> TblSecondaryCostElement { get; set; }
        public virtual DbSet<TblSettings> TblSettings { get; set; }
        public virtual DbSet<TblShift> TblShift { get; set; }
        public virtual DbSet<TblShiftTimings> TblShiftTimings { get; set; }
        public virtual DbSet<TblSize> TblSize { get; set; }
        public virtual DbSet<tblQCDetails> tblQCDetails { get; set; }

        public virtual DbSet<tblQCResults> tblQCResults { get; set; }
        public virtual DbSet<tblQCMaster> tblQCMaster { get; set; }
        public virtual DbSet<TblStateWiseGst> TblStateWiseGst { get; set; }
        public virtual DbSet<TblStockInformation> TblStockInformation { get; set; }
        public virtual DbSet<TblStorageLocation> TblStorageLocation { get; set; }
        public virtual DbSet<TblStoreTypes> TblStoreTypes { get; set; }
        public virtual DbSet<TblSubAssetMaster> TblSubAssetMaster { get; set; }
        public virtual DbSet<TblSubAssetMasterTransaction> TblSubAssetMasterTransaction { get; set; }
        public virtual DbSet<TblSuffixPrefix> TblSuffixPrefix { get; set; }
        public virtual DbSet<TblSupplierQuotationDetails> TblSupplierQuotationDetails { get; set; }
        public virtual DbSet<TblSupplierQuotationsMaster> TblSupplierQuotationsMaster { get; set; }
        public virtual DbSet<TblSupplierTermsAndConditons> TblSupplierTermsAndConditons { get; set; }
        public virtual DbSet<TblTaskMaster> TblTaskMaster { get; set; }
        public virtual DbSet<TblTaskResources> TblTaskResources { get; set; }
        public virtual DbSet<TblTaxRates> TblTaxRates { get; set; }
        public virtual DbSet<TblTaxtransactions> TblTaxtransactions { get; set; }
        public virtual DbSet<TblTaxtypes> TblTaxtypes { get; set; }
        public virtual DbSet<TblTdsRates> TblTdsRates { get; set; }
        public virtual DbSet<TblTdstypes> TblTdstypes { get; set; }
        public virtual DbSet<TblTitle> TblTitle { get; set; }
        public virtual DbSet<TblTransactions> TblTransactions { get; set; }
        public virtual DbSet<TblUnit> TblUnit { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserBranch> TblUserBranch { get; set; }
        public virtual DbSet<TblUserNew> TblUserNew { get; set; }
        public virtual DbSet<TblVoucherSeries> TblVoucherSeries { get; set; }
        public virtual DbSet<TblVoucherType> TblVoucherType { get; set; }
        public virtual DbSet<Voucherclass> TblVoucherclass { get; set; }
        public virtual DbSet<TblWbs> TblWbs { get; set; }
        public virtual DbSet<TblWorkCenterCapacity> TblWorkCenterCapacity { get; set; }
        public virtual DbSet<TblWorkcenterActivity> TblWorkcenterActivity { get; set; }
        public virtual DbSet<TblWorkcenterMaster> TblWorkcenterMaster { get; set; }
        public virtual DbSet<View1> View1 { get; set; }
        public virtual DbSet<ViewCashBank> ViewCashBank { get; set; }
        public virtual DbSet<VoucherTypes> VoucherTypes { get; set; }
        public virtual DbSet<VwMaxRate> VwMaxRate { get; set; }
        public virtual DbSet<VwMinRate> VwMinRate { get; set; }
        public virtual DbSet<VwStockQuery> VwStockQuery { get; set; }
        public virtual DbSet<TblPurchaseOrderNoRange> TblPurchaseOrderNoRange { get; set; }
        public virtual DbSet<LeaveTypes> LeaveTypes { get; set; }
        public virtual DbSet<LeaveBalanceMaster> LeaveBalanceMaster { get; set; }
        public virtual DbSet<Ptmaster> Ptmaster { get; set; }
        public virtual DbSet<Pfmaster> Pfmaster { get; set; }
        public virtual DbSet<TblPoQueue> TblPoQueue { get; set; }
        public virtual DbSet<ComponentMaster> ComponentMaster { get; set; }
        public virtual DbSet<StructureCreation> StructureCreation { get; set; }
        public virtual DbSet<StructureComponents> StructureComponents { get; set; }
        public virtual DbSet<LeaveApplDetails> LeaveApplDetails { get; set; }
        public virtual DbSet<ApplyOddata> ApplyOddata { get; set; }
        public virtual DbSet<PermissionRequest> PermissionRequest { get; set; }
        public virtual DbSet<VehicleRequisition> VehicleRequisition { get; set; }
        public virtual DbSet<TblSaleOrderMaster> TblSaleOrderMaster { get; set; }
        public virtual DbSet<tblJobworkMaster> tblJobworkMaster { get; set; }
        public virtual DbSet<tblJobworkDetails> tblJobworkDetails { get; set; }
        public virtual DbSet<tblJWReceiptDetails> tblJWReceiptDetails { get; set; }
        public virtual DbSet<tblJWReceiptMaster> tblJWReceiptMaster { get; set; }
        public virtual DbSet<Counters> Counters { get; set; }
        public virtual DbSet<TblSaleOrderDetail> TblSaleOrderDetail { get; set; }
        public virtual DbSet<TblInvoiceDetail> TblInvoiceDetail { get; set; }
        public virtual DbSet<TblInvoiceMaster> TblInvoiceMaster { get; set; }
        public virtual DbSet<TblInvoiceMasterReturn> TblInvoiceMasterReturn { get; set; }
        public virtual DbSet<TblInvoiceReturnDetail> TblInvoiceReturnDetail { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server = 103.67.236.159, 7912; Database = ERP; User Id = sa; pwd =)CEEV9BZUv!$; MultipleActiveResultSets = true; TrustServerCertificate = True");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GroupName).HasMaxLength(100);

                entity.Property(e => e.SeqId).ValueGeneratedOnAdd();

                entity.Property(e => e.Valu).HasMaxLength(500);
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

            modelBuilder.Entity<AssignmentSubaccounttoGl>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AssignmentSubaccounttoGL");

                entity.Property(e => e.FromGl)
                    .HasColumnName("FromGL")
                    .HasMaxLength(50);

                entity.Property(e => e.Glgroup)
                    .HasColumnName("GLGroup")
                    .HasMaxLength(50);

                entity.Property(e => e.SubAccount).HasMaxLength(50);

                entity.Property(e => e.ToGl)
                    .HasColumnName("ToGL")
                    .HasMaxLength(50);
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
                entity.HasKey(e => e.Code)
                    .HasName("PK_CostCenter_1");

                entity.Property(e => e.Code).HasMaxLength(15);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ResponsiblePerson)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasMaxLength(50);

            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryCode);

                entity.Property(e => e.CountryCode).HasMaxLength(5);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.DecimalFormat).HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(5);

                //entity.HasOne(d => d.CurrencyNavigation)
                //    .WithMany(p => p.Countries)
                //    .HasForeignKey(d => d.Currency)
                //    .HasConstraintName("FK__Countries__Curre__22B6AD3C");

                //entity.HasOne(d => d.LanguageNavigation)
                //    .WithMany(p => p.Countries)
                //    .HasForeignKey(d => d.Language)
                //    .HasConstraintName("FK__Countries__Langu__21C28903");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentId).HasMaxLength(5);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ResponsiblePersonCode).HasMaxLength(5);
            });

            modelBuilder.Entity<Divisions>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

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

            modelBuilder.Entity<GeneralLedgerAccounts>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_GLAccounts");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.AccountChart).HasMaxLength(50);

                entity.Property(e => e.AccountGroup).HasMaxLength(50);

                entity.Property(e => e.AccountLevel).HasMaxLength(50);

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.BankKey).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.ConsolidatedAccount).HasMaxLength(50);

                entity.Property(e => e.ControlAccount)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.CostElementCategory).HasMaxLength(50);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LegacyGl)
                    .HasColumnName("LegacyGL")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxCategory).HasMaxLength(50);
            });

            modelBuilder.Entity<GlaccGroup>(entity =>
            {
                entity.HasKey(e => e.GroupCode);

                entity.ToTable("GLAccGroup");

                entity.Property(e => e.GroupCode).HasMaxLength(5);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupName).HasMaxLength(50);

            });

            modelBuilder.Entity<Glaccounts>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK_GLAccounts_1");

                entity.ToTable("GLAccounts");

                entity.Property(e => e.AccountNumber).HasMaxLength(20);

                entity.Property(e => e.AccGroup).HasMaxLength(50);

                entity.Property(e => e.BankKey).HasMaxLength(50);

                entity.Property(e => e.ChartAccount)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ClearingAccount).HasMaxLength(40);

                entity.Property(e => e.Company).HasMaxLength(20);

                entity.Property(e => e.ConsolidatedAccount).HasMaxLength(50);

                entity.Property(e => e.ControlAccount).HasMaxLength(50);

                entity.Property(e => e.CostElementCategory).HasMaxLength(50);

                entity.Property(e => e.Currency).HasMaxLength(20);

                entity.Property(e => e.GlaccountName)
                    .HasColumnName("GLAccountName")
                    .HasMaxLength(50);

                entity.Property(e => e.GroupUnder)
                    .HasColumnName("groupUnder")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LegacyGl)
                    .HasColumnName("LegacyGL")
                    .HasMaxLength(50);

                entity.Property(e => e.NoPostingAllowed).HasMaxLength(50);

                entity.Property(e => e.RelevantCashFlow).HasMaxLength(50);

                entity.Property(e => e.Subgroup).HasMaxLength(50);

                entity.Property(e => e.TaxCategory).HasMaxLength(20);
            });

            modelBuilder.Entity<Ledger>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Ledger__3214EC27F5A5F686");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.LedgerType).HasMaxLength(50);
            });

            modelBuilder.Entity<LedgerType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);
            });

            modelBuilder.Entity<MenuAccesses>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.AddDate)
                    .HasColumnName("addDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.OperationCode).HasMaxLength(50);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("RoleID")
                    .HasMaxLength(200);

                entity.Property(e => e.screenName).HasMaxLength(100);

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
                    .HasMaxLength(100);

                entity.Property(e => e.IsMasterScreen)
                    .HasColumnName("isMasterScreen")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OperationCode).HasMaxLength(50);

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasMaxLength(20);

                entity.Property(e => e.Route)
                    .HasColumnName("route")
                    .HasMaxLength(100);

                entity.Property(e => e.ScreenType).HasMaxLength(100);
            });

            modelBuilder.Entity<NoAssignment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyCode).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.MaterialGroup).HasMaxLength(50);

                entity.Property(e => e.NoType).HasMaxLength(30);

                entity.Property(e => e.NumberInterval).HasMaxLength(30);
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

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Bpcategory)
                    .HasColumnName("BPCategory")
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);
            });

            modelBuilder.Entity<ProfitCenters>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Address1)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(5);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.PONumber);
                entity.Property(e => e.POPrefix).HasMaxLength(5);
                entity.Property(e => e.SONumber);
                entity.Property(e => e.SOPrefix).HasMaxLength(5);

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.PinCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Region).HasMaxLength(5);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(5);

                entity.Property(e => e.State).HasMaxLength(5);

                //entity.HasOne(d => d.CountryNavigation)
                //    .WithMany(p => p.ProfitCenters)
                //    .HasForeignKey(d => d.Country)
                //    .HasConstraintName("FK__ProfitCen__Count__570A79EA");

                //entity.HasOne(d => d.CurrencyNavigation)
                //    .WithMany(p => p.ProfitCenters)
                //    .HasForeignKey(d => d.Currency)
                //    .HasConstraintName("FK__ProfitCen__Curre__57FE9E23");

                //entity.HasOne(d => d.LanguageNavigation)
                //    .WithMany(p => p.ProfitCenters)
                //    .HasForeignKey(d => d.Language)
                //    .HasConstraintName("FK__ProfitCen__Langu__34D55D77");

                //entity.HasOne(d => d.RegionNavigation)
                //    .WithMany(p => p.ProfitCenters)
                //    .HasForeignKey(d => d.Region)
                //    .HasConstraintName("FK__ProfitCen__Regio__561655B1");

                //entity.HasOne(d => d.StateNavigation)
                //    .WithMany(p => p.ProfitCenters)
                //    .HasForeignKey(d => d.State)
                //    .HasConstraintName("FK__ProfitCen__State__55223178");
            });

            modelBuilder.Entity<SalesDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentCode);

                entity.Property(e => e.DepartmentCode).HasMaxLength(5);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Panno)
                    .HasColumnName("PANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(6);

                entity.Property(e => e.Region).HasMaxLength(5);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(5);

                entity.Property(e => e.Tanno)
                    .HasColumnName("TANNo")
                    .HasMaxLength(50);

                //entity.HasOne(d => d.CountryNavigation)
                //    .WithMany(p => p.SalesDepartment)
                //    .HasForeignKey(d => d.Country)
                //    .HasConstraintName("FK__SalesDepa__Count__65589941");

                //entity.HasOne(d => d.CurrencyNavigation)
                //    .WithMany(p => p.SalesDepartment)
                //    .HasForeignKey(d => d.Currency)
                //    .HasConstraintName("FK__SalesDepa__Curre__664CBD7A");

                //entity.HasOne(d => d.RegionNavigation)
                //    .WithMany(p => p.SalesDepartment)
                //    .HasForeignKey(d => d.Region)
                //    .HasConstraintName("FK__SalesDepa__Regio__64647508");

                //entity.HasOne(d => d.StateNavigation)
                //    .WithMany(p => p.SalesDepartment)
                //    .HasForeignKey(d => d.State)
                //    .HasConstraintName("FK__SalesDepa__State__637050CF");
            });

            modelBuilder.Entity<Segment>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sizes>(entity =>
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
                entity.HasKey(e => e.StateCode);

                entity.Property(e => e.StateCode).HasMaxLength(5);

                entity.Property(e => e.CountryCode).HasMaxLength(5);

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50);

                //entity.HasOne(d => d.CountryCodeNavigation)
                //    .WithMany(p => p.States)
                //    .HasForeignKey(d => d.CountryCode)
                //    .HasConstraintName("FK__States__CountryC__2E285FE8");

                //entity.HasOne(d => d.LanguageNavigation)
                //    .WithMany(p => p.States)
                //    .HasForeignKey(d => d.Language)
                //    .HasConstraintName("FK__States__Language__2D343BAF");
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

            modelBuilder.Entity<TbBommaster>(entity =>
            {
                entity.HasKey(e => e.Bomnumber);

                entity.ToTable("tb_BOMMaster");

                entity.Property(e => e.Bomnumber)
                    .HasColumnName("BOMNumber")
                    .HasMaxLength(0);

                entity.Property(e => e.Batch).HasMaxLength(50);

                entity.Property(e => e.Bomtype)
                    .HasColumnName("BOMType")
                    .HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.TotalTax);

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.TotalAmount);
            });

            modelBuilder.Entity<TblAccountGroup>(entity =>
            {
                entity.HasKey(e => e.AccountGroupId);

                entity.ToTable("tbl_AccountGroup");

                entity.Property(e => e.AccountGroupId)
                    .HasColumnName("accountGroupId")
                    .HasMaxLength(10);

                entity.Property(e => e.AccountGroupName)
                    .HasColumnName("accountGroupName")
                    .HasMaxLength(50);

                entity.Property(e => e.GroupUnder)
                    .HasColumnName("groupUnder")
                    .HasMaxLength(10);

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(50);

                entity.Property(e => e.Nature)
                    .HasColumnName("nature")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StructureKey).HasMaxLength(10);
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

            modelBuilder.Entity<TblAccountLedgerTransactions>(entity =>
            {
                entity.ToTable("tbl_AccountLedgerTransactions");

                entity.HasIndex(e => new { e.LedgerCode, e.VoucherNumber, e.DebitAmount, e.CreditAmount })
                    .HasName("NonClusteredAccountLedgerTransCols");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountingIndicator).HasMaxLength(10);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.CreditAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DebitAmount)
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.LedgerCode).HasMaxLength(10);

                entity.Property(e => e.LedgerName).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.VoucherAmount)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNumber)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblAlternateControlAccTrans>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("tbl_AlternateControlAccTrans");

                entity.Property(e => e.AlternativeControlAccount).HasMaxLength(50);

                entity.Property(e => e.ChartofAccount).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.NormalControlAccount).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssetAccountkey>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssetAccountkey");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.AccumulatedGl)
                    .HasColumnName("AccumulatedGL")
                    .HasMaxLength(15);

                entity.Property(e => e.AcquisitionsGl)
                    .HasColumnName("AcquisitionsGL")
                    .HasMaxLength(15);

                entity.Property(e => e.Auggl)
                    .HasColumnName("AUGGL")
                    .HasMaxLength(15);

                entity.Property(e => e.ChartofAccount).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.DepreciationGl)
                    .HasColumnName("DepreciationGL")
                    .HasMaxLength(15);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.GainOnSaleGl)
                    .HasColumnName("GainOnSaleGL")
                    .HasMaxLength(15);

                entity.Property(e => e.LossOnSaleGl)
                    .HasColumnName("LossOnSaleGL")
                    .HasMaxLength(15);

                entity.Property(e => e.SalesRevenueGl)
                    .HasColumnName("SalesRevenueGL")
                    .HasMaxLength(15);

                entity.Property(e => e.ScrappingGl)
                    .HasColumnName("ScrappingGL")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<TblAssetBeginingAcquisition>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.ToTable("tbl_AssetBeginingAcquisition");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.AcquisitionCost).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.MainAssetDescription).HasMaxLength(50);

                entity.Property(e => e.MainAssetNo).HasMaxLength(50);

                entity.Property(e => e.SubAssetDescription).HasMaxLength(50);

                entity.Property(e => e.SubAssetNo).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssetBeginingAcquisitionDetail>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.ToTable("tbl_AssetBeginingAcquisitionDetail");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AccumulatedDepreciation).HasMaxLength(50);

                entity.Property(e => e.DepreciationArea).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssetBegningAccumulatedDepreciation>(entity =>
            {
                entity.HasKey(e => new { e.id });
                entity.ToTable("tbl_AssetBegningAccumulatedDepreciation");

                entity.Property(e => e.mainAssetNo).HasMaxLength(50);

                entity.Property(e => e.accumulatedDepreciation).HasMaxLength(50);

                entity.Property(e => e.subAssetNo).HasMaxLength(50);

                entity.Property(e => e.depreciationArea).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssetBlock>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssetBlock");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.DepreciationKey).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext)
                    .HasColumnName("ext")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssetClass>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssetClass");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.AssetLowValue).HasMaxLength(5);

                entity.Property(e => e.ClassType).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LowValueAssetClass).HasMaxLength(5);

                entity.Property(e => e.Nature).HasMaxLength(50);

                entity.Property(e => e.NumberRange).HasMaxLength(5);
            });

            modelBuilder.Entity<TblAssetDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_AssetDetails");

                entity.Property(e => e.AccumulatedDepreciationUptoDateCurrentYear).HasMaxLength(50);

                entity.Property(e => e.AccumulatedPreviousYearDepreciation).HasMaxLength(50);

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(5);

                entity.Property(e => e.DepreciationArea).HasMaxLength(50);

                entity.Property(e => e.DepreciationCode).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MainAssetNo).HasMaxLength(50);

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.SubAssetNo).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssetNumberRange>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssetNumberRange");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FromRange);

                entity.Property(e => e.NonNumeric).HasMaxLength(5);

                entity.Property(e => e.ToRange);
            });

            modelBuilder.Entity<TblAssetTransactiontype>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssetTransactiontype");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssetTransfer>(entity =>
            {
                entity.HasKey(e => e.VoucherNumber);

                entity.ToTable("tbl_AssetTransfer");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.AssetTransactionType).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.EditDate).HasColumnType("datetime");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TransferDate).HasColumnType("date");

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblAssetTransferDetails>(entity =>
            {
                entity.ToTable("tbl_AssetTransferDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccumulatedValue).HasMaxLength(50);

                entity.Property(e => e.AcquisitionValue).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.MainAssetNo).HasMaxLength(50);

                entity.Property(e => e.ReceiverBranch).HasMaxLength(50);

                entity.Property(e => e.ReceiverCostCenter).HasMaxLength(50);

                entity.Property(e => e.ReceiverProfitCenter).HasMaxLength(50);

                entity.Property(e => e.ReceiverSegment).HasMaxLength(50);

                entity.Property(e => e.SenderBranch).HasMaxLength(50);

                entity.Property(e => e.SenderCostCenter).HasMaxLength(50);

                entity.Property(e => e.SenderProfitCenter).HasMaxLength(50);

                entity.Property(e => e.SenderSegment).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.SubAssetNo).HasMaxLength(50);

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssignAccountkeytoAsset>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssignAccountkeytoAsset");

                entity.Property(e => e.AccountKey).HasMaxLength(5);

                entity.Property(e => e.AssetClass).HasMaxLength(5);
            });

            modelBuilder.Entity<TblAssignAssetClasstoBlockAsset>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssignAssetClasstoBlockAsset");

                entity.Property(e => e.AssetBlock).HasMaxLength(5);

                entity.Property(e => e.AssetClass).HasMaxLength(5);
            });

            modelBuilder.Entity<TblAssignTaxacctoTaxcode>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssignTaxacctoTaxcode");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Cgstgl)
                    .HasColumnName("CGSTGL")
                    .HasMaxLength(50);

                entity.Property(e => e.ChartofAccount).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CompositeAccount).HasMaxLength(50);

                entity.Property(e => e.Igstgl)
                    .HasColumnName("IGSTGL")
                    .HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.Sgstgl)
                    .HasColumnName("SGSTGL")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugstgl)
                    .HasColumnName("UGSTGL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssignchartaccttoCompanycode>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssignchartaccttoCompanycode");

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.GroupCoa)
                    .HasColumnName("GroupCOA")
                    .HasMaxLength(5);

                entity.Property(e => e.OperationCoa)
                    .HasColumnName("OperationCOA")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<TblAssignment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_Assignment");

                entity.Property(e => e.Bpgroup)
                    .HasColumnName("BPGroup")
                    .HasMaxLength(5);

                entity.Property(e => e.NumberRangeKey).HasMaxLength(5);
            });

            modelBuilder.Entity<TblAssignmentVoucherSeriestoVoucherType>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("tbl_AssignmentVoucherSeriestoVoucherType");

                entity.Property(e => e.Suffix).HasMaxLength(5);

                entity.Property(e => e.VoucherSeries).HasMaxLength(5);

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblBankMaster>(entity =>
            {
                entity.HasKey(e => e.BankCode);

                entity.ToTable("tbl_BankMaster");

                entity.Property(e => e.BankCode).HasMaxLength(5);

                entity.Property(e => e.AccountNumber).HasMaxLength(50);

                entity.Property(e => e.AccountType).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.BankLimits).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BranchNumber).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.ContactPersion).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(15);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Region).HasMaxLength(5);

                entity.Property(e => e.State).HasMaxLength(5);

                entity.Property(e => e.Swiftkey)
                    .HasColumnName("SWIFTKey")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblBatchMaster>(entity =>
            {
                entity.HasKey(e => e.BatchNumber);

                entity.ToTable("tbl_BatchMaster");

                entity.Property(e => e.BatchNumber).HasMaxLength(20);

                entity.Property(e => e.ActualEndDate).HasColumnType("date");

                entity.Property(e => e.ActualStartDate).HasColumnType("date");

                entity.Property(e => e.BatchSize).HasMaxLength(10);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.PlantEndDate).HasColumnType("date");

                entity.Property(e => e.PlantStart).HasMaxLength(50);

                entity.Property(e => e.Uom).HasColumnName("UOM");

                entity.Property(e => e.Year).HasMaxLength(5);
            });

            modelBuilder.Entity<TblBinsCreation>(entity =>
            {
                entity.HasKey(e => e.BinNumber);

                entity.ToTable("tbl_BinsCreation");

                entity.Property(e => e.BinNumber).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Material).HasMaxLength(10);

                entity.Property(e => e.OpenQty).HasColumnName("OpenQTY");

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.StorageLocation).HasMaxLength(5);

                entity.Property(e => e.StoreIncharge).HasMaxLength(50);

                entity.Property(e => e.Uom).HasColumnName("UOM");
            });

            modelBuilder.Entity<TblBomDetails>(entity =>
            {
                entity.ToTable("tbl_BomDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.BomKey).HasMaxLength(10);

                entity.Property(e => e.Amount);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.MaterialName).HasMaxLength(50);

                entity.Property(e => e.ManufacturingType).HasMaxLength(50);

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.TaxAmount);
            });

            modelBuilder.Entity<TblBpgroup>(entity =>
            {
                entity.HasKey(e => e.Bpgroup);

                entity.ToTable("tbl_BPGroup");

                entity.Property(e => e.Bpgroup)
                    .HasColumnName("BPGroup")
                    .HasMaxLength(5);

                entity.Property(e => e.Bptype)
                    .HasColumnName("BPType")
                    .HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasColumnName("ext1");
            });

            modelBuilder.Entity<TblBranch>(entity =>
            {
                entity.HasKey(e => e.BranchCode);

                entity.ToTable("tbl_Branch");

                entity.HasIndex(e => new { e.BranchName, e.Panno, e.BranchCode })
                    .HasName("NonClusteredIndex-20181226-173932");

                entity.Property(e => e.BranchCode).HasMaxLength(5);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(5);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.IsMainBranch)
                    .HasColumnName("isMainBranch")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Panno)
                    .HasColumnName("PANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pincode).HasMaxLength(6);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(5);

                entity.Property(e => e.State).HasMaxLength(5);

                entity.Property(e => e.SubBranchof).HasDefaultValueSql("((0))");

                entity.Property(e => e.Tanno)
                    .HasColumnName("TANNo")
                    .HasMaxLength(50);

                //entity.HasOne(d => d.CompanyCodeNavigation)
                //    .WithMany(p => p.TblBranch)
                //    .HasForeignKey(d => d.CompanyCode)
                //    .HasConstraintName("FK__tbl_Branc__Compa__5A06E226");

                //entity.HasOne(d => d.CountryNavigation)
                //    .WithMany(p => p.TblBranch)
                //    .HasForeignKey(d => d.Country)
                //    .HasConstraintName("FK__tbl_Branc__Count__5BCF2F07");

                //entity.HasOne(d => d.CurrencyNavigation)
                //    .WithMany(p => p.TblBranch)
                //    .HasForeignKey(d => d.Currency)
                //    .HasConstraintName("FK__tbl_Branc__Curre__5CC35340");

                //entity.HasOne(d => d.RegionNavigation)
                //    .WithMany(p => p.TblBranch)
                //    .HasForeignKey(d => d.Region)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__tbl_Branc__Regio__5ADB0ACE");

                //entity.HasOne(d => d.StateNavigation)
                //    .WithMany(p => p.TblBranch)
                //    .HasForeignKey(d => d.State)
                //    .HasConstraintName("FK__tbl_Branc__State__59E6E695");
            });

            modelBuilder.Entity<TblBusinessPartnerAccount>(entity =>
            {
                entity.HasKey(e => e.Bpnumber);

                entity.ToTable("tbl_BusinessPartnerAccount");

                entity.Property(e => e.Bpnumber)
                    .HasColumnName("BPNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.BankAccountNo).HasMaxLength(50);

                entity.Property(e => e.BankBranch).HasMaxLength(50);

                entity.Property(e => e.BankBranchNo).HasMaxLength(50);

                entity.Property(e => e.BankKey).HasMaxLength(6);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.Bpgroup)
                    .HasColumnName("BPGroup")
                    .HasMaxLength(15);

                entity.Property(e => e.Bptype)
                    .HasColumnName("BPType")
                    .HasMaxLength(5);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.ContactPersion).HasMaxLength(50);

                entity.Property(e => e.ContactPersionMobile).HasMaxLength(15);

                entity.Property(e => e.ControlAccount).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(15);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.ObligationFrom).HasMaxLength(50);

                entity.Property(e => e.ObligationTo).HasMaxLength(50);

                entity.Property(e => e.Panno)
                    .HasColumnName("PANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.PaymentTerms).HasMaxLength(5);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Region).HasMaxLength(5);

                entity.Property(e => e.Search).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(5);

                entity.Property(e => e.Swiftcode)
                    .HasColumnName("SWIFTCode")
                    .HasMaxLength(15);

                entity.Property(e => e.Tanno)
                    .HasColumnName("TANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxClassification).HasMaxLength(50);

                entity.Property(e => e.Tdsrate)
                    .HasColumnName("TDSRate")
                    .HasMaxLength(50);

                entity.Property(e => e.Tdstype)
                    .HasColumnName("TDSType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblBusinessTransactionTypes>(entity =>
            {
                entity.HasKey(e => e.Code);
                entity.ToTable("tbl_BusinessTransactionTypes");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCashBankDetails>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ToTable("tbl_CashBankDetails");

                entity.Property(e => e.AccountingIndicator).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Bttypes)
                    .HasColumnName("BTTypes")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Commitment).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(8);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.FunctionalDept).HasMaxLength(5);

                entity.Property(e => e.FundCenter).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsnsaccode)
                    .HasColumnName("HSNSACCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.LineItemNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetWork).HasMaxLength(50);

                entity.Property(e => e.OrderNo).HasMaxLength(50);

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.ReferenceDate).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.Sgstamount)
                    .HasColumnName("SGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(5);

                entity.Property(e => e.Ugstamount)
                    .HasColumnName("UGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.WorkBreakStructureElement).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCashBankMaster>(entity =>
            {
                entity.HasKey(e => e.VoucherNumber);

                entity.ToTable("tbl_CashBankMaster");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AccountingIndicator).HasMaxLength(10);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NatureofTransaction).HasMaxLength(20);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.ReferenceDate).HasColumnType("date");

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TransactionType).HasMaxLength(5);

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblChartAccount>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_ChartAccount");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Desctiption).HasMaxLength(50);

                entity.Property(e => e.Ext)
                    .HasColumnName("ext")
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCommitmentItem>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_CommitmentItem");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyCode)
                    .HasName("PK__tbl_Comp__AD5459903E723F9C");

                entity.ToTable("tbl_Company");

                entity.Property(e => e.CompanyCode).HasMaxLength(5);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Panno)
                    .HasColumnName("PANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Region).HasMaxLength(5);

                entity.Property(e => e.ShortName).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(5);

                entity.Property(e => e.Tanno)
                    .HasColumnName("TANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.WebSite).HasMaxLength(50);

                //entity.HasOne(d => d.CountryNavigation)
                //    .WithMany(p => p.TblCompany)
                //    .HasForeignKey(d => d.Country)
                //    .HasConstraintName("FK__tbl_Compa__Count__4C8CEB77");

                //entity.HasOne(d => d.CurrencyNavigation)
                //    .WithMany(p => p.TblCompany)
                //    .HasForeignKey(d => d.Currency)
                //    .HasConstraintName("FK__tbl_Compa__Curre__5339E906");

                //entity.HasOne(d => d.LanguageNavigation)
                //    .WithMany(p => p.TblCompany)
                //    .HasForeignKey(d => d.Language)
                //    .HasConstraintName("FK__tbl_Compa__Langu__33E1393E");
            });

            modelBuilder.Entity<TblCostingActivity>(entity =>
            {
                entity.HasKey(e => e.ActivityCode);

                entity.ToTable("tbl_CostingActivity");

                entity.Property(e => e.ActivityCode).HasMaxLength(10);

                entity.Property(e => e.BasisofFixedPrice).HasMaxLength(50);

                entity.Property(e => e.CostElement).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Uom).HasColumnName("UOM");
            });

            modelBuilder.Entity<TblCostingKeyFigures>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_CostingKeyFigures");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Uom).HasColumnName("UOM");
            });

            modelBuilder.Entity<TblCostingNumberSeries>(entity =>
            {
                entity.HasKey(e => e.NumberObject);

                entity.ToTable("tbl_CostingNumberSeries");

                entity.Property(e => e.NumberObject).HasMaxLength(5);

                entity.Property(e => e.NonNumaric).HasMaxLength(5);

                entity.Property(e => e.Prefix).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCostingObjectTypes>(entity =>
            {
                entity.HasKey(e => e.ObjectType);

                entity.ToTable("tbl_CostingObjectTypes");

                entity.Property(e => e.ObjectType).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Usage).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCostingUnitsCreation>(entity =>
            {
                entity.HasKey(e => e.ObjectNumber);

                entity.ToTable("tbl_CostingUnitsCreation");

                entity.Property(e => e.ObjectNumber).HasMaxLength(15);

                entity.Property(e => e.CostUnitType).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ManufacturingType).HasMaxLength(50);

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.ObjectType).HasMaxLength(50);

                entity.Property(e => e.PerUnitCostBy).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCostingnumberAssigntoObject>(entity =>
            {
                entity.HasKey(e => e.ObjectType);

                entity.ToTable("tbl_CostingnumberAssigntoObject");

                entity.Property(e => e.ObjectType).HasMaxLength(5);

                entity.Property(e => e.NumberSeries).HasMaxLength(5);
            });

            modelBuilder.Entity<TblCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencySymbol)
                    .HasName("PK__tbl_Curr__DAF0B20A592635D8");

                entity.ToTable("tbl_Currency");

                entity.Property(e => e.CurrencySymbol).HasMaxLength(5);

                entity.Property(e => e.CurrencyName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblDepreciation>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_Depreciation");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.DepreciationMethod).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.MaxDepreciationAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MaxDepreciationRate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PurchaseWithin).HasMaxLength(5);

                entity.Property(e => e.Rate).HasColumnName("Rate");

                entity.Property(e => e.Upto1Months).HasColumnName("UPto1Months");

                entity.Property(e => e.Upto1Rate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Upto2Rate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Upto3Rate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Upto4Rate).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblDepreciationAreas>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_DepreciationAreas");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.DepreciationType).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext)
                    .HasColumnName("ext")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblDepreciationDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_DepreciationDetails");

                entity.Property(e => e.AccumulatedPreviousYearDeprecation).HasColumnType("date");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(5);

                entity.Property(e => e.CurrentYearDate).HasColumnType("date");

                entity.Property(e => e.DepreciationArea).HasMaxLength(50);

                entity.Property(e => e.DepreciationCode).HasMaxLength(50);

                entity.Property(e => e.DepreciationPostedUpto).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MainAssetNo).HasMaxLength(50);

                entity.Property(e => e.Month).HasMaxLength(5);

                entity.Property(e => e.PeriodFrom).HasColumnType("date");

                entity.Property(e => e.PeriodTo).HasColumnType("date");

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.SubAssetNo).HasMaxLength(50);

                entity.Property(e => e.Year).HasMaxLength(5);
            });

            modelBuilder.Entity<TblDepreciationcodeDetails>(entity =>
            {
                entity.ToTable("tbl_depreciationcodeDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepreciationCode).HasMaxLength(5);

                entity.Property(e => e.Monthupto).HasMaxLength(5);

                entity.Property(e => e.Rateupto).HasMaxLength(50);

                entity.Property(e => e.Yearsupto).HasMaxLength(5);
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

            modelBuilder.Entity<TblHoliday>(entity =>
            {
                entity.HasKey(e => e.HolidayId);


                entity.ToTable("tbl_Holiday");

                entity.Property(e => e.HolidayId)
                    .HasColumnName("holidayId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HolidayName)
                    .HasColumnName("holidayName")
                    .IsUnicode(false);

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .IsUnicode(false);

                entity.Property(e => e.Extra2)
                    .HasColumnName("extra2")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDistributionChannel>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_DistributionChannel");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblDownTimeReasons>(entity =>
            {
                entity.HasKey(e => e.ReasonCode);

                entity.ToTable("tbl_DownTimeReasons");

                entity.Property(e => e.ReasonCode).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<TblDynamicPages>(entity =>
            {
                entity.HasKey(e => e.FormName);

                entity.ToTable("tbl_DynamicPages");

                entity.Property(e => e.FormName).HasMaxLength(50);

                entity.Property(e => e.Component).HasMaxLength(100);

                entity.Property(e => e.Delete).HasMaxLength(50);

                entity.Property(e => e.DeleteUrl)
                    .HasColumnName("DeleteURL")
                    .HasMaxLength(100);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ListName).HasMaxLength(50);

                entity.Property(e => e.PrimaryKey).HasMaxLength(50);

                entity.Property(e => e.RegisterUrl)
                    .HasColumnName("RegisterURL")
                    .HasMaxLength(100);

                entity.Property(e => e.TabScreen).HasMaxLength(5);

                entity.Property(e => e.UpdateUrl)
                    .HasColumnName("UpdateURL")
                    .HasMaxLength(100);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeCode)
                    .HasName("PK__tbl_Empl__C134C9C125518C17");

                entity.ToTable("tbl_Employee");


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


                entity.Property(e => e.BloodGroup)
                    .HasColumnName("bloodGroup")
                    .IsUnicode(false);



                entity.Property(e => e.BranchId)
                    .HasColumnName("branchID");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("designationId");

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



                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.JoiningDate)
                    .HasColumnName("joiningDate")
                    .HasColumnType("datetime");



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


                entity.Property(e => e.ReportedBy).IsUnicode(false);


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

            modelBuilder.Entity<TblFieldsConfiguration>(entity =>
            {
                entity.HasKey(e => e.OperationCode);
                entity.ToTable("TBL_FieldsConfiguration");

                entity.Property(e => e.Id).HasColumnName("id");


                entity.Property(e => e.OperationCode)
                    .IsRequired()
                    .HasColumnName("OperationCode")
                    .HasMaxLength(50);

                entity.Property(e => e.ScreenName).HasMaxLength(50);

                entity.Property(e => e.ShowControl).HasMaxLength(4000);
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

            modelBuilder.Entity<TblFormula>(entity =>
            {
                entity.HasKey(e => e.FormulaKey);

                entity.ToTable("tbl_Formula");

                entity.Property(e => e.FormulaKey).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FormulaBar).HasMaxLength(500);

                entity.Property(e => e.FormulaType).HasMaxLength(50);
            });

            modelBuilder.Entity<TblFunctionalDepartment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_FunctionalDepartment");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(5);
            });

            modelBuilder.Entity<TblFundCenter>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_FundCenter");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Person).HasMaxLength(50);

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(50);
            });

            modelBuilder.Entity<TblGinnoSeries>(entity =>
            {
                entity.HasKey(e => e.Ginseries);

                entity.ToTable("tbl_GINNoSeries");

                entity.Property(e => e.Ginseries)
                    .HasColumnName("GINSeries")
                    .HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(5);
            });

            modelBuilder.Entity<TblGinseriesAssignment>(entity =>
            {
                entity.HasKey(e => new { e.id });

                entity.ToTable("tbl_GINSeriesAssignment");

                entity.Property(e => e.Ginseries)
                    .HasColumnName("GINSeries")
                    .HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.MaterilaType).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);
            });

            modelBuilder.Entity<TblGlsubAccount>(entity =>
            {
                entity.HasKey(e => e.GlsubCode);

                entity.ToTable("Tbl_GLSubAccount");

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(10);

                entity.Property(e => e.GlsubCode)
                    .HasColumnName("GLSubCode")
                    .HasMaxLength(10);

                entity.Property(e => e.GlsubName)
                    .HasColumnName("GLSubName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblGoodsIssueDetails>(entity =>
            {
                entity.ToTable("tbl_GoodsIssueDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.GoodsIssueId);

                entity.Property(e => e.JobOrder).HasMaxLength(50);

                entity.Property(e => e.JoborProject).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(50);

                entity.Property(e => e.Qty);

                entity.Property(e => e.Wbs)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblGoodsIssueMaster>(entity =>
            {
                entity.HasKey(e => e.GoodsIssueId)
                    .HasName("PK_tbl_GoodsIssue");

                entity.ToTable("tbl_GoodsIssueMaster");

                entity.Property(e => e.GoodsIssueId).HasColumnName("GoodsIssueID");

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.ProductionPerson).HasMaxLength(50);

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.SaleOrderNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.StoresPerson).HasMaxLength(50);
            });

            modelBuilder.Entity<TblGoodsReceiptDetails>(entity =>
            {
                entity.ToTable("tbl_GoodsReceiptDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LotDate).HasColumnType("date");

                entity.Property(e => e.LotNo).HasMaxLength(50);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.MovementType).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(50);

                entity.Property(e => e.Poqty).HasColumnName("POQTY");

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.PurchaseOrderNo).HasMaxLength(50);

                entity.Property(e => e.ReceivedQty).HasColumnName("ReceivedQTY");

                entity.Property(e => e.StorageLocation).HasMaxLength(50);
                entity.Property(e => e.NetWeight);
                entity.Property(e => e.RejectQty);
            });

            modelBuilder.Entity<TblGoodsReceiptMaster>(entity =>
            {
                entity.ToTable("tbl_GoodsReceiptMaster");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.EditDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("date");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(50);

                entity.Property(e => e.InspectionNoteNo).HasMaxLength(50);

                entity.Property(e => e.MovementType).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(50);

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.PurchaseOrderNo).HasMaxLength(50);

                entity.Property(e => e.QualityCheck).HasMaxLength(5);

                entity.Property(e => e.ReceiptDate);

                entity.Property(e => e.ReceivedBy).HasMaxLength(50);

                entity.Property(e => e.ReceivedDate);

                entity.Property(e => e.Rrno)
                    .HasColumnName("RRNo")
                    .HasMaxLength(50);

                entity.Property(e => e.StorageLocation).HasMaxLength(50);

                entity.Property(e => e.SupplierCode).HasMaxLength(50);

                entity.Property(e => e.SupplierGinno)
                    .HasColumnName("SupplierGINNo")
                    .HasMaxLength(50);

                entity.Property(e => e.SupplierReferenceNo).HasMaxLength(50);

                entity.Property(e => e.VehicleNo).HasMaxLength(15);
                entity.Property(e => e.TotalAmount);
                entity.Property(e => e.Status);
            });

            modelBuilder.Entity<TblGrnassignment>(entity =>
            {
                entity.HasKey(e => new { e.Grnseries, e.Company });

                entity.ToTable("tbl_GRNAssignment");

                entity.Property(e => e.Grnseries)
                    .HasColumnName("GRNSeries")
                    .HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.MaterialType).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);
            });

            modelBuilder.Entity<TblGrnnoSeries>(entity =>
            {
                entity.HasKey(e => e.Grnseries);

                entity.ToTable("tbl_GRNNoSeries");

                entity.Property(e => e.Grnseries)
                    .HasColumnName("GRNSeries")
                    .HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(5);
            });

            modelBuilder.Entity<TblHideTableColumns>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_HideTableColumns");

                entity.Property(e => e.AliasName).HasMaxLength(50);

                entity.Property(e => e.ColumnName).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TableName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblHsnsac>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_HSNSAC");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext)
                    .HasColumnName("ext")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1)
                    .HasColumnName("ext1")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblIncomeTypes>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_IncomeTypes");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Desctiption).HasMaxLength(50);

                entity.Property(e => e.Ext)
                    .HasColumnName("ext")
                    .HasMaxLength(50);

                entity.Property(e => e.SectionCode).HasMaxLength(10);

                entity.Property(e => e.ThresholdContract).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ThresholdLimit).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblInspectionCheckMaster>(entity =>
            {
                entity.HasKey(e => e.InspectionCheckNo);

                entity.ToTable("tbl_InspectionCheckMaster");

                entity.Property(e => e.InspectionCheckNo).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.InspectionType).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.EditDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.saleOrderNumber).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.Status).HasMaxLength(15);
            });

            modelBuilder.Entity<TblInspectionCheckDetails>(entity =>
            {
                entity.ToTable("tbl_InspectionCheckDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InspectionCheckNo).HasMaxLength(50);

                entity.Property(e => e.productionTag).HasMaxLength(50);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.saleOrderNumber).HasMaxLength(50);

            });

            modelBuilder.Entity<TblInvoiceMemoDetails>(entity =>
            {
                entity.ToTable("tbl_InvoiceMemoDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountingIndicator).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Bttypes)
                    .HasColumnName("BTTypes")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Commitment).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(8);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.FunctionalDept).HasMaxLength(50);

                entity.Property(e => e.FundCenter).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsnsac)
                    .HasColumnName("HSNSAC")
                    .HasMaxLength(50);

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.LineItemNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetWork).HasMaxLength(50);

                entity.Property(e => e.OrderNo).HasMaxLength(50);

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.ReferenceDate).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(50);

                entity.Property(e => e.Sgstamount)
                    .HasColumnName("SGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(5);

                entity.Property(e => e.Ugstamount)
                    .HasColumnName("UGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNo).HasMaxLength(50);

                entity.Property(e => e.WorkBreakStructureElement).HasMaxLength(50);
            });

            modelBuilder.Entity<TblInvoiceMemoHeader>(entity =>
            {
                entity.HasKey(e => e.VoucherNumber);

                entity.ToTable("tbl_InvoiceMemoHeader");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.AccountingIndicator).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Bpcategory)
                    .HasColumnName("BPCategory")
                    .HasMaxLength(5);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("date");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NatureofTransaction).HasMaxLength(50);

                entity.Property(e => e.PartyAccount).HasMaxLength(50);

                entity.Property(e => e.PartyInvoiceDate).HasMaxLength(50);

                entity.Property(e => e.PartyInvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Paymentterms).HasMaxLength(50);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ReferenceDate).HasColumnType("date");

                entity.Property(e => e.ReferenceNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TransactionType).HasMaxLength(20);

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblInvoiceVerificationDetails>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tbl_InvoiceVerificationDetails");

                entity.Property(e => e.AccountKey).HasMaxLength(50);

                entity.Property(e => e.AccountKeyAccount).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.OtherExpenses).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.OtherExpensesAccount).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PurchaseOrderNo).HasMaxLength(50);

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblInvoiceVerificationMaster>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderNo);

                entity.ToTable("tbl_InvoiceVerificationMaster");

                entity.Property(e => e.PurchaseOrderNo).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EditDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("date");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.SupplierCode).HasMaxLength(50);
            });

            modelBuilder.Entity<TblInvoiceVerificationOtherExpenses>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tbl_InvoiceVerificationOtherExpenses");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Drcr)
                    .HasColumnName("DRCR")
                    .HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(50);

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.PurchaseOrderNo).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(50);
            });

            modelBuilder.Entity<TblJvdetails>(entity =>
            {
                entity.ToTable("tbl_JVDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountingIndicator).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Bttypes)
                    .HasColumnName("BTTypes")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Commitment).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(8);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.FunctionalDept).HasMaxLength(5);

                entity.Property(e => e.FundCenter).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsnsac)
                    .HasColumnName("HSNSAC")
                    .HasMaxLength(50);

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.LineItemNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetWork).HasMaxLength(50);

                entity.Property(e => e.OrderNo).HasMaxLength(50);

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.ReferenceDate).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.Sgstamount)
                    .HasColumnName("SGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(5);

                entity.Property(e => e.Ugstamount)
                    .HasColumnName("UGSTAmount")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.VoucherDate).HasMaxLength(50);

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.WorkBreakStructureElement).HasMaxLength(50);
            });

            modelBuilder.Entity<TblJvmaster>(entity =>
            {
                entity.HasKey(e => e.VoucherNumber)
                    .HasName("PK_tbl_JVMaster_1");

                entity.ToTable("tbl_JVMaster");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.AccountingIndicator).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ReferenceDate).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TransactionType).HasMaxLength(20);

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblLanguage>(entity =>
            {
                entity.HasKey(e => e.LanguageCode);

                entity.ToTable("tbl_Language");

                entity.Property(e => e.LanguageCode).HasMaxLength(5);

                entity.Property(e => e.LanguageName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("tbl_Location");

                entity.Property(e => e.LocationId)
                    .HasColumnName("LocationID")
                    .HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);
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

            modelBuilder.Entity<TblLotAssignment>(entity =>
            {
                entity.HasKey(e => new { e.LotSeries, e.Company });

                entity.ToTable("tbl_LotAssignment");

                entity.Property(e => e.LotSeries).HasMaxLength(10);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.MaterialType).HasMaxLength(10);

                entity.Property(e => e.Plant).HasMaxLength(5);
            });

            modelBuilder.Entity<TblLotSeries>(entity =>
            {
                entity.HasKey(e => e.SeriesKey);

                entity.ToTable("tbl_LotSeries");

                entity.Property(e => e.SeriesKey).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(5);
            });

            modelBuilder.Entity<TblMainAssetMaster>(entity =>
            {
                entity.HasKey(e => e.AssetNumber);

                entity.ToTable("tbl_MainAssetMaster");

                entity.Property(e => e.AssetNumber).HasMaxLength(15);

                entity.Property(e => e.AccountKey).HasMaxLength(50);

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.AssetLowValue).HasMaxLength(5);

                entity.Property(e => e.Assetclass)
                    .HasColumnName("assetclass")
                    .HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.ClassType).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.DepreciationArea).HasMaxLength(5);

                entity.Property(e => e.DepreciationCode).HasMaxLength(5);

                entity.Property(e => e.DepreciationData).HasMaxLength(50);

                entity.Property(e => e.DepreciationStartDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Division).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.LowValueAssetClass).HasMaxLength(5);

                entity.Property(e => e.MaterialNo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Name1).HasMaxLength(50);

                entity.Property(e => e.Nature).HasMaxLength(50);

                entity.Property(e => e.NumberRange).HasMaxLength(5);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.Room).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.SerialNo).HasMaxLength(50);

                entity.Property(e => e.Supplier).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMainAssetMasterTransaction>(entity =>
            {
                entity.ToTable("tbl_MainAssetMasterTransaction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.DepreciationArea).HasMaxLength(50);

                entity.Property(e => e.DepreciationCode).HasMaxLength(50);

                entity.Property(e => e.DepreciationStartDate).HasColumnType("date");

                entity.Property(e => e.Rate).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblMaintenancearea>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_Maintenancearea");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);
            });

            modelBuilder.Entity<TblMaterialGroups>(entity =>
            {
                entity.HasKey(e => e.GroupKey);

                entity.ToTable("tbl_MaterialGroups");
                entity.Property(e => e.GroupKey).HasMaxLength(50);

                entity.Property(e => e.narration).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.extra1).HasMaxLength(50);

                entity.Property(e => e.extra2).HasMaxLength(50);
                entity.Property(e => e.extraDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblMaterialMaster>(entity =>
            {
                entity.HasKey(e => new { e.MaterialCode });

                entity.ToTable("tbl_MaterialMaster");

                entity.Property(e => e.MaterialCode).HasMaxLength(20);

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Chapter).HasMaxLength(50);

                entity.Property(e => e.Classification).HasMaxLength(50);

                entity.Property(e => e.ClosingQty).HasColumnName("ClosingQTY");

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Division).HasMaxLength(5);

                entity.Property(e => e.EconomicOrderQty).HasColumnName("EconomicOrderQTY");

                entity.Property(e => e.EditDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.GoodsServiceDescription).HasMaxLength(50);

                entity.Property(e => e.GrossWeight).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Hsnsac)
                    .HasColumnName("HSNSAC")
                    .HasMaxLength(20);

                entity.Property(e => e.MaterialGroup).HasMaxLength(15);

                entity.Property(e => e.MaterialType).HasMaxLength(15);

                entity.Property(e => e.ModelPattern).HasMaxLength(15);

                entity.Property(e => e.NetWeight).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NetWeightUom)
                    .HasColumnName("NetWeightUOM")
                    .HasMaxLength(50);

                entity.Property(e => e.OpeningQty).HasColumnName("OpeningQTY");

                entity.Property(e => e.Ouom)
                    .HasColumnName("OUOM")
                    .HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.PurchaseOrderText).HasMaxLength(50);

                entity.Property(e => e.PurchasingGroup).HasMaxLength(15);

                entity.Property(e => e.Qtyvalues)
                    .HasColumnName("QTYValues")
                    .HasMaxLength(50);

                entity.Property(e => e.Schedule).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.Property(e => e.Taxable).HasMaxLength(50);

                entity.Property(e => e.TransferPrice).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Uom)
                    .HasColumnName("UOM")
                    .HasMaxLength(50);

                entity.Property(e => e.Valuation).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMaterialNoAssignment>(entity =>
            {
                entity.HasKey(e => new { e.ID });

                entity.ToTable("tbl_MaterialNoAssignment");

                entity.Property(e => e.NumberRange).HasMaxLength(10);

                entity.Property(e => e.CompanyCode).HasMaxLength(5);

                entity.Property(e => e.MaterialType).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);
            });

            modelBuilder.Entity<TblMaterialNoSeries>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_MaterialNoSeries");

                entity.Property(e => e.Code).HasMaxLength(5);
                entity.Property(e => e.FromInterval).HasMaxLength(10);
                entity.Property(e => e.ToInterval).HasMaxLength(10);
                entity.Property(e => e.CurrentNumber).HasMaxLength(10);
                entity.Property(e => e.NonNumeric).HasMaxLength(50);
                entity.Property(e => e.Prefix).HasMaxLength(50);
                entity.Property(e => e.Autogenerator).HasMaxLength(50);
                entity.Property(e => e.Ext).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMaterialPurchasePrice>(entity =>
            {
                entity.ToTable("tbl_MaterialPurchasePrice");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("date");

                entity.Property(e => e.Grnnumber)
                    .HasColumnName("GRNNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.Podae)
                    .HasColumnName("PODae")
                    .HasColumnType("date");

                entity.Property(e => e.Ponumber)
                    .HasColumnName("PONumber")
                    .HasMaxLength(50);

                entity.Property(e => e.PurchasePrice).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SupplierCode).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMaterialRequisitionDetails>(entity =>
            {
                entity.ToTable("tbl_MaterialRequisitionDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.JoborProject).HasMaxLength(50);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.Order).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.RequisitionNumber).HasMaxLength(20);

                entity.Property(e => e.SotrageLocation).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Wbs)
                    .HasColumnName("WBS")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblMaterialRequisitionMaster>(entity =>
            {
                entity.HasKey(e => e.RequisitionNmber);

                entity.ToTable("tbl_MaterialRequisitionMaster");

                entity.Property(e => e.RequisitionNmber).HasMaxLength(20);

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.BomorderNumber)
                    .HasColumnName("BOMOrderNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Department).HasMaxLength(5);

                entity.Property(e => e.EditDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.Project).HasMaxLength(50);

                entity.Property(e => e.RequisitionDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMaterialSize>(entity =>
            {
                entity.HasKey(e => e.unitId)
                    .HasName("PK_MaterialSize");

                entity.ToTable("tbl_MaterialSize");

                entity.Property(e => e.narration)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.unitName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMaterialSupplierDetails>(entity =>
            {
                entity.ToTable("tbl_MaterialSupplierDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LastSupplyOn).HasColumnType("date");

                entity.Property(e => e.LastSupplyPrice).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.Podate)
                    .HasColumnName("PODate")
                    .HasColumnType("date");

                entity.Property(e => e.Ponumber)
                    .HasColumnName("PONumber")
                    .HasMaxLength(20);

                entity.Property(e => e.PriceperUnit).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SupplierCode).HasMaxLength(15);
            });

            modelBuilder.Entity<TblMaterialSupplierMaster>(entity =>
            {
                entity.HasKey(e => e.SupplierCode);

                entity.ToTable("tbl_MaterialSupplierMaster");

                entity.Property(e => e.SupplierCode).HasMaxLength(15);

                entity.Property(e => e.ContactPerson).HasMaxLength(50);

                entity.Property(e => e.DeliveryTime).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(15);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(5);

                entity.Property(e => e.SupplierName).HasMaxLength(50);

                entity.Property(e => e.TransportMethod).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMaterialTypes>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_MaterialTypes");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasColumnName("ext1");

                entity.Property(e => e.Usage).HasMaxLength(50);
            });

            modelBuilder.Entity<TblModelPattern>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_ModelPattern");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);
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

            modelBuilder.Entity<TblMovementType>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_MovementType");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblMrnnoAssignment>(entity =>
            {
                entity.HasKey(e => new { e.ID });

                entity.ToTable("tbl_MRNNoAssignment");

                entity.Property(e => e.Mrnseries)
                    .HasColumnName("MRNSeries")
                    .HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.MaterialType).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);
            });

            modelBuilder.Entity<TblMrnnoSeries>(entity =>
            {
                entity.HasKey(e => e.Mrnseries);

                entity.ToTable("tbl_MRNNoSeries");

                entity.Property(e => e.Mrnseries)
                    .HasColumnName("MRNSeries")
                    .HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Prefix).HasMaxLength(5);
            });

            modelBuilder.Entity<TblNumberAssignment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_NumberAssignment");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Bpgroup)
                    .HasColumnName("BPGroup")
                    .HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NumberRange).HasMaxLength(5);
            });

            modelBuilder.Entity<TblNumberRange>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_NumberRange");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.NonNumaric)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblOpenLedger>(entity =>
            {
                entity.ToTable("tbl_OpenLedger");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountingYear).HasMaxLength(5);

                entity.Property(e => e.FinancialYearEndTo).HasMaxLength(5);

                entity.Property(e => e.FinancialYearStartFrom).HasMaxLength(5);

                entity.Property(e => e.LedgerKey)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOrderType>(entity =>
            {
                entity.HasKey(e => e.OrderType);

                entity.ToTable("tbl_OrderType");

                entity.Property(e => e.OrderType).HasMaxLength(10);

                entity.Property(e => e.CostUnit).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.NatureofOrder).HasMaxLength(50);

                entity.Property(e => e.PrintText).HasMaxLength(50);
            });

            modelBuilder.Entity<ApprovalType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Approval)
                    .HasColumnName("Approval")
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);



                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.ImmediateReporting)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecomendedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPartyCashBankMaster>(entity =>
            {
                entity.HasKey(e => e.VoucherNumber);

                entity.ToTable("tbl_PartyCashBankMaster");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AccountingIndicator).HasMaxLength(10);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Bpcategory)
                    .HasColumnName("BPCategory")
                    .HasMaxLength(5);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.ChequeDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChequeNo).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NatureofTransaction).HasMaxLength(10);

                entity.Property(e => e.PartyAccount).HasMaxLength(50);

                entity.Property(e => e.Period)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.ReferenceDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.TransactionType).HasMaxLength(10);

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblParyCashBankDetails>(entity =>
            {
                entity.ToTable("tbl_ParyCashBankDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.AdjustmentAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.BalanceDue).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ClearedAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Discount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.DiscountGl)
                    .HasColumnName("DiscountGL")
                    .HasMaxLength(50);

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MemoAmount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NotDue).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.PartyInvoiceDate).HasColumnType("date");

                entity.Property(e => e.PartyInvoiceNo).HasMaxLength(50);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.WriteOffAmount).HasMaxLength(50);

                entity.Property(e => e.WriteOffGl)
                    .HasColumnName("WriteOffGL")
                    .HasMaxLength(50);

                entity.Property(e => e.Writeoff).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblPaymentTermDetails>(entity =>
            {
                entity.ToTable("tbl_PaymentTermDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.PaymentTermCode).HasMaxLength(5);
            });

            modelBuilder.Entity<TblPaymentTerms>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_tbl_PaymentTerms_1");

                entity.ToTable("tbl_PaymentTerms");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPermissions>(entity =>
            {
                entity.HasKey(e => e.SeqId);

                entity.ToTable("Tbl_Permissions");

                entity.Property(e => e.SeqId).HasColumnName("seqId");

                entity.Property(e => e.ScreenModule).HasMaxLength(50);

                entity.Property(e => e.screenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblPlant>(entity =>
            {
                entity.HasKey(e => e.PlantCode);

                entity.ToTable("tbl_Plant");

                entity.Property(e => e.PlantCode).HasMaxLength(5);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Panno)
                    .HasColumnName("PANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(6);

                entity.Property(e => e.Plantname).HasMaxLength(50);

                entity.Property(e => e.Region).HasMaxLength(5);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(5);

                entity.Property(e => e.State).HasMaxLength(5);

                //entity.HasOne(d => d.CountryNavigation)
                //    .WithMany(p => p.TblPlant)
                //    .HasForeignKey(d => d.Country)
                //    .HasConstraintName("FK__tbl_Plant__Count__6093E424");

                //entity.HasOne(d => d.CurrencyNavigation)
                //    .WithMany(p => p.TblPlant)
                //    .HasForeignKey(d => d.Currency)
                //    .HasConstraintName("FK__tbl_Plant__Curre__6188085D");

                //entity.HasOne(d => d.LanguageNavigation)
                //    .WithMany(p => p.TblPlant)
                //    .HasForeignKey(d => d.Language)
                //    .HasConstraintName("FK__tbl_Plant__Langu__5AFB065F");

                //entity.HasOne(d => d.RegionNavigation)
                //    .WithMany(p => p.TblPlant)
                //    .HasForeignKey(d => d.Region)
                //    .HasConstraintName("FK__tbl_Plant__Regio__5F9FBFEB");

                //entity.HasOne(d => d.StateNavigation)
                //    .WithMany(p => p.TblPlant)
                //    .HasForeignKey(d => d.State)
                //    .HasConstraintName("FK__tbl_Plant__State__5EAB9BB2");
            });

            modelBuilder.Entity<TblPosaleAssetInvoiceMemoDetails>(entity =>
            {
                entity.ToTable("tbl_POSaleAssetInvoiceMemoDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountingIndicator).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Bttypes)
                    .HasColumnName("bttypes")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Commitment).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(8);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.FunctionalDept).HasMaxLength(50);

                entity.Property(e => e.FundCenter).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsnsac)
                    .HasColumnName("HSNSAC")
                    .HasMaxLength(50);

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LineItemNo).HasMaxLength(50);

                entity.Property(e => e.MainAssetNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetWork).HasMaxLength(50);

                entity.Property(e => e.OrderNo).HasMaxLength(50);

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.ReferenceDate).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(50);

                entity.Property(e => e.Sgstamount)
                    .HasColumnName("SGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.SubAssetNo).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(5);

                entity.Property(e => e.Ugstamount)
                    .HasColumnName("UGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNo).HasMaxLength(50);

                entity.Property(e => e.WorkBreakStructureElement).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPosaleAssetInvoiceMemoHeader>(entity =>
            {
                entity.HasKey(e => e.VoucherNumber);

                entity.ToTable("tbl_POSaleAssetInvoiceMemoHeader");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.AccountingIndicator).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AssetTransactionType).HasMaxLength(50);

                entity.Property(e => e.Bpcategory)
                    .HasColumnName("BPCategory")
                    .HasMaxLength(5);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("date");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.PartyAccount).HasMaxLength(50);

                entity.Property(e => e.PartyInvoiceDate).HasColumnType("date");

                entity.Property(e => e.PartyInvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Paymentterms).HasMaxLength(50);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ReferenceDate).HasColumnType("date");

                entity.Property(e => e.ReferenceNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TransactionType).HasMaxLength(20);

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblPosting>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_Posting");

                entity.Property(e => e.Branch).HasMaxLength(15);

                entity.Property(e => e.ChartofAccount).HasMaxLength(15);

                entity.Property(e => e.Company).HasMaxLength(15);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(15);

                entity.Property(e => e.Plant).HasMaxLength(15);

                entity.Property(e => e.Tdsrate)
                    .HasColumnName("TDSRate")
                    .HasMaxLength(15);
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

            modelBuilder.Entity<TblPrimaryCostElement>(entity =>
            {
                entity.HasKey(e => e.GeneralLedger);
                entity.ToTable("tbl_PrimaryCostElement");

                entity.Property(e => e.ChartofAccount).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Element).HasMaxLength(50);

                entity.Property(e => e.GeneralLedger).HasMaxLength(50);

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Uom).HasColumnName("UOM");

                entity.Property(e => e.Usage).HasMaxLength(50);
            });

            modelBuilder.Entity<TblRequisitionNoRange>(entity =>
            {
                entity.HasKey(e => e.numberRange);

                entity.ToTable("tbl_RequisitionNoRange");

                entity.Property(e => e.numberRange).HasMaxLength(10);

                entity.Property(e => e.Department).HasMaxLength(5);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.Prefix).HasMaxLength(5);
                entity.Property(e => e.FromInterval).HasMaxLength(5);

                entity.Property(e => e.ToInterval).HasMaxLength(5);
                entity.Property(e => e.CurrentNumber).HasMaxLength(5);
            });

            modelBuilder.Entity<TblProcess>(entity =>
            {
                entity.HasKey(e => e.ProcessKey);

                entity.ToTable("tbl_Process");

                entity.Property(e => e.ProcessKey).HasMaxLength(5);

                entity.Property(e => e.ByProduct).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostUnit).HasMaxLength(50);

                entity.Property(e => e.JointProduct).HasMaxLength(50);

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.NextProcess).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.ReWork).HasMaxLength(50);

                entity.Property(e => e.Wipcalculation)
                    .HasColumnName("WIPCalculation")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<TblPurchaseDepartment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_PurchaseDepartment");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPurchaseGroup>(entity =>
            {
                entity.HasKey(e => e.PruchaseGroup);

                entity.ToTable("tbl_PurchaseGroup");

                entity.Property(e => e.PruchaseGroup).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPurchaseNoRange>(entity =>
            {
                entity.HasKey(e => e.code);

                entity.ToTable("tbl_PurchaseNoRange");

                entity.Property(e => e.code).HasMaxLength(5);

                entity.Property(e => e.Prefix).HasMaxLength(5);
            });
            modelBuilder.Entity<TblPurchaseOrderNoRange>(entity =>
            {
                entity.HasKey(e => e.numberRange);

                entity.ToTable("tbl_PurchaseOrderNoRange");

                entity.Property(e => e.numberRange).HasMaxLength(5);

                entity.Property(e => e.Prefix).HasMaxLength(5);
            });

            modelBuilder.Entity<TblPurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PurchaseOrderNumber);

                entity.ToTable("tbl_PurchaseOrder");

                entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(50);

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Advance).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CustPONumber).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.EditDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.SaleOrderNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(15);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.PurchaseOrderDate).HasColumnType("date");

                entity.Property(e => e.PurchaseOrderType).HasMaxLength(50);

                entity.Property(e => e.SupplierCode).HasMaxLength(50);

                entity.Property(e => e.IGST).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.UGST).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.CGST).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.SGST).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.TotalAmount).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.TotalTax).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.ProfitCenter).HasMaxLength(50);
                entity.Property(e => e.Location).HasMaxLength(50);
                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPurchaseOrderDetails>(entity =>
            {
                entity.ToTable("tbl_PurchaseOrderDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Discount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.PurchaseOrderNumber);

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.TaxCode).HasMaxLength(50); ;

                entity.Property(e => e.IGST).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.UGST).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.CGST).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.SGST).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");
                entity.Property(e => e.NetWeight).HasColumnType("numeric(18, 4)");

            });

            modelBuilder.Entity<TblPurchaseOrderNoAssignment>(entity =>
            {
                entity.HasKey(e => e.NumberRange);

                entity.ToTable("tbl_PurchaseOrderNoAssignment");

                entity.Property(e => e.NumberRange).HasMaxLength(5);

                entity.Property(e => e.CompanyCode).HasMaxLength(5);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.PurchaseOrderType).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPurchaseOrderNoAssignmentst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_PurchaseOrderNoAssignmentst");

                entity.Property(e => e.CompanyCode).HasMaxLength(5);

                entity.Property(e => e.NumberRange).HasMaxLength(5);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.PurchaseOrderType).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPurchaseOrderType>(entity =>
            {
                entity.HasKey(e => e.purchaseType);

                entity.ToTable("tbl_PurchaseOrderType");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.PrintText).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPurchasePerson>(entity =>
            {
                entity.HasKey(e => new { e.id });

                entity.ToTable("tbl_PurchasePerson");

                entity.Property(e => e.PurchasePerson).HasMaxLength(50);

                entity.Property(e => e.PurchaseGroup).HasMaxLength(10);

                entity.Property(e => e.PurchaseTypes).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPurchaseRequisitionDetails>(entity =>
            {
                entity.ToTable("tbl_PurchaseRequisitionDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EditDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.ProductionOrder).HasMaxLength(50);

                entity.Property(e => e.PurchaseGroup).HasMaxLength(50);

                entity.Property(e => e.PurchaseRequisitionNumber).HasMaxLength(20);

                entity.Property(e => e.RecommendedBy).HasMaxLength(50);

                entity.Property(e => e.RecommendedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequiredDate).HasColumnType("date");

                entity.Property(e => e.Rate).HasColumnName("Rate");

                entity.Property(e => e.ReservationNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.Qty).HasColumnName("QTY");
            });

            modelBuilder.Entity<TblPurchaseRequisitionMaster>(entity =>
            {
                entity.HasKey(e => e.RequisitionNumber);

                entity.ToTable("tbl_PurchaseRequisitionMaster");

                entity.Property(e => e.RequisitionNumber).HasMaxLength(20);

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.ApprovedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(8);

                entity.Property(e => e.Department).HasMaxLength(5);

                entity.Property(e => e.EditDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.ProjectName).HasMaxLength(50);

                entity.Property(e => e.RecomendedBy).HasMaxLength(50);

                entity.Property(e => e.RecomendedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Requiredfor).HasMaxLength(50);

                entity.Property(e => e.RequisitionDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Wbs)
                    .HasColumnName("WBS")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<TblPurchaseType>(entity =>
            {
                entity.HasKey(e => e.PurchaseType);

                entity.ToTable("tbl_PurchaseType");

                entity.Property(e => e.PurchaseType).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblQuotationAnalysis>(entity =>
            {
                entity.HasKey(e => e.QuotationNumber);

                entity.ToTable("tbl_QuotationAnalysis");

                entity.Property(e => e.QuotationNumber).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.Supplier).HasMaxLength(50);
            });

            modelBuilder.Entity<TblQuotationAnalysisDetails>(entity =>
            {
                entity.ToTable("tbl_QuotationAnalysisDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Advance).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Credit).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Delivery).HasMaxLength(50);

                entity.Property(e => e.Discount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.NetPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.QuotationNumber).HasMaxLength(50);

                entity.Property(e => e.Tax).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblQuotationNoAssignment>(entity =>
            {
                entity.HasKey(e => new { e.NumberRange, e.Company });

                entity.ToTable("tbl_QuotationNoAssignment");

                entity.Property(e => e.NumberRange).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Plant).HasMaxLength(5);
            });

            modelBuilder.Entity<TblQuotationNoRange>(entity =>
            {
                entity.HasKey(e => e.NumberRange);

                entity.ToTable("tbl_QuotationNoRange");

                entity.Property(e => e.NumberRange).HasMaxLength(5);

                entity.Property(e => e.Prefix).HasMaxLength(5);
            });

            modelBuilder.Entity<TblRegion>(entity =>
            {
                entity.HasKey(e => e.RegionCode);

                entity.ToTable("tbl_Region");

                entity.Property(e => e.RegionCode).HasMaxLength(5);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Ext)
                    .HasColumnName("ext")
                    .HasMaxLength(50);

                entity.Property(e => e.RegionName).HasMaxLength(5);

                //entity.HasOne(d => d.CountryNavigation)
                //    .WithMany(p => p.TblRegion)
                //    .HasForeignKey(d => d.Country)
                //    .HasConstraintName("FK__tbl_Regio__Count__2C401776");
            });

            modelBuilder.Entity<TblRejectionReason>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_RejectionReason");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);
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

            modelBuilder.Entity<TblReqNoAssignment>(entity =>
            {
                entity.HasKey(e => new { e.numberRange, e.Company })
                    .HasName("PK_tbl_ReqNoAssignment_1");

                entity.ToTable("tbl_ReqNoAssignment");

                entity.Property(e => e.numberRange).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Plant)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            //modelBuilder.Entity<TblRequisitionNoRange>(entity =>
            //{
            //    entity.HasKey(e => e.Code);

            //    entity.ToTable("tbl_RequisitionNoRange");

            //    entity.Property(e => e.Code).HasMaxLength(5);

            //    entity.Property(e => e.Prefix).HasMaxLength(5);
            //});

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

            modelBuilder.Entity<TblRoutingActiitiesAssignment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tbl_RoutingActiitiesAssignment");

                entity.Property(e => e.Activity).HasMaxLength(50);

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.Formula).HasMaxLength(50);

                entity.Property(e => e.RoutingKey).HasMaxLength(10);

                entity.Property(e => e.StandardValue).HasMaxLength(50);

                entity.Property(e => e.Uom)
                    .HasColumnName("UOM")
                    .HasMaxLength(50);

                entity.Property(e => e.WorkCenter).HasMaxLength(50);
            });

            modelBuilder.Entity<TblRoutingBasicData>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tbl_RoutingBasicData");

                entity.Property(e => e.Operation).HasMaxLength(50);

                entity.Property(e => e.OperationUnit).HasMaxLength(50);

                entity.Property(e => e.RoutingKey).HasMaxLength(10);

                entity.Property(e => e.SubOperation).HasMaxLength(50);

                entity.Property(e => e.WorkCenter).HasMaxLength(50);
            });

            modelBuilder.Entity<TblRoutingMasterData>(entity =>
            {
                entity.HasKey(e => e.RoutingKey);

                entity.ToTable("tbl_RoutingMasterData");

                entity.Property(e => e.RoutingKey).HasMaxLength(10);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostUnit).HasMaxLength(10);

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.SaleDocument).HasMaxLength(50);

                entity.Property(e => e.SaleOrder).HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(5);
            });

            modelBuilder.Entity<TblRoutingMaterialAssignment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tbl_RoutingMaterialAssignment");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.RoutingKey).HasMaxLength(10);

                entity.Property(e => e.Uom)
                    .HasColumnName("UOM")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblRoutingToolsEqupments>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tbl_RoutingToolsEqupments");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.RoutingKey).HasMaxLength(10);

                entity.Property(e => e.ToolsEqupment).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSalesGroup>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_SalesGroup");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSalesOffice>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_SalesOffice");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(5);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Region).HasMaxLength(5);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(5);

                entity.Property(e => e.State).HasMaxLength(5);

                //entity.HasOne(d => d.CountryNavigation)
                //    .WithMany(p => p.TblSalesOffice)
                //    .HasForeignKey(d => d.Country)
                //    .HasConstraintName("FK__tbl_Sales__Count__6A1D4E5E");

                //entity.HasOne(d => d.CurrencyNavigation)
                //    .WithMany(p => p.TblSalesOffice)
                //    .HasForeignKey(d => d.Currency)
                //    .HasConstraintName("FK__tbl_Sales__Curre__6B117297");

                //entity.HasOne(d => d.LanguageNavigation)
                //    .WithMany(p => p.TblSalesOffice)
                //    .HasForeignKey(d => d.Language)
                //    .HasConstraintName("FK__tbl_Sales__Langu__629C2827");

                //entity.HasOne(d => d.RegionNavigation)
                //    .WithMany(p => p.TblSalesOffice)
                //    .HasForeignKey(d => d.Region)
                //    .HasConstraintName("FK__tbl_Sales__Regio__69292A25");

                //entity.HasOne(d => d.StateNavigation)
                //    .WithMany(p => p.TblSalesOffice)
                //    .HasForeignKey(d => d.State)
                //    .HasConstraintName("FK__tbl_Sales__State__683505EC");
            });

            modelBuilder.Entity<TblSecondaryCostElement>(entity =>
            {
                entity.HasKey(e => e.SecondaryCostCode);

                entity.ToTable("tbl_SecondaryCostElement");

                entity.Property(e => e.SecondaryCostCode).HasMaxLength(10);

                entity.Property(e => e.ChartofAccount).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.RecordQty)
                    .HasColumnName("RecordQTY")
                    .HasMaxLength(5);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Uom).HasColumnName("UOM");
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

                entity.Property(e => e.SizeId).HasColumnName("sizeId");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(50);

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<tblQCMaster>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_QCMaster");

                entity.Property(e => e.Code).HasMaxLength(10);

            });

            modelBuilder.Entity<tblQCDetails>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ToTable("tbl_QCDetails");

                entity.Property(e => e.Uom).HasColumnName("UOM");
            });

            modelBuilder.Entity<tblQCResults>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tbl_QCResults");
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
            });

            modelBuilder.Entity<TblStockInformation>(entity =>
            {
                entity.ToTable("tbl_StockInformation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AddWho).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.EditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditWho).HasMaxLength(50);

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);

                entity.Property(e => e.InwardQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OutwardQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductCode).HasMaxLength(50);

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<TblStorageLocation>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_StorageLocation");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);
            });

            modelBuilder.Entity<TblStoreTypes>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_StoreTypes");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSubAssetMaster>(entity =>
            {
                entity.HasKey(e => e.SubAssetNumber);

                entity.ToTable("tbl_SubAssetMaster");

                entity.Property(e => e.SubAssetNumber).HasMaxLength(20);

                entity.Property(e => e.AccountKey).HasMaxLength(50);

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.DepreciationArea).HasMaxLength(50);

                entity.Property(e => e.DepreciationCode).HasMaxLength(50);

                entity.Property(e => e.DepreciationData).HasMaxLength(50);

                entity.Property(e => e.DepreciationStartDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Division).HasMaxLength(5);

                entity.Property(e => e.Location).HasMaxLength(5);

                entity.Property(e => e.MainAssetNo).HasMaxLength(15);

                entity.Property(e => e.MaterialNo).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.Room).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.Supplier).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSubAssetMasterTransaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("tbl_SubAssetMasterTransaction");

                entity.Property(e => e.DepreciationArea).HasMaxLength(50);

                entity.Property(e => e.DepreciationCode).HasMaxLength(50);

                entity.Property(e => e.DepreciationRate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DepreciationStartDate).HasColumnType("date");

                entity.Property(e => e.MainAssetNumber).HasMaxLength(15);

                entity.Property(e => e.SubAssetNumber).HasMaxLength(15);
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

            modelBuilder.Entity<TblSupplierQuotationDetails>(entity =>
            {
                entity.ToTable("tbl_SupplierQuotationDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Discount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.Rate).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.QuotationNumber).HasMaxLength(50);

                entity.Property(e => e.Tax).HasColumnType("numeric(18, 2)");
            });

            modelBuilder.Entity<TblSupplierQuotationsMaster>(entity =>
            {
                entity.HasKey(e => e.QuotationNumber);

                entity.ToTable("tbl_SupplierQuotationsMaster");

                entity.Property(e => e.QuotationNumber).HasMaxLength(50);

                entity.Property(e => e.Advance).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.DeliveryMethod).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(50);

                entity.Property(e => e.QuotationDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerCode).HasMaxLength(50);

                entity.Property(e => e.SupplierQuoteDate).HasColumnType("date");

                entity.Property(e => e.TransportMethod).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSupplierTermsAndConditons>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_SupplierTermsAndConditons");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Advance).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ContactPerson).HasMaxLength(50);

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.DeliveryMethod).HasMaxLength(50);

                entity.Property(e => e.DeliveryPeriod).HasMaxLength(5);

                entity.Property(e => e.DeliveryPlace).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            });

            modelBuilder.Entity<TblTaskMaster>(entity =>
            {
                entity.HasKey(e => e.TaskNumber);

                entity.ToTable("tbl_TaskMaster");

                entity.Property(e => e.TaskNumber).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.ImmediatePrecedessors).HasMaxLength(50);

                entity.Property(e => e.Person).HasMaxLength(50);

                entity.Property(e => e.Risk).HasMaxLength(50);

                entity.Property(e => e.SuccessorTask).HasMaxLength(50);

                entity.Property(e => e.Wbselement)
                    .HasColumnName("WBSElement")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblTaskResources>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.ToTable("tbl_TaskResources");

                entity.Property(e => e.Activity).HasMaxLength(50);

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.MaterialCode).HasMaxLength(50);

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.Rate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Resource).HasMaxLength(50);

                entity.Property(e => e.TaskNumber).HasMaxLength(10);
            });

            modelBuilder.Entity<TblTaxRates>(entity =>
            {
                entity.HasKey(e => e.TaxRateCode);

                entity.ToTable("tbl_TaxRates");

                entity.Property(e => e.TaxRateCode).HasMaxLength(5);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CompositeCess).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EffectiveFrom).HasColumnType("date");

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TaxCondition).HasMaxLength(50);

                entity.Property(e => e.TaxTransaction).HasMaxLength(5);

                entity.Property(e => e.TaxType).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TblTaxtransactions>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_Taxtransactions");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.TaxType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblTaxtypes>(entity =>
            {
                entity.HasKey(e => e.TaxKey);

                entity.ToTable("tbl_Taxtypes");

                entity.Property(e => e.TaxKey).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Nature).HasMaxLength(50);
            });

            modelBuilder.Entity<TblTdsRates>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_TdsRates");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Desctiption).HasMaxLength(50);

                entity.Property(e => e.EffectiveFrom).HasColumnType("date");

                entity.Property(e => e.IncomeType).HasMaxLength(5);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Tdstype)
                    .HasColumnName("TDSType")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<TblInvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.InvoiceDetailId)
                    .HasName("PK__tbl_InvoiceDetail");

                entity.ToTable("tbl_InvoiceDetail");

                entity.Property(e => e.InvoiceDetailId)
                    .HasColumnName("invoiceDetailId");

                entity.Property(e => e.AvailStock)
                    .HasColumnName("availStock");

                entity.Property(e => e.Cgst)
                    .HasColumnName("cgst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId");

                entity.Property(e => e.FQty)
                    .HasColumnName("fQty");

                entity.Property(e => e.GrossAmount)
                    .HasColumnName("grossAmount")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HsnNo)
                    .HasColumnName("hsnNo");

                entity.Property(e => e.Igst)
                    .HasColumnName("igst")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoiceDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InvoiceMasterId)
                    .HasColumnName("invoiceMasterId");

                entity.Property(e => e.InvoiceNo)
                    .HasColumnName("invoiceNo")
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .IsUnicode(false);

                entity.Property(e => e.ProductGroupCode)
                    .HasColumnName("productGroupCode");

                entity.Property(e => e.ProductGroupId)
                    .HasColumnName("productGroupId");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId");

                entity.Property(e => e.ProductName)
                    .HasColumnName("productName")
                    .IsUnicode(false);


                entity.Property(e => e.Qty)
                    .HasColumnName("qty");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate");

                entity.Property(e => e.ServerDateTime)
                    .HasColumnName("serverDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sgst)
                    .HasColumnName("sgst");

                entity.Property(e => e.ShiftId)
                    .HasColumnName("shiftId");

                entity.Property(e => e.SlipNo)
                    .HasColumnName("slipNo");

                entity.Property(e => e.StateCode)
                    .HasMaxLength(20);

                entity.Property(e => e.TaxGroupCode)
                    .HasColumnName("taxGroupCode")
                    .IsUnicode(false);

                entity.Property(e => e.TaxGroupId)
                    .HasColumnName("taxGroupId");

                entity.Property(e => e.TaxGroupName)
                    .HasColumnName("taxGroupName")
                    .IsUnicode(false);

                entity.Property(e => e.TaxStructureCode)
                    .HasColumnName("taxStructureCode");

                entity.Property(e => e.TaxStructureId)
                    .HasColumnName("taxStructureId");

                entity.Property(e => e.TotalGst)
                    .HasColumnName("totalGST")
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userId");

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
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AccountBalance)
                    .HasColumnName("accountBalance")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.AmountInWords).HasMaxLength(250);

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(80);

                entity.Property(e => e.Profitcenter)
                    .HasColumnName("Profitcenter")
                    .HasMaxLength(250);

                entity.Property(e => e.CustomerGstin)
                    .HasColumnName("customerGSTIN")
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customerName")
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId");

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
                    .HasColumnName("ledgerId");

                entity.Property(e => e.LedgerName)
                    .HasColumnName("ledgerName")
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderNo).IsUnicode(false);

                entity.Property(e => e.MemberCode)
                    .HasColumnName("memberCode");

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
                    .HasColumnName("paymentMode");

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
                    .HasColumnName("shiftId");

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
                    .HasColumnName("userId");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId)
                    .HasColumnName("vehicleId");

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

            modelBuilder.Entity<TblTdstypes>(entity =>
            {
                entity.HasKey(e => e.TdsCode);

                entity.ToTable("tbl_Tdstypes");

                entity.Property(e => e.TdsCode).HasMaxLength(5);

                entity.Property(e => e.Desctiption).HasMaxLength(50);

                entity.Property(e => e.Ext)
                    .HasColumnName("ext")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1)
                    .HasColumnName("ext1")
                    .HasMaxLength(50);
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

            modelBuilder.Entity<TblTransactions>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Tbl_Transactions");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<TblUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .HasName("PK__tbl_Unit__55D792354242D080");

                entity.ToTable("tbl_Unit");

                entity.Property(e => e.UnitId)
                    .HasColumnName("unitId")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(50);

                entity.Property(e => e.NoOfDecimalplaces).HasColumnName("noOfDecimalplaces");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .HasMaxLength(50);
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

            modelBuilder.Entity<TblVoucherSeries>(entity =>
            {
                entity.HasKey(e => e.VoucherSeriesKey);

                entity.ToTable("tbl_VoucherSeries");

                entity.Property(e => e.VoucherSeriesKey).HasMaxLength(5);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.FromInterval).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.Prefix).HasMaxLength(50);

                entity.Property(e => e.Suffix).HasMaxLength(50);

                entity.Property(e => e.ToInterval).HasMaxLength(50);

                entity.Property(e => e.Year).HasMaxLength(5);
            });

            modelBuilder.Entity<TblVoucherType>(entity =>
            {
                entity.HasKey(e => e.VoucherTypeId)
                    .HasName("PK__tbl_Vouc__96246DEA68687968");

                entity.ToTable("tbl_VoucherType");

                entity.Property(e => e.VoucherTypeId)
                    .HasColumnName("VoucherTypeID")
                    .HasMaxLength(5);

                entity.Property(e => e.voucherClass).HasMaxLength(50);

                entity.Property(e => e.accountType).HasMaxLength(50);

                entity.Property(e => e.printText).HasMaxLength(50);

                entity.Property(e => e.VoucherTypeName)
                    .HasColumnName("voucherTypeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Voucherclass>(entity =>
            {
                entity.HasKey(e => e.VoucherKey)
                    .HasName("PK__tbl_VoucherTypes");

                entity.ToTable("Voucherclass");

                entity.Property(e => e.VoucherKey).HasMaxLength(5);

                entity.Property(e => e.VoucherNature).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(5);

                entity.Property(e => e.Active).HasMaxLength(1);
                entity.Property(e => e.AddDate).HasColumnType("date");
            });

            modelBuilder.Entity<TblWbs>(entity =>
            {
                entity.HasKey(e => e.Wbscode);

                entity.ToTable("tbl_WBS");

                entity.Property(e => e.Wbscode)
                    .HasColumnName("WBSCode")
                    .HasMaxLength(10);

                entity.Property(e => e.AdditionalInformation).HasMaxLength(50);

                entity.Property(e => e.Approvals).HasMaxLength(50);

                entity.Property(e => e.CostUnit).HasMaxLength(50);

                entity.Property(e => e.Deliverables).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.MileStones).HasMaxLength(50);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(50);

                entity.Property(e => e.Risk).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UnderWbs)
                    .HasColumnName("UnderWBS")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblWorkCenterCapacity>(entity =>
            {
                entity.HasKey(e => e.WorkCenterCode);
                entity.ToTable("tbl_WorkCenterCapacity");

                entity.Property(e => e.BreakTime).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Capacity).HasMaxLength(50);

                entity.Property(e => e.NetHours).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Resource).HasMaxLength(50);

                entity.Property(e => e.TotalCapacity).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.WorkCenterCode).HasMaxLength(10);

                entity.Property(e => e.WorkingHours).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<TblWorkcenterActivity>(entity =>
            {
                entity.HasKey(e => e.WorkcenterCode);
                entity.ToTable("tbl_WorkcenterActivity");

                entity.Property(e => e.Activity).HasMaxLength(50);

                entity.Property(e => e.CostCenter).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Formula).HasMaxLength(50);

                entity.Property(e => e.Uom).HasColumnName("UOM");

                entity.Property(e => e.WorkcenterCode).HasMaxLength(10);
            });

            modelBuilder.Entity<TblWorkcenterMaster>(entity =>
            {
                entity.HasKey(e => e.WorkcenterCode);

                entity.ToTable("tbl_WorkcenterMaster");

                entity.Property(e => e.WorkcenterCode).HasMaxLength(10);

                entity.Property(e => e.AutopostingGoods).HasMaxLength(5);

                entity.Property(e => e.CapacityReqirement).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostDerivation).HasMaxLength(5);

                entity.Property(e => e.GoodsReceiptPosting).HasMaxLength(5);

                entity.Property(e => e.LeadTime).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.MoveTime).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Person).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.QualityInspection).HasMaxLength(5);

                entity.Property(e => e.QueueTime).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.RunTimeforEachUnit).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Scheduling).HasMaxLength(5);

                entity.Property(e => e.SetupTime).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Usage).HasMaxLength(50);

                entity.Property(e => e.WaitTime).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.WorkcenterType).HasMaxLength(50);
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
            modelBuilder.Entity<LeaveTypes>(entity =>
            {
                entity.HasKey(e => e.LeaveCode);
                entity.Property(e => e.CompanyCode).HasMaxLength(40);

                entity.Property(e => e.LeaveCode).HasMaxLength(40);

                entity.Property(e => e.LeaveMaxLimit).HasMaxLength(40);

                entity.Property(e => e.LeaveMinLimit).HasMaxLength(40);

                entity.Property(e => e.LeaveName).HasMaxLength(40);
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

            modelBuilder.Entity<StructureCreation>(entity =>
            {
                entity.HasKey(e => new { e.StructureCode });

                entity.Property(e => e.StructureName).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.Active).HasMaxLength(50);

            });

            modelBuilder.Entity<Ptmaster>(entity =>
            {
                entity.HasKey(e => e.Ptslab);
                entity.ToTable("PTMaster");

                entity.HasKey(e => e.Id);
                entity.ToTable("PTMaster");

                entity.Property(e => e.Id).HasColumnName("id");

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
            modelBuilder.Entity<Pfmaster>(entity =>
            {
                entity.HasKey(e => e.Id);
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

                entity.Property(e => e.PfType)
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

                entity.Property(e => e.PfName)
                    .HasColumnName("PFName")
                    .HasMaxLength(50);
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
            modelBuilder.Entity<PermissionRequest>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedId)
                    .HasColumnName("ApprovedID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FromTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fromdate).HasColumnType("datetime");

                entity.Property(e => e.PermissionDate).HasColumnType("date");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RejectReason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RejectedId)
                    .HasColumnName("RejectedID")
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

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Todate).HasColumnType("datetime");
            });
            modelBuilder.Entity<VehicleRequisition>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_VehicleRequisition_1");

                entity.Property(e => e.AccDate)
                    .HasColumnName("Acc_date")
                    .HasColumnType("date");

                entity.Property(e => e.AccptedId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApplDate)
                    .HasColumnName("Appl_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprDate)
                    .HasColumnName("appr_date")
                    .HasColumnType("date");

                entity.Property(e => e.ApproveName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedId)
                    .HasColumnName("ApprovedID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Approvedby)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyGroupCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CompanyGroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPersonNo).HasMaxLength(12);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasColumnName("Emp_Code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.FromTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Purpose)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RecDate)
                    .HasColumnName("rec_date")
                    .HasColumnType("date");

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

                entity.Property(e => e.ReportingTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReprtingAddress).HasMaxLength(50);

                entity.Property(e => e.Skip)
                    .HasColumnName("skip")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp).HasColumnType("date");

                entity.Property(e => e.Todate).HasColumnType("date");

                entity.Property(e => e.Totime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<TblSaleOrderDetail>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.SaleOrderNo)
                .HasMaxLength(50);

                entity.Property(e => e.QTY);

                entity.Property(e => e.Rate);

                entity.Property(e => e.MaterialCode);

                entity.Property(e => e.Discount);

                entity.Property(e => e.Total);

                entity.Property(e => e.DeliveryDate);

                entity.Property(e => e.NetWeight);

            });

            modelBuilder.Entity<TblSaleOrderMaster>(entity =>
            {
                entity.HasKey(e => e.SaleOrderNo);

                entity.Property(e => e.CustomerCode)
                .HasMaxLength(50).IsUnicode(false);

                entity.Property(e => e.OrderDate);

                entity.Property(e => e.PONumber)
                    .HasMaxLength(50).IsUnicode(false);

                entity.Property(e => e.PODate);

                entity.Property(e => e.DateofSupply);

                entity.Property(e => e.PlaceofSupply)
                    .HasMaxLength(50).IsUnicode(false);

                entity.Property(e => e.DocumentURL)
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .HasMaxLength(50);
                entity.Property(e => e.TotalTax);
                entity.Property(e => e.IGST);
                entity.Property(e => e.UGST);
                entity.Property(e => e.CGST);
                entity.Property(e => e.SGST);
                entity.Property(e => e.TotalAmount);
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.CreatedBy);
                entity.Property(e => e.ProfitCenter);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
