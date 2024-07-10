namespace DictionaryEditorDb.Models
{
    public class Language
    {       
        public Guid Id { get; set; }
        public string Value { get; set; } 
        public List<Word> Words { get; set; }
        public Language(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }
    }
}
