namespace DictionaryEditorDb.Models
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Language Language { get; set; }
        public VocabularyItem VocabularyItem { get; set; }
        public Guid VocabularyItemId { get; set; }
    }
}
