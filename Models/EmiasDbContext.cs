using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMIAS_API.Models;

public partial class EmiasDbContext : DbContext
{
    public EmiasDbContext()
    {
    }

    public EmiasDbContext(DbContextOptions<EmiasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AnalysDocument> AnalysDocuments { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentDocument> AppointmentDocuments { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<ResearchDocument> ResearchDocuments { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Admin__4C3F97F42DD00A75");

            entity.ToTable("Admin");

            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.SurName).HasMaxLength(50);
        });

        modelBuilder.Entity<AnalysDocument>(entity =>
        {
            entity.HasKey(e => e.IdAnalys).HasName("PK__AnalysDo__266A12D79DBF7083");

            entity.ToTable("AnalysDocument");

            entity.Property(e => e.IdAnalys).HasColumnName("idAnalys");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__ECE24AAB8028394F");

            entity.Property(e => e.Oms).HasColumnName("OMS");
        });

        modelBuilder.Entity<AppointmentDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__44E34BD40D4D9594");

            entity.ToTable("AppointmentDocument");

            entity.Property(e => e.IdAppointment).HasColumnName("idAppointment");
            entity.Property(e => e.Name).HasMaxLength(50);

        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirection).HasName("PK__Directio__7780E2B24081CDDF");

            entity.Property(e => e.Oms).HasColumnName("OMS");

        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__Doctor__F838DB3EFD22EADE");

            entity.ToTable("Doctor");

            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.SurName).HasMaxLength(50);
            entity.Property(e => e.WorkAddress).HasMaxLength(50);

        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Oms).HasName("PK__Patient__CB396B8BF2BE4D16");

            entity.ToTable("Patient");

            entity.Property(e => e.Oms).HasColumnName("OMS");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LivingAddress).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Nickname).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(18);
            entity.Property(e => e.SurName).HasMaxLength(50);
        });

        modelBuilder.Entity<ResearchDocument>(entity =>
        {
            entity.HasKey(e => e.IdResearch).HasName("PK__Research__59084967C1A3EE7C");

            entity.ToTable("ResearchDocument");

            entity.Property(e => e.IdResearch).HasColumnName("idResearch");
            entity.Property(e => e.Attachment)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);

        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.IdSpeciality).HasName("PK__Speciali__5C8D4E6823E97D87");

            entity.Property(e => e.ImagePath).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Status__B450643A978D8384");

            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
