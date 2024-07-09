using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDb.Models
{
    public class TagsValue
    {
        public Guid Id { get; set; }
        public Tag Tag { get; set; }
        public string Value { get; set; }
    }
}
