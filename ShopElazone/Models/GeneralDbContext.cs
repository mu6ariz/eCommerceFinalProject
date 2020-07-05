using Elazone.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopElazone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elazone.Models
{
    public class GeneralDbContext: IdentityDbContext<AppUser, IdentityRole<int>, int>
    {

        public GeneralDbContext(DbContextOptions options) : base(options) { }
            
        public DbSet<UserOrders> UserOrders { get; set; }
       
        
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public  DbSet<Products> Products { get; set; }

        public DbSet<Status> Statuses { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<UserOrders>().HasKey(x => new { x.UserId, x.ProductId });

            modelbuilder.Entity<UserOrders>().HasOne(x => x.Products).WithMany(t => t.UserOrders);

            modelbuilder.Entity<UserOrders>().HasOne(x => x.User).WithMany(t => t.UserOrders);

            base.OnModelCreating(modelbuilder);
        }

    }

    
}
