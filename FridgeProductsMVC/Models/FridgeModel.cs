using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FridgeProductsМVC.Models
{
    [Table("fridge_model")]
    public class FridgeModel
    {
        public string Name { get; set; }

        public int? Year { get; set; }
    }
}
