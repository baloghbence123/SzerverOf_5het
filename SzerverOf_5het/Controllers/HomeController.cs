using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SzerverOf_5het.Data;
using SzerverOf_5het.Models;

namespace SzerverOf_5het.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<SiteUser> userManager;

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<SiteUser> userManager, ILogger<HomeController> logger, ApplicationDbContext db, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            _logger = logger;
            _db = db;
            this._roleManager = roleManager;
        }

        public async Task<IActionResult> DelegateAdmin()
        {
            var principal = this.User;
            var user = await userManager.GetUserAsync(principal);
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(role);
            }
            await userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(_db.Hirdetesek);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Hirdetes hirdetes)
        {
            hirdetes.OwnerId = userManager.GetUserId(this.User);

            
            _db.Hirdetesek.Add(hirdetes);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(string Uid)
        {
            var item = _db.Hirdetesek.FirstOrDefault(t => t.Uid==Uid);
            if (item != null && item.OwnerId == userManager.GetUserId(this.User));
            {
                _db.Hirdetesek.Remove(item);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var principal = this.User;
            var user = await userManager.GetUserAsync(principal);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}