using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Top_2000_mvc.Models;
using Owin;
using System.Security.Claims;
using System;

[assembly: OwinStartupAttribute(typeof(Top_2000_mvc.Startup))]
namespace Top_2000_mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }



        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Beheerder"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Beheerder";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                 
            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Gebruiker"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Gebruiker";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "TestBeheerder";
                user.Email = "Testbeheerder@student.rocvantwente.nl";
                string userPWD = "Top2000!";
                var chkUser = UserManager.Create(user, userPWD);
                UserManager.AddToRole(user.Id, "Beheerder");

                var user2 = new ApplicationUser();
                user2.UserName = "TestGebruiker";
                user2.Email = "Testgebruiker@student.rocvantwente.nl";
                string user2PWD = "Top2000!";
                var chkUser2 = UserManager.Create(user2, user2PWD);
                UserManager.AddToRole(user2.Id, "Gebruiker");
            }

        }
    }
}
