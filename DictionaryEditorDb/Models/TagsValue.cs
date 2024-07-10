namespace DictionaryEditorDb.Models
{
    public class TagsValue
    {
        public Guid Id { get; set; }
        public Tag Tag { get; set; }
        public string Value { get; set; }
        public VocabularyItem VocabularyItem { get; set; }
        public Guid VocabularyItemId { get; set; }
    }
}
