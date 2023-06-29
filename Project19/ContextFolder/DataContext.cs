using Microsoft.EntityFrameworkCore;
using Project19.Entitys;

namespace Project19.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                  DataBase=EntityCoreProject20;
                  Trusted_Connection=True;");
        }
    }
}
