using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectRole.Models.SirSPA
{
    public class ItemA
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, Display(Name = "Product Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        public string Image { get; set; }


        public DateTime EntryDate { get; set; }

        [Required]
        public long Quantity { get; set; }

        [ForeignKey("CategoryA")]
        public long CategoryID { get; set; }


        public virtual CategoryA CategoryA { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
