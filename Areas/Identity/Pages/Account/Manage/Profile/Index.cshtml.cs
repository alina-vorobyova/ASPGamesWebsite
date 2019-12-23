using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSearchAsp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSearchAsp.Areas.Identity.Pages.Account.Manage.Profile
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> userManager;

        public IndexModel(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Image { get; set; }

        [BindProperty]
        public string AboutMe { get; set; }

        [BindProperty]
        public DateTime Birthday { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {
                Id = user.Id;
                UserName = user.UserName;
                Email = user.Email;
                AboutMe = user.AboutMe;
                Birthday = user.Birthday;
                if (user.Image != null)
                {
                    Image = user.Image;
                }
                else
                {
                    Image = "../../../../../../images/websitebg.jpg";
                }
                return Page();
            }
            else
            {
                throw new Exception("User not found!");
            }
        }
    }
}
