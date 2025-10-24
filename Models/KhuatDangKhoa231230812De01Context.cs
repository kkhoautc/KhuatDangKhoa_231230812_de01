using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KhuatDangKhoa_231230812_de01.Models;

public partial class KhuatDangKhoa231230812De01Context : DbContext
{
    public KhuatDangKhoa231230812De01Context()
    {
    }

    public KhuatDangKhoa231230812De01Context(DbContextOptions<KhuatDangKhoa231230812De01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<KdkComputer> KdkComputers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=KhuatDangKhoa_231230812_de01;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KdkComputer>(entity =>
        {
            entity.HasKey(e => e.KdkComId).HasName("PK__KdkCompu__4718018671B36224");

            entity.ToTable("KdkComputer");

            entity.Property(e => e.KdkComId)
                .ValueGeneratedNever()
                .HasColumnName("kdkComId");
            entity.Property(e => e.KdkComImage)
                .HasMaxLength(100)
                .HasColumnName("kdkComImage");
            entity.Property(e => e.KdkComName)
                .HasMaxLength(10)
                .HasColumnName("kdkComName");
            entity.Property(e => e.KdkComPrice)
                .HasColumnType("money")
                .HasColumnName("kdkComPrice");
            entity.Property(e => e.KdkComStatus)
                .HasDefaultValue(true)
                .HasColumnName("kdkComStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
