using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public IConfiguration Configuration { get; }

        public ApplicationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MSSQL"));
            base.OnConfiguring(optionsBuilder);
        }


    }
}