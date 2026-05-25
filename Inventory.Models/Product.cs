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

        // CATEGORY FOREIGN KEY
        [Required(ErrorMessage = "Please select category")]
        [Display(Name = "Category")]
        public int CId { get; set; }

        // CATEGORY NAVIGATION PROPERTY
        [ForeignKey("CId")]
        public Category? Category { get; set; }

        // SUPPLIER FOREIGN KEY
        public int? SupplierId { get; set; }

        // SUPPLIER NAVIGATION PROPERTY
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 10000000,
            ErrorMessage = "Price must be between 1 and 10,000,000")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string? ImagePath { get; set; }
        public Stock? Stock { get; set; }
    }
}