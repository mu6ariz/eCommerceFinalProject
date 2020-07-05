using Elazone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elazone.Entity
{
    public class Order:EntityBase
    {
        
        public User User { get; set; }
        [Required]
        public string OrderImage { get; set; }

        public Status Status { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public decimal TotalOrderPrice { get; set; }
        [Required]
        public decimal TotalDiscount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
