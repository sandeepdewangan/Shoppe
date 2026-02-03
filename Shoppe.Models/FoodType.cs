using System.ComponentModel.DataAnnotations;

namespace ShoppeWeb.Models
{
    public class FoodType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
