using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeProductsМVC.Models
{
    [Table("fridge_products")]
    public class FridgeProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int? DefaultQuantity { get; set; }
    }
}
