using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjectAllocationSystem_ICT2_Assignment2_38Q2.Models;

public partial class ProjectAllocationDbContext : DbContext
{
    public ProjectAllocationDbContext()
    {
    }

    public ProjectAllocationDbContext(DbContextOptions<ProjectAllocationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectAllocation> ProjectAllocations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=projectAllocationDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("employee");

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
            entity.ToTable("project");

            entity.Property(e => e.ProjectId)
                .ValueGeneratedNever()
                .HasColumnName("project_id");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("project_name");
        });

        modelBuilder.Entity<ProjectAllocation>(entity =>
        {
            entity.HasKey(e => e.ProAllocateId);

            entity.ToTable("ProjectAllocation");

            entity.Property(e => e.ProAllocateId)
                .ValueGeneratedNever()
                .HasColumnName("proAllocate_id");
            entity.Property(e => e.AllocatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Allocated_date");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.Emp).WithMany(p => p.ProjectAllocations)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectAllocation_employee");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectAllocations)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectAllocation_project");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
