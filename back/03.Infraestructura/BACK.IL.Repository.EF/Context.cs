using BACK.CORE.Entities;
using BACK.IL.Repository.EF.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BACK.IL.Repository.EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}