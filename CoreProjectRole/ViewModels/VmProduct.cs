using CoreProjectRole.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectRole.ViewModels
{
    public class VmProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public IFormFile ImgFile { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}
