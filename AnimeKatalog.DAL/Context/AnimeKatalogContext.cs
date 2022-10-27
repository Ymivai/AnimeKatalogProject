using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AnimeKatalog.DAL.Context
{
    public partial class AnimeKatalogContext : DbContext
    {
        public AnimeKatalogContext()
            : base("name=AnimeKatalogContext")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Anime> Anime { get; set; }
        public virtual DbSet<Avtor> Avtor { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<Ganre> Ganre { get; set; }
        public virtual DbSet<Series> Series { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Anime)
                .WithMany(e => e.Account)
                .Map(m => m.ToTable("AccountAnime").MapLeftKey("AccountID").MapRightKey("AnimeID"));

            modelBuilder.Entity<Anime>()
                .HasMany(e => e.Ganre)
                .WithMany(e => e.Anime)
                .Map(m => m.ToTable("GanreAnime").MapLeftKey("AnimeID").MapRightKey("GanreID"));

            modelBuilder.Entity<Avtor>()
                .HasMany(e => e.Anime)
                .WithOptional(e => e.Avtor1)
                .HasForeignKey(e => e.Avtor);
        }
    }
}
