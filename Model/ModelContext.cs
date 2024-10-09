using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp25.Model
{
    public class ModelContext: DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbSet <Role> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Test.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
