using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProjectAllocationMVC.Models;

public partial class ProjectAllocationDB : DbContext
{
    public ProjectAllocationDB()
    {
    }

    public ProjectAllocationDB(DbContextOptions<ProjectAllocationDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectAllocation> ProjectAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=V\\SQLEXPRESS;Initial Catalog=ProjectAllocationDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("emp_id");
            entity.Property(e => e.EmpDepartment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_department");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_designation");
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_email");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProId);

            entity.ToTable("Project");

            entity.Property(e => e.ProId)
                .ValueGeneratedNever()
                .HasColumnName("pro_id");
            entity.Property(e => e.ProDatetime)
                .HasColumnType("datetime")
                .HasColumnName("pro_datetime");
            entity.Property(e => e.ProName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pro_name");
        });

        modelBuilder.Entity<ProjectAllocation>(entity =>
        {
            entity.HasKey(e => e.ProAllocateId);

            entity.ToTable("ProjectAllocation");

            entity.Property(e => e.ProAllocateId)
                .ValueGeneratedNever()
                .HasColumnName("proAllocate_id");
            entity.Property(e => e.AllocationDate)
                .HasColumnType("datetime")
                .HasColumnName("allocation_date");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.ProId).HasColumnName("pro_id");

            entity.HasOne(d => d.Emp).WithMany(p => p.ProjectAllocations)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectAllocation_ToTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
