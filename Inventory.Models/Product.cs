using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        //public int CId { get; set; }

        [Required]
        public string ProductName { get; set; }
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        //public int Quantity { get; set; }
        //public string Description { get; set; }
        //public string ImageUrl { get; set; }


    }
}
