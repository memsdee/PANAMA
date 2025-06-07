using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PANAMA.Models;

public partial class PanamaContext : DbContext
{
    public PanamaContext()
    {
    }

    public PanamaContext(DbContextOptions<PanamaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<FormContact> FormContacts { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ADMIN;Initial Catalog=PANAMA;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.IdAccount).HasName("PK__account__213379EB7958D021");

            entity.ToTable("account");

            entity.Property(e => e.IdAccount).HasColumnName("ID_Account");
            entity.Property(e => e.AdminName)
                .HasMaxLength(30)
                .HasColumnName("adminName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Pass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pass");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contact__3214EC075F5335D5");

            entity.ToTable("contact");

            entity.Property(e => e.AboutText1).IsUnicode(false);
            entity.Property(e => e.AboutText2).IsUnicode(false);
            entity.Property(e => e.AboutText3).IsUnicode(false);
            entity.Property(e => e.FacebookUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FacebookURL");
            entity.Property(e => e.FanpageName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FanpageUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FanpageURL");
            entity.Property(e => e.MainAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MainPhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StudioAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudioPhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.YouTubeUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("YouTubeURL");
        });

        modelBuilder.Entity<FormContact>(entity =>
        {
            entity.HasKey(e => e.IdForm).HasName("PK__formCont__195D4BB418FC9F04");

            entity.ToTable("formContact");

            entity.Property(e => e.IdForm).HasColumnName("ID_Form");
            entity.Property(e => e.AreaOfInterest)
                .HasMaxLength(50)
                .HasColumnName("areaOfInterest");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime");
            entity.Property(e => e.StatusCheck).HasColumnName("statusCheck");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userEmail");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .HasColumnName("userName");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.IdMedia).HasName("PK__media__397340FC6F74EA89");

            entity.ToTable("media");

            entity.Property(e => e.IdMedia).HasColumnName("ID_Media");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("filePath");
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fileType");
            entity.Property(e => e.Idproject).HasColumnName("IDProject");

            entity.HasOne(d => d.IdprojectNavigation).WithMany(p => p.Media)
                .HasForeignKey(d => d.Idproject)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__media__nameProje__173876EA");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.IdProject).HasName("PK__project__D310AEBF4D95BA44");

            entity.ToTable("project");

            entity.Property(e => e.IdProject).HasColumnName("ID_Project");
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .HasColumnName("category");
            entity.Property(e => e.DescProject).HasColumnName("descProject");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail");
            entity.Property(e => e.TimeProject)
                .HasColumnType("datetime")
                .HasColumnName("timeProject");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasKey(e => e.IdSponsor).HasName("PK__sponsor__B555EC9CE40ECA97");

            entity.ToTable("sponsor");

            entity.Property(e => e.IdSponsor).HasColumnName("ID_Sponsor");
            entity.Property(e => e.LogoPath)
                .HasMaxLength(255)
                .HasColumnName("logoPath");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.IdToken).HasName("PK__Token__55591596574A0389");

            entity.ToTable("token");

            entity.Property(e => e.IdToken).HasColumnName("Id_Token");
            entity.Property(e => e.AccountId).HasColumnName("account_ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Expiration).HasColumnType("datetime");
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("refreshToken");
            entity.Property(e => e.Token1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("token");

            entity.HasOne(d => d.Account).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Token__account_I__24927208");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
