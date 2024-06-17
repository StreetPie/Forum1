using Microsoft.AspNetCore.Mvc;
using Forum1.Models.DBContext;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly ForumContext _context;

    public HomeController(ForumContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        //var posts = _context.ForumPosts.Include(p => p.Profile).ToList(); // Получаем все посты из базы данных с профилями

        if (User.Identity.IsAuthenticated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = _context.UserAccounts
                .FirstOrDefault(u => u.AccountId.ToString() == userId);

            if (viewModel == null)
            {
                return NotFound(); // Обработка случая, если пользователя с указанным Id не найдено
            }

            return View("Home", viewModel);
        }
        else
        {
            return RedirectToAction("Login", "Authorization"); // Перенаправление на страницу входа
        }
    }
}