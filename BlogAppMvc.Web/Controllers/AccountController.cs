using BlogApp.Core.Concrete;
using BlogAppMvc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppMvc.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email, Bio = "Yazar Bilgileri", FirstName = "Ad", LastName = "Soyad", ProfilePicture = "Resim" };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError(string.Empty, "Kullanıcı Adı veya Şifre hatalı.");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult List()
        {
            return View(_userManager.Users);
        }

        public async Task<IActionResult> Update(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null)
            {
                UpdateVM userUpdateVM = new UpdateVM()
                {
                    Id = id,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    Bio = appUser.Bio,
                    ProfilePicture = appUser.ProfilePicture,
                    Email = appUser.Email,
                };
                return View(userUpdateVM);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByIdAsync(updateVM.Id);
                appUser.FirstName = updateVM.FirstName;
                appUser.LastName = updateVM.LastName;
                appUser.Bio = updateVM.Bio;
                appUser.ProfilePicture = updateVM.ProfilePicture;
                appUser.Email = updateVM.Email;
                IdentityResult identityResult = await _userManager.UpdateAsync(appUser);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    foreach (IdentityError item in identityResult.Errors)
                    {
                        TempData["Error"] = $" hata kodu : {item.Code} - açıklama : {item.Description} ";
                    }
                }
            }
            return View(updateVM);
        }

        public async Task<IActionResult> Delete(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser != null)
            {
                IdentityResult identityResult = await _userManager.DeleteAsync(appUser);
                if (identityResult.Succeeded)
                {
                    return RedirectToAction("List");
                }

            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı yok !");
            }
            return View("List");
        }
    }
}
