using Microsoft.EntityFrameworkCore;

using ASPNET_006_Book_Vault.Models;

namespace ASPNET_006_Book_Vault.Data
{
    public class AppDbContext : DbContext
    {
        /*** Constructor ***/
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /*** DB Sets ***/
        public DbSet<Log> Logs { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}