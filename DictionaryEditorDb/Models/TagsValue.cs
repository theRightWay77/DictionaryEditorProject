namespace DictionaryEditorDb.Models
{
    public class TagsValue
    {
        public Guid Id { get; set; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
        public string Value { get; set; }
        public List<VocabularyItem> VocabularyItems { get; set; } = new List<VocabularyItem>();
        public TagsValue(Tag tag, string value)
        {
            Id = Guid.NewGuid();
          //  Tag = tag;
            Value = value;
        }
        public TagsValue()
        {
           
        }
    }
}
