using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebStatus.Models;

namespace WebStatus.Controllers;

public class HomeController() : Controller
    {
    private const string HealthChecksUiPath = "/healthchecks-ui";
    private const int DefaultResponseCacheDuration = 0;
    public IActionResult Index()
    {
        return Redirect(HealthChecksUiPath);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = DefaultResponseCacheDuration, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
