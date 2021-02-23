using CoreProjectRole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectRole.ViewModels
{
    public class VmProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<VmProduct> ProductList { get; set; }
    }
}
