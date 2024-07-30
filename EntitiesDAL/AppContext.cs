using EntitiesDAL.Data;
using EntitiesDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EntitiesDAL
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Country> Countrys { get; set; } = null!;
        public DbSet<Province> Provinces { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var data = InitializationData.GetData();
            modelBuilder.Entity<Country>().HasData(data.Item1);
            modelBuilder.Entity<Province>().HasData(data.Item2);
        }

        public AppContext(DbContextOptions options) : base(options) { }
    }
}
