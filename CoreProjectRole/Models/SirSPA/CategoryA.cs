using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectRole.Models.SirSPA
{
    public class CategoryA
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, Display(Name = "CategoryA")]
        public string Name { get; set; }


        public virtual IList<ItemA> Items { get; set; }
    }
}
