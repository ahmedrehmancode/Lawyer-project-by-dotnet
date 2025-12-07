using Microsoft.EntityFrameworkCore;
using MyApp.Model;

namespace MyApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Client> T_Students { get; set; }
        public DbSet<LawyerRegistration> RegisterLawyers { get; set; }
        public DbSet<signup> signupdetail { get; set; }
    }
}
