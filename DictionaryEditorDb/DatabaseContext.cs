using DictionaryEditorDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryEditorDb
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagsValue> TagsValues { get; set; }
        public DbSet<Vocabulary> Vocabulary { get; set; }
        public DbSet<TranslationAndExample> TranslationsAndExamples { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TranslationAndExample>()
            .HasKey(e => new { e.Word1Id, e.Word2Id });

          

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
            //    modelBuilder.Entity<Product>().HasData(new List<Product>()
            //    {

            //            new Product("Евгений Онегин", "Александр Сергеевич Пушкин", 250, "Описание книги","/images/img1.png"),
            //            new Product("Грозовой Перевал", "Эмили Бронте", 250, "Описание книги","/images/img0.png"),
            //            new Product("Евгения Гранде", "Оноре де Бальзак", 250,"Описание книги", "/images/img2.png"),
            //            new Product("История с кладбищем", "Нил Гейман", 250,"Описание книги", "/images/img3.png"),
            //            new Product("Евгений Онегин", "Александр Сергеевич Пушкин", 250,"Описание книги", "/images/img1.png"),
            //            new Product("Грозовой Перевал", "Эмили Бронте", 250,"Описание книги", "/images/img0.png"),
            //            new Product("Евгения Гранде", "Оноре де Бальзак", 250,"Описание книги", "/images/img2.png"),
            //            new Product("История с кладбищем", "Нил Гейман", 250,"Описание книги", "/images/img3.png"),

            //    });
        }
    }
}
