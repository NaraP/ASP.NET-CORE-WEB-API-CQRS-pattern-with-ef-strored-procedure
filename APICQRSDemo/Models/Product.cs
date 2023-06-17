using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APICQRSDemo.Models
{
    public partial class Product
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }

    public partial class ProductSp 
    {
        [Key] 
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }
}
