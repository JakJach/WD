﻿// <auto-generated />
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
    [Migration("20210505194121_Initial")]
    partial class Initial
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

                    b.Property<short>("Note")
                        .HasColumnType("smallint");

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

                    b.Property<double?>("Note")
                        .HasColumnType("float");

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

                    b.Property<double?>("PromoterNote")
                        .HasColumnType("float");

                    b.Property<string>("PromoterOpinion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<double?>("ReviewerNote")
                        .HasColumnType("float");

                    b.Property<string>("Scope")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
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
                        .IsUnique();

                    b.ToTable("Theses");
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
                        .HasForeignKey("WD.Data.Models.Thesis", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
