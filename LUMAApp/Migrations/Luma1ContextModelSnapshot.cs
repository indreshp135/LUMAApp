﻿// <auto-generated />
using System;
using LUMAApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LUMAApp.Migrations
{
    [DbContext(typeof(Luma1Context))]
    partial class Luma1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LUMAApp.Entities.EmpMaster", b =>
                {
                    b.Property<string>("EmpId")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("emp_id");

                    b.Property<string>("Dept")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("dept");

                    b.Property<string>("Desgn")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("desgn");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("date")
                        .HasColumnName("DOB");

                    b.Property<DateTime?>("Doj")
                        .HasColumnType("date")
                        .HasColumnName("DOJ");

                    b.Property<string>("EmpName")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("emp_name");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("gender")
                        .IsFixedLength();

                    b.HasKey("EmpId")
                        .HasName("PK__emp_mast__1299A86157AF7BC0");

                    b.ToTable("emp_master", (string)null);
                });

            modelBuilder.Entity("LUMAApp.Entities.ItemMaster", b =>
                {
                    b.Property<string>("ItemId")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("item_id");

                    b.Property<string>("ItemCategory")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("item_category");

                    b.Property<string>("ItemDescp")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("item_descp");

                    b.Property<string>("ItemMake")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("item_make");

                    b.Property<string>("ItemStatus")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .HasColumnName("item_status")
                        .IsFixedLength();

                    b.Property<int?>("ItemValuation")
                        .HasColumnType("int")
                        .HasColumnName("item_valuation");

                    b.HasKey("ItemId")
                        .HasName("PK__item_mas__52020FDD153DD1E2");

                    b.ToTable("item_master", (string)null);
                });

            modelBuilder.Entity("LUMAApp.Entities.LoanCardMaster", b =>
                {
                    b.Property<string>("LoanId")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)")
                        .HasColumnName("loan_id");

                    b.Property<int?>("DurationYears")
                        .HasColumnType("int")
                        .HasColumnName("duration_years");

                    b.Property<string>("LoanType")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("loan_type");

                    b.HasKey("LoanId")
                        .HasName("PK__loan_car__A1F79554DD11A340");

                    b.ToTable("loan_card_master", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
