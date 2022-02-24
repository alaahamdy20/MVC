using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Day02.Models
{
    public partial class MVCDBContext : DbContext
    {
        public MVCDBContext()
        {
        }

        public MVCDBContext(DbContextOptions<MVCDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
/*        public virtual DbSet<CourseResult> CourseResults { get; set; }
*/        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instractor> Instractors { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=MVCDBCodeFirstTwo;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseResult>().HasKey(cr => new { cr.CrId, cr.TraineeId });
        }

    }
}
