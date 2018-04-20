using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using NewsApp.DAL;
using NewsApp.Models;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(NewsApp.Startup))]
namespace NewsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
            CreateCategories();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role1 = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role1);

                var role2 = new IdentityRole
                {
                    Name = "User"
                };
                roleManager.Create(role2);

                var user = new ApplicationUser
                {
                    UserName = "admin@abc.pl",
                    Email = "admin@abc.pl"
                };
                string password = "Admin!2";

                var createdUser = userManager.Create(user, password);

                if (createdUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
        }

        private void CreateCategories() {

            EfDbContext context = new EfDbContext();
            List<string> listCategory = new List<string>
            {
                "top",
                "business",
                "entertainment",
                "health",
                "science",
                "sports",
                "technology"
            };

            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Category]");
            context.SaveChanges();

            foreach (string category in listCategory)
            {
                var categoryObj = new Category
                {
                    name = category
                };
                context.Categories.Add(categoryObj);
                context.SaveChanges();
            }
        }
    }
}
