using System;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace lab_2_library
{
    public class ReadersContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Reader> Readers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        }
    }
}
