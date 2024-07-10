namespace DictionaryEditorDb.Models
{
    public class VocabularyItem
    {
        public Guid Id { get; set; }
        public Word Word { get; set; }
        public TagsValue TagsValue { get; set; }
        public Guid TagsValueId { get; set; }

    }
}
