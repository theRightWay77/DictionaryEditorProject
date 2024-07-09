using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDb.Models
{
    public class Language
    {       
        public Guid Id { get; set; }
        public string Value { get; set; } 
        public Language(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
        }
    }
}
