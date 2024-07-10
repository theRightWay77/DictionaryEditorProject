using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDb.Models
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Language Language { get; set; }
        public Word(string value)
        {
            Id = Guid.NewGuid();
            Value = value;           
        }
    }
}
