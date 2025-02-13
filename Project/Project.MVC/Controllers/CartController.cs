using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.BL.DTOs.BasketDTO;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Contexts;
using System;

namespace Project.MVC.Controllers;

public class CartController(PetPatFinalProjectDbContext _context,IProductService _productService) : Controller
{
    public IActionResult Index()
    {
        BasketDto basket = GetBasket();

        return View(basket);
    }
	[HttpPost]
	public IActionResult AddToBasket(int productId, int quantity)
	{
		Product? product = _context.Products.Find(productId);
		if (product == null)
		{
			return NotFound("Məhsul tapılmadı.");
		}

		var cookieOption = new CookieOptions()
		{
			Expires = DateTime.Now.AddDays(7),
			HttpOnly = true
		};

		BasketDto basket = GetBasket();
		if (basket == null)
		{
			basket = new BasketDto();
		}

		BasketItemDto? existingBasketItem = basket.Items.FirstOrDefault(g => g.Id == product.Id);
		if (existingBasketItem == null)
		{
			
			BasketItemDto basketItemDto = new BasketItemDto()
			{
				Description = product.Description,
				Id = product.Id,
				ImageUrl = product.CoverImageUrl,
				Title = product.Title,
				NewPrice = product.NewPrice, 
				OldPrice = product.OldPrice, 
				DepartmentId = product.DepartmentId,
				Quantity = quantity
			};

			
			if (!product.NewPrice.HasValue)
			{
				basketItemDto.NewPrice = product.OldPrice; 
			}

			basket.Items.Add(basketItemDto);
		}
		else
		{
			
			existingBasketItem.Quantity += quantity;
		}

		var cookieBasket = JsonConvert.SerializeObject(basket);
		Response.Cookies.Append("Basket", cookieBasket, cookieOption);

		return RedirectToAction("OurShop", "Shop");
	}





	public BasketDto GetBasket()
    {
        var basket = Request.Cookies["Basket"];
        if (basket != null)
        {
            BasketDto? existingBasket = JsonConvert.DeserializeObject<BasketDto>(basket);
            return existingBasket;

        }
        return new BasketDto();
    }
  
    public IActionResult RemoveFromBasket(int productId)
    {
        var basket = GetBasket();
        if (basket == null || basket.Items.Count == 0)
        {
            return NotFound("Basket boşdur və ya tapılmadı.");
        }

        var itemToRemove = basket.Items.FirstOrDefault(g => g.Id == productId);
        if (itemToRemove != null)
        {
            basket.Items.Remove(itemToRemove);
            var cookieOption = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            };
            var cookieBasket = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", cookieBasket, cookieOption);
            return Ok();
        }

        return NotFound("Məhsul tapılmadı.");
    }


}

