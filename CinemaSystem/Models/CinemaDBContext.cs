using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace CinemaSystem.Models
{
    public partial class CinemaDBContext : DbContext
    {
        public CinemaDBContext()
        {
        }

        public CinemaDBContext(DbContextOptions<CinemaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audithorium> Audithoria { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieRating> MovieRatings { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Screening> Screenings { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CinemaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

         /*   modelBuilder.HasSequence<int>("Employee", schema: "dbo")
                   .StartsAt(0)
                   .IncrementsBy(1);

            modelBuilder.Entity<Employee>()
                .Property(o => o.EmployeeId)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.Order_seq");
         */
            modelBuilder.Entity<Audithorium>(entity =>
            {
                entity.ToTable("Audithorium");

             //   entity.Property(e => e.AudithoriumId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
               
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

              //  entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_Employee_ToTable");
            });

           

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

              //  entity.Property(e => e.MovieId).ValueGeneratedNever();

                entity.Property(e => e.Cast)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Director)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MovieRating).HasColumnName("Movie_Rating");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MovieRatingNavigation)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.MovieRating)
                    .HasConstraintName("FK_Movie_ToTable");
            });

            modelBuilder.Entity<MovieRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__Movie_Ra__FCCDF87C45BE88B9");

                entity.ToTable("Movie_Rating");

             //   entity.Property(e => e.RatingId).ValueGeneratedNever();

                entity.Property(e => e.RatingValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

              //  entity.Property(e => e.PostId).ValueGeneratedNever();

                entity.Property(e => e.PostName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

              //  entity.Property(e => e.ReservationId).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Reservation_ToTable_1");

                entity.HasOne(d => d.Screening)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ScreeningId)
                    .HasConstraintName("FK_Reservation_ToTable");
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.ToTable("Screening");

             //   entity.Property(e => e.ScreeningId).ValueGeneratedNever();

                entity.HasOne(d => d.Audithorium)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.AudithoriumId)
                    .HasConstraintName("FK_Screening_ToTable_1");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Screenings)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_Screening_ToTable");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.ToTable("Seat");

             //   entity.Property(e => e.SeatId).ValueGeneratedNever();

                entity.HasOne(d => d.Audithorium)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.AudithoriumId)
                    .HasConstraintName("FK_Seat_ToTable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
