using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class Order
    {
        [Key]
        public int OId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal TotalAmount { get; set; }
    }
}
