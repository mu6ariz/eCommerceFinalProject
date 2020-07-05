using Elazone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Elazone.Entity
{
    public class User:EntityBase
    {
        public int UserId { get; set; }
        [MaxLength(30,ErrorMessage ="Name length must be under 30 symbol")]
        [Required]
        public string Name { get; set; }
        [MaxLength(30, ErrorMessage = "Name length must be under 30 symbol")]
        public string LastName { get; set; }
        [MaxLength(25, ErrorMessage = "Email length must be under 25 symbol")]
        [Required]
        public string Email { get; set; }

        public string Telephone { get; set; }
        [MinLength(5, ErrorMessage = "Password must contain minimum 5 symbol")]
        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public string Title { get; set; }

        public string City { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Email length must be under 100 symbol")]
        public string Address { get; set; }

        public ICollection<UserOrders> UserOrders { get; set; }


    }
}
