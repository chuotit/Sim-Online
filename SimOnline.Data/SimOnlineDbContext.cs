using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimOnline.Model.Models;

namespace SimOnline.Data
{
    public class SimOnlineDbContext : IdentityDbContext<AppUser>
    {
        public SimOnlineDbContext() : base("SimOnline")
        {
            // Cài đặt để khi incluce bảng cha thì tự động include luôn bảng con của nó.
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<SimNetwork> SimNetworks { set; get; }
        public DbSet<FirstNumber> FirstNumbers { set; get; }
        public DbSet<SimStore> SimStores { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<Agent> Agents { set; get; }
        public DbSet<AgentLevel> AgentLevels { set; get; }

        public DbSet<AppGroup> AppGroups { set; get; }
        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<AppRoleGroup> AppRoleGroups { set; get; }
        public DbSet<AppUserGroup> AppUserGroups { set; get; }

        public static SimOnlineDbContext Create()
        {
            return new SimOnlineDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("AppUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("AppUserLogins");
            builder.Entity<IdentityRole>().ToTable("AppRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("AppUserClaims");
            builder.Entity<IdentityUser>().ToTable("AppUsers");

            builder.Entity<Agent>().ToTable("Agents");
            builder.Entity<AgentLevel>().HasKey(i=> i.ID).ToTable("AgentLevels");
            builder.Entity<SimStore>().ToTable("SimStores");
        }
    }
}