using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public partial class CyclixContext : DbContext
{
    public CyclixContext()
    {
    }

    public CyclixContext(DbContextOptions<CyclixContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BikeType> BikeTypes { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<ServiceData> ServiceData { get; set; }

    public virtual DbSet<ServicePackage> ServicePackages { get; set; }

    public virtual DbSet<ServicePackageType> ServicePackageTypes { get; set; }

    public virtual DbSet<StandardService> StandardServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Cyclix;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BikeType>(entity =>
        {
            entity.ToTable("BikeType");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceData>(entity =>
        {
            entity.HasKey(e => e.ServiceDataId);

            entity.Property(e => e.CostCeiling).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PostCode).HasMaxLength(20);

            entity.HasOne(d => d.BikeType).WithMany(p => p.ServiceData)
                .HasForeignKey(d => d.BikeTypeId)
                .HasConstraintName("FK_ServiceData_BikeType");

            entity.HasOne(d => d.Brand).WithMany(p => p.ServiceData)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_ServiceData_Brand");

            entity.HasOne(d => d.StandardService).WithMany(p => p.ServiceData)
                .HasForeignKey(d => d.StandardServiceId)
                .HasConstraintName("FK_ServiceData_StandardService");
        });

        modelBuilder.Entity<ServicePackage>(entity =>
        {
            entity.ToTable("ServicePackage");

            entity.Property(e => e.Currency)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.ServicePackageType).WithMany(p => p.ServicePackages)
                .HasForeignKey(d => d.ServicePackageTypeId)
                .HasConstraintName("FK_ServicePackage_ServicePackageType");
        });

        modelBuilder.Entity<ServicePackageType>(entity =>
        {
            entity.ToTable("ServicePackageType");
        });

        modelBuilder.Entity<StandardService>(entity =>
        {
            entity.ToTable("StandardService");

            entity.Property(e => e.Currency)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
