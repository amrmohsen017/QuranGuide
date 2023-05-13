using Microsoft.EntityFrameworkCore;
using QuranGuide.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuranGuide.Data
{
    public class QuranContext : DbContext
    {
        public QuranContext(DbContextOptions<QuranContext> options) : base(options)
        {
        }
        public DbSet<Surah> surahs { get; set; }

        public DbSet<Verse> verses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Verse>()
                  .HasKey(m => new { m.id, m.surahId });

        }
    }
}
