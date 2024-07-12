namespace DictionaryEditorDb.Models
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Language Language { get; set; }
        public List<VocabularyItem> VocabularyItems { get; set; } = new List<VocabularyItem>();
        public Word(string value)
        {
            Id = Guid.NewGuid();
            Value = value;      
            
        }
    }
}
