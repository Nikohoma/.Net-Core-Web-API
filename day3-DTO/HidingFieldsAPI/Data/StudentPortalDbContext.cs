using System;
using System.Collections.Generic;
using HidingFieldsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HidingFieldsAPI.Data;

public partial class StudentPortalDbContext : DbContext
{
    public StudentPortalDbContext()
    {
    }

    public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Courses> Courses { get; set; }

    public virtual DbSet<Enrollments> Enrollments { get; set; }

    public virtual DbSet<Students> Students { get; set; }

    public virtual DbSet<tblLog> tblLog { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SSN\\SQLEXPRESS;Initial Catalog=StudentPortalDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Courses>(entity =>
        {
            entity.HasKey(e => e.CourseId);

            entity.HasIndex(e => e.Title, "IX_Courses_Title");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Courses_CreatedAt");
            entity.Property(e => e.Fee).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Courses_IsActive");
            entity.Property(e => e.Level).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Enrollments>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId);

            entity.HasIndex(e => e.CourseId, "IX_Enrollments_CourseId");

            entity.HasIndex(e => e.StudentId, "IX_Enrollments_StudentId");

            entity.HasIndex(e => new { e.StudentId, e.CourseId }, "UQ_Enrollments_StudentCourse").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Enrollments_CreatedAt");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending", "DF_Enrollments_PaymentStatus");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Courses");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Students");
        });

        modelBuilder.Entity<Students>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.HasIndex(e => e.Email, "UX_Students_Email").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Students_CreatedAt");
            entity.Property(e => e.Email).HasMaxLength(180);
            entity.Property(e => e.FullName).HasMaxLength(120);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active", "DF_Students_Status");
        });

        modelBuilder.Entity<tblLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.Property(e => e.LogId).ValueGeneratedNever();
            entity.Property(e => e.Info)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.tblLog)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblLog_Students");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
