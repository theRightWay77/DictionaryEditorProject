using DictionaryEditorDb.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace DictionaryEditorDb
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagsValue> TagsValues { get; set; }
        public DbSet<VocabularyItem> VocabularyItems { get; set; }
        public DbSet<TranslationAndExample> TranslationsAndExamples { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
            //  Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TranslationAndExample>()
            .HasKey(e => new { e.Word1Id, e.Word2Id });

            modelBuilder.Entity<TagsValue>()
                .HasOne(tv => tv.VocabularyItem)
                .WithOne(vi => vi.TagsValue)
                .HasForeignKey<VocabularyItem>(vi => vi.TagsValueId);

            modelBuilder.Entity<VocabularyItem>()
                .HasOne(vi => vi.Word)
                .WithOne(w => w.VocabularyItem)
                .HasForeignKey<Word>(w => w.VocabularyItemId);

            modelBuilder.Entity<Language>().HasData(new List<Language>()
            {
                new Language("Russian"),
                new Language("Ossetian"),
            });

            modelBuilder.Entity<Tag>().HasData(new List<Tag>()
            {
                new Tag("часть речи"),
                new Tag("род"),
                new Tag("время"),
                new Tag("падеж"),
                new Tag("число"),
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
