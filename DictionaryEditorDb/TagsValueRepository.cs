using DictionaryEditorDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryEditorDb
{
    public class TagsValueRepository
    {
       private readonly DatabaseContext databaseContext;
        public TagsValueRepository(DatabaseContext databaseContext) 
        { 
            this.databaseContext = databaseContext;
        }
        public TagsValue TryGetTagsValue(string tagsValue)
        {
            return databaseContext.TagsValues
               // .Include(tv => tv.Tag)
                .Include(tv => tv.VocabularyItems)
                .ThenInclude(vi => vi.Word)
                .ThenInclude(w => w.Language)
                .FirstOrDefault(x => x.Value == tagsValue);
        }
       
    }
}
