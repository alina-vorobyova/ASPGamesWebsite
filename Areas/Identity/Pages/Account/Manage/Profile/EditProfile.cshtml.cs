using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSearchAsp.Areas.Admin.Helpers;
using GamesSearchAsp.Helpers;
using GamesSearchAsp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSearchAsp.Areas.Identity.Pages.Account.Manage.Profile
{
    public class EditProfileModel : PageModel
    {
        private readonly UserManager<AppUser> userManager;
        private readonly GameAppDbContext context;

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

        [BindProperty]
        public IFormFile ImgFile { get; set; }

        [BindProperty]
        public string ImgUrl { get; set; }


        public EditProfileModel(UserManager<AppUser> userManager, GameAppDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

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
                throw new Exception("User not found");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            //string path = null;
            //if (uploadImg != null)
            //{
            //    path = await FileUploadHelper.UploadFile(uploadImg);
            //    gameProduct.Image = path;
            //}
            //else if (gameProduct.Image != url)
            //{
            //    var pathUrl = await ImageLoader.DownloadFile(url);
            //    gameProduct.Image = pathUrl;
            //}
            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {
                user.UserName = UserName;
                user.Email = Email;
                user.AboutMe = AboutMe;
                user.Birthday = Birthday;
                if (ImgFile != null)
                {
                    var path = await FileUploadHelper.UploadFile(ImgFile);
                    if (user.Image != path)
                    {
                        user.Image = path;
                    }
                }
                else if(user.Image != ImgUrl)
                {
                    var pathUrl = await ImageLoader.DownloadFile(ImgUrl);
                    user.Image = pathUrl;
                    
                }
                await userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                throw new Exception("User not found");
            }
            //return RedirectToRoute($"./Identity/Account/Manage/Profile/EditProfile?id={Id}");
        }
    }
}
