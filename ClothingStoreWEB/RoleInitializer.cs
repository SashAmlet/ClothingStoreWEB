using ClothingStoreWEB.Models;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace CounterWeb
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //roleManager.DeleteAsync(await roleManager.FindByNameAsync("user"));
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("seller") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("seller"));
            }
            if (await roleManager.FindByNameAsync("customer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }
        }

    }
}
