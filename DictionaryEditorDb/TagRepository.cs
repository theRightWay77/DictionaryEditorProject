using DictionaryEditorDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDb
{  
    public class TagRepository
    {
        private readonly DatabaseContext databaseContext;
        public TagRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Tag TryGetTag(string tagName)
        {
            return databaseContext.Tags
                .Include(t => t.TagsValues)
                .ThenInclude(tv => tv.VocabularyItems)
                .ThenInclude(vi => vi.Word)
                .ThenInclude(w => w.Language)
                .FirstOrDefault(x => x.Value ==  tagName);           
        }
    }
}
