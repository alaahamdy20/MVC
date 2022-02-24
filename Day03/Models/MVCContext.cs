using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Day03.Models
{
    public partial class MVCContext : DbContext
    {
        public MVCContext()
        {
        }

        public MVCContext(DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CrsResult> CrsResults { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=MVC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Degree).HasColumnName("degree");

                entity.Property(e => e.DeptId).HasColumnName("dept-id");

                entity.Property(e => e.Mindegree).HasColumnName("mindegree");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CrsResult>(entity =>
            {
                entity.HasKey(e => new { e.CrsId, e.TraineeId });

                entity.ToTable("Crs_Result");

                entity.Property(e => e.CrsId).HasColumnName("crs-id");

                entity.Property(e => e.TraineeId).HasColumnName("trainee-id");

                entity.Property(e => e.Degree).HasColumnName("degree");

                entity.HasOne(d => d.Crs)
                    .WithMany(p => p.CrsResults)
                    .HasForeignKey(d => d.CrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crs_Result_Course");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.CrsResults)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Crs_Result_Trainee");
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.ToTable("Trainee");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.DeptId).HasColumnName("dept-id");

                entity.Property(e => e.Greade).HasColumnName("greade");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
