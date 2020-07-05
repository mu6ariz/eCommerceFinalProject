using Elazone.Entity;
using ShopElazone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elazone.Models
{
    public class Products:EntityBase
    {

        [Required]
        public int CategoryId { get; set; }
        [Required]

        public Category Category { get; set; }
        [Required]
            
        public string Brand { get; set; }
        [Required]

        public string Model { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Required]

        public string Photo1 { get; set; }

        [Required]

        public string Photo2 { get; set; }

        [Required]

        public string Photo3 { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        [MaxLength(30,ErrorMessage ="Name must be under the 30 symbols")]
        public string OperatingSystem { get; set; }

        public int CoreCount { get; set; }

        public string Processor { get; set; }
        
        public string Vga { get; set; }

        public decimal Price { get; set; }

        public string Color { get; set; }

        public string TypeOfInternalMemory { get; set; }
        public string MemoryInternal { get; set; }
        public decimal Discount { get; set; }

        public int Stock { get; set; }

        public string ScreenSize { get; set; }

        public int Ram { get; set; }

        public string CameraMp { get; set; }
        public string BatteryMah { get; set; }
      
        public bool IsActive { get; set; }

        public int Quantity { get; set; }

        public ICollection<UserOrders> UserOrders { get; set; }
    }
}
