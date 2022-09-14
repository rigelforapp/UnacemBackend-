﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UNACEM.Persistence.Database;

#nullable disable

namespace UNACEM.Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220914203408_Migration32")]
    partial class Migration32
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UNACEM.Domain.BrickFormats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrickA")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("BrickB")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Diameter")
                        .HasColumnType("int");

                    b.Property<string>("Group")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("QuantityA")
                        .HasColumnType("int");

                    b.Property<int>("QuantityB")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.ToTable("BrickFormats");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
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

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.ToTable("BudgetCurrency");
                });

            modelBuilder.Entity("UNACEM.Domain.Budgets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VersionId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetStretch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("BrickACost")
                        .HasColumnType("float");

                    b.Property<double>("BrickBCost")
                        .HasColumnType("float");

                    b.Property<int?>("BrickFormatId")
                        .HasColumnType("int");

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StretchId")
                        .HasColumnType("int");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.Property<double>("WedgeACost")
                        .HasColumnType("float");

                    b.Property<double>("WedgeAQuantity")
                        .HasColumnType("float");

                    b.Property<double>("WedgeBCost")
                        .HasColumnType("float");

                    b.Property<double>("WedgeBQuantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrickFormatId");

                    b.HasIndex("BudgetId");

                    b.HasIndex("StretchId");

                    b.ToTable("BudgetStretch");
                });

            modelBuilder.Entity("UNACEM.Domain.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Hex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("UNACEM.Domain.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
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

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VersionId");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("UNACEM.Domain.Headquarters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.ToTable("Headquarters");
                });

            modelBuilder.Entity("UNACEM.Domain.Ovens", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
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

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HeadquarterId");

                    b.HasIndex("UserId");

                    b.ToTable("Ovens");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderBricks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ccs")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Composition")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
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

                    b.Property<string>("RecommendedZone")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("ThermalConductivity100")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ThermalConductivity300")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ThermalConductivity700")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProviderImportationId");

                    b.ToTable("ProviderBricks");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderConcretes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Composition")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("MaterialNeeded")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProviderImportationId")
                        .HasColumnType("int");

                    b.Property<string>("RecommendedZone")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<double>("ThermalConductivity100")
                        .HasColumnType("float");

                    b.Property<double>("ThermalConductivity300")
                        .HasColumnType("float");

                    b.Property<double>("ThermalConductivity700")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.Property<string>("WaterMix")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ProviderImportationId");

                    b.ToTable("ProviderConcretes");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderImportations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProviderImportations");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderInsulatings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Composition")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("MaterialNeeded")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProviderImportationId")
                        .HasColumnType("int");

                    b.Property<string>("RecommendedZone")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<double>("ThermalConductivity100")
                        .HasColumnType("float");

                    b.Property<double>("ThermalConductivity300")
                        .HasColumnType("float");

                    b.Property<double>("ThermalConductivity700")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.Property<string>("WaterMix")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ProviderImportationId");

                    b.ToTable("ProviderInsulatings");
                });

            modelBuilder.Entity("UNACEM.Domain.Providers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("UNACEM.Domain.Stretchs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrickFormatId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("PositionEnd")
                        .HasColumnType("float");

                    b.Property<double>("PositionIni")
                        .HasColumnType("float");

                    b.Property<int>("ProviderBrickId")
                        .HasColumnType("int");

                    b.Property<int>("TextureId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrickFormatId");

                    b.HasIndex("ProviderBrickId");

                    b.HasIndex("VersionId");

                    b.ToTable("Stretchs");
                });

            modelBuilder.Entity("UNACEM.Domain.Tyres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("OvenId")
                        .HasColumnType("int");

                    b.Property<double>("Position")
                        .HasColumnType("float");

                    b.Property<int>("TextureId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("OvenId");

                    b.ToTable("Tyres");
                });

            modelBuilder.Entity("UNACEM.Domain.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UNACEM.Domain.Versions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateIni")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OvenId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

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

            modelBuilder.Entity("UNACEM.Domain.ProviderConcretes", b =>
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

            modelBuilder.Entity("UNACEM.Domain.ProviderInsulatings", b =>
                {
                    b.HasOne("UNACEM.Domain.ProviderImportations", "ProviderImportations")
                        .WithMany()
                        .HasForeignKey("ProviderImportationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProviderImportations");
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
