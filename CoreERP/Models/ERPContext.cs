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
        public virtual DbSet<ApprovalType> ApprovalType { get; set; }
        public virtual DbSet<AsignmentAcctoAccClass> AsignmentAcctoAccClass { get; set; }
        public virtual DbSet<AsignmentCashAccBranch> AsignmentCashAccBranch { get; set; }
        public virtual DbSet<AsnBillsRcvBranch> AsnBillsRcvBranch { get; set; }
        public virtual DbSet<AssetMaster> AssetMaster { get; set; }
        public virtual DbSet<Balances> Balances { get; set; }
        public virtual DbSet<BillingNoSeries> BillingNoSeries { get; set; }
        public virtual DbSet<BillingReturns> BillingReturns { get; set; }
        public virtual DbSet<BranchTransfer> BranchTransfer { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<BrandModel> BrandModel { get; set; }
        public virtual DbSet<CardType> CardType { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<ComponentMaster> ComponentMaster { get; set; }
        public virtual DbSet<ComponentType> ComponentType { get; set; }
        public virtual DbSet<CostCenters> CostCenters { get; set; }
        public virtual DbSet<Counters> Counters { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Ctcbreakup> Ctcbreakup { get; set; }
        public virtual DbSet<CustomerReceipts> CustomerReceipts { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Divisions> Divisions { get; set; }
        public virtual DbSet<EmployeeInBranches> EmployeeInBranches { get; set; }
        public virtual DbSet<EmployeeType> EmployeeType { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<ErpConfiguration> ErpConfiguration { get; set; }
        public virtual DbSet<Erpuser> Erpuser { get; set; }
        public virtual DbSet<Finance> Finance { get; set; }
        public virtual DbSet<GlaccGroup> GlaccGroup { get; set; }
        public virtual DbSet<GlaccSubGroup> GlaccSubGroup { get; set; }
        public virtual DbSet<GlaccUnderSubGroup> GlaccUnderSubGroup { get; set; }
        public virtual DbSet<Glaccounts> Glaccounts { get; set; }
        public virtual DbSet<GlsubCode> GlsubCode { get; set; }
        public virtual DbSet<Gst> Gst { get; set; }
        public virtual DbSet<HolidayMaster> HolidayMaster { get; set; }
        public virtual DbSet<Interpretation> Interpretation { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<ItemMaster> ItemMaster { get; set; }
        public virtual DbSet<LeaveApplDetails> LeaveApplDetails { get; set; }
        public virtual DbSet<LeaveTypes> LeaveTypes { get; set; }
        public virtual DbSet<Leaveopeningbalances> Leaveopeningbalances { get; set; }
        public virtual DbSet<MatTranTypes> MatTranTypes { get; set; }
        public virtual DbSet<MaterialGroup> MaterialGroup { get; set; }
        public virtual DbSet<MenuAccesses> MenuAccesses { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<MonthlyLeavesAvailed> MonthlyLeavesAvailed { get; set; }
        public virtual DbSet<NoAssignment> NoAssignment { get; set; }
        public virtual DbSet<NoSeries> NoSeries { get; set; }
        public virtual DbSet<PartnerCreation> PartnerCreation { get; set; }
        public virtual DbSet<PartnerDetails> PartnerDetails { get; set; }
        public virtual DbSet<PartnerType> PartnerType { get; set; }
        public virtual DbSet<PayrollCycle> PayrollCycle { get; set; }
        public virtual DbSet<PermissionRequest> PermissionRequest { get; set; }
        public virtual DbSet<Pfmaster> Pfmaster { get; set; }
        public virtual DbSet<ProfitCenters> ProfitCenters { get; set; }
        public virtual DbSet<Ptmaster> Ptmaster { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseInvoice> PurchaseInvoice { get; set; }
        public virtual DbSet<PurchaseInvoiceDetails> PurchaseInvoiceDetails { get; set; }
        public virtual DbSet<PurchaseItems> PurchaseItems { get; set; }
        public virtual DbSet<PurchaseRequisitions> PurchaseRequisitions { get; set; }
        public virtual DbSet<PurchaseReturns> PurchaseReturns { get; set; }
        public virtual DbSet<SalaryEarnDedn> SalaryEarnDedn { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesItems> SalesItems { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<ShiftTimeConfig> ShiftTimeConfig { get; set; }
        public virtual DbSet<Sizes> Sizes { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<StructureCreation> StructureCreation { get; set; }
        public virtual DbSet<TaxIntegration> TaxIntegration { get; set; }
        public virtual DbSet<TaxMasters> TaxMasters { get; set; }
        public virtual DbSet<TblCurrency> TblCurrency { get; set; }
        public virtual DbSet<TblMeterReading> TblMeterReading { get; set; }
        public virtual DbSet<TblMshsdrates> TblMshsdrates { get; set; }
        public virtual DbSet<TblOilConversionDetails> TblOilConversionDetails { get; set; }
        public virtual DbSet<TblOilConversionMaster> TblOilConversionMaster { get; set; }
        public virtual DbSet<TblOpeningBalance> TblOpeningBalance { get; set; }
        public virtual DbSet<TblOperatorStockIssues> TblOperatorStockIssues { get; set; }
        public virtual DbSet<TblOperatorStockIssuesDetail> TblOperatorStockIssuesDetail { get; set; }
        public virtual DbSet<TblOperatorStockReceipt> TblOperatorStockReceipt { get; set; }
        public virtual DbSet<TblOperatorStockReceiptDetail> TblOperatorStockReceiptDetail { get; set; }
        public virtual DbSet<TblPackageConversion> TblPackageConversion { get; set; }
        public virtual DbSet<TblProductPacking> TblProductPacking { get; set; }
        public virtual DbSet<TblUnit> TblUnit { get; set; }
        public virtual DbSet<TblVehicle> TblVehicle { get; set; }
        public virtual DbSet<TblVehicleType> TblVehicleType { get; set; }
        public virtual DbSet<TourAdvance> TourAdvance { get; set; }
        public virtual DbSet<VehicleRequisition> VehicleRequisition { get; set; }
        public virtual DbSet<VendorPayments> VendorPayments { get; set; }
        public virtual DbSet<VoucherClass> VoucherClass { get; set; }
        public virtual DbSet<VoucherProcessing> VoucherProcessing { get; set; }
        public virtual DbSet<VoucherTransaction> VoucherTransaction { get; set; }
        public virtual DbSet<VoucherTypes> VoucherTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.2.26;Database=ERP;User Id=sa; pwd=dotnet@!@#; MultipleActiveResultSets=true;");
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

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyGroupCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CompanyGroupName)
                    .HasMaxLength(100)
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

            modelBuilder.Entity<ApprovalType>(entity =>
            {
                entity.HasKey(e => e.ApprovalId);

                entity.Property(e => e.ApprovalId)
                    .HasColumnName("ApprovalID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovalScreen).HasMaxLength(50);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.RecommendedBy).HasMaxLength(50);
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

            modelBuilder.Entity<AsnBillsRcvBranch>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Asn_Bills_Rcv_Branch");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssetMaster>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Address1).HasMaxLength(40);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.Address3).HasMaxLength(40);

                entity.Property(e => e.Address4).HasMaxLength(40);

                entity.Property(e => e.AquationValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AsseetName).HasMaxLength(20);

                entity.Property(e => e.AssetNo).HasMaxLength(20);

                entity.Property(e => e.CompCode).HasMaxLength(20);

                entity.Property(e => e.DepresiationUptoDate).HasMaxLength(30);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Glcode)
                    .HasColumnName("GLCode")
                    .HasMaxLength(30);

                entity.Property(e => e.MeasureofDepresiation).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20);

                entity.Property(e => e.PinCode).HasMaxLength(6);

                entity.Property(e => e.Place).HasMaxLength(30);

                entity.Property(e => e.RateOfDeprecation).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(20);

                entity.Property(e => e.UsefulHike).HasMaxLength(30);

                entity.Property(e => e.UsefulHikemonth)
                    .HasColumnName("usefulHikemonth")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Balances>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.AccountName).HasMaxLength(200);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CrAmount).HasMaxLength(20);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DrAmount).HasMaxLength(20);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionNo).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);
            });

            modelBuilder.Entity<BillingNoSeries>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.NumberSeries).HasMaxLength(50);

                entity.Property(e => e.Year).HasMaxLength(15);
            });

            modelBuilder.Entity<BillingReturns>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.Baseamount).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BranchTransfer>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.Baseamount).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BillsReceivableAccount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAccount).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAccount).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Ext7).HasMaxLength(50);

                entity.Property(e => e.FinanceAccount).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(16);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.HasKey(e => e.BranchCode);

                entity.Property(e => e.BranchCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Address1).HasMaxLength(400);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.Address3).HasMaxLength(40);

                entity.Property(e => e.Address4).HasMaxLength(40);

                entity.Property(e => e.BankAccountNumber).HasMaxLength(30);

                entity.Property(e => e.BankBranch).HasMaxLength(30);

                entity.Property(e => e.BankName).HasMaxLength(30);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(20);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNo).HasMaxLength(20);

                entity.Property(e => e.PinCode).HasMaxLength(6);

                entity.Property(e => e.Place).HasMaxLength(30);

                entity.HasOne(d => d.CompanyCodeNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CompanyCode)
                    .HasConstraintName("FK_Branches_Companies");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BrandName).HasMaxLength(100);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustomerCare).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);
            });

            modelBuilder.Entity<BrandModel>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.ClosingStock).HasMaxLength(50);

                entity.Property(e => e.CompName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.InputTaxCode).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.MaterialGroupCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.OutputTaxCode).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.CardName).HasMaxLength(50);

                entity.Property(e => e.CardType1)
                    .HasColumnName("Card_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.CompanyCode)
                    .HasName("PK_Companies_1");

                entity.Property(e => e.CompanyCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Address1).HasMaxLength(40);

                entity.Property(e => e.Address2).HasMaxLength(40);

                entity.Property(e => e.Address3).HasMaxLength(40);

                entity.Property(e => e.Address4).HasMaxLength(40);

                entity.Property(e => e.BooksBeginFrom).HasColumnType("date");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.FinacialYear).HasMaxLength(50);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NatureOfBusiness).HasMaxLength(50);

                entity.Property(e => e.PanNo).HasMaxLength(20);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone3)
                    .HasColumnName("Phone_3")
                    .HasMaxLength(20);

                entity.Property(e => e.PinCode).HasMaxLength(6);

                entity.Property(e => e.Place).HasMaxLength(30);

                entity.Property(e => e.State).HasMaxLength(20);

                entity.Property(e => e.TanNo).HasMaxLength(20);
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

            modelBuilder.Entity<ComponentType>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ComponentType1)
                    .HasColumnName("ComponentType")
                    .HasMaxLength(50)
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

                entity.HasOne(d => d.CompCodeNavigation)
                    .WithMany(p => p.CostCenters)
                    .HasForeignKey(d => d.CompCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostCenters_Companies");
            });

            modelBuilder.Entity<Counters>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(200);

                entity.Property(e => e.Ext4).HasMaxLength(200);

                entity.Property(e => e.Prefix).HasMaxLength(20);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

            modelBuilder.Entity<CustomerReceipts>(entity =>
            {
                entity.HasKey(e => e.SeqId);

                entity.Property(e => e.SeqId).HasColumnName("SeqID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.AdjAmount).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CheckDate).HasDefaultValueSql("('0001-01-01T00:00:00.000')");

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CreditAcc).HasMaxLength(50);

                entity.Property(e => e.DebitAcc).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.ItemReference).HasMaxLength(50);

                entity.Property(e => e.PartyNo).HasMaxLength(50);

                entity.Property(e => e.ReceiptFrom).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.CompanyGroupCode).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasMaxLength(50);

                entity.Property(e => e.DepartmentName).HasMaxLength(50);

                entity.Property(e => e.ResponsiblePersonCode).HasMaxLength(50);

                entity.Property(e => e.ResponsiblePersonDesc).HasMaxLength(50);
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.DesigCode);

                entity.Property(e => e.DesigCode)
                    .HasColumnName("Desig_Code")
                    .HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.CompanyGroupCode).HasMaxLength(50);

                entity.Property(e => e.DesigName)
                    .HasColumnName("Desig_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.DesigShortName)
                    .HasColumnName("Desig_Short_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Formno)
                    .HasColumnName("formno")
                    .HasMaxLength(50);

                entity.Property(e => e.GradeCode)
                    .HasColumnName("Grade_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasMaxLength(50);

                entity.Property(e => e.Trmno)
                    .HasColumnName("trmno")
                    .HasMaxLength(50);

                entity.Property(e => e.Usrid)
                    .HasColumnName("usrid")
                    .HasMaxLength(50);
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

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.CompanyGroupCode).HasMaxLength(50);

                entity.Property(e => e.EmployeeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Aadhar).HasMaxLength(50);

                entity.Property(e => e.AccessCard).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.BankAccNo).HasMaxLength(50);

                entity.Property(e => e.BankBranch).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(100);

                entity.Property(e => e.BolldGroup).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Designation).HasMaxLength(20);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasMaxLength(20);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Esinumber)
                    .HasColumnName("ESINumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.FatherName).HasMaxLength(50);

                entity.Property(e => e.Ifsccode)
                    .HasColumnName("IFSCCode")
                    .HasMaxLength(20);

                entity.Property(e => e.JoinDate).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Pan).HasMaxLength(50);

                entity.Property(e => e.Pfnumber)
                    .HasColumnName("PFNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone1)
                    .HasColumnName("Phone_1")
                    .HasMaxLength(20);

                entity.Property(e => e.Phone2)
                    .HasColumnName("Phone_2")
                    .HasMaxLength(20);

                entity.Property(e => e.RecommendedBy).HasMaxLength(50);

                entity.Property(e => e.RelDate).HasMaxLength(50);

                entity.Property(e => e.ReportingTo).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Shift).HasMaxLength(20);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Uannumber)
                    .HasColumnName("UANNumber")
                    .HasMaxLength(50);
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

            modelBuilder.Entity<Finance>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.AssetCategory).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.DbdexcludeGst)
                    .HasColumnName("DBDExcludeGST")
                    .HasMaxLength(50);

                entity.Property(e => e.DbdincGst)
                    .HasColumnName("DBDIncGST")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DownPayment).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Facilitation).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.FinancerName).HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Insurance).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.LoanAmt).HasMaxLength(50);

                entity.Property(e => e.LoanNo).HasMaxLength(50);

                entity.Property(e => e.MarginAmt).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.NoOfAdvEmi)
                    .HasColumnName("NoOfAdvEMI")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.ProcessFee).HasMaxLength(50);

                entity.Property(e => e.ProductType).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Roi)
                    .HasColumnName("ROI")
                    .HasMaxLength(16);

                entity.Property(e => e.SchemeName).HasMaxLength(50);

                entity.Property(e => e.SerialNumber).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.Tenure).HasMaxLength(50);
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

            modelBuilder.Entity<GlaccSubGroup>(entity =>
            {
                entity.HasKey(e => e.SubGroupCode);

                entity.ToTable("GLAccSubGroup");

                entity.Property(e => e.SubGroupCode).HasMaxLength(20);

                entity.Property(e => e.AccGroup).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.SubGroupName).HasMaxLength(50);

                entity.Property(e => e.UnderSubGroupCode).HasMaxLength(20);
            });

            modelBuilder.Entity<GlaccUnderSubGroup>(entity =>
            {
                entity.HasKey(e => e.UnderSubGroupCode);

                entity.ToTable("GLAccUnderSubGroup");

                entity.Property(e => e.UnderSubGroupCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.SubGroupName).HasMaxLength(50);

                entity.Property(e => e.UnderSubGroupName).HasMaxLength(50);
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

            modelBuilder.Entity<GlsubCode>(entity =>
            {
                entity.HasKey(e => e.SubCode);

                entity.ToTable("GLSubCode");

                entity.Property(e => e.SubCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(30);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Glcode)
                    .HasColumnName("GLCode")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Gst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GST");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompName).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.StateCode).HasMaxLength(50);

                entity.Property(e => e.StateName).HasMaxLength(50);
            });

            modelBuilder.Entity<HolidayMaster>(entity =>
            {
                entity.HasKey(e => e.Date);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.Divisions).HasMaxLength(50);

                entity.Property(e => e.Holiday).HasMaxLength(50);

                entity.Property(e => e.Holidaytype).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.ProfitCenterCode).HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(50);

                entity.Property(e => e.TimeStamp).HasMaxLength(50);

                entity.Property(e => e.Userid).HasMaxLength(50);

                entity.Property(e => e.Year).HasMaxLength(50);
            });

            modelBuilder.Entity<Interpretation>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(30);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.DiscountReceivedAc).HasMaxLength(50);

                entity.Property(e => e.DiscountallowAc).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(20);

                entity.Property(e => e.Ext4).HasMaxLength(20);

                entity.Property(e => e.FrightAc).HasMaxLength(50);

                entity.Property(e => e.InstallationChargesAc).HasMaxLength(50);

                entity.Property(e => e.OtherExpensesAc).HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(14);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.Drcrindicator)
                    .HasColumnName("DRCRIndicator")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(50);

                entity.Property(e => e.PurchaseValue).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.ReceivingUnit).HasMaxLength(50);

                entity.Property(e => e.ReferenceNo).HasMaxLength(50);

                entity.Property(e => e.SaleValue).HasMaxLength(50);

                entity.Property(e => e.SendingUnit).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.SubGlacc)
                    .HasColumnName("SubGLAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.Property(e => e.Uom)
                    .HasColumnName("UOM")
                    .HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceNo);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.Baseamount).HasMaxLength(50);

                entity.Property(e => e.BillsReceivableAccount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAccount).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAccount).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CheckAmount).HasMaxLength(50);

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.Code).ValueGeneratedOnAdd();

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.Dbdamount)
                    .HasColumnName("DBDAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext10).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Ext7).HasMaxLength(50);

                entity.Property(e => e.Ext8).HasMaxLength(50);

                entity.Property(e => e.Ext9).HasMaxLength(50);

                entity.Property(e => e.FinanceAccount).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PayTm)
                    .HasColumnName("PayTM")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.PhonePay).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(16);

                entity.Property(e => e.Rtgsamount)
                    .HasColumnName("RTGSAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.Rtgsid)
                    .HasColumnName("RTGSID")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Address3).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.Baseamount).HasMaxLength(50);

                entity.Property(e => e.BillsReceivableAccount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAccount).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAccount).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CheckAmount).HasMaxLength(50);

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.Dbdamount)
                    .HasColumnName("DBDAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext10).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Ext7).HasMaxLength(50);

                entity.Property(e => e.Ext8).HasMaxLength(50);

                entity.Property(e => e.Ext9).HasMaxLength(50);

                entity.Property(e => e.FinanceAccount).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Gstin)
                    .HasColumnName("GSTIN")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PayTm)
                    .HasColumnName("PayTM")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.PhonePay).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(16);

                entity.Property(e => e.Rtgsamount)
                    .HasColumnName("RTGSAmount")
                    .HasMaxLength(50);

                entity.Property(e => e.Rtgsid)
                    .HasColumnName("RTGSID")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ItemMaster>(entity =>
            {
                entity.HasKey(e => e.ItemNumber);

                entity.Property(e => e.ItemNumber).HasMaxLength(20);

                entity.Property(e => e.AccClass).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Brand).HasMaxLength(100);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(200);

                entity.Property(e => e.Ext2).HasMaxLength(200);

                entity.Property(e => e.Ext3).HasMaxLength(200);

                entity.Property(e => e.Ext4).HasMaxLength(200);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.InputTaxCode).HasMaxLength(50);

                entity.Property(e => e.InventoryAccount).HasMaxLength(50);

                entity.Property(e => e.ItemGroup).HasMaxLength(100);

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.MaxQty)
                    .HasColumnName("MaxQTY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MinQty)
                    .HasColumnName("MinQTY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.Mrpprice)
                    .HasColumnName("MRPPrice")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.OutputTaxCode).HasMaxLength(50);

                entity.Property(e => e.PackingCode).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.ReOrdQty)
                    .HasColumnName("ReOrdQTY")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RetailPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalePrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesAccount).HasMaxLength(50);

                entity.Property(e => e.Size).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.WholePrice).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<LeaveApplDetails>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK_Leave_Appl_Details_1");

                entity.ToTable("Leave_Appl_Details");

                entity.Property(e => e.AcceptedRemarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ApplDate)
                    .HasColumnName("Appl_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovedDate).HasColumnType("datetime");

                entity.Property(e => e.ApprovedId)
                    .HasColumnName("ApprovedID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasColumnName("Emp_Code")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.EmpName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ext1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.LeaveCode)
                    .HasColumnName("Leave_Code")
                    .HasMaxLength(4)
                    .IsFixedLength();

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

                entity.Property(e => e.Reason)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedId)
                    .HasColumnName("RecommendedID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LeaveTypes>(entity =>
            {
                entity.HasKey(e => e.LeaveCode);

                entity.Property(e => e.LeaveCode).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyCode).HasMaxLength(20);

                entity.Property(e => e.CompanyName).HasMaxLength(40);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LeaveMaxLimit).HasMaxLength(40);

                entity.Property(e => e.LeaveName).HasMaxLength(40);
            });

            modelBuilder.Entity<Leaveopeningbalances>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Cl).HasColumnName("CL");

                entity.Property(e => e.Clopbalance).HasColumnName("CLOPBalance");

                entity.Property(e => e.ComOffOpbalance).HasColumnName("ComOffOPBalance");

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.El).HasColumnName("EL");

                entity.Property(e => e.Elopbalance).HasColumnName("ELOPBalance");

                entity.Property(e => e.LeaveType).HasMaxLength(50);

                entity.Property(e => e.Lp).HasColumnName("LP");

                entity.Property(e => e.Lpopbalance).HasColumnName("LPOPBalance");

                entity.Property(e => e.Ml).HasColumnName("ML");

                entity.Property(e => e.Mlopbalance).HasColumnName("MLOPBalance");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Pl).HasColumnName("PL");

                entity.Property(e => e.Plopbalance).HasColumnName("PLOPBalance");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Slopbalance).HasColumnName("SLOPBalance");

                entity.Property(e => e.Year).HasMaxLength(50);
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

            modelBuilder.Entity<MaterialGroup>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.AccClass).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustomerCare).HasMaxLength(100);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.HsnCode).HasMaxLength(20);
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

                entity.Property(e => e.Ext3).HasMaxLength(200);

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnName("RoleID")
                    .HasMaxLength(200);
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

            modelBuilder.Entity<MonthlyLeavesAvailed>(entity =>
            {
                entity.ToTable("Monthly_Leaves_Availed");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cl).HasColumnName("CL");

                entity.Property(e => e.ClsCl).HasColumnName("CLS_CL");

                entity.Property(e => e.ClsEl).HasColumnName("CLS_EL");

                entity.Property(e => e.ClsR).HasColumnName("CLS_R");

                entity.Property(e => e.ClsSl).HasColumnName("CLS_SL");

                entity.Property(e => e.Co).HasColumnName("CO");

                entity.Property(e => e.CompanyCode).HasMaxLength(8);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.El).HasColumnName("EL");

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasColumnName("Emp_Code")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpGrp)
                    .HasColumnName("Emp_Grp")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeGroupId).HasMaxLength(5);

                entity.Property(e => e.EmployeeGroupName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Lop).HasColumnName("LOP");

                entity.Property(e => e.LopMonth)
                    .IsRequired()
                    .HasColumnName("Lop_Month")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LopYear)
                    .IsRequired()
                    .HasColumnName("Lop_Year")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MonthYear)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OpnCl).HasColumnName("OPN_CL");

                entity.Property(e => e.OpnEl).HasColumnName("OPN_EL");

                entity.Property(e => e.OpnR).HasColumnName("OPN_R");

                entity.Property(e => e.OpnSl).HasColumnName("OPN_SL");

                entity.Property(e => e.Ot4hrs).HasColumnName("OT4hrs");

                entity.Property(e => e.Ot8hrs).HasColumnName("OT8Hrs");

                entity.Property(e => e.Othrs).HasColumnName("OTHrs");

                entity.Property(e => e.PaidDays).HasColumnName("Paid_Days");

                entity.Property(e => e.Ph).HasColumnName("PH");

                entity.Property(e => e.ProfitCenterCode).HasMaxLength(5);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Ssl).HasColumnName("SSL");

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("TIME_STAMP")
                    .HasColumnType("datetime");

                entity.Property(e => e.Upload)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usrid)
                    .HasColumnName("USRID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Vtc).HasColumnName("VTC");

                entity.Property(e => e.Wo).HasColumnName("WO");
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

            modelBuilder.Entity<PartnerDetails>(entity =>
            {
                entity.HasKey(e => e.PartnerCode);

                entity.Property(e => e.PartnerCode).HasMaxLength(50);

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Avtive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.FatherOrhusbandName)
                    .HasColumnName("FatherORHusbandName")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GovtIdcardType)
                    .HasColumnName("GovtIDCardType")
                    .HasMaxLength(50);

                entity.Property(e => e.IdcareNumber)
                    .HasColumnName("IDCareNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Nominee).HasMaxLength(50);

                entity.Property(e => e.Occupation).HasMaxLength(50);

                entity.Property(e => e.PartnerName).HasMaxLength(100);

                entity.Property(e => e.Passbook).HasMaxLength(50);

                entity.Property(e => e.PassbookStatus).HasMaxLength(50);

                entity.Property(e => e.Relation).HasMaxLength(50);
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
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyGroupCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CompanyGroupName)
                    .HasMaxLength(100)
                    .IsFixedLength();

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

                entity.Property(e => e.PermissionDate).HasColumnType("date");

                entity.Property(e => e.PermissionType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

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

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustGstno)
                    .HasColumnName("CustGSTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryNoteNo).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Freight).HasMaxLength(50);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(20);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.SalePrice).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorCode).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseInvoice>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustGstno)
                    .HasColumnName("CustGSTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryNoteNo).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Freight).HasMaxLength(50);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(20);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.SalePrice).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorCode).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseInvoiceDetails>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Adjusted).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.ChequeNo).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.PaymentAmount).HasMaxLength(50);

                entity.Property(e => e.PaymentReference).HasMaxLength(50);

                entity.Property(e => e.VendorAccount).HasMaxLength(50);

                entity.Property(e => e.VoucherNo).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseItems>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Adjusted).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.ChequeNo).HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.PaymentAmount).HasMaxLength(50);

                entity.Property(e => e.PaymentReference).HasMaxLength(50);

                entity.Property(e => e.VendorAccount).HasMaxLength(50);

                entity.Property(e => e.VoucherNo).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseRequisitions>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_PurchaseRequisition");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.ApprovedBy).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(50);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustGstno)
                    .HasColumnName("CustGSTNO")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryNoteNo).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Freight).HasMaxLength(50);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(20);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.RecommendedBy).HasMaxLength(50);

                entity.Property(e => e.SalePrice).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorCode).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(50);
            });

            modelBuilder.Entity<PurchaseReturns>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(20);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.DeliveryNoteNo).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Freight).HasMaxLength(50);

                entity.Property(e => e.GoodsReceiptNo).HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceAmount).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(20);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.ModelCode).HasMaxLength(50);

                entity.Property(e => e.ModelName).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.OtherExpences).HasMaxLength(20);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.PurchaseAccount).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rate).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorCode).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(50);
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

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(20);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SalesItems>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BillNo).HasMaxLength(50);

                entity.Property(e => e.BillsReceivableAccount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(20);

                entity.Property(e => e.BrandCode).HasMaxLength(50);

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.CardAccount).HasMaxLength(50);

                entity.Property(e => e.CardAmount).HasMaxLength(50);

                entity.Property(e => e.CardType).HasMaxLength(50);

                entity.Property(e => e.CashAccount).HasMaxLength(50);

                entity.Property(e => e.CashAmount).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.CgstaccNumber)
                    .HasColumnName("CGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgsttax)
                    .HasColumnName("CGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.CompCode).HasMaxLength(20);

                entity.Property(e => e.CompGstno)
                    .HasColumnName("CompGSTNo")
                    .HasMaxLength(50);

                entity.Property(e => e.CustName).HasMaxLength(50);

                entity.Property(e => e.DaNumber).HasMaxLength(50);

                entity.Property(e => e.DeliveryBranch).HasMaxLength(50);

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Exchange).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.Ext3).HasMaxLength(50);

                entity.Property(e => e.Ext4).HasMaxLength(50);

                entity.Property(e => e.Ext5).HasMaxLength(50);

                entity.Property(e => e.Ext6).HasMaxLength(50);

                entity.Property(e => e.Ext7).HasMaxLength(50);

                entity.Property(e => e.Ext8).HasMaxLength(50);

                entity.Property(e => e.FinanceAccount).HasMaxLength(50);

                entity.Property(e => e.FinanceAmount).HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.IgstaccNumber)
                    .HasColumnName("IGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Igsttax)
                    .HasColumnName("IGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Influaction).HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasMaxLength(50);

                entity.Property(e => e.ItemName).HasMaxLength(50);

                entity.Property(e => e.MaterialTranType).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModeofSale).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.NetAmount).HasMaxLength(50);

                entity.Property(e => e.NetAmtReceived).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationCode).HasMaxLength(50);

                entity.Property(e => e.PartnerCreationGlaccount)
                    .HasColumnName("PartnerCreationGLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone2).HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(50);

                entity.Property(e => e.Place).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.Rtgs)
                    .HasColumnName("RTGS")
                    .HasMaxLength(16);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.SgstaccNumber)
                    .HasColumnName("SGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgsttax)
                    .HasColumnName("SGSTTax")
                    .HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.TaxBaseAmount).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.UgstaccNumber)
                    .HasColumnName("UGSTAccNumber")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugsttax)
                    .HasColumnName("UGSTTax")
                    .HasMaxLength(50);
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

            modelBuilder.Entity<ShiftTimeConfig>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CompanyCode).HasMaxLength(50);

                entity.Property(e => e.CompanyDesc).HasMaxLength(50);

                entity.Property(e => e.DivCode).HasMaxLength(50);

                entity.Property(e => e.DivisionName).HasMaxLength(50);

                entity.Property(e => e.FirstInTime).HasMaxLength(50);

                entity.Property(e => e.FirstOutTime).HasMaxLength(50);

                entity.Property(e => e.InGracePeriod).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Userid).HasMaxLength(50);
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

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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
            });

            modelBuilder.Entity<StructureCreation>(entity =>
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

            modelBuilder.Entity<TblCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyId)
                    .HasName("PK__tbl_Curr__DAF0B20A592635D8");

                entity.ToTable("tbl_Currency");

                entity.Property(e => e.CurrencyId)
                    .HasColumnName("currencyId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

            modelBuilder.Entity<TblMeterReading>(entity =>
            {
                entity.HasKey(e => e.MeterReadingId);

                entity.ToTable("tbl_MeterReading");

                entity.Property(e => e.MeterReadingId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

            modelBuilder.Entity<TblMshsdrates>(entity =>
            {
                entity.ToTable("tbl_MSHSDRates");

                entity.Property(e => e.ID)
                    .HasColumnName("iD")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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
                    .HasName("PK__tbl_Open__5E1AFE19C20A28DF");

                entity.ToTable("tbl_OpeningBalance");

                entity.Property(e => e.OpeningBalanceId)
                    .HasColumnName("openingBalanceId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

            modelBuilder.Entity<TblProductPacking>(entity =>
            {
                entity.HasKey(e => e.PackingId)
                    .HasName("PK__tbl_Prod__8084521F217CC17C");

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

            modelBuilder.Entity<TblVehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .HasName("PK__tbl_Vehicle");

                entity.ToTable("tbl_Vehicle");

                entity.Property(e => e.VehicleId)
                    .HasColumnName("vehicleId")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AddDate).HasColumnType("datetime");

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

                entity.Property(e => e.AddDate).HasColumnType("datetime");

                entity.Property(e => e.VehicleTypeName)
                    .IsRequired()
                    .HasColumnName("vehicleTypeName")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TourAdvance>(entity =>
            {
                entity.HasKey(e => new { e.EmpCode, e.JourneyDate })
                    .HasName("PK_Tour_Advance_1");

                entity.Property(e => e.EmpCode)
                    .HasColumnName("Emp_Code")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.JourneyDate)
                    .HasColumnName("Journey_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcceptedAmount).HasColumnName("Accepted_Amount");

                entity.Property(e => e.AcceptedBy)
                    .HasColumnName("Accepted_By")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AcceptedDate)
                    .HasColumnName("Accepted_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AcceptedRemarks)
                    .HasColumnName("Accepted_Remarks")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AcceptedStatus)
                    .HasColumnName("Accepted_Status")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ApplyDate)
                    .HasColumnName("Apply_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovedBy)
                    .HasColumnName("Approved_By")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ApprovedDate)
                    .HasColumnName("Approved_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApprovedRemarks)
                    .HasColumnName("Approved_Remarks")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedStatus)
                    .HasColumnName("Approved_Status")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AuthorisedBy)
                    .HasColumnName("Authorised_By")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AuthorisedDate)
                    .HasColumnName("Authorised_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AuthorisedRemarks)
                    .HasColumnName("Authorised_Remarks")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorisedStatus)
                    .HasColumnName("Authorised_Status")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Jtime)
                    .HasColumnName("JTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModeOfTransport)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PlaceOfVisiting)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Purpose)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.Skip)
                    .HasMaxLength(10)
                    .IsFixedLength();
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

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

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

            modelBuilder.Entity<VendorPayments>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Account).HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(20);

                entity.Property(e => e.ChequeNo).HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CompCode).HasMaxLength(20);

                entity.Property(e => e.CustomerAccount).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Empcode)
                    .HasColumnName("EMPCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.PartyNo).HasMaxLength(50);

                entity.Property(e => e.PayementNo).HasMaxLength(20);

                entity.Property(e => e.Reference).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.VoucherNo).HasMaxLength(50);
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

            modelBuilder.Entity<VoucherProcessing>(entity =>
            {
                entity.HasKey(e => e.VoucherNo);

                entity.Property(e => e.VoucherNo).HasMaxLength(50);

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.CustAccount).HasMaxLength(50);

                entity.Property(e => e.Division).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(50);

                entity.Property(e => e.Ext2).HasMaxLength(50);

                entity.Property(e => e.ExtVoucherNo).HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.RefNo).HasMaxLength(50);

                entity.Property(e => e.SubAccount).HasMaxLength(50);

                entity.Property(e => e.Transaction).HasMaxLength(50);

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.Property(e => e.VoucherType).HasMaxLength(50);
            });

            modelBuilder.Entity<VoucherTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .HasMaxLength(40);

                entity.Property(e => e.AccYear).HasMaxLength(50);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AddUser).HasMaxLength(50);

                entity.Property(e => e.Amount).HasMaxLength(50);

                entity.Property(e => e.BanTaxAmt).HasMaxLength(50);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.Branch).HasMaxLength(50);

                entity.Property(e => e.Cgst)
                    .HasColumnName("CGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Cgstacc)
                    .HasColumnName("CGSTAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.CheckNo).HasMaxLength(50);

                entity.Property(e => e.Company).HasMaxLength(5);

                entity.Property(e => e.CustAccount).HasMaxLength(50);

                entity.Property(e => e.DrCr).HasMaxLength(50);

                entity.Property(e => e.EditUser).HasMaxLength(50);

                entity.Property(e => e.Ext1).HasMaxLength(20);

                entity.Property(e => e.Ext2).HasMaxLength(20);

                entity.Property(e => e.ExtVoucherNo).HasMaxLength(50);

                entity.Property(e => e.Glaccount)
                    .HasColumnName("GLAccount")
                    .HasMaxLength(50);

                entity.Property(e => e.GlsubCode)
                    .HasColumnName("GLSubCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Hsncode)
                    .HasColumnName("HSNCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Igst)
                    .HasColumnName("IGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Igstacc)
                    .HasColumnName("IGSTAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.InvoiceNo).HasMaxLength(50);

                entity.Property(e => e.Narration).HasMaxLength(50);

                entity.Property(e => e.OffSettingAcc).HasMaxLength(50);

                entity.Property(e => e.RefNo).HasMaxLength(50);

                entity.Property(e => e.Sgst)
                    .HasColumnName("SGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Sgstacc)
                    .HasColumnName("SGSTAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(50);

                entity.Property(e => e.Ugst)
                    .HasColumnName("UGST")
                    .HasMaxLength(50);

                entity.Property(e => e.Ugstacc)
                    .HasColumnName("UGSTAcc")
                    .HasMaxLength(50);

                entity.Property(e => e.VoucherNo).HasMaxLength(40);

                entity.Property(e => e.VoucherType).HasMaxLength(50);
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
