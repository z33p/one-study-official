using System.Linq;
using Microsoft.EntityFrameworkCore;
using OneStudy.Lib.Models;

namespace OneStudy.Lib.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<CardDeck> CardsDecks { get; set; }

        public static void ApplyMigrations(DataContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardDeck>().HasKey(cd => new { cd.CardId, cd.DeckId});

            modelBuilder.Entity<CardDeck>()
                .HasOne<Card>(cd => cd.Card)
                .WithMany(s => s.CardDecks)
                .HasForeignKey(cd => cd.CardId);

            modelBuilder.Entity<CardDeck>()
                .HasOne<Deck>(cd => cd.Deck)
                .WithMany(s => s.CardDecks)
                .HasForeignKey(cd => cd.DeckId);
        }
    }
}