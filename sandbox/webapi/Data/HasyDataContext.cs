using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Data
{
    public class HastyDataContext : DbContext
    {
        protected HastyDataContext(DbContextOptions options):base(options)
        {
        }

        public HastyDataContext()
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseInMemoryDatabase("Hasty");
    }
}
