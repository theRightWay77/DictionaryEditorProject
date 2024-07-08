using DictionaryEditorDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryEditorDb
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagsValue> TagsValues { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
