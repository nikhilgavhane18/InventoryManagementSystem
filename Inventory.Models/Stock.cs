using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventory.Models
{
    public class Stock
    {
        [Key]
        public int SId { get; set; }
        public int PId { get; set; }
        public int Quantity { get; set; }
        public string StockType { get; set; }
    }
}
