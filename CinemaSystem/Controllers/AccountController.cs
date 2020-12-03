using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using CinemaSystem.ViewModels;

namespace RolesApp.Controllers
{
    public class AccountController : Controller
    {
        private CinemaDBContext _context;
        public AccountController(CinemaDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Employee user = await _context.Employees.FirstOrDefaultAsync(u => u.Username == model.Username);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new Employee { Username = model.Username, Password = model.Password };
                    Post userRole = await _context.Posts.FirstOrDefaultAsync(r => r.PostName == "Customer");
                    if (userRole != null)
                        user.Post = userRole;

                    _context.Employees.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); // аутентификаци

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Employee user = await _context.Employees
                    .Include(u => u.Post)
                    .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        private async Task Authenticate(Employee user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Post?.PostName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}