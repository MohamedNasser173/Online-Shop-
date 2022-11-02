using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductTypes> productTypes { get; set; }
        public DbSet<SpecialTags> specialTags { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } 
    }
}
