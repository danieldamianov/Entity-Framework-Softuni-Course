using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Student> Students { get; set; }

        public StudentSystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public StudentSystemContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-B3I8JPR\\SQLEXPRESS;Database=StudentSystemDb;Integrated Security = true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCourse(modelBuilder);
            ConfigureHomework(modelBuilder);
            ConfigureResource(modelBuilder);
            ConfigureStudent(modelBuilder);
            ConfigureStudentCourse(modelBuilder);
        }

        private void ConfigureStudentCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId ,sc.CourseId});

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey("CourseId");

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey("StudentId");
        }

        private void ConfigureStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired(true);

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasColumnType("varchar(10)")
                .IsRequired(false);
        }

        private void ConfigureResource(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasKey(r => r.ResourceId);

            modelBuilder.Entity<Resource>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Resource>()
                .Property(c => c.Url)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey("CourseId");
        }

        private void ConfigureHomework(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>()
                .HasKey(r => r.HomeworkId);

            modelBuilder.Entity<Homework>()
                .Property(h => h.Content)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey("CourseId");

            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey("StudentId");
        }

        private void ConfigureCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId);

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .HasMaxLength(80)
                .IsRequired()
                .IsUnicode();

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode();
        }
    }
}
