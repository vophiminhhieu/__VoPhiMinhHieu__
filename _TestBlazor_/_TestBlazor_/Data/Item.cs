using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _TestBlazor_.Data
{
    

    [Table("item")]
    public class Item
    {
        [Key]
        public string title { get; set; }
        public string note { get; set; }
        public bool important { get; set; }
        public bool done { get; set; }
    }
    
}
