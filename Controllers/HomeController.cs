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

    public IActionResult Index()
    {

        var roles = db.Roles.ToList();
        foreach (var item in roles)
        {
            Console.WriteLine("RoleId =>" + item.Id);
            Console.WriteLine("RoleName =>" + item.Name);
            Console.WriteLine("Controller_Name =>" + item.Controller_Name);
            Console.WriteLine("actionName => " + item.Action_Name);
            Console.WriteLine("===============================================");

        }
        return View();
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
