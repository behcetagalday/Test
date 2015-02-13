using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public CategoryDTO Category { get; set; }
        public BrandDTO Brand { get; set; }
        public float Discoount { get; set; }
        public int Quantity { get; set; }
        public string Picture { get; set; }
        public int ProductCount { get; set; }
    }
}