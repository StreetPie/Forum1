using Forum1.Models.DBContext;
using Forum1.Models.DBModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Forum1.ViewModels;

namespace Forum1.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly ForumContext _context;

        public AuthorizationController(ForumContext context)
        {
            _context = context;
        }

        public string EncryptPassword(string password)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = SHA512.HashData(inputBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "");
            return hash;
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = EncryptPassword(enteredPassword);
            return enteredHash.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var viewModel = _context.UserAccounts
                    .FirstOrDefault(u => u.AccountId.ToString() == userId);

                if (viewModel == null)
                {
                    // Обработка случая, если пользователя с указанным Id не найдено
                    return NotFound();
                }

                return View(viewModel);
            }
            else
            {
                // Обработка случая, если пользователь не аутентифицирован
                return RedirectToAction("Login", "Authorization"); // Перенаправление на страницу входа
            }
        }

        private async Task Authenticate(UserAccount user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name),
                new Claim(ClaimTypes.NameIdentifier, user.AccountId.ToString()),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

            // После успешной аутентификации перенаправляем пользователя на главную страницу
            Response.Redirect("/Home/Index");
        }

        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var existingAccount = _context.UserAccounts.FirstOrDefault(a => a.Login == model.Login);

                if (existingAccount != null)
                {
                    ViewBag.ErrorMessage = "Пользователь с таким логином уже существует.";
                    return View(model);
                }

                var userRole = _context.Roles.FirstOrDefault(q => q.Name == "Пользователь");
                if (userRole != null)
                {
                    var user = new UserAccount
                    {
                        Login = model.Login,
                        Password = EncryptPassword(model.Password),
                        Role = userRole,
                        RegistrationDate = DateTime.UtcNow // Пример даты регистрации
                    };

                    _context.UserAccounts.Add(user);
                    _context.SaveChanges();

                }
                else
                {
                    ViewBag.ErrorMessage = "Роль 'Пользователь' не найдена.";
                    return View(model);
                }
                return RedirectToAction("Login");
            }

            return View("Registration", model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Login == model.Login);

                if (user != null && VerifyPassword(model.Password, user.Password))
                {
                    await Authenticate(user); // аутентификация
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.ErrorMessage = "Неверный логин или пароль";
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Profile()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId = Convert.ToInt32(userIdString);
            var user = _context.UserAccounts.FirstOrDefault(u => u.AccountId == userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // Действие для обновления профиля пользователя
        [HttpPost]
        public IActionResult UpdateProfile(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userId = Convert.ToInt32(userIdString);
                var user = _context.UserAccounts.FirstOrDefault(u => u.AccountId == userId);

                if (user != null)
                {
                    user.Email = model.Email;
                    user.FullName = model.FullName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.DateOfBirth = model.DateOfBirth;

                    _context.SaveChanges();

                    return RedirectToAction("Profile");
                }
            }

            // Если ModelState не валиден, вернуть представление с ошибкой
            ViewBag.ErrorMessage = "Произошла ошибка при сохранении данных пользователя.";
            return View("Profile", model);
        }
    }
    }

