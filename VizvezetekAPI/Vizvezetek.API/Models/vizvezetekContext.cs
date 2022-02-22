using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Vizvezetek.API.Models
{
    public partial class vizvezetekContext : DbContext
    {
        public vizvezetekContext()
        {
        }

        public vizvezetekContext(DbContextOptions<vizvezetekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<hely> hely { get; set; }
        public virtual DbSet<munkalap> munkalap { get; set; }
        public virtual DbSet<szerelo> szerelo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=localhost;user=root;database=vizvezetek", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<munkalap>(entity =>
            {
                entity.HasOne(d => d.hely)
                    .WithMany(p => p.munkalap)
                    .HasForeignKey(d => d.hely_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("munkalap_ibfk_1");

                entity.HasOne(d => d.szerelo)
                    .WithMany(p => p.munkalap)
                    .HasForeignKey(d => d.szerelo_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("munkalap_ibfk_2");
            });

            modelBuilder.Entity<szerelo>(entity =>
            {
                entity.Property(e => e.id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
