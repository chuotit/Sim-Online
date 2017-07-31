using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimOnline.Model.Models;

namespace SimOnline.Data
{
    public class SimOnlineDbContext : IdentityDbContext<ApplicationUser>
    {
        public SimOnlineDbContext() : base("SimOnline")
        {
            // Cài đặt để khi incluce bảng cha thì tự động include luôn bảng con của nó.
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<SimNetwork> SimNetworks { set; get; }
        public DbSet<FirstNumber> FirstNumbers { set; get; }
        public DbSet<SimNumber> SimNumbers { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<Consigner> Consigners { set; get; }
        public DbSet<ConsignerLevel> ConsignerLevels { set; get; }

        public static SimOnlineDbContext Create()
        {
            return new SimOnlineDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}