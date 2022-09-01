﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UNACEM.Persistence.Database;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UNACEM.Domain.BrickFormats", b =>
                {
                    b.Property<int>("BrickFormatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrickFormatId"), 1L, 1);

                    b.Property<string>("Brick_a")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Brick_b")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Diameter")
                        .HasColumnType("int");

                    b.Property<string>("Group")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Quantity_a")
                        .HasColumnType("int");

                    b.Property<int>("Quantity_b")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.HasKey("BrickFormatId");

                    b.ToTable("BrickFormats");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetCurrency", b =>
                {
                    b.Property<int>("BudgetCurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BudgetCurrencyId"), 1L, 1);

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<double>("Equivalence")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.HasKey("BudgetCurrencyId");

                    b.HasIndex("BudgetId");

                    b.ToTable("BudgetCurrency");
                });

            modelBuilder.Entity("UNACEM.Domain.Budgets", b =>
                {
                    b.Property<int>("BudgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BudgetId"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total_Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("BudgetId");

                    b.HasIndex("VersionId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetStretch", b =>
                {
                    b.Property<int>("BudgetStretchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BudgetStretchId"), 1L, 1);

                    b.Property<int?>("BrickFormatId")
                        .HasColumnType("int");

                    b.Property<double>("Brick_a_Cost")
                        .HasColumnType("float");

                    b.Property<double>("Brick_b_Cost")
                        .HasColumnType("float");

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StretchId")
                        .HasColumnType("int");

                    b.Property<double>("Total_Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<double>("Wedge_a_Cost")
                        .HasColumnType("float");

                    b.Property<double>("Wedge_a_Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Wedge_b_Cost")
                        .HasColumnType("float");

                    b.Property<double>("Wedge_b_Quantity")
                        .HasColumnType("float");

                    b.HasKey("BudgetStretchId");

                    b.HasIndex("BrickFormatId");

                    b.HasIndex("BudgetId");

                    b.HasIndex("StretchId");

                    b.ToTable("BudgetStretch");
                });

            modelBuilder.Entity("UNACEM.Domain.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"), 1L, 1);

                    b.Property<int>("Hex")
                        .HasColumnType("int");

                    b.HasKey("ColorId");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("UNACEM.Domain.Gallery", b =>
                {
                    b.Property<int>("GalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GalleryId"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("GalleryId");

                    b.HasIndex("VersionId");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("UNACEM.Domain.Headquarters", b =>
                {
                    b.Property<int>("HeadquarterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HeadquarterId"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.HasKey("HeadquarterId");

                    b.ToTable("Headquarters");
                });

            modelBuilder.Entity("UNACEM.Domain.Ovens", b =>
                {
                    b.Property<int>("OvenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OvenId"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Diameter")
                        .HasColumnType("int");

                    b.Property<int>("HeadquarterId")
                        .HasColumnType("int");

                    b.Property<decimal>("Large")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OvenId");

                    b.HasIndex("HeadquarterId");

                    b.HasIndex("UserId");

                    b.ToTable("Ovens");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderBricks", b =>
                {
                    b.Property<int>("ProviderBrickId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProviderBrickId"), 1L, 1);

                    b.Property<string>("Ccs")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Composition")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Density")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Porosity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProviderImportationId")
                        .HasColumnType("int");

                    b.Property<string>("Recommended_Zone")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("Thermal_Conductivity_100")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("Thermal_Conductivity_300")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("Thermal_Conductivity_700")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("ProviderBrickId");

                    b.HasIndex("ProviderImportationId");

                    b.ToTable("ProviderBricks");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderImportations", b =>
                {
                    b.Property<int>("ProviderImportationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProviderImportationId"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<string>("Created_By")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Deleted_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<string>("Updated_By")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProviderImportationId");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProviderImportations");
                });

            modelBuilder.Entity("UNACEM.Domain.Providers", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProviderId"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<string>("Created_By")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Deleted_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<string>("Updated_By")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("UNACEM.Domain.Stretchs", b =>
                {
                    b.Property<int>("StretchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StretchId"), 1L, 1);

                    b.Property<int>("BrickFormatId")
                        .HasColumnType("int");

                    b.Property<int>("Color_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<double>("Position_End")
                        .HasColumnType("float");

                    b.Property<double>("Position_Ini")
                        .HasColumnType("float");

                    b.Property<int>("ProviderBrickId")
                        .HasColumnType("int");

                    b.Property<int>("Texture_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("StretchId");

                    b.HasIndex("BrickFormatId");

                    b.HasIndex("ProviderBrickId");

                    b.HasIndex("VersionId");

                    b.ToTable("Stretchs");
                });

            modelBuilder.Entity("UNACEM.Domain.Tyres", b =>
                {
                    b.Property<int>("TyreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TyreId"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("OvenId")
                        .HasColumnType("int");

                    b.Property<double>("Position")
                        .HasColumnType("float");

                    b.Property<int>("Texture_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.HasKey("TyreId");

                    b.HasIndex("ColorId");

                    b.HasIndex("OvenId");

                    b.ToTable("Tyres");
                });

            modelBuilder.Entity("UNACEM.Domain.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UNACEM.Domain.Versions", b =>
                {
                    b.Property<int>("VersionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VersionId"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("Date_End")
                        .HasColumnType("Date");

                    b.Property<DateTime>("Date_Ini")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OvenId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.HasKey("VersionId");

                    b.HasIndex("OvenId");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetCurrency", b =>
                {
                    b.HasOne("UNACEM.Domain.Budgets", "Budgets")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budgets");
                });

            modelBuilder.Entity("UNACEM.Domain.Budgets", b =>
                {
                    b.HasOne("UNACEM.Domain.Versions", "Versions")
                        .WithMany()
                        .HasForeignKey("VersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Versions");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetStretch", b =>
                {
                    b.HasOne("UNACEM.Domain.BrickFormats", "BrickFormats")
                        .WithMany()
                        .HasForeignKey("BrickFormatId");

                    b.HasOne("UNACEM.Domain.Budgets", "Budgets")
                        .WithMany()
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.Stretchs", "Stretchs")
                        .WithMany()
                        .HasForeignKey("StretchId");

                    b.Navigation("BrickFormats");

                    b.Navigation("Budgets");

                    b.Navigation("Stretchs");
                });

            modelBuilder.Entity("UNACEM.Domain.Gallery", b =>
                {
                    b.HasOne("UNACEM.Domain.Versions", "Versions")
                        .WithMany()
                        .HasForeignKey("VersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Versions");
                });

            modelBuilder.Entity("UNACEM.Domain.Ovens", b =>
                {
                    b.HasOne("UNACEM.Domain.Headquarters", "Headquarters")
                        .WithMany()
                        .HasForeignKey("HeadquarterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Headquarters");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderBricks", b =>
                {
                    b.HasOne("UNACEM.Domain.ProviderImportations", "ProviderImportations")
                        .WithMany()
                        .HasForeignKey("ProviderImportationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProviderImportations");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderImportations", b =>
                {
                    b.HasOne("UNACEM.Domain.Providers", "Providers")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Providers");
                });

            modelBuilder.Entity("UNACEM.Domain.Stretchs", b =>
                {
                    b.HasOne("UNACEM.Domain.BrickFormats", "BrickFormats")
                        .WithMany()
                        .HasForeignKey("BrickFormatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.ProviderBricks", "ProviderBricks")
                        .WithMany()
                        .HasForeignKey("ProviderBrickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.Versions", "Versions")
                        .WithMany()
                        .HasForeignKey("VersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BrickFormats");

                    b.Navigation("ProviderBricks");

                    b.Navigation("Versions");
                });

            modelBuilder.Entity("UNACEM.Domain.Tyres", b =>
                {
                    b.HasOne("UNACEM.Domain.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.Ovens", "Ovens")
                        .WithMany()
                        .HasForeignKey("OvenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Ovens");
                });

            modelBuilder.Entity("UNACEM.Domain.Versions", b =>
                {
                    b.HasOne("UNACEM.Domain.Ovens", "Ovens")
                        .WithMany()
                        .HasForeignKey("OvenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ovens");
                });
#pragma warning restore 612, 618
        }
    }
}
