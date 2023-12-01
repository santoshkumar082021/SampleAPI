﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SampleAPI.Models;

namespace SampleAPI.Entities
{
    public partial class SampleApiDbContext : DbContext
    {
        public SampleApiDbContext()
        {
        }

        public SampleApiDbContext(DbContextOptions<SampleApiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("SampleApiDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.ToTable("tblOrder");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsInvoiced)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
