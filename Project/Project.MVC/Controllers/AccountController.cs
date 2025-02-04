using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Project.BL.DTOs.AppUserDTO;
using Project.BL.EmailServices.Abstraction;
using Project.BL.Utilities;
using Project.Core.Enums;
using Project.Core.Model;
using System.Data;

namespace Project.MVC.Controllers;


public class AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<IdentityRole> _roleManager,IEmailService _emailService) : Controller
{
    public bool IsAuthendicated => HttpContext.User.Identity?.IsAuthenticated ?? false;
    public IActionResult Register()
    {

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        AppUser user = new AppUser
        {
            FullName = dto.FullName,
            UserName = dto.UserName,
            Email = dto.Email,
        };
        var userCreate = await _userManager.CreateAsync(user, dto.Password);
        if (!userCreate.Succeeded)
        {
            foreach (var err in userCreate.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View(dto);
        }
        var roleAdd = await _userManager.AddToRoleAsync(user,Roles.User.GetRole());
        if (!roleAdd.Succeeded)
        {
            foreach (var err in roleAdd.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View(dto);
        }
        _emailService.SendWelcome(user.Email);
        return RedirectToAction("Login", "Account");
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto, string? returnUrl = null)
    {
        if (IsAuthendicated) return RedirectToAction("Index", "Home");
        if (!ModelState.IsValid) return View(dto);
        AppUser user = null;
        if (dto.UserNameOrEmail.Contains("@"))
        {
            user = await _userManager.FindByEmailAsync(dto.UserNameOrEmail);
        }
        else
        {
            user = await _userManager.FindByNameAsync(dto.UserNameOrEmail);
        }
        if (user == null)
        {
            ModelState.AddModelError("", "User tapilmadi");
        }
        var sign = await _signInManager.PasswordSignInAsync(user, dto.Password, false, true);
        if (!sign.Succeeded)
        {
            if (sign.IsLockedOut)
            {
                ModelState.AddModelError("", "Siz 1 deqiqelik bloklandiniz");
            }
            if (sign.IsNotAllowed)
            {
                ModelState.AddModelError("", "user veya pasvor yanlishdir");
            }
            return View(dto);
        }
        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> MyRoleMethod()
    {
        var data = await _userManager.FindByNameAsync("admin");
        if (data == null)
        {
            AppUser admin = new AppUser
            {
                FullName = "Admin",
                UserName = "admin",
                Email = "admin@mail.com"
            };
            var createAdmin = await _userManager.CreateAsync(admin, "123456");
            if (!createAdmin.Succeeded)
            {
                return BadRequest("admin yaradilmadi");
            }
            if (!await _roleManager.RoleExistsAsync(Roles.Admin.GetRole()))
            {
                var crad = await _roleManager.CreateAsync(new IdentityRole(Roles.Admin.GetRole()));
                if (!crad.Succeeded)
                {
                    return BadRequest("admin  rolu yaradilmadi");
                }
            }
            var add = await _userManager.AddToRoleAsync(admin, Roles.Admin.GetRole());
            if (!add.Succeeded)
            {
                return BadRequest("admin roluna elave edilmedi ");
            }
        }
        foreach (Roles item in Enum.GetValues(typeof(Roles)))
        {
            var roleName = item.GetRole();
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var crtRole = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (!crtRole.Succeeded)
                {
                    return BadRequest($"{roleName} rolu yaradilmadi");
                }
            }
        }
        return RedirectToAction("Login", "Index");
    }
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
