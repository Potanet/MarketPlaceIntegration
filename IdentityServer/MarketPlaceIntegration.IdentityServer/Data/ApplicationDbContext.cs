using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MarketPlaceIntegration.IdentityServer.Models;

namespace MarketPlaceIntegration.IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Scaffold-DbContext "Server=94.138.223.70;database=ERP;user=ERPUser;password=Erp?2021!;" Microsoft.EntityFrameworkCore.SqlServer -f -v -o Models -context "AppDBContext"
                optionsBuilder.UseSqlServer("Server=DESKTOP-OI4A2E8;Database=identityDB;User=sa;Password=H@lit594");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Marketplace> Marketplace { get; set; }
        public DbSet<MarketplaceLogin> MarketplaceLogin { get; set; }
        public DbSet<UserMarketplace> UserMarketplaces { get; set; }
    }
}
