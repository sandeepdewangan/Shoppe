using ShoppeWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shoppe.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double Price { get; set; }

        public int FoodTypeId { get; set; }
        // Navigation
        [ForeignKey("FoodTypeId")]
        public FoodType FoodType { get; set; }

        public int CategoryId { get; set; }
        // Navigation
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
