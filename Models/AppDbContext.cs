using Microsoft.EntityFrameworkCore;
using Quote_genarator.Models;
using System.Collections.Generic;

namespace Quote_genarator.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("Quotes");

                entity.HasKey(q => q.Id);

                entity.Property(q => q.Text)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.Property(q => q.Author)
                      .IsRequired()
                      .HasMaxLength(100);

                // Seed some default quotes
                entity.HasData(
                    new Quote { Id = 1, Text = "Stay hungry, stay foolish.", Author = "Steve Jobs" },
                    new Quote { Id = 2, Text = "Imagination is more important than knowledge.", Author = "Albert Einstein" },
                    new Quote { Id = 3, Text = "Be water, my friend.", Author = "Bruce Lee" },
                    new Quote { Id = 4, Text = "Do or do not, there is no try.", Author = "Yoda" }
                );
            });
        }
    }
}