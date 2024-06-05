global using Microsoft.EntityFrameworkCore;
global using Project.Models;

namespace Project.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);


        }

        public DbSet<Items> Items { get; set; }

        public DbSet<Purchase> purchases { get; set; }

        public DbSet<Stocks> stocks { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<Person> persons { get; set; }


    }
}


