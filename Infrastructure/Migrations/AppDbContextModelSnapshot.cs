﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CampaignType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("CampaignTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SEO"
                        },
                        new
                        {
                            Id = 2,
                            Name = "PPC"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Social Media"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Email Marketing"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Interaction", b =>
                {
                    b.Property<Guid>("InteractionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("InteractionType")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InteractionID");

                    b.HasIndex("InteractionType");

                    b.HasIndex("ProjectID");

                    b.ToTable("Interactions", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.InteractionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("InteractionTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Initial Meeting"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Phone call"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Email"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Presentation of Results"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskID");

                    b.HasIndex("AssignedTo");

                    b.HasIndex("ProjectID");

                    b.HasIndex("Status");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.JobStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("TaskStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Name = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Blocked"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Done"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cancel"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CampaignType")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectID");

                    b.HasIndex("CampaignType");

                    b.HasIndex("ClientID");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserID");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "jdone@marketing.com",
                            Name = "Joe Done"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "namstrong@marketing.com",
                            Name = "Nill Armstrong"
                        },
                        new
                        {
                            UserID = 3,
                            Email = "mmorales@marketing.com",
                            Name = "Marlyn Morales"
                        },
                        new
                        {
                            UserID = 4,
                            Email = "aorue@marketing.com",
                            Name = "Antony Orué"
                        },
                        new
                        {
                            UserID = 5,
                            Email = "jfernandez@marketing.com",
                            Name = "Jazmin Fernandez"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Interaction", b =>
                {
                    b.HasOne("Domain.Entities.InteractionType", "InteractionTypes")
                        .WithMany("Interactions")
                        .HasForeignKey("InteractionType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("Interactions")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InteractionTypes");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Entities.Job", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Jobs")
                        .HasForeignKey("AssignedTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("Jobs")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.JobStatus", "JobStatus")
                        .WithMany("Jobs")
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobStatus");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.HasOne("Domain.Entities.CampaignType", "CampaignTypes")
                        .WithMany("Projects")
                        .HasForeignKey("CampaignType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CampaignTypes");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Domain.Entities.CampaignType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Client", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Domain.Entities.InteractionType", b =>
                {
                    b.Navigation("Interactions");
                });

            modelBuilder.Entity("Domain.Entities.JobStatus", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Navigation("Interactions");

                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
