using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
        public DbSet<Customers> Customers {get; set;}
        public DbSet<Orders> Orders {get; set;}
        public DbSet<Products> Products {get; set;}
        public DbSet<Products_description> Products_Descriptions {get; set;}
        public DbSet<Customers_description> Customers_Description {get; set;}
    }
}