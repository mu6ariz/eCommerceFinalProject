using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elazone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopElazone.Models;
using ShopElazone.UI.Infrastructure.Attributes;
using ShopElazone.UI.Infrastructure.Extensions;
using SignInNS = Microsoft.AspNetCore.Identity;
namespace ShopElazone.Controllers
{

    public class AccountController : Controller
    {
        private readonly GeneralDbContext _GeneralDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordValidator<AppUser> _password;
        public AccountController(GeneralDbContext GeneralDbContext
                                   , UserManager<AppUser> userManager
                                        , SignInManager<AppUser> signInManager
                                            , IPasswordValidator<AppUser> password)
        {
            _GeneralDbContext = GeneralDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _password = password;
        }

        [HttpGet]
        [ImportModelState]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ExportModelState]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser currentUser = await _userManager.FindByEmailAsync(loginModel.Email);
                var checkPass = _password.ValidateAsync(_userManager, currentUser, loginModel.Password);
                if (currentUser != null && checkPass.Result.Succeeded)
                {
                  SignInNS.SignInResult sgManager = await _signInManager.PasswordSignInAsync(currentUser, loginModel.Password, true,false);
                   
                    if(sgManager.Succeeded)
                    {
                        return RedirectToAction("Index", "DashBoard", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "sign in failed!!");
                        return this.RedirectToSameAction();
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is not correct");
                    return this.RedirectToSameAction();
                }
            }
            else
            {
                return this.RedirectToSameAction();
            }
        }

    }
}