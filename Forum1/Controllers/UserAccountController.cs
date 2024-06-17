using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum1.Models.DBContext;
using Forum1.Models.DBModels;
using Forum1.Models.DBModels;

namespace Forum1.Controllers
{
    public class UserAccountController(ForumContext context) : Controller
    {
        private readonly ForumContext _context = context;

        // Index action for managing user accounts
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            var userAccounts = await _context.UserAccounts
                .Include(u => u.Role)
                .ToListAsync();

            return View(userAccounts);
        }

        // Delete action for user accounts
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);

            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);

            if (userAccount != null)
            {
                _context.UserAccounts.Remove(userAccount);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // Create action for user accounts
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        public IActionResult Create()
        {
            var roles = _context.Roles.Select(r => new SelectListItem
            {
                Value = r.RoleId.ToString(),
                Text = r.Name
            }).ToList();

            ViewBag.Roles = roles;

            return View();
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.UserAccounts.FirstOrDefaultAsync(u => u.Login == userAccount.Login);

                if (existingUser != null)
                {
                    ModelState.AddModelError("Login", "Учетная запись с таким логином уже существует.");

                    var roles = _context.Roles.Select(r => new SelectListItem
                    {
                        Value = r.RoleId.ToString(),
                        Text = r.Name
                    }).ToList();

                    ViewBag.Roles = roles;

                    return View(userAccount);
                }

                userAccount.LastLogin = DateOnly.FromDateTime(DateTime.Now);
                userAccount.Password = EncryptPassword(userAccount.Password);

                if (userAccount.RoleId != null)
                {
                    var role = await _context.Roles.FindAsync(userAccount.RoleId);

                    if (role != null)
                    {
                        userAccount.Role = role;
                    }
                    else
                    {
                        throw new Exception($"Ошибка создания роли, роль {userAccount.RoleId} не существует");
                    }
                }

                _context.UserAccounts.Add(userAccount);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var rolesList = _context.Roles.Select(r => new SelectListItem
            {
                Value = r.RoleId.ToString(),
                Text = r.Name
            }).ToList();

            ViewBag.Roles = rolesList;

            return View(userAccount);
        }

        // Edit action for user accounts
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts.FindAsync(id);

            if (userAccount == null)
            {
                return NotFound();
            }

            var roles = _context.Roles.Select(r => new SelectListItem
            {
                Value = r.RoleId.ToString(),
                Text = r.Name
            }).ToList();

            ViewBag.Roles = roles;

            return View(userAccount);
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Email,Login,RoleId,LastLogin,Status")] UserAccount userAccount)
        {
            if (id != userAccount.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = await _context.UserAccounts.FindAsync(id);

                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                    existingUser.Login = userAccount.Login;
                    existingUser.Password = userAccount.Password;
                    existingUser.Email = userAccount.Email;
                    existingUser.RoleId = userAccount.RoleId;
                    existingUser.Status = userAccount.Status;
                    existingUser.LastLogin = DateOnly.FromDateTime(DateTime.Now);

                    _context.Update(existingUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            var roles = _context.Roles.Select(r => new SelectListItem
            {
                Value = r.RoleId.ToString(),
                Text = r.Name
            }).ToList();

            ViewBag.Roles = roles;

            return View(userAccount);
        }

        private bool UserAccountExists(int id)
        {
            return _context.UserAccounts.Any(e => e.AccountId == id);
        }

        // Helper method to encrypt password
        private static string EncryptPassword(string password)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = SHA512.HashData(inputBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "");

            return hash;
        }
    }
}
