using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Repository.Abstaction;

namespace Project.MVC.Controllers;

public class ShopController(IProductService _service,IGenericRepository<Product> _repository) : Controller
{
    public async Task <IActionResult> OurShop()
    {

        var result=await _service.GetAllAsync();
        return View(result);
    }
    public async Task<IActionResult> ShopDetails(int id)
    {
        var result = await _service.GetByIdProductAsync(id);
        return View(result);
    }
}
