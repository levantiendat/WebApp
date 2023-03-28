using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models.Entities1;

public partial class DbhocphanContext : DbContext
{
    public DbhocphanContext()
    {
    }

    public DbhocphanContext(DbContextOptions<DbhocphanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Giangvien> Giangviens { get; set; }

    public virtual DbSet<Hocphan> Hocphans { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Lophp> Lophps { get; set; }

    public virtual DbSet<Lopsinhhoat> Lopsinhhoats { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6CLAM5L\\TIENDAT_SQL;Initial Catalog=DBHOCPHAN;Integrated Security=True ;TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Giangvien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GIANGVIE__3214EC27F5BF1495");

            entity.ToTable("GIANGVIEN");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Makhoa).HasColumnName("MAKHOA");
            entity.Property(e => e.Namegv)
                .HasMaxLength(40)
                .HasColumnName("namegv");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.Giangviens)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK__GIANGVIEN__MAKHO__267ABA7A");
        });

        modelBuilder.Entity<Hocphan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HOCPHAN__3214EC27A6DA0909");

            entity.ToTable("HOCPHAN");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Makhoa).HasColumnName("MAKHOA");
            entity.Property(e => e.Namehp)
                .HasMaxLength(60)
                .HasColumnName("namehp");
            entity.Property(e => e.Tinchi).HasColumnName("tinchi");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.Hocphans)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK__HOCPHAN__MAKHOA__29572725");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KHOA__3214EC276CC467DC");

            entity.ToTable("KHOA");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(40)
                .HasColumnName("MAKHOA");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Mssv).HasName("pk_MSSV_01");

            entity.ToTable("login");

            entity.Property(e => e.Mssv)
                .HasMaxLength(20)
                .HasColumnName("MSSV");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .HasColumnName("PASSWORD");
        });

        modelBuilder.Entity<Lophp>(entity =>
        {
            entity.HasKey(e => e.Malophocphan).HasName("PK_LOPHP_ID");

            entity.ToTable("LOPHP");

            entity.Property(e => e.Malophocphan)
                .HasMaxLength(60)
                .HasColumnName("MALOPHOCPHAN");
            entity.Property(e => e.Clc).HasColumnName("CLC");
            entity.Property(e => e.Dk).HasColumnName("DK");
            entity.Property(e => e.Dubi).HasColumnName("DUBI");
            entity.Property(e => e.Hocki).HasColumnName("HOCKI");
            entity.Property(e => e.Khoahoc)
                .HasMaxLength(4)
                .HasColumnName("KHOAHOC");
            entity.Property(e => e.Magv).HasColumnName("MAGV");
            entity.Property(e => e.Mahocphan).HasColumnName("MAHOCPHAN");
            entity.Property(e => e.Nhomlophp)
                .HasMaxLength(5)
                .HasColumnName("NHOMLOPHP");
            entity.Property(e => e.NumDubi).HasColumnName("numDUBI");
            entity.Property(e => e.Sl).HasColumnName("SL");
            entity.Property(e => e.Tkb)
                .HasMaxLength(30)
                .HasColumnName("TKB");
            entity.Property(e => e.Tuanhoc)
                .HasMaxLength(30)
                .HasColumnName("TUANHOC");

            entity.HasOne(d => d.MagvNavigation).WithMany(p => p.Lophps)
                .HasForeignKey(d => d.Magv)
                .HasConstraintName("FK__LOPHP__MAGV__34C8D9D1");

            entity.HasOne(d => d.MahocphanNavigation).WithMany(p => p.Lophps)
                .HasForeignKey(d => d.Mahocphan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LOPHP__MAHOCPHAN__33D4B598");

            entity.HasMany(d => d.Mssvs).WithMany(p => p.Malophocphans)
                .UsingEntity<Dictionary<string, object>>(
                    "Lophpdetail",
                    r => r.HasOne<Sinhvien>().WithMany()
                        .HasForeignKey("Mssv")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LOPHPDETAI__MSSV__6B24EA82"),
                    l => l.HasOne<Lophp>().WithMany()
                        .HasForeignKey("Malophocphan")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LOPHPDETA__MALOP__6A30C649"),
                    j =>
                    {
                        j.HasKey("Malophocphan", "Mssv").HasName("PK__LOPHPDET__8A576352141D1110");
                        j.ToTable("LOPHPDETAIL");
                        j.IndexerProperty<string>("Malophocphan")
                            .HasMaxLength(60)
                            .HasColumnName("MALOPHOCPHAN");
                        j.IndexerProperty<string>("Mssv")
                            .HasMaxLength(20)
                            .HasColumnName("MSSV");
                    });
        });

        modelBuilder.Entity<Lopsinhhoat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOPSINHH__3214EC27B27C157D");

            entity.ToTable("LOPSINHHOAT");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Lopsh)
                .HasMaxLength(20)
                .HasColumnName("LOPSH");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.Mssv).HasName("PK__SINHVIEN__6CB3B7F9F7BE8FE1");

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.Mssv)
                .HasMaxLength(20)
                .HasColumnName("MSSV");
            entity.Property(e => e.Malop).HasColumnName("MALOP");
            entity.Property(e => e.NameSv)
                .HasMaxLength(40)
                .HasColumnName("NameSV");

            entity.HasOne(d => d.MalopNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Malop)
                .HasConstraintName("FK__SINHVIEN__MALOP__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
