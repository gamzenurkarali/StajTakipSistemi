﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StajyerTakipSistemi.Web.Models;

#nullable disable

namespace StajyerTakipSistemi.Web.Migrations
{
    [DbContext(typeof(StajyerTakipSistemiDbContext))]
    [Migration("20240423174243_mi1")]
    partial class mi1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Receiver")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Sender")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UnixTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("(datediff(second,'1970-01-01 00:00:00',getutcdate()))");

                    b.HasKey("MessageId");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.NewMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<Guid>("Receiver")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Sender")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UnixTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("(datediff(second,'1970-01-01 00:00:00',getutcdate()))");

                    b.HasKey("Id");

                    b.ToTable("NewMessages", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.PasswordResetToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PK__PasswordResetToken__3214EC07F8C9F041");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("PasswordResetTokens", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SAbsenceInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AbsenceDate")
                        .HasColumnType("date");

                    b.Property<int?>("InternId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__S_absenc__3214EC07F8C9F041");

                    b.HasIndex("InternId");

                    b.ToTable("S_absenceInformation", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ApplicationDate")
                        .HasColumnType("date");

                    b.Property<string>("ApprovalStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Cv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DesiredField")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id")
                        .HasName("PK__S_applic__3214EC07B0C25BF1");

                    b.ToTable("S_applications", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SAssignedTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AssignmentDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("date");

                    b.Property<int?>("InternId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__S_assign__3214EC07E47A0C5A");

                    b.HasIndex("InternId");

                    b.HasIndex("TaskId");

                    b.ToTable("S_assignedTask", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SDailyReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InternId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<long>("UnixTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("(datediff(second,'1970-01-01 00:00:00',getutcdate()))");

                    b.Property<Guid>("internGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.HasKey("Id")
                        .HasName("PK__S_dailyR__3214EC07B49E10A5");

                    b.HasIndex("InternId");

                    b.ToTable("S_dailyReports", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SFinal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("EvaluationStatus")
                        .HasColumnType("bit");

                    b.Property<string>("GitHubLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternId")
                        .HasColumnType("int");

                    b.Property<string>("RelatedDocuments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("YouTubeLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__final__3214EC07D2EAEF69");

                    b.HasIndex("InternId");

                    b.ToTable("S_Final", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SIntern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("DesiredField")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Explanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__S_intern__3214EC07A4DAB455");

                    b.HasIndex(new[] { "Username" }, "UQ__S_intern__536C85E4102FC61A")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("S_interns", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SInternToManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("InternId")
                        .HasColumnType("int");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__S_intern__3214EC071E1FDB18");

                    b.HasIndex("ManagerId");

                    b.HasIndex(new[] { "InternId" }, "UQ__S_intern__6910EDE361C24DC6")
                        .IsUnique()
                        .HasFilter("[InternId] IS NOT NULL");

                    b.ToTable("S_internToManager", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SManager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__S_manage__3214EC07506EE75C");

                    b.HasIndex(new[] { "Username" }, "UQ__S_manage__536C85E4F41DE357")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("S_managers", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SMessagesforintern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UnixTimestamp")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__S_messag__3214EC07ABF4B60B");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("S_messagesforinterns", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SMessagesformanager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UnixTimestamp")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__S_messag__3214EC073A5F8234");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("S_messagesformanagers", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.STaskDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contents")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__S_taskDe__3214EC074A5D6F73");

                    b.ToTable("S_taskDetails", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.Sadmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("S_admin", (string)null);
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.TestResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsPassed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SAbsenceInformation", b =>
                {
                    b.HasOne("StajyerTakipSistemi.Web.Models.SIntern", "Intern")
                        .WithMany("SAbsenceInformations")
                        .HasForeignKey("InternId")
                        .HasConstraintName("FK__S_absence__Inter__3F466844");

                    b.Navigation("Intern");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SAssignedTask", b =>
                {
                    b.HasOne("StajyerTakipSistemi.Web.Models.SIntern", "Intern")
                        .WithMany("SAssignedTasks")
                        .HasForeignKey("InternId")
                        .HasConstraintName("FK__S_assigne__Inter__4BAC3F29");

                    b.HasOne("StajyerTakipSistemi.Web.Models.STaskDetail", "Task")
                        .WithMany("SAssignedTasks")
                        .HasForeignKey("TaskId")
                        .HasConstraintName("FK__S_assigne__TaskI__4CA06362");

                    b.Navigation("Intern");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SDailyReport", b =>
                {
                    b.HasOne("StajyerTakipSistemi.Web.Models.SIntern", "Intern")
                        .WithMany("SDailyReports")
                        .HasForeignKey("InternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__S_dailyRe__Conte__46E78A0C");

                    b.Navigation("Intern");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SFinal", b =>
                {
                    b.HasOne("StajyerTakipSistemi.Web.Models.SIntern", null)
                        .WithMany()
                        .HasForeignKey("InternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SInternToManager", b =>
                {
                    b.HasOne("StajyerTakipSistemi.Web.Models.SIntern", "Intern")
                        .WithOne("SInternToManager")
                        .HasForeignKey("StajyerTakipSistemi.Web.Models.SInternToManager", "InternId")
                        .HasConstraintName("FK__S_internT__Inter__4316F928");

                    b.HasOne("StajyerTakipSistemi.Web.Models.SManager", "Manager")
                        .WithMany("SInternToManagers")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__S_internT__Manag__440B1D61");

                    b.Navigation("Intern");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SMessagesforintern", b =>
                {
                    b.HasOne("StajyerTakipSistemi.Web.Models.SManager", "Receiver")
                        .WithMany("SMessagesforinterns")
                        .HasForeignKey("ReceiverId")
                        .HasConstraintName("FK__S_message__Recei__5070F446");

                    b.HasOne("StajyerTakipSistemi.Web.Models.SIntern", "Sender")
                        .WithMany("SMessagesforinterns")
                        .HasForeignKey("SenderId")
                        .HasConstraintName("FK__S_message__Sende__4F7CD00D");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SMessagesformanager", b =>
                {
                    b.HasOne("StajyerTakipSistemi.Web.Models.SIntern", "Receiver")
                        .WithMany("SMessagesformanagers")
                        .HasForeignKey("ReceiverId")
                        .HasConstraintName("FK__S_message__Recei__5441852A");

                    b.HasOne("StajyerTakipSistemi.Web.Models.SManager", "Sender")
                        .WithMany("SMessagesformanagers")
                        .HasForeignKey("SenderId")
                        .HasConstraintName("FK__S_message__Sende__534D60F1");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SIntern", b =>
                {
                    b.Navigation("SAbsenceInformations");

                    b.Navigation("SAssignedTasks");

                    b.Navigation("SDailyReports");

                    b.Navigation("SInternToManager");

                    b.Navigation("SMessagesforinterns");

                    b.Navigation("SMessagesformanagers");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.SManager", b =>
                {
                    b.Navigation("SInternToManagers");

                    b.Navigation("SMessagesforinterns");

                    b.Navigation("SMessagesformanagers");
                });

            modelBuilder.Entity("StajyerTakipSistemi.Web.Models.STaskDetail", b =>
                {
                    b.Navigation("SAssignedTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
