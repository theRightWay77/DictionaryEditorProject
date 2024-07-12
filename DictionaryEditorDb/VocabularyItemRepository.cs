using DictionaryEditorDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDb
{
    public class VocabularyItemRepository
    {
        private readonly DatabaseContext databaseContext;
        public VocabularyItemRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void AddWord(VocabularyItem item)
        {
            databaseContext.VocabularyItems.Add(item);
            databaseContext.SaveChanges();
        }
    }
}
