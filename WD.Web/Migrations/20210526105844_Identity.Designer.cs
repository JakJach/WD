// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WD.Web.Models;

namespace WD.Web.Migrations
{
    [DbContext(typeof(WDWebContext))]
    [Migration("20210526105844_Identity")]
    partial class Identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassStudent", b =>
                {
                    b.Property<int>("ClassesClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsUserID")
                        .HasColumnType("int");

                    b.HasKey("ClassesClassId", "StudentsUserID");

                    b.HasIndex("StudentsUserID");

                    b.ToTable("ClassStudent");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjectStudent", b =>
                {
                    b.Property<int>("ProjectsProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsUserID")
                        .HasColumnType("int");

                    b.HasKey("ProjectsProjectId", "StudentsUserID");

                    b.HasIndex("StudentsUserID");

                    b.ToTable("ProjectStudent");
                });

            modelBuilder.Entity("WD.Data.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherUserID")
                        .HasColumnType("int");

                    b.HasKey("ClassId");

                    b.HasIndex("TeacherUserID");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            Name = "Laboratorium Specjalizacyjne"
                        },
                        new
                        {
                            ClassId = 2,
                            Name = "Seminarium Dyplomowe"
                        });
                });

            modelBuilder.Entity("WD.Data.Models.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("ThesisId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FileId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ThesisId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("WD.Data.Models.FinalNote", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<float>("Note")
                        .HasColumnType("real");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("NoteId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("FinalNotes");
                });

            modelBuilder.Entity("WD.Data.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Goal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReviewed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubmitted")
                        .HasColumnType("bit");

                    b.Property<float?>("Note")
                        .HasColumnType("real");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Scope")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("ClassId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            ClassId = 1,
                            CreationDate = new DateTime(2021, 5, 26, 12, 58, 43, 905, DateTimeKind.Local).AddTicks(6478),
                            Goal = "Działająca i przetestowana aplikacja z funkcjonalnościami: dodawania ocen, oddawania projektów, składania pracy dyplomowej",
                            IsReviewed = false,
                            IsSubmitted = false,
                            Scope = "Wykonanie aplikacji webowej obsługującej wirtualny dziekanat uczelni wyższej",
                            Title = "Wirtualny Dziekanat"
                        });
                });

            modelBuilder.Entity("WD.Data.Models.Thesis", b =>
                {
                    b.Property<int>("ThesisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AcceptationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Goal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReviewed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubmitted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTaken")
                        .HasColumnType("bit");

                    b.Property<int>("PromoterId")
                        .HasColumnType("int");

                    b.Property<float?>("PromoterNote")
                        .HasColumnType("real");

                    b.Property<string>("PromoterOpinion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<float?>("ReviewerNote")
                        .HasColumnType("real");

                    b.Property<string>("Scope")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("StudentQualifications")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TakeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThesisId");

                    b.HasIndex("PromoterId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.ToTable("Theses");

                    b.HasData(
                        new
                        {
                            ThesisId = 1,
                            CreationDate = new DateTime(2021, 5, 26, 12, 58, 43, 906, DateTimeKind.Local).AddTicks(8945),
                            Goal = "Wykonanie działającej  i gotowej do użycia wtyczki",
                            IsAccepted = false,
                            IsReviewed = false,
                            IsSubmitted = false,
                            IsTaken = true,
                            PromoterId = 4,
                            ReviewerId = 5,
                            Scope = "Stowrzenie skryptów uczenia maszynowego, wykonanie biblioteki dll wykorzystującej wyniki działąnia ww. skryptów, wykonanie hosta",
                            StudentId = 1,
                            StudentQualifications = "C#; Python",
                            TakeDate = new DateTime(2021, 5, 26, 12, 58, 43, 907, DateTimeKind.Local).AddTicks(1981),
                            Title = "Wtyczka VST realizująca proces masteringu poprzez autmoatyczne dopasowanie korektora EQ"
                        });
                });

            modelBuilder.Entity("WD.Data.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WD.Data.Models.Student", b =>
                {
                    b.HasBaseType("WD.Data.Models.User");

                    b.Property<bool>("HasThesis")
                        .HasColumnType("bit");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "jakjach@student.agh.edu.pl",
                            Name = "Jakub",
                            Password = "42e7c00e8f7af060ba54331cd81b13a8",
                            Surname = "Jachowicz",
                            HasThesis = true
                        },
                        new
                        {
                            UserID = 2,
                            Email = "alexbial@student.agh.edu.pl",
                            Name = "Alex",
                            Password = "124b63f14a3e2e080eb65521285f9611",
                            Surname = "Białas",
                            HasThesis = true
                        },
                        new
                        {
                            UserID = 3,
                            Email = "matkas@student.agh.edu.pl",
                            Name = "Mateusz",
                            Password = "db4a311ab5789e9cdfafbec0f8e6bdc6",
                            Surname = "Kasprzak",
                            HasThesis = true
                        });
                });

            modelBuilder.Entity("WD.Data.Models.Teacher", b =>
                {
                    b.HasBaseType("WD.Data.Models.User");

                    b.Property<bool>("CanBePromoter")
                        .HasColumnType("bit");

                    b.Property<bool>("CanBeReviewer")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            UserID = 4,
                            Email = "rotter@agh.edu.pl",
                            Name = "Paweł",
                            Password = "18182f494c2d6cfdda3e893934b7ea5c",
                            Surname = "Rotter",
                            CanBePromoter = true,
                            CanBeReviewer = true
                        },
                        new
                        {
                            UserID = 5,
                            Email = "baranowski@agh.edu.pl",
                            Name = "Jerzy",
                            Password = "25d8eb2adfa874aefccb40e132d95639",
                            Surname = "Baranowski",
                            CanBePromoter = true,
                            CanBeReviewer = true
                        });
                });

            modelBuilder.Entity("ClassStudent", b =>
                {
                    b.HasOne("WD.Data.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassesClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WD.Data.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectStudent", b =>
                {
                    b.HasOne("WD.Data.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WD.Data.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WD.Data.Models.Class", b =>
                {
                    b.HasOne("WD.Data.Models.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherUserID");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("WD.Data.Models.File", b =>
                {
                    b.HasOne("WD.Data.Models.Project", "Project")
                        .WithMany("Files")
                        .HasForeignKey("ProjectId");

                    b.HasOne("WD.Data.Models.Thesis", "Thesis")
                        .WithMany("Files")
                        .HasForeignKey("ThesisId");

                    b.Navigation("Project");

                    b.Navigation("Thesis");
                });

            modelBuilder.Entity("WD.Data.Models.FinalNote", b =>
                {
                    b.HasOne("WD.Data.Models.Class", "Class")
                        .WithMany("FinalNote")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WD.Data.Models.Student", "Student")
                        .WithMany("FinalNote")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WD.Data.Models.Project", b =>
                {
                    b.HasOne("WD.Data.Models.Class", "Class")
                        .WithMany("Projects")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("WD.Data.Models.Thesis", b =>
                {
                    b.HasOne("WD.Data.Models.Teacher", "Promoter")
                        .WithMany("PromotedTheses")
                        .HasForeignKey("PromoterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WD.Data.Models.Teacher", "Reviewer")
                        .WithMany("ReviewedTheses")
                        .HasForeignKey("ReviewerId");

                    b.HasOne("WD.Data.Models.Student", "Student")
                        .WithOne("Thesis")
                        .HasForeignKey("WD.Data.Models.Thesis", "StudentId");

                    b.Navigation("Promoter");

                    b.Navigation("Reviewer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WD.Data.Models.Student", b =>
                {
                    b.HasOne("WD.Data.Models.User", null)
                        .WithOne()
                        .HasForeignKey("WD.Data.Models.Student", "UserID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WD.Data.Models.Teacher", b =>
                {
                    b.HasOne("WD.Data.Models.User", null)
                        .WithOne()
                        .HasForeignKey("WD.Data.Models.Teacher", "UserID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WD.Data.Models.Class", b =>
                {
                    b.Navigation("FinalNote");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("WD.Data.Models.Project", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("WD.Data.Models.Thesis", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("WD.Data.Models.Student", b =>
                {
                    b.Navigation("FinalNote");

                    b.Navigation("Thesis");
                });

            modelBuilder.Entity("WD.Data.Models.Teacher", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("PromotedTheses");

                    b.Navigation("ReviewedTheses");
                });
#pragma warning restore 612, 618
        }
    }
}
