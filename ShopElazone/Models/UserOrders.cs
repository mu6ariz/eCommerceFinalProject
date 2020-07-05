using Elazone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elazone.Entity
{
    public class UserOrders:EntityBase
    {
        public User User { get; set; }

        public int UserId { get; set; }

        public Products Products { get; set; }

        public int ProductId { get; set; }
    }
}
