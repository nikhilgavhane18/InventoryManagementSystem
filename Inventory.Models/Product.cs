using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(40,
            ErrorMessage = "Product Name cannot exceed 40 characters")]
        public string ProductName { get; set; }

        // FOREIGN KEY
        [Required(ErrorMessage = "Please select category")]
        [Display(Name = "Category")]
        public int CId { get; set; }

        // NAVIGATION PROPERTY
        [ForeignKey("CId")]
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 10000000,
            ErrorMessage = "Price must be between 1 and 10,000,000")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage = "Description is required")]
        //[StringLength(300,
        //    ErrorMessage = "Description cannot exceed 300 characters")]
        public string Description { get; set; }

        public string? ImagePath { get; set; }

        public int Quantity { get; set; } = 1;
    }
}