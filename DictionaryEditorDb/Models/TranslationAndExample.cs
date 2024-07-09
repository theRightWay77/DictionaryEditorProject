using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEditorDb.Models
{
    public class TranslationAndExample
    {
       
        public Guid Word1Id { get; set; }
        
        public Guid Word2Id { get; set; }
        public string Example1 { get; set; }
        public string Example2 { get; set; }
    }
}
