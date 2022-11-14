using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI_for_GoldGym.Models
{
    public partial class GoldGymDBContext : DbContext
    {
        public GoldGymDBContext()
        {
        }

        public GoldGymDBContext(DbContextOptions<GoldGymDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBaiTap> TblBaiTaps { get; set; } = null!;
        public virtual DbSet<TblChiTietDstap> TblChiTietDstaps { get; set; } = null!;
        public virtual DbSet<TblChiTietLichTap> TblChiTietLichTaps { get; set; } = null!;
        public virtual DbSet<TblDonGd> TblDonGds { get; set; } = null!;
        public virtual DbSet<TblDstap> TblDstaps { get; set; } = null!;
        public virtual DbSet<TblLichTap> TblLichTaps { get; set; } = null!;
        public virtual DbSet<TblTaiKhoan> TblTaiKhoans { get; set; } = null!;
        public virtual DbSet<TblThongTinTk> TblThongTinTks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=GoldGymDB;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBaiTap>(entity =>
            {
                entity.HasKey(e => e.IdBaiTap)
                    .HasName("PK__tblBaiTa__4552506303BBAA76");

                entity.ToTable("tblBaiTap");

                entity.Property(e => e.BpCoThe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NhomCo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TbsuDung)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TBSuDung");

                entity.Property(e => e.TenBaiTap)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Urlanh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("URLAnh");
            });

            modelBuilder.Entity<TblChiTietDstap>(entity =>
            {
                entity.HasKey(e => e.IdChiTietDstap)
                    .HasName("PK__tblChiTi__BE4060F7F0DDB575");

                entity.ToTable("tblChiTietDSTap");

                entity.Property(e => e.IdChiTietDstap).HasColumnName("IdChiTietDSTap");

                entity.Property(e => e.IdDstap).HasColumnName("IdDSTap");

            });

            modelBuilder.Entity<TblChiTietLichTap>(entity =>
            {
                entity.HasKey(e => e.IdChiTietLichTap)
                    .HasName("PK__tblChiTi__3FA804DA4E2FCFF7");

                entity.ToTable("tblChiTietLichTap");

                entity.Property(e => e.IdDstap).HasColumnName("IdDSTap");

            });

            modelBuilder.Entity<TblDonGd>(entity =>
            {
                entity.HasKey(e => e.IdDonGd)
                    .HasName("PK__tblDonGD__F2726D993AECA4DD");

                entity.ToTable("tblDonGD");

                entity.Property(e => e.IdDonGd).HasColumnName("IdDonGD");

                entity.Property(e => e.MaGd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MaGD");

                entity.Property(e => e.TgguiDon)
                    .HasColumnType("datetime")
                    .HasColumnName("TGGuiDon");

                entity.Property(e => e.TtpheDuyet)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TTPheDuyet");
            });

            modelBuilder.Entity<TblDstap>(entity =>
            {
                entity.HasKey(e => e.IdDstap)
                    .HasName("PK__tblDSTap__C273F1BBCEDAB979");

                entity.ToTable("tblDSTap");

                entity.Property(e => e.IdDstap).HasColumnName("IdDSTap");

                entity.Property(e => e.LoaiDstap)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LoaiDSTap");

                entity.Property(e => e.MoTaDstap)
                    .HasMaxLength(200)
                    .HasColumnName("MoTaDSTap");

                entity.Property(e => e.TenDstap)
                    .HasMaxLength(100)
                    .HasColumnName("TenDSTap");
            });

            modelBuilder.Entity<TblLichTap>(entity =>
            {
                entity.HasKey(e => e.IdLichTap)
                    .HasName("PK__tblLichT__C2D7FE466B6D1C5B");

                entity.ToTable("tblLichTap");

                entity.Property(e => e.MoTaLichTap).HasMaxLength(200);

                entity.Property(e => e.NgayTap).HasColumnType("datetime");

                entity.Property(e => e.TenLichTap).HasMaxLength(100);

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTaiKhoan>(entity =>
            {
                entity.HasKey(e => e.IdTaiKhoan)
                    .HasName("PK__tblTaiKh__9A53D3DD463B4CBD");

                entity.ToTable("tblTaiKhoan");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Quyen)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ThoiGianDk)
                    .HasColumnType("datetime")
                    .HasColumnName("ThoiGianDK");

                entity.Property(e => e.IdTaiKhoan).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TblThongTinTk>(entity =>
            {
                entity.HasKey(e => e.IdThongTinTk)
                    .HasName("PK__tblThong__B59668BCAF4D9BDB");

                entity.ToTable("tblThongTinTK");

                entity.Property(e => e.IdThongTinTk).HasColumnName("IdThongTinTK");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(3);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
