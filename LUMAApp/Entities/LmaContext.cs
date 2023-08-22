using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LUMAApp.Entities;

public partial class LmaContext : DbContext
{
    public LmaContext()
    {
    }

    public LmaContext(DbContextOptions<LmaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmpMaster> EmpMasters { get; set; }

    public virtual DbSet<EmployeeCardDetail> EmployeeCardDetails { get; set; }

    public virtual DbSet<EmployeeIssueDetail> EmployeeIssueDetails { get; set; }

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

        modelBuilder.Entity<EmployeeCardDetail>(entity =>
        {
            entity.HasKey(e => new { e.EmpId, e.LoanId }).HasName("PK__employee__4886D13468744E9C");

            entity.ToTable("employee_card_details");

            entity.Property(e => e.EmpId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("emp_id");
            entity.Property(e => e.LoanId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("loan_id");
            entity.Property(e => e.CardIssueDate)
                .HasColumnType("date")
                .HasColumnName("card_issue_date");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeCardDetails)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee___emp_i__36B12243");

            entity.HasOne(d => d.Loan).WithMany(p => p.EmployeeCardDetails)
                .HasForeignKey(d => d.LoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee___loan___37A5467C");
        });

        modelBuilder.Entity<EmployeeIssueDetail>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PK__employee__D6185C39B647C266");

            entity.ToTable("employee_issue_details");

            entity.Property(e => e.IssueId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("issue_id");
            entity.Property(e => e.EmpId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("emp_id");
            entity.Property(e => e.IssueDate)
                .HasColumnType("date")
                .HasColumnName("issue_date");
            entity.Property(e => e.ItemId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("item_id");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("return_date");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeIssueDetails)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__employee___emp_i__3A81B327");

            entity.HasOne(d => d.Item).WithMany(p => p.EmployeeIssueDetails)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__employee___item___3B75D760");
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

            entity.HasOne(d => d.ItemCategoryNavigation).WithMany(p => p.ItemMasters)
                .HasPrincipalKey(p => p.LoanType)
                .HasForeignKey(d => d.ItemCategory)
                .HasConstraintName("FK_LOAN_TYPE_ITEM_CATEGORY");
        });

        modelBuilder.Entity<LoanCardMaster>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__loan_car__A1F79554DD11A340");

            entity.ToTable("loan_card_master");

            entity.HasIndex(e => e.LoanType, "SET_UNIQUE_LOAN_TYPE").IsUnique();

            entity.Property(e => e.LoanId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("loan_id");
            entity.Property(e => e.DurationYears).HasColumnName("duration_years");
            entity.Property(e => e.LoanType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("loan_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
