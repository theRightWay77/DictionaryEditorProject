using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDb.Models
{
    public class Vocabulary
    {
        public Guid Id { get; set; }
        public Guid WordId { get; set; }
        public TagsValue TagsValueId { get; set; }

    }
}
