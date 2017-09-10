namespace SimOnline.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SimOnline.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SimOnline.Data.SimOnlineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SimOnlineDbContext context)
        {
            CreateUser(context);
        }

        private void CreateUser(SimOnlineDbContext context)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new SimOnlineDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SimOnlineDbContext()));

            var user = new AppUser()
            {
                UserName = "admin",
                Email = "simonline@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Admin"

            };
            if (manager.Users.Count(x => x.UserName == "admin") == 0)
            {
                manager.Create(user, "123654$");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByEmail("simonline@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            }

        }
    }
}
