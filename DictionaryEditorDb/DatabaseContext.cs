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

            //modelBuilder.Entity<TagsValue>()
            //    .HasOne(tv => tv.VocabularyItems)
            //    .WithMany(vi => vi.TagsValue)
            //    .HasForeignKey<VocabularyItem>(vi => vi.TagsValueId);

            modelBuilder.Entity<VocabularyItem>()
                .HasOne(vi => vi.Word)
                .WithMany(w => w.VocabularyItems)
                .HasForeignKey(vi => vi.WordId);

            modelBuilder.Entity<VocabularyItem>()
               .HasOne(vi => vi.TagsValue)
               .WithMany(tv => tv.VocabularyItems)
               .HasForeignKey(vi => vi.TagsValueId);

            modelBuilder.Entity<Language>().HasData(new List<Language>()
            {
                new Language("Russian")
                {
                    Id = Guid.Parse("66be7803-143c-4353-91f6-1642b3cab3a1")
                },
                new Language("Ossetian")
                {
                    Id = Guid.Parse("3e53afc7-71e5-4dc5-8d6a-87a2ce5031bd")
                },
            }) ;

            modelBuilder.Entity<Tag>().HasData(new List<Tag>()
            {
                new Tag("partOfSpeech"){Id = Guid.Parse("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f")},
                new Tag("gender"){Id = Guid.Parse("c9ecd2db-0a26-4070-927f-71bfb8a80b81")},
                new Tag("tense"){Id = Guid.Parse("45c21b89-2c3d-46bd-8c51-48e736d9ba7e")},
              //  new Tag("case"){Id = Guid.Parse("80a5341a-431b-49f0-858f-86feccc457b5")},
                new Tag("number"){Id = Guid.Parse("8403879b-267e-4694-8b1e-f2b31fb058c0")},
            });

            modelBuilder.Entity<TagsValue>().HasData(new List<TagsValue>()
            {
                new TagsValue()
                {
                    Id = Guid.Parse("ce733542-8353-4ab0-8729-7cfdaa621c69"),
                    TagId = Guid.Parse("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), 
                    Value = "существительное"
                },
                new TagsValue(){ Id = Guid.Parse("d8e694f5-0d72-4845-be4c-8de15bb5773e"),TagId = Guid.Parse("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), Value = "Глагол"},
                new TagsValue(){ Id = Guid.Parse("6d1027e4-3540-4ee9-ad67-dd84b0b1e5f2"),TagId = Guid.Parse("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), Value = "Прилагательное"},
                new TagsValue(){ Id = Guid.Parse("a8243201-9fe8-45ff-82d1-211086c049e0"),TagId = Guid.Parse("e1260d2a-e7de-4a22-bd57-622ba0bf4c4f"), Value = "Наречие"},

                new TagsValue(){ Id = Guid.Parse("2b87e731-5927-428d-a995-3146160f33ad"),TagId = Guid.Parse("c9ecd2db-0a26-4070-927f-71bfb8a80b81"), Value = "Мужской"},
                new TagsValue(){ Id = Guid.Parse("1c57ae51-646f-4147-a428-fd6bef86c760"),TagId = Guid.Parse("c9ecd2db-0a26-4070-927f-71bfb8a80b81"), Value = "Женский"},
                new TagsValue(){ Id = Guid.Parse("de073eaf-d3f5-47e3-8f37-59338fe14b2f"),TagId = Guid.Parse("c9ecd2db-0a26-4070-927f-71bfb8a80b81"), Value = "Средний"},

                new TagsValue(){ Id = Guid.Parse("78071fbb-1f19-46a3-a458-e77e906bc4ef"),TagId = Guid.Parse("45c21b89-2c3d-46bd-8c51-48e736d9ba7e"), Value = "past"},
                new TagsValue(){ Id = Guid.Parse("f88a7c76-e882-4dce-9024-9f18e911c34a"),TagId = Guid.Parse("45c21b89-2c3d-46bd-8c51-48e736d9ba7e"), Value = "present"},
                new TagsValue(){ Id = Guid.Parse("b30b749a-35e7-4a7c-8e50-d84c9fcca794"),TagId = Guid.Parse("45c21b89-2c3d-46bd-8c51-48e736d9ba7e"), Value = "future"},

                new TagsValue(){ Id = Guid.Parse("254ea92e-b848-4815-b41b-81dbca1d7ab4"),TagId = Guid.Parse("8403879b-267e-4694-8b1e-f2b31fb058c0"), Value = "plural"},
                new TagsValue(){ Id = Guid.Parse("68d5999f-9d0a-4b5e-80ae-35ca860b8781"),TagId = Guid.Parse("8403879b-267e-4694-8b1e-f2b31fb058c0"), Value = "single"},

               
               
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
