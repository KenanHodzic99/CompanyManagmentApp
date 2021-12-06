﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AlfaThermTaskApp.DatabaseModels
{
    public partial class AlfathermdbContext : DbContext
    {
        public AlfathermdbContext(DbContextOptions<AlfathermdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkCard> WorkCard { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.PersonalIdentityNumber).HasMaxLength(13);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__Employees__JobID__29572725");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobTitle).HasMaxLength(20);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Jobs__Department__267ABA7A");
            });

            modelBuilder.Entity<Departments>(entity => 
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentName).HasMaxLength(40);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModuleName).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(c => c.Permissions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Permissio__UserI__300424B4");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProjectLocation).HasMaxLength(100);

                entity.Property(e => e.ProjectName).HasMaxLength(40);

                entity.Property(e => e.ProjectStatus).HasMaxLength(20);

                entity.Property(e => e.ProjectType).HasMaxLength(20);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "UQ__Users__7AD04FF09AFE1919")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.PasswordHash).HasMaxLength(100);

                entity.Property(e => e.PasswordSalt).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(20);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Users)
                    .HasForeignKey<Users>(d => d.EmployeeId)
                    .HasConstraintName("FK__Users__EmployeeI__2D27B809");
            });

            modelBuilder.Entity<WorkCard>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activities).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.WorkCard)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__WorkCard__Employ__34C8D9D1");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.WorkCard)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__WorkCard__Projec__35BCFE0A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}