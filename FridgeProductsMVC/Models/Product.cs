using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeProductsМVC.Models
{
    [Table("products")]
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
    }
}
