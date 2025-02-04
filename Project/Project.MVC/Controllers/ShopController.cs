using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstraction;

namespace Project.MVC.Controllers;

public class ShopController(IProductService _service) : Controller
{
    public async Task <IActionResult> OurShop()
    {

        var result=await _service.GetAllAsync();
        return View(result);
    }
    public IActionResult ShopDetails()
    {
        return View();
    }
}
