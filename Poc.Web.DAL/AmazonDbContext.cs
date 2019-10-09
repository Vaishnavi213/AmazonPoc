using Microsoft.EntityFrameworkCore;
using Poc.Web.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Poc.Web.DAL
{
    public class AmazonDbContext:DbContext
    {
        public AmazonDbContext()
        {
        }

        public AmazonDbContext(DbContextOptions<AmazonDbContext> options) : base(options)
        {

        }
        
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CustomerOrderHistory> CustomerOrderHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
                                            optionsBuilder.UseSqlServer(@"Server=XIPL9387\SQLEXPRESS;
                                            Database=AmazonPocDB;
                                            Trusted_Connection=True;");
    } 
}
