using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webPorjectCS.Models
{
    public class Order
    {
        [Required]
        [Key]
        public string ProductName { set; get; }

        [Required]
        public int OrderAmount { set; get; }

        [Required]
        public string BuyerName { set; get; }

        [Required]
        public DateTime DateOfOrder { set; get; }
    }
}