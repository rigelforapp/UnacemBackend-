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
    [Migration("20220901172432_Migration25")]
    partial class Migration25
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

                    b.HasKey("Id");

                    b.ToTable("BrickFormats");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Budget_Id")
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

                    b.HasKey("Id");

                    b.HasIndex("Budget_Id");

                    b.ToTable("BudgetCurrency");
                });

            modelBuilder.Entity("UNACEM.Domain.Budgets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<double>("Total_Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<int>("Version_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Version_Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetStretch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BrickFormat_Id")
                        .HasColumnType("int");

                    b.Property<double>("Brick_a_Cost")
                        .HasColumnType("float");

                    b.Property<double>("Brick_b_Cost")
                        .HasColumnType("float");

                    b.Property<int>("Budget_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Stretch_Id")
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

                    b.HasKey("Id");

                    b.HasIndex("BrickFormat_Id");

                    b.HasIndex("Budget_Id");

                    b.HasIndex("Stretch_Id");

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

                    b.Property<int>("Version_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Version_Id");

                    b.ToTable("Gallery");
                });

            modelBuilder.Entity("UNACEM.Domain.Headquarters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_At")
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

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Diameter")
                        .HasColumnType("int");

                    b.Property<int>("Headquarter_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Large")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Headquarter_Id");

                    b.HasIndex("User_Id");

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

                    b.Property<int>("ProviderImportation_Id")
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

                    b.HasKey("Id");

                    b.HasIndex("ProviderImportation_Id");

                    b.ToTable("ProviderBricks");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderImportations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<int>("Provider_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<string>("Updated_By")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Provider_Id");

                    b.ToTable("ProviderImportations");
                });

            modelBuilder.Entity("UNACEM.Domain.Providers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("UNACEM.Domain.Stretchs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrickFormat_Id")
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

                    b.Property<int>("ProviderBrick_Id")
                        .HasColumnType("int");

                    b.Property<int>("Texture_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.Property<int>("Version_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrickFormat_Id");

                    b.HasIndex("ProviderBrick_Id");

                    b.HasIndex("Version_Id");

                    b.ToTable("Stretchs");
                });

            modelBuilder.Entity("UNACEM.Domain.Tyres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Color_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .IsRequired()
                        .HasColumnType("DateTime");

                    b.Property<DateTime?>("Deleted_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("Oven_Id")
                        .HasColumnType("int");

                    b.Property<double>("Position")
                        .HasColumnType("float");

                    b.Property<int>("Texture_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("Color_Id");

                    b.HasIndex("Oven_Id");

                    b.ToTable("Tyres");
                });

            modelBuilder.Entity("UNACEM.Domain.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UNACEM.Domain.Versions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<int>("Oven_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.HasIndex("Oven_Id");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetCurrency", b =>
                {
                    b.HasOne("UNACEM.Domain.Budgets", "Budgets")
                        .WithMany()
                        .HasForeignKey("Budget_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budgets");
                });

            modelBuilder.Entity("UNACEM.Domain.Budgets", b =>
                {
                    b.HasOne("UNACEM.Domain.Versions", "Versions")
                        .WithMany()
                        .HasForeignKey("Version_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Versions");
                });

            modelBuilder.Entity("UNACEM.Domain.BudgetStretch", b =>
                {
                    b.HasOne("UNACEM.Domain.BrickFormats", "BrickFormats")
                        .WithMany()
                        .HasForeignKey("BrickFormat_Id");

                    b.HasOne("UNACEM.Domain.Budgets", "Budgets")
                        .WithMany()
                        .HasForeignKey("Budget_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.Stretchs", "Stretchs")
                        .WithMany()
                        .HasForeignKey("Stretch_Id");

                    b.Navigation("BrickFormats");

                    b.Navigation("Budgets");

                    b.Navigation("Stretchs");
                });

            modelBuilder.Entity("UNACEM.Domain.Gallery", b =>
                {
                    b.HasOne("UNACEM.Domain.Versions", "Versions")
                        .WithMany()
                        .HasForeignKey("Version_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Versions");
                });

            modelBuilder.Entity("UNACEM.Domain.Ovens", b =>
                {
                    b.HasOne("UNACEM.Domain.Headquarters", "Headquarters")
                        .WithMany()
                        .HasForeignKey("Headquarter_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.Users", "Users")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Headquarters");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderBricks", b =>
                {
                    b.HasOne("UNACEM.Domain.ProviderImportations", "ProviderImportations")
                        .WithMany()
                        .HasForeignKey("ProviderImportation_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProviderImportations");
                });

            modelBuilder.Entity("UNACEM.Domain.ProviderImportations", b =>
                {
                    b.HasOne("UNACEM.Domain.Providers", "Providers")
                        .WithMany()
                        .HasForeignKey("Provider_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Providers");
                });

            modelBuilder.Entity("UNACEM.Domain.Stretchs", b =>
                {
                    b.HasOne("UNACEM.Domain.BrickFormats", "BrickFormats")
                        .WithMany()
                        .HasForeignKey("BrickFormat_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.ProviderBricks", "ProviderBricks")
                        .WithMany()
                        .HasForeignKey("ProviderBrick_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.Versions", "Versions")
                        .WithMany()
                        .HasForeignKey("Version_Id")
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
                        .HasForeignKey("Color_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UNACEM.Domain.Ovens", "Ovens")
                        .WithMany()
                        .HasForeignKey("Oven_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Ovens");
                });

            modelBuilder.Entity("UNACEM.Domain.Versions", b =>
                {
                    b.HasOne("UNACEM.Domain.Ovens", "Ovens")
                        .WithMany()
                        .HasForeignKey("Oven_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ovens");
                });
#pragma warning restore 612, 618
        }
    }
}
