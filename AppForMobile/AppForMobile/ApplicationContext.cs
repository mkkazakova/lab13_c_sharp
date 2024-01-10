using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AppForMobile
{
    public class ApplicationContext : DbContext
    {
        private string _databasePath;

        public DbSet<Client> Clients { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<PriceOfTariff> PriceOfTariffs { get; set; }

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
