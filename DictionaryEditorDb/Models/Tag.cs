namespace DictionaryEditorDb.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public List<TagsValue> TagsValues { get; set; }
        public Tag(string value)
        {
           // Id = Guid.NewGuid();
            Value = value;
        }
        public Tag()
        {
        }
    }
}
