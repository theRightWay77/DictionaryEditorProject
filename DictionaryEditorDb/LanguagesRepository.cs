using DictionaryEditorDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryEditorDb
{
    public class LanguagesRepository
    {
        private readonly DatabaseContext databaseContext;
        public LanguagesRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Language TryGetById(Guid id) 
        {
            return databaseContext.Languages
                .Include(l => l.Words)
                .ThenInclude(w => w.VocabularyItems)
                .ThenInclude(vi => vi.TagsValue)
                .ThenInclude(tv => tv.Tag)
                .FirstOrDefault(l => l.Id == id);
        }
    }
}
