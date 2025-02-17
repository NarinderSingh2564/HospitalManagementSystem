using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Web.Models;
using HospitalManagementSystem.Repository.Abstract;

namespace HospitalManagementSystem.Web.Controllers;

public class HomeController : Controller
{
    private readonly IAccountRepository _logger;

    public HomeController(IAccountRepository logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //var kk = _logger.Login("amrit@gmail.com", "admin123");
        return RedirectToAction("Login", "Account");
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
