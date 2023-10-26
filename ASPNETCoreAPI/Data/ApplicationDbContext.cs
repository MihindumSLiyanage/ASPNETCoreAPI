using ASPNETCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }
    }
}
