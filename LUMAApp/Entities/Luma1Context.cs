using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LUMAApp.Entities;

public partial class Luma1Context : DbContext
{
    public Luma1Context()
    {
    }

    public Luma1Context(DbContextOptions<Luma1Context> options)
        : base(options)
    {
    }


    public virtual DbSet<EmpMaster> EmpMasters { get; set; }

    public virtual DbSet<ItemMaster> ItemMasters { get; set; }

    public virtual DbSet<LoanCardMaster> LoanCardMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WINDOWS-BVQNF6J;Initial Catalog=LMA;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
modelBuilder.Entity<EmpMaster>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__emp_mast__1299A86157AF7BC0");

            entity.ToTable("emp_master");

            entity.Property(e => e.EmpId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("emp_id");
            entity.Property(e => e.Dept)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dept");
            entity.Property(e => e.Desgn)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("desgn");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Doj)
                .HasColumnType("date")
                .HasColumnName("DOJ");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
    
        });

        modelBuilder.Entity<ItemMaster>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__item_mas__52020FDD153DD1E2");

            entity.ToTable("item_master");

            entity.Property(e => e.ItemId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("item_id");
            entity.Property(e => e.ItemCategory)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("item_category");
            entity.Property(e => e.ItemDescp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("item_descp");
            entity.Property(e => e.ItemMake)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("item_make");
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("item_status");
            entity.Property(e => e.ItemValuation).HasColumnName("item_valuation");
        });

        modelBuilder.Entity<LoanCardMaster>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__loan_car__A1F79554DD11A340");

            entity.ToTable("loan_card_master");

            entity.Property(e => e.LoanId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("loan_id");
            entity.Property(e => e.DurationYears).HasColumnName("duration_years");
            entity.Property(e => e.LoanType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("loan_type");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
