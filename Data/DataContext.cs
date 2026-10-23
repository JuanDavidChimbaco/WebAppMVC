// Purpose: This file contains the DataContext class, 
// which is responsible for managing the database context and 
// providing access to the database using Entity Framework Core.
using Microsoft.EntityFrameworkCore;

namespace WebAppMVC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Supplier> Suppliers { get; set; }

    }
}