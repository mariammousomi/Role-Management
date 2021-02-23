using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectRole.ViewModels
{
    public class ProductV
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Column(TypeName = "Date")]
        [Display(Name = "Issue date")]
        [Required(ErrorMessage = "Issue date is required")]
        public DateTime IssueDate { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageUrl { get; set; }
    }
}
