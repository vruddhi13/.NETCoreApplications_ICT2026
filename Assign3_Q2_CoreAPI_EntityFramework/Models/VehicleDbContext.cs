using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assign3_Q2_CoreAPI_EntityFramework.Models;

public partial class VehicleDbContext : DbContext
{
    public VehicleDbContext()
    {
    }

    public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=vehicleDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VId).HasName("PK__vehicle__AD3D8441C9ECD67F");

            entity.ToTable("vehicle");

            entity.Property(e => e.VId)
                .ValueGeneratedNever()
                .HasColumnName("v_id");
            entity.Property(e => e.VBrand)
                .HasMaxLength(50)
                .HasColumnName("v_brand");
            entity.Property(e => e.VColor)
                .HasMaxLength(50)
                .HasColumnName("v_color");
            entity.Property(e => e.VModel)
                .HasMaxLength(50)
                .HasColumnName("v_model");
            entity.Property(e => e.VPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("v_price");
            entity.Property(e => e.VYear).HasColumnName("v_year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
