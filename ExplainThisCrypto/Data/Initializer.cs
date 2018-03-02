using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplainThisCrypto.Data
{
    public static class Initializer
    {
        public static async Task Initial(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole("Admin");
                await roleManager.CreateAsync(role);
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                var role = new IdentityRole("User");
                await roleManager.CreateAsync(role);
            }
            if (!await roleManager.RoleExistsAsync("Manager"))
            {
                var role = new IdentityRole("Manager");
                await roleManager.CreateAsync(role);
            }
            if (!await roleManager.RoleExistsAsync("Anonymous"))
            {
                var role = new IdentityRole("Anonymous");
                await roleManager.CreateAsync(role);
            }
        }
    }
}
