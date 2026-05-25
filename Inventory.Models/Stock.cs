using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventory.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        public int PId { get; set; }

        [ForeignKey("PId")]
        public Product? Product { get; set; }

        public int StockQuantity { get; set; }

        public string Status { get; set; }
    }
}
    

