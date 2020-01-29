using AreaManagement.Entity;
using Microsoft.EntityFrameworkCore;

namespace AreaManagement.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TblArea> TblAreas { get; set; }
        public DbSet<TblUser> TblUsers { get; set; }
    }
}
