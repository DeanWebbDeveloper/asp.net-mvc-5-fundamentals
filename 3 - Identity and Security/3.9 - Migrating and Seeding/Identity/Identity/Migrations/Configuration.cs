namespace Identity.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Identity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Identity.Models.ApplicationDbContext";
        }

        protected override void Seed(Identity.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "cwebb"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "cwebb" };

                manager.Create(user, "password");
            }
        }
    }
}
