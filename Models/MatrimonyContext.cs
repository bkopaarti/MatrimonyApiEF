using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MatrimonyApiEF.Models;

public partial class MatrimonyContext : DbContext
{
    public MatrimonyContext()
    {
    }

    public MatrimonyContext(DbContextOptions<MatrimonyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BasicInfo> BasicInfos { get; set; }

    public virtual DbSet<EducationalDetail> EducationalDetails { get; set; }

    public virtual DbSet<FamilyDetail> FamilyDetails { get; set; }

    public virtual DbSet<ParnterPreferenceDetail> ParnterPreferenceDetails { get; set; }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    public virtual DbSet<UserPicture> UserPictures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AARTI-BAGOJIKOP\\AARTI;Database=matrimony;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BasicInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("basicInfo");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Pincode).HasColumnName("pincode");
        });

        modelBuilder.Entity<EducationalDetail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("educationalDetails");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Education)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("education");
            entity.Property(e => e.Educationalqulification)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("educationalqulification");
            entity.Property(e => e.Income)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("income");
            entity.Property(e => e.Incometype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("incometype");
            entity.Property(e => e.Occupation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("occupation");
            entity.Property(e => e.Profession)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("profession");

            entity.HasOne(d => d.User).WithOne(p => p.EducationalDetail)
                .HasForeignKey<EducationalDetail>(d => d.UserId)
                .HasConstraintName("FK_login_basicInfo");
        });

        modelBuilder.Entity<FamilyDetail>(entity =>
        {
            entity.HasKey(e => e.Userid);

            entity.ToTable("familyDetails");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("userid");
            entity.Property(e => e.Brothers).HasColumnName("brothers");
            entity.Property(e => e.Choiceoflifeparternaer)
                .HasMaxLength(20)
                .HasColumnName("choiceoflifeparternaer");
            entity.Property(e => e.Familyincome)
                .HasMaxLength(20)
                .HasColumnName("familyincome");
            entity.Property(e => e.Father)
                .HasMaxLength(10)
                .HasColumnName("father");
            entity.Property(e => e.Incometype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("incometype");
            entity.Property(e => e.Marriedbrother).HasColumnName("marriedbrother");
            entity.Property(e => e.Marriedsister).HasColumnName("marriedsister");
            entity.Property(e => e.Mother)
                .HasMaxLength(10)
                .HasColumnName("mother");
            entity.Property(e => e.Nativeplaceinsindh)
                .HasMaxLength(20)
                .HasColumnName("nativeplaceinsindh");
            entity.Property(e => e.RelativeContacts)
                .HasMaxLength(100)
                .HasColumnName("relativeContacts");
            entity.Property(e => e.Sisters).HasColumnName("sisters");

            entity.HasOne(d => d.User).WithOne(p => p.FamilyDetail)
                .HasForeignKey<FamilyDetail>(d => d.Userid)
                .HasConstraintName("FK_familyDetails_basicInfo");
        });

        modelBuilder.Entity<ParnterPreferenceDetail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("parnterPreferenceDetail");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.AgeRange)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("age_range");
            entity.Property(e => e.AnnualIncome)
                .HasMaxLength(20)
                .HasColumnName("annual_income");
            entity.Property(e => e.CountryLivingIn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("country_living_in");
            entity.Property(e => e.Diet)
                .HasMaxLength(10)
                .HasColumnName("diet");
            entity.Property(e => e.HeightRange)
                .HasMaxLength(10)
                .HasColumnName("height_range");
            entity.Property(e => e.MarritalStatus)
                .HasMaxLength(10)
                .HasColumnName("marrital_status");
            entity.Property(e => e.Profession)
                .HasMaxLength(10)
                .HasColumnName("profession");
            entity.Property(e => e.Qualification)
                .HasMaxLength(10)
                .HasColumnName("qualification");
            entity.Property(e => e.StateLivingIn)
                .HasMaxLength(10)
                .HasColumnName("state_living_in");

            entity.HasOne(d => d.User).WithOne(p => p.ParnterPreferenceDetail)
                .HasForeignKey<ParnterPreferenceDetail>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_parnterPreferenceDetail_basicInfo");
        });

        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("personalDetails");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Bloodgroup)
                .HasMaxLength(5)
                .HasColumnName("bloodgroup");
            entity.Property(e => e.Built)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("built");
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("datetime")
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Diet)
                .HasMaxLength(10)
                .HasColumnName("diet");
            entity.Property(e => e.Disease)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("disease");
            entity.Property(e => e.Height)
                .HasMaxLength(10)
                .HasColumnName("height");
            entity.Property(e => e.Hobbies)
                .HasMaxLength(50)
                .HasColumnName("hobbies");
            entity.Property(e => e.Lens)
                .HasMaxLength(10)
                .HasColumnName("lens");
            entity.Property(e => e.Manglik)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("manglik");
            entity.Property(e => e.MarrigeStatus)
                .HasMaxLength(10)
                .HasColumnName("marrigeStatus");
            entity.Property(e => e.Placeofbirth)
                .HasMaxLength(20)
                .HasColumnName("placeofbirth");
            entity.Property(e => e.Timeofbirth)
                .HasMaxLength(10)
                .HasColumnName("timeofbirth");
            entity.Property(e => e.Weight)
                .HasMaxLength(10)
                .HasColumnName("weight");

            entity.HasOne(d => d.User).WithOne(p => p.PersonalDetail)
                .HasForeignKey<PersonalDetail>(d => d.UserId)
                .HasConstraintName("FK_personalDetails_basicInfo");
        });

        modelBuilder.Entity<UserPicture>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserPicture");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Filepath).HasMaxLength(100);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.User).WithOne(p => p.UserPicture)
                .HasForeignKey<UserPicture>(d => d.UserId)
                .HasConstraintName("FK_UserPicture_basicInfo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
