using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webPorjectCS.Models
{
    public class Manager
    {
        [Key]
        [Required]
        public string UserName {  get; set; }

        [Required]
        public string Password { get; set; }

    }
}