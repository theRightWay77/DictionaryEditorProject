using DictionaryEditorDb.Models;

namespace DictionaryEditorDb
{
    public class TagsValueRepository
    {
       private readonly DatabaseContext databaseContext;
        public TagsValueRepository(DatabaseContext databaseContext) 
        { 
            this.databaseContext = databaseContext;
        }
      
        public void AddWord(Word word) 
        { 
            databaseContext.Words.Add(word);
            databaseContext.SaveChanges();
        }
    }
}
