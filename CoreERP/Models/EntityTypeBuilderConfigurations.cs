using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreERP.Models
{
    public partial class ERPContext : DbContext
    {
        private void ConfigureModels(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TblLangugageEntityConfig());
        }
    }

    public class TblLangugageEntityConfig : IEntityTypeConfiguration<TblLanguage>
    {
        public void Configure(EntityTypeBuilder<TblLanguage> builder)
        {
            //builder.HasKey(e => e.LanguageCode);

            //builder.ToTable("tbl_Language");


            //builder.Property(e => e.Id).UseSqlServerIdentityColumn();
           // builder.Property(e => e.Id).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        }
    }
}

//ERPContext
//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    ConfigureModels(modelBuilder);
//modelBuilder.Entity<AccountingClass>(entity =>
//            {