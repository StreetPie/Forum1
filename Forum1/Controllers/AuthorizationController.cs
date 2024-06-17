using Forum1.Models.DBContext;
using Forum1.Models.DBModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

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
                // Успешная аутентификация
                await Authenticate(user);
                return RedirectToAction("Profile"); // Перенаправляем на страницу профиля
            }

            // Неверные данные для входа
            ViewBag.ErrorMessage = "Неверный логин или пароль.";
        }

        // Если ModelState не валиден, возвращаем представление с ошибкой
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
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
                    Email = model.Email,
                    FullName = model.FullName,
                    Role = userRole,
                    RegistrationDate = DateTime.UtcNow
                };

                _context.UserAccounts.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login"); // Перенаправляем на страницу входа
            }
            else
            {
                ViewBag.ErrorMessage = "Роль 'Пользователь' не найдена.";
                return View(model);
            }
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

        ViewBag.ErrorMessage = "Произошла ошибка при сохранении данных пользователя.";
        return View("Profile", model);
    }
}
