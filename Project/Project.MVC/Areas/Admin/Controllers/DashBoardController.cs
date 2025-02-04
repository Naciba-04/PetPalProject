using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class DashBoardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
