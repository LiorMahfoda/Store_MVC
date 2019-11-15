using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace webPorjectCS.Models
{
    public class Product
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        [StringLength (6,MinimumLength=6)]
        [Key]
        public string SN { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}