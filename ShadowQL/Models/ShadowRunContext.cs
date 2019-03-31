using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace ShadowQL.Models
{
    public partial class ShadowRunContext : DbContext
    {
        public ShadowRunContext()
        {
        }

        public ShadowRunContext(DbContextOptions<ShadowRunContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Metatype> Metatypes { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Characters");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Agility).HasColumnName("agility");

                entity.Property(e => e.Charisma).HasColumnName("charisma");

                entity.Property(e => e.Edge).HasColumnName("edge");

                entity.Property(e => e.Essence)
                    .HasColumnName("essence")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.Handle)
                    .HasColumnName("handle")
                    .HasMaxLength(100);

                entity.Property(e => e.IsAwakened).HasColumnName("isAwakened");

                entity.Property(e => e.IsEmerged).HasColumnName("isEmerged");

                entity.Property(e => e.Karma).HasColumnName("karma");

                entity.Property(e => e.KarmaBalance).HasColumnName("karmaBalance");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.Logic).HasColumnName("logic");

                entity.Property(e => e.Metatype).HasColumnName("metatype");

                entity.Property(e => e.PlayerId).HasColumnName("playerId");

                entity.Property(e => e.Strength).HasColumnName("strength");

                entity.Property(e => e.Willpower).HasColumnName("willpower");

                entity.HasOne(d => d.MetatypeNavigation)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.Metatype)
                    .HasConstraintName("FK_Characters_Metatypes");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Characters_Players");
            });

            modelBuilder.Entity<Metatype>(entity =>
            {
                entity.ToTable("Metatypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Players");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);
            });
        }
    }
}
