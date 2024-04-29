using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TelephoneСompany.DataBase.DBModel;

namespace TelephoneСompany.DataBase
{
    public class AppDBContext : DbContext
    {
        public DbSet<Abonent> Abonents { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<Street> Streets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}
