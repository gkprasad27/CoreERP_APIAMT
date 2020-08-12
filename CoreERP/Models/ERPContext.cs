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

        public virtual DbSet<AsignmentAcctoAccClass> AsignmentAcctoAccClass { get; set; }
        public virtual DbSet<AsignmentCashAccBranch> AsignmentCashAccBranch { get; set; }
        public virtual DbSet<CashInOutFlow1> CashInOutFlow1 { get; set; }
        public virtual DbSet<ConfigurationTable> ConfigurationTable { get; set; }
        public virtual DbSet<CostCenters> CostCenters { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<EmployeeInBranches> EmployeeInBranches { get; set; }
        public virtual DbSet<ErpConfiguration> ErpConfiguration { get; set; }
        public virtual DbSet<Erpuser> Erpuser { get; set; }
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
        public virtual DbSet<TblAccountGroup> TblAccountGroup { get; set; }
        public virtual DbSet<TblAccountLedger> TblAccountLedger { get; set; }
        public virtual DbSet<TblAccountLedgerTransactions> TblAccountLedgerTransactions { get; set; }
        public virtual DbSet<TblAlternateControlAccTrans> TblAlternateControlAccTrans { get; set; }
        public virtual DbSet<TblAssetAccountkey> TblAssetAccountkey { get; set; }
        public virtual DbSet<TblAssetBeginingAcquisition> TblAssetBeginingAcquisition { get; set; }
        public virtual DbSet<TblAssetBegningAccumulatedDepreciation> TblAssetBegningAccumulatedDepreciation { get; set; }
        public virtual DbSet<TblAssetBlock> TblAssetBlock { get; set; }
        public virtual DbSet<TblAssetClass> TblAssetClass { get; set; }
        public virtual DbSet<TblAssetDetails> TblAssetDetails { get; set; }
        public virtual DbSet<TblAssetNumberRange> TblAssetNumberRange { get; set; }
        public virtual DbSet<TblAssetTransactiontype> TblAssetTransactiontype { get; set; }
        public virtual DbSet<TblAssetTransfer> TblAssetTransfer { get; set; }
        public virtual DbSet<TblAssignAccountkeytoAsset> TblAssignAccountkeytoAsset { get; set; }
        public virtual DbSet<TblAssignAssetClasstoBlockAsset> TblAssignAssetClasstoBlockAsset { get; set; }
        public virtual DbSet<TblAssignTaxacctoTaxcode> TblAssignTaxacctoTaxcode { get; set; }
        public virtual DbSet<TblAssignchartaccttoCompanycode> TblAssignchartaccttoCompanycode { get; set; }
        public virtual DbSet<TblAssignment> TblAssignment { get; set; }
        public virtual DbSet<TblAssignmentVoucherSeriestoVoucherType> TblAssignmentVoucherSeriestoVoucherType { get; set; }
        public virtual DbSet<TblBankMaster> TblBankMaster { get; set; }
        public virtual DbSet<TblBpgroup> TblBpgroup { get; set; }
        public virtual DbSet<TblBranch> TblBranch { get; set; }
        public virtual DbSet<TblBusinessPartnerAccount> TblBusinessPartnerAccount { get; set; }
        public virtual DbSet<TblCashBankDetails> TblCashBankDetails { get; set; }
        public virtual DbSet<TblCashBankMaster> TblCashBankMaster { get; set; }
        public virtual DbSet<TblChartAccount> TblChartAccount { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblCurrency> TblCurrency { get; set; }
        public virtual DbSet<TblDepreciation> TblDepreciation { get; set; }
        public virtual DbSet<TblDepreciationAreas> TblDepreciationAreas { get; set; }
        public virtual DbSet<TblDepreciationDetails> TblDepreciationDetails { get; set; }
        public virtual DbSet<TblDesignation> TblDesignation { get; set; }
        public virtual DbSet<TblDistributionChannel> TblDistributionChannel { get; set; }
        public virtual DbSet<TblDynamicPages> TblDynamicPages { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEmployeeMaster> TblEmployeeMaster { get; set; }
        public virtual DbSet<TblFormMenuCollection> TblFormMenuCollection { get; set; }
        public virtual DbSet<TblFunctionalDepartment> TblFunctionalDepartment { get; set; }
        public virtual DbSet<TblHideTableColumns> TblHideTableColumns { get; set; }
        public virtual DbSet<TblHoliday> TblHoliday { get; set; }
        public virtual DbSet<TblHsnsac> TblHsnsac { get; set; }
        public virtual DbSet<TblIncomeTypes> TblIncomeTypes { get; set; }
        public virtual DbSet<TblJvdetails> TblJvdetails { get; set; }
        public virtual DbSet<TblJvmaster> TblJvmaster { get; set; }
        public virtual DbSet<TblLanguage> TblLanguage { get; set; }
        public virtual DbSet<TblLocation> TblLocation { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblMainAssetMaster> TblMainAssetMaster { get; set; }
        public virtual DbSet<TblMaintenancearea> TblMaintenancearea { get; set; }
        public virtual DbSet<TblMonthList> TblMonthList { get; set; }
        public virtual DbSet<TblMonthListForReports> TblMonthListForReports { get; set; }
        public virtual DbSet<TblNumberAssignment> TblNumberAssignment { get; set; }
        public virtual DbSet<TblNumberRange> TblNumberRange { get; set; }
        public virtual DbSet<TblOpenLedger> TblOpenLedger { get; set; }
        public virtual DbSet<TblPartyCashBankMaster> TblPartyCashBankMaster { get; set; }
        public virtual DbSet<TblParyCashBankDetails> TblParyCashBankDetails { get; set; }
        public virtual DbSet<TblPaymentTerms> TblPaymentTerms { get; set; }
        public virtual DbSet<TblPlant> TblPlant { get; set; }
        public virtual DbSet<TblPosaleAssetInvoiceMemoDetails> TblPosaleAssetInvoiceMemoDetails { get; set; }
        public virtual DbSet<TblPosaleAssetInvoiceMemoHeader> TblPosaleAssetInvoiceMemoHeader { get; set; }
        public virtual DbSet<TblPosting> TblPosting { get; set; }
        public virtual DbSet<TblPriceList> TblPriceList { get; set; }
        public virtual DbSet<TblPurchaseDepartment> TblPurchaseDepartment { get; set; }
        public virtual DbSet<TblRegion> TblRegion { get; set; }
        public virtual DbSet<TblRelation> TblRelation { get; set; }
        public virtual DbSet<TblReminder> TblReminder { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblRoute> TblRoute { get; set; }
        public virtual DbSet<TblSalesGroup> TblSalesGroup { get; set; }
        public virtual DbSet<TblSalesOffice> TblSalesOffice { get; set; }
        public virtual DbSet<TblSettings> TblSettings { get; set; }
        public virtual DbSet<TblShift> TblShift { get; set; }
        public virtual DbSet<TblShiftTimings> TblShiftTimings { get; set; }
        public virtual DbSet<TblSize> TblSize { get; set; }
        public virtual DbSet<TblStateWiseGst> TblStateWiseGst { get; set; }
        public virtual DbSet<TblStorageLocation> TblStorageLocation { get; set; }
        public virtual DbSet<TblSubAssetMaster> TblSubAssetMaster { get; set; }
        public virtual DbSet<TblSuffixPrefix> TblSuffixPrefix { get; set; }
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
        public virtual DbSet<TblVoucherclass> TblVoucherclass { get; set; }
        public virtual DbSet<ViewCashBank> ViewCashBank { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=183.82.48.82;Database=ERP;User Id=sa; pwd=dotnet@!@#; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                entity.HasKey(e => e.CountryCode);

                entity.Property(e => e.CountryCode).HasMaxLength(5);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Currency).HasMaxLength(5);

                entity.Property(e => e.Currency1).HasMaxLength(50);

                entity.Property(e => e.Currency2).HasMaxLength(50);

                entity.Property(e => e.DateFormat).HasMaxLength(50);

                entity.Property(e => e.DecimalFormat).HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.TimeFormat).HasMaxLength(50);

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK__Countries__Curre__22B6AD3C");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__Countries__Langu__21C28903");
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

                entity.Property(e => e.GroupType).HasMaxLength(50);

                entity.Property(e => e.NumberRangeFrom).HasMaxLength(10);

                entity.Property(e => e.NumberRangeTo).HasMaxLength(10);
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

                entity.Property(e => e.NoPostingAllowed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

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

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

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

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.ProfitCenters)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__ProfitCen__Count__570A79EA");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.ProfitCenters)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK__ProfitCen__Curre__57FE9E23");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.ProfitCenters)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__ProfitCen__Langu__34D55D77");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.ProfitCenters)
                    .HasForeignKey(d => d.Region)
                    .HasConstraintName("FK__ProfitCen__Regio__561655B1");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.ProfitCenters)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK__ProfitCen__State__55223178");
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

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.SalesDepartment)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__SalesDepa__Count__65589941");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.SalesDepartment)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK__SalesDepa__Curre__664CBD7A");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.SalesDepartment)
                    .HasForeignKey(d => d.Region)
                    .HasConstraintName("FK__SalesDepa__Regio__64647508");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.SalesDepartment)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK__SalesDepa__State__637050CF");
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

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK__States__CountryC__2E285FE8");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__States__Language__2D343BAF");
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
                entity.HasKey(e => e.LedgerTransactionId);

                entity.ToTable("tbl_AccountLedgerTransactions");

                entity.HasIndex(e => new { e.LedgerCode, e.VoucherDetailId, e.DebitAmount, e.CreditAmount })
                    .HasName("NonClusteredAccountLedgerTransCols");

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

            modelBuilder.Entity<TblAlternateControlAccTrans>(entity =>
            {
                entity.HasKey(e => e.Code);

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
                    .HasMaxLength(5);

                entity.Property(e => e.AcquisitionsGl)
                    .HasColumnName("AcquisitionsGL")
                    .HasMaxLength(5);

                entity.Property(e => e.Auggl)
                    .HasColumnName("AUGGL")
                    .HasMaxLength(5);

                entity.Property(e => e.ChartofAccount).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.DepreciationGl)
                    .HasColumnName("DepreciationGL")
                    .HasMaxLength(5);

                entity.Property(e => e.GainOnSaleGl)
                    .HasColumnName("GainOnSaleGL")
                    .HasMaxLength(5);

                entity.Property(e => e.LossOnSaleGl)
                    .HasColumnName("LossOnSaleGL")
                    .HasMaxLength(5);

                entity.Property(e => e.SalesRevenueGl)
                    .HasColumnName("SalesRevenueGL")
                    .HasMaxLength(5);

                entity.Property(e => e.ScrappingGl)
                    .HasColumnName("ScrappingGL")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<TblAssetBeginingAcquisition>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_AssetBeginingAcquisition");

                entity.Property(e => e.AcquisitionCost).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MainAssetDescription).HasMaxLength(50);

                entity.Property(e => e.MainAssetNo).HasMaxLength(50);

                entity.Property(e => e.SubAssetDescription).HasMaxLength(50);

                entity.Property(e => e.SubAssetNo).HasMaxLength(50);
            });

            modelBuilder.Entity<TblAssetBegningAccumulatedDepreciation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_AssetBegningAccumulatedDepreciation");

                entity.Property(e => e.AccumulatedDepreciation).HasMaxLength(50);

                entity.Property(e => e.DepreciationArea).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MainAssetNo).HasMaxLength(50);

                entity.Property(e => e.SubAssetNo).HasMaxLength(50);
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

                entity.Property(e => e.FromRange).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NonNumeric).HasMaxLength(5);

                entity.Property(e => e.ToRange).HasColumnType("numeric(18, 0)");
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
                entity.HasNoKey();

                entity.ToTable("tbl_AssetTransfer");

                entity.Property(e => e.AcquisitionValue).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AssetTransactionType).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MainAsset).HasMaxLength(50);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ReceiverBranch).HasMaxLength(5);

                entity.Property(e => e.ReceiverCostCenter).HasMaxLength(50);

                entity.Property(e => e.ReceiverProfitCenter).HasMaxLength(50);

                entity.Property(e => e.ReceiverSegment).HasMaxLength(50);

                entity.Property(e => e.SenderBranch).HasMaxLength(5);

                entity.Property(e => e.SenderCostCenter).HasMaxLength(50);

                entity.Property(e => e.SenderProfitCenter).HasMaxLength(50);

                entity.Property(e => e.SenderSegment).HasMaxLength(50);

                entity.Property(e => e.SubAsset).HasMaxLength(50);

                entity.Property(e => e.TransferDate).HasColumnType("date");

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNo).HasMaxLength(50);

                entity.Property(e => e.VoucherType).HasMaxLength(5);
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

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

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
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_AssignmentVoucherSeriestoVoucherType");

                entity.Property(e => e.Ext).HasMaxLength(50);

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

                entity.Property(e => e.Ext1)
                    .HasColumnName("ext1")
                    .HasMaxLength(50);
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

                entity.Property(e => e.BranchImage).HasColumnType("image");

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

                entity.HasOne(d => d.CompanyCodeNavigation)
                    .WithMany(p => p.TblBranch)
                    .HasForeignKey(d => d.CompanyCode)
                    .HasConstraintName("FK__tbl_Branc__Compa__5A06E226");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.TblBranch)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__tbl_Branc__Count__5BCF2F07");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.TblBranch)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK__tbl_Branc__Curre__5CC35340");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.TblBranch)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Branc__Regio__5ADB0ACE");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.TblBranch)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK__tbl_Branc__State__59E6E695");
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

                entity.Property(e => e.Code).HasMaxLength(5);

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

                entity.Property(e => e.Name1).HasMaxLength(50);

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

                entity.Property(e => e.Tdstate)
                    .HasColumnName("TDSTate")
                    .HasMaxLength(50);

                entity.Property(e => e.Tdstype)
                    .HasColumnName("TDSType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblCashBankDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_CashBankDetails");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Commitment).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.FunctionalDept).HasMaxLength(5);

                entity.Property(e => e.FundCenter).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Gldescription)
                    .HasColumnName("GLDescription")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsnsaccode)
                    .HasColumnName("HSNSACCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("numeric(18, 0)");

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
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxCode).HasMaxLength(5);

                entity.Property(e => e.TaxCodeDescription).HasMaxLength(50);

                entity.Property(e => e.Ugstamount)
                    .HasColumnName("UGSTAmount")
                    .HasColumnType("numeric(18, 0)");

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

                entity.Property(e => e.Accounting).HasMaxLength(10);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Indicator).HasMaxLength(10);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NatureofTransaction).HasMaxLength(20);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.ReferenceDate).HasColumnType("date");

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(5);

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

                entity.Property(e => e.HouseNo).HasMaxLength(50);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Language).HasMaxLength(5);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Panno)
                    .HasColumnName("PANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Region).HasMaxLength(5);

                entity.Property(e => e.ShortName).HasMaxLength(10);

                entity.Property(e => e.State).HasMaxLength(5);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Tanno)
                    .HasColumnName("TANNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.Property(e => e.WebSite).HasMaxLength(50);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.TblCompany)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__tbl_Compa__Count__4C8CEB77");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.TblCompany)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK__tbl_Compa__Curre__5339E906");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TblCompany)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__tbl_Compa__Langu__33E1393E");
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

                entity.Property(e => e.Rate).HasColumnName("%Rate");

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


            modelBuilder.Entity<TblDistributionChannel>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_DistributionChannel");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
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

            modelBuilder.Entity<TblFunctionalDepartment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_FunctionalDepartment");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.ResponsiblePerson).HasMaxLength(5);
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

            modelBuilder.Entity<TblJvdetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_JVDetails");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Commitment).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.FunctionalDept).HasMaxLength(5);

                entity.Property(e => e.FundCenter).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Gldescription)
                    .HasColumnName("GLDescription")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsnsac)
                    .HasColumnName("HSNSAC")
                    .HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Igstamount)
                    .HasColumnName("IGSTAmount")
                    .HasColumnType("numeric(18, 0)");

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
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxCode).HasMaxLength(5);

                entity.Property(e => e.TaxDescription).HasMaxLength(50);

                entity.Property(e => e.Ugstamount)
                    .HasColumnName("UGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherDate).HasMaxLength(50);

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.WorkBreakStructureElement).HasMaxLength(50);
            });

            modelBuilder.Entity<TblJvmaster>(entity =>
            {
                entity.ToTable("tbl_JVMaster");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ReferenceDate).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(20);

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

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

            modelBuilder.Entity<TblMainAssetMaster>(entity =>
            {
                entity.HasKey(e => e.AssetNumber);

                entity.ToTable("tbl_MainAssetMaster");

                entity.Property(e => e.AssetNumber).HasMaxLength(15);

                entity.Property(e => e.AccountKey).HasMaxLength(50);

                entity.Property(e => e.AcquisitionDate).HasColumnType("date");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.DepreciationArea).HasMaxLength(5);

                entity.Property(e => e.DepreciationCode).HasMaxLength(5);

                entity.Property(e => e.DepreciationData).HasMaxLength(50);

                entity.Property(e => e.DepreciationStartDate).HasColumnType("date");

                entity.Property(e => e.Division).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.MaterialNo).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Name1).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.ProfitCenter).HasMaxLength(5);

                entity.Property(e => e.Room).HasMaxLength(50);

                entity.Property(e => e.Segment).HasMaxLength(5);

                entity.Property(e => e.SerialNo).HasMaxLength(50);

                entity.Property(e => e.Supplier).HasMaxLength(50);
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

                entity.Property(e => e.FinancialYearEndTo).HasColumnType("date");

                entity.Property(e => e.FinancialYearStartFrom).HasColumnType("date");

                entity.Property(e => e.LedgerKey)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPartyCashBankMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_PartyCashBankMaster");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.AccountingIndicator).HasMaxLength(10);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Bpcategory)
                    .HasColumnName("BPCategory")
                    .HasMaxLength(5);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.ChequeDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ChequeNo).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

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

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblParyCashBankDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_ParyCashBankDetails");

                entity.Property(e => e.AdjustmentAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BalanceDue).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ClearedAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DiscountGl)
                    .HasColumnName("DiscountGL")
                    .HasMaxLength(50);

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.InvoiceAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MemoAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NotDue).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PartyInvoiceDate).HasColumnType("date");

                entity.Property(e => e.PartyInvoiceNo).HasMaxLength(50);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.WriteOffAmount).HasMaxLength(50);

                entity.Property(e => e.WriteOffGl)
                    .HasColumnName("WriteOffGL")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblPaymentTerms>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_tbl_PaymentTerms_1");

                entity.ToTable("tbl_PaymentTerms");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);
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

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.TblPlant)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__tbl_Plant__Count__6093E424");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.TblPlant)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK__tbl_Plant__Curre__6188085D");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TblPlant)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__tbl_Plant__Langu__5AFB065F");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.TblPlant)
                    .HasForeignKey(d => d.Region)
                    .HasConstraintName("FK__tbl_Plant__Regio__5F9FBFEB");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.TblPlant)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK__tbl_Plant__State__5EAB9BB2");
            });

            modelBuilder.Entity<TblPosaleAssetInvoiceMemoDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_POSaleAssetInvoiceMemoDetails");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Cgstamount)
                    .HasColumnName("CGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Commitment).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CostCenter).HasMaxLength(5);

                entity.Property(e => e.FunctionalDept).HasMaxLength(50);

                entity.Property(e => e.FundCenter).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.GlaccountDescription)
                    .HasColumnName("GLAccountDescription")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsnsac)
                    .HasColumnName("HSNSAC")
                    .HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

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

                entity.Property(e => e.SubAssetNo).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(5);

                entity.Property(e => e.TaxCodeDescription).HasMaxLength(50);

                entity.Property(e => e.Ugstamount)
                    .HasColumnName("UGSTAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNo).HasMaxLength(50);

                entity.Property(e => e.WorkBreakStructureElement).HasMaxLength(50);
            });

            modelBuilder.Entity<TblPosaleAssetInvoiceMemoHeader>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_POSaleAssetInvoiceMemoHeader");

                entity.Property(e => e.AccountingIndicator).HasMaxLength(50);

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.AssetTransactionType).HasMaxLength(50);

                entity.Property(e => e.Bpcategory)
                    .HasColumnName("BPCategory")
                    .HasMaxLength(5);

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Grndate)
                    .HasColumnName("GRNDate")
                    .HasColumnType("date");

                entity.Property(e => e.Grnno)
                    .HasColumnName("GRNNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.PartyAccount).HasMaxLength(50);

                entity.Property(e => e.PartyInvoiceDate).HasMaxLength(50);

                entity.Property(e => e.PartyInvoiceNo).HasMaxLength(50);

                entity.Property(e => e.PaymentItem).HasMaxLength(50);

                entity.Property(e => e.Period).HasColumnType("date");

                entity.Property(e => e.PostingDate).HasColumnType("date");

                entity.Property(e => e.ReferenceDate).HasColumnType("date");

                entity.Property(e => e.ReferenceNumber).HasMaxLength(50);

                entity.Property(e => e.TaxAmount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Term1).HasMaxLength(50);

                entity.Property(e => e.Term2).HasMaxLength(50);

                entity.Property(e => e.Term3).HasMaxLength(50);

                entity.Property(e => e.Term4).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(20);

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherDate).HasColumnType("date");

                entity.Property(e => e.VoucherNumber).HasMaxLength(50);

                entity.Property(e => e.VoucherType).HasMaxLength(5);
            });

            modelBuilder.Entity<TblPosting>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_Posting");

                entity.Property(e => e.Branch).HasMaxLength(5);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(5);

                entity.Property(e => e.Plant).HasMaxLength(5);

                entity.Property(e => e.Tdsrate)
                    .HasColumnName("TDSRate")
                    .HasMaxLength(5);

                entity.Property(e => e.Tdstype)
                    .HasColumnName("TDSType")
                    .HasMaxLength(5);
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

            modelBuilder.Entity<TblPurchaseDepartment>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_PurchaseDepartment");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext).HasMaxLength(50);
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

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.TblRegion)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__tbl_Regio__Count__2C401776");
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

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.TblSalesOffice)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK__tbl_Sales__Count__6A1D4E5E");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.TblSalesOffice)
                    .HasForeignKey(d => d.Currency)
                    .HasConstraintName("FK__tbl_Sales__Curre__6B117297");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TblSalesOffice)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK__tbl_Sales__Langu__629C2827");

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.TblSalesOffice)
                    .HasForeignKey(d => d.Region)
                    .HasConstraintName("FK__tbl_Sales__Regio__69292A25");

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.TblSalesOffice)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK__tbl_Sales__State__683505EC");
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

                entity.Property(e => e.SizeId)
                    .HasColumnName("sizeId")
                    .HasMaxLength(5);

                entity.Property(e => e.Extra1)
                    .HasColumnName("extra1")
                    .HasMaxLength(50);

                entity.Property(e => e.ExtraDate)
                    .HasColumnName("extraDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Narration)
                    .HasColumnName("narration")
                    .HasMaxLength(50);

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasMaxLength(50);
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

            modelBuilder.Entity<TblStorageLocation>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tbl_StorageLocation");

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Ext).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Plant).HasMaxLength(5);
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

                entity.Property(e => e.Code).HasMaxLength(5);

                entity.Property(e => e.Desctiption).HasMaxLength(50);

                entity.Property(e => e.EffectiveFrom).HasColumnType("date");

                entity.Property(e => e.IncomeType).HasMaxLength(5);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Tdstype)
                    .HasColumnName("TDSType")
                    .HasMaxLength(5);
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
                    .HasMaxLength(5);

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

                entity.Property(e => e.PrintText).HasMaxLength(50);

                entity.Property(e => e.VoucherClass).HasMaxLength(5);

                entity.Property(e => e.VoucherTypeName)
                    .HasColumnName("voucherTypeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblVoucherclass>(entity =>
            {
                entity.HasKey(e => e.VoucherKey)
                    .HasName("PK__tbl_VoucherTypes");

                entity.ToTable("tbl_Voucherclass");

                entity.Property(e => e.VoucherKey).HasMaxLength(5);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.VoucherNature).HasMaxLength(50);
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
