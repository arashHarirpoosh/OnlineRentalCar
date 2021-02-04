using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CarRentalProject.Models.ViewModels;

namespace CarRentalProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private RoleManager<IdentityRole> RoleManager;

        public AccountController(UserManager<IdentityUser> userMgr,
                SignInManager<IdentityUser> signInMgr, RoleManager<IdentityRole> roleManager)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            RoleManager = roleManager;
        }

        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                    await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                            loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public ViewResult Signup(string returnUrl)
        {
            return View(new SignupModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(SignupModel signupModel)
        {
            if (ModelState.IsValid)
            {

            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(signupModel);
        }


        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
