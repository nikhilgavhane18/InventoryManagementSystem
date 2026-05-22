using Microsoft.AspNetCore.Identity;

namespace Inventory.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

        //// FOR SUPPLIER ROLE
        //public int? SupplierId { get; set; }

        //public Supplier? Supplier { get; set; }
    }
}