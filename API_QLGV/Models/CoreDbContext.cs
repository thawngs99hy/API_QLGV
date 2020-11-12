using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_QLGV.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bacluong> Bacluong { get; set; }
        public virtual DbSet<Bomontrungtam> Bomontrungtam { get; set; }
        public virtual DbSet<Chucvu> Chucvu { get; set; }
        public virtual DbSet<Giangvien> Giangvien { get; set; }
        public virtual DbSet<Gioday> Gioday { get; set; }
        public virtual DbSet<Hocvan> Hocvan { get; set; }
        public virtual DbSet<Khenthuong> Khenthuong { get; set; }
        public virtual DbSet<Khoa> Khoa { get; set; }
        public virtual DbSet<Khoahoc> Khoahoc { get; set; }
        public virtual DbSet<Lichlamviec> Lichlamviec { get; set; }
        public virtual DbSet<Luong> Luong { get; set; }
        public virtual DbSet<Monhoc> Monhoc { get; set; }
        public virtual DbSet<Sukien> Sukien { get; set; }
        public virtual DbSet<User2> User2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=MSI\\THAWNGS;Database=QLGV;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bacluong>(entity =>
            {
                entity.HasKey(e => e.MaBac)
                    .HasName("PK__BACLUONG__1B8FFFBD1E9C6449");
            });

            modelBuilder.Entity<Bomontrungtam>(entity =>
            {
                entity.HasKey(e => e.Mabm)
                    .HasName("PK__BOMONTRU__603FFF9E8F55A748");

                entity.Property(e => e.Fax)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("CHUCVU_pk");
            });

            modelBuilder.Entity<Giangvien>(entity =>
            {
                entity.HasKey(e => e.MaGv)
                    .HasName("PK__GIANGVIE__2725AEF3DE884613");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Fax)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Img).IsUnicode(false);

                entity.Property(e => e.Tel)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Website).IsUnicode(false);

                entity.HasOne(d => d.MaBmNavigation)
                    .WithMany(p => p.Giangvien)
                    .HasForeignKey(d => d.MaBm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GIANGVIEN__MaBM__267ABA7A");

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.Giangvien)
                    .HasForeignKey(d => d.MaCv)
                    .HasConstraintName("FK__GIANGVIEN__maCv__01142BA1");
            });

            modelBuilder.Entity<Gioday>(entity =>
            {
                entity.HasKey(e => e.MaGd)
                    .HasName("PK__GIODAY__7A3E2D670095266C");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Gioday)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GIODAY__MaGV__52593CB8");
            });

            modelBuilder.Entity<Hocvan>(entity =>
            {
                entity.HasKey(e => e.MaHv)
                    .HasName("PK__HOCVAN__7A3E149448B97958");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Hocvan)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOCVAN__MaGV__5812160E");
            });

            modelBuilder.Entity<Khenthuong>(entity =>
            {
                entity.HasKey(e => e.MaKt)
                    .HasName("PK__KHENTHUO__7A3ECFF895FAAFDD");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Khenthuong)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KHENTHUONG__MaGV__5AEE82B9");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("PK__KHOA__C79B8C227D9D1207");
            });

            modelBuilder.Entity<Khoahoc>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KHOAHOC__7A3ECFE4CA3C0CF3");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Khoahoc)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KHOAHOC__MaGV__5535A963");
            });

            modelBuilder.Entity<Lichlamviec>(entity =>
            {
                entity.HasKey(e => e.MaLlv)
                    .HasName("PK__LICHLAMV__3B9BF60FF7AF25B3");

                entity.HasOne(d => d.MaGvNavigation)
                    .WithMany(p => p.Lichlamviec)
                    .HasForeignKey(d => d.MaGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LICHLAMVIE__MaGV__2A4B4B5E");
            });

            modelBuilder.Entity<Luong>(entity =>
            {
                entity.HasKey(e => e.MaLuong)
                    .HasName("PK__LUONG__31F4B61190B6B7C5");

                entity.HasOne(d => d.MaBacNavigation)
                    .WithMany(p => p.Luong)
                    .HasForeignKey(d => d.MaBac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LUONG__maBac__4F7CD00D");
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("PK__MONHOC__7A3EDFA6A25F974B");
            });

            modelBuilder.Entity<Sukien>(entity =>
            {
                entity.HasKey(e => e.MaSk)
                    .HasName("PK__SUKIEN__27250811F40AE636");
            });

            modelBuilder.Entity<User2>(entity =>
            {
                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.ImageUrl).IsUnicode(false);

                entity.Property(e => e.Matkhau).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.Taikhoan).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
