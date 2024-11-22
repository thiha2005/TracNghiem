using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TracNghiem.Models;

public partial class TracnghiemContext : DbContext
{
    public TracnghiemContext()
    {
    }

    public TracnghiemContext(DbContextOptions<TracnghiemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CauHoi> CauHois { get; set; }

    public virtual DbSet<DeThi> DeThis { get; set; }

    public virtual DbSet<DeThiCauHoi> DeThiCauHois { get; set; }

    public virtual DbSet<KetQua> KetQuas { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<MucDo> MucDos { get; set; }

    public virtual DbSet<ThanhVien> ThanhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=14.0.22.12,1433;Initial Catalog=tracnghiem;User ID=tn;Password=@Abc123456;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("db_accessadmin")
            .UseCollation("Vietnamese_CI_AS");

        modelBuilder.Entity<CauHoi>(entity =>
        {
            entity.ToTable("CauHois", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CauHoi1)
                .HasMaxLength(250)
                .HasColumnName("CauHoi");
            entity.Property(e => e.DapAn)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.DapAnA)
                .HasMaxLength(250)
                .HasColumnName("DapAn_a");
            entity.Property(e => e.DapAnB)
                .HasMaxLength(250)
                .HasColumnName("DapAn_b");
            entity.Property(e => e.DapAnC)
                .HasMaxLength(250)
                .HasColumnName("DapAn_c");
            entity.Property(e => e.DapAnD)
                .HasMaxLength(250)
                .HasColumnName("DapAn_d");
            entity.Property(e => e.GhiChu).HasMaxLength(250);

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.CauHois)
                .HasForeignKey(d => d.MaMonHoc)
                .HasConstraintName("FK_CauHois_MonHocs");

            entity.HasOne(d => d.MaMucDoNavigation).WithMany(p => p.CauHois)
                .HasForeignKey(d => d.MaMucDo)
                .HasConstraintName("FK_CauHois_MucDos");
        });

        modelBuilder.Entity<DeThi>(entity =>
        {
            entity.ToTable("DeThis", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TenDeThi).HasMaxLength(50);
        });

        modelBuilder.Entity<DeThiCauHoi>(entity =>
        {
            entity.ToTable("DeThi_CauHois", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.HasOne(d => d.MaCauHoiNavigation).WithMany(p => p.DeThiCauHois)
                .HasForeignKey(d => d.MaCauHoi)
                .HasConstraintName("FK_DeThi_CauHois_CauHois");

            entity.HasOne(d => d.MaDeThiNavigation).WithMany(p => p.DeThiCauHois)
                .HasForeignKey(d => d.MaDeThi)
                .HasConstraintName("FK_DeThi_CauHois_DeThis");
        });

        modelBuilder.Entity<KetQua>(entity =>
        {
            entity.ToTable("KetQuas", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DapAn)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MaSinhVien)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaDeThiCauHoiNavigation).WithMany(p => p.KetQuas)
                .HasForeignKey(d => d.MaDeThiCauHoi)
                .HasConstraintName("FK_KetQuas_DeThi_CauHois");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.KetQuas)
                .HasForeignKey(d => d.MaSinhVien)
                .HasConstraintName("FK_KetQuas_ThanhViens");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.ToTable("MonHocs", "dbo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TenMonHoc).HasMaxLength(70);
        });

        modelBuilder.Entity<MucDo>(entity =>
        {
            entity.ToTable("MucDos", "dbo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TenMucDo)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<ThanhVien>(entity =>
        {
            entity.ToTable("ThanhViens", "dbo");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Lop)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgaySinh).HasColumnName("NgaySInh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenSinhVien).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
