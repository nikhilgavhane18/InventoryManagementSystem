using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string? CompanyName { get; set; }

        public string? Address { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}