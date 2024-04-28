using Microsoft.EntityFrameworkCore;
using TelephoneСompany.DataBase.DBModel;

namespace TelephoneСompany.DataBase
{
    public class AppDBContext : DbContext
    {
        public DbSet<Abonent> Abonents { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<Street> Streets { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            Database.EnsureCreated();
            Database.Migrate();
        }
    }
}
