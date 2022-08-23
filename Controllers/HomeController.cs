using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Role_Test.Data;
using Role_Test.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Role_Test.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public MyDB db;

    public HomeController(ILogger<HomeController> logger, MyDB _db)
    {
        _logger = logger;
        db = _db;
    }

    public async Task<IActionResult> Index()
    {

        var roles = await db.Roles.ToListAsync();
        var role_list = db.GetRoles();
        if (roles.Count() == 0)
        {
            db.Roles.AddRange(role_list);
            await db.SaveChangesAsync();
        }
        roles = await db.Roles.ToListAsync();
        return View(roles);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
