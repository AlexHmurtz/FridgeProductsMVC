using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeProductsМVC.Models
{
    [Table("fridge")]
    public class Fridge
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid FridgeModelId { get; set; }
        public FridgeModel FridgeModel { get; set; }
    }
}
