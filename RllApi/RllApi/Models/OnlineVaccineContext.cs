using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RllApi.Models;

public partial class OnlineVaccineContext : DbContext
{
    public OnlineVaccineContext()
    {
    }

    public OnlineVaccineContext(DbContextOptions<OnlineVaccineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoginAdmin> LoginAdmins { get; set; }

    public virtual DbSet<LoginUser> LoginUsers { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<VaccineCentre> VaccineCentres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HP\\SQLEXPRESS;Initial Catalog=OnlineVaccine;Trusted_Connection = True; MultipleActiveResultSets=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginAdmin>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Login_Ad__1788CCAC146D3127");

            entity.ToTable("Login_Admin");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.CentreId).HasColumnName("CentreID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Centre).WithMany(p => p.LoginAdmins)
                .HasForeignKey(d => d.CentreId)
                .HasConstraintName("FK_Login_Admin_Centre");
        });

        modelBuilder.Entity<LoginUser>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK__Login_Us__7ED91AEF61AA84E3");

            entity.ToTable("Login_Users");

            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.AadharNumber).HasName("PK__Members__5003EE644D065E08");

            entity.Property(e => e.AadharNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.Dose1CentreId).HasColumnName("Dose1CentreID");
            entity.Property(e => e.Dose1Data).HasColumnType("date");
            entity.Property(e => e.Dose1SlotCentreId).HasColumnName("Dose1SlotCentreID");
            entity.Property(e => e.Dose1SlotDate).HasColumnType("date");
            entity.Property(e => e.Dose1Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dose1VaccineName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Dose2CentreId).HasColumnName("Dose2CentreID");
            entity.Property(e => e.Dose2Data).HasColumnType("date");
            entity.Property(e => e.Dose2SlotCentreId).HasColumnName("Dose2SlotCentreID");
            entity.Property(e => e.Dose2SlotDate).HasColumnType("date");
            entity.Property(e => e.Dose2Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dose2VaccineName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RefId).HasColumnName("RefID");

            entity.HasOne(d => d.Dose1Centre).WithMany(p => p.MemberDose1Centres)
                .HasForeignKey(d => d.Dose1CentreId)
                .HasConstraintName("FK_Members_Dose1Centre");

            entity.HasOne(d => d.Dose2Centre).WithMany(p => p.MemberDose2Centres)
                .HasForeignKey(d => d.Dose2CentreId)
                .HasConstraintName("FK_Members_Dose2Centre");

            entity.HasOne(d => d.Email).WithMany(p => p.Members)
                .HasForeignKey(d => d.EmailId)
                .HasConstraintName("FK_Members_Login_Users");

            entity.HasOne(d => d.Dose1Slot).WithMany(p => p.MemberDose1Slots)
                .HasForeignKey(d => new { d.Dose1SlotCentreId, d.Dose1SlotDate })
                .HasConstraintName("FK_Members_Dose1Slot");

            entity.HasOne(d => d.Dose2Slot).WithMany(p => p.MemberDose2Slots)
                .HasForeignKey(d => new { d.Dose2SlotCentreId, d.Dose2SlotDate })
                .HasConstraintName("FK_Members_Dose2Slot");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => new { e.CentreId, e.Date }).HasName("PK__Slots__D59B722A554CBFBF");

            entity.Property(e => e.CentreId).HasColumnName("CentreID");
            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Centre).WithMany(p => p.Slots)
                .HasForeignKey(d => d.CentreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Slots_Centre");
        });

        modelBuilder.Entity<VaccineCentre>(entity =>
        {
            entity.HasKey(e => e.CentreId).HasName("PK__VaccineC__A2E8F5FA48EE6ED7");

            entity.Property(e => e.CentreId)
                .ValueGeneratedNever()
                .HasColumnName("CentreID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HospitalName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Hospital_Name");
            entity.Property(e => e.PinCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pin_code");
            entity.Property(e => e.Sales).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VaccineCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.VaccineName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
