using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<JobStatus> JobStatus { get; set; }
        public DbSet<Job> Jobs { get; set; }        
        public DbSet<Project> Projects { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<CampaignType> CampaignTypes { get; set; }
        public DbSet<Client> Clients { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.UserID);               

                entity.Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();                              
            }
            );

            modelBuilder.Entity<JobStatus>(entity =>
            {
                entity.ToTable("TaskStatus");
                entity.HasKey(js => js.Id);                

                entity.Property(js => js.Name)
                .HasColumnType("varchar(25)")
                .IsRequired();                
            }
            );

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(j => j.TaskID);

                entity.Property(j => j.Name)
                .IsRequired();

                entity.Property(j => j.DueDate)
                .IsRequired();

                entity.HasOne(j => j.Project)
                .WithMany(p => p.Jobs)
                .HasForeignKey(j => j.ProjectID);

                entity.HasOne(j => j.User)
                .WithMany(u => u.Jobs)
                .HasForeignKey(j => j.AssignedTo);

                entity.HasOne(j => j.JobStatus)
                .WithMany(js => js.Jobs)
                .HasForeignKey(j => j.Status);

                entity.Property(p => p.CreateDate)
                .IsRequired();
            }
            );

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects");                

                entity.Property(p => p.ProjectName)
                .HasColumnType("varchar(255)")
                .IsRequired();

                entity.Property(p => p.StartDate)
                .IsRequired();

                entity.Property(p => p.EndDate)
                .IsRequired();

                entity.HasOne(p => p.CampaignTypes)
                .WithMany(ct => ct.Projects)
                .HasForeignKey(p => p.CampaignType);

                entity.HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientID);

                entity.HasMany(p => p.Interactions)
                .WithOne(i => i.Project)
                .HasForeignKey(i => i.ProjectID);

                entity.Property(p => p.CreateDate)
                .IsRequired();
            }
            );

            modelBuilder.Entity<InteractionType>(entity =>
            {
                entity.ToTable("InteractionTypes");
                entity.HasKey(it => it.Id);                

                entity.Property(it => it.Name)
                .HasMaxLength(25)
                .IsRequired();                
            }
            );

            modelBuilder.Entity<Interaction>(entity =>
            {
                entity.ToTable("Interactions");                

                entity.Property(i => i.Date)
                .IsRequired();

                entity.Property(i => i.Notes)
                .HasColumnType("varchar(max)")
                .IsRequired();                

                entity.HasOne(i => i.InteractionTypes)
                .WithMany(it => it.Interactions)
                .HasForeignKey(i => i.InteractionType);
            }
            );

            modelBuilder.Entity<CampaignType>(entity =>
            {
                entity.ToTable("CampaignTypes");
                entity.HasKey(ct => ct.Id);                

                entity.Property(ct => ct.Name)
                .HasColumnType("varchar(25)")
                .IsRequired();                
            }
            );

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients");
                entity.HasKey(c => c.ClientID);
                entity.Property(c => c.ClientID)
                .ValueGeneratedOnAdd();

                entity.Property(c => c.Name)
                .HasColumnType("varchar(255)")
                .IsRequired();

                entity.Property(c => c.Email)
                .HasColumnType("varchar(255)")
                .IsRequired();

                entity.Property(c => c.Phone)
                .HasColumnType("varchar(255)")
                .IsRequired();

                entity.Property(c => c.Company)
                .HasColumnType("varchar(100)")
                .IsRequired();

                entity.Property(c => c.Address)
                .HasColumnType("varchar(max)")
                .IsRequired();

                entity.Property(p => p.CreateDate)
                .IsRequired();

            }
            );

            // Cargar datos predeterminados
            SeedData.Seed(modelBuilder);

        }

        
    }
}
