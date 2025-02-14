using Azure;
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
        // Məhsulu tapırıq
        var product = _context.Products.Find(productId);
        if (product == null)
        {
            // Məhsul tapılmadısa, səhv yönləndirmə
            return RedirectToAction("Index", "Shop");
        }

        // Səbətə məhsul əlavə edirik
        var basket = GetBasket(); // Burada GetBasket() metodunu istifadə edirik
        var basketItem = basket.Items.FirstOrDefault(i => i.Id == productId);

        if (basketItem == null)
        {
            basket.Items.Add(new BasketItemDto
            {
                Id = productId,
                Title = product.Title,
                NewPrice = product.NewPrice,
                OldPrice = product.OldPrice,
                Quantity = 1,
                ImageUrl= product.CoverImageUrl
            });
        }
        else
        {
            // Məhsul artıq varsa, sayını artırırıq
            basketItem.Quantity += quantity;  // Yeni miqdarı artırırıq
        }

        // Yeni səbət məlumatlarını cookie-yə əlavə edirik
        var basketJson = JsonConvert.SerializeObject(basket);
        Response.Cookies.Append("Basket", basketJson, new CookieOptions
        {
            Expires = DateTime.Now.AddDays(7),
            HttpOnly = true
        });

        // Səbətə əlavə etdikdən sonra istifadəçini səbət səhifəsinə yönləndiririk
        return RedirectToAction("Index", "Cart");
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

	[HttpPost]
	public IActionResult RemoveFromBasket(int productId)
	{
		var basket = GetBasket(); // Basketi əldə edirik
		var basketItem = basket.Items.FirstOrDefault(i => i.Id == productId);

		if (basketItem != null)
		{
			basket.Items.Remove(basketItem); // Məhsulu silirik

			var basketJson = JsonConvert.SerializeObject(basket);
			Response.Cookies.Append("Basket", basketJson, new CookieOptions
			{
				Expires = DateTime.Now.AddDays(7),
				HttpOnly = true
			});

			decimal newTotalPrice = basket.Items.Sum(item => item.NewPrice.HasValue ? item.NewPrice.Value * item.Quantity : item.OldPrice.HasValue ? item.OldPrice.Value * item.Quantity : 0);

			return Json(new { success = true, totalPrice = newTotalPrice });
		}

		return Json(new { success = false });
	}


	[HttpPost]
	public IActionResult UpdateQuantity(int productId, int quantity)
	{
		var basket = GetBasket(); // Basketi əldə edirik
		var basketItem = basket.Items.FirstOrDefault(i => i.Id == productId);

		if (basketItem != null && quantity > 0)  // Müsbət miqdar yoxlanır
		{
			basketItem.Quantity = quantity;

			// Basketi yeniləyirik
			var basketJson = JsonConvert.SerializeObject(basket);
			Response.Cookies.Append("Basket", basketJson, new CookieOptions
			{
				Expires = DateTime.Now.AddDays(7),
				HttpOnly = true
			});

			// Yeni ümumi qiyməti göndəririk
			decimal newTotalPrice = basket.Items.Sum(item => item.NewPrice.HasValue ? item.NewPrice.Value * item.Quantity : item.OldPrice.HasValue ? item.OldPrice.Value * item.Quantity : 0);

			// Hər bir məhsulun yeni qiymətini də döndəririk
			var itemPrices = basket.Items.Select(item => new
			{
				itemId = item.Id,
				itemTotal = item.NewPrice.HasValue ? item.NewPrice.Value * item.Quantity : item.OldPrice.HasValue ? item.OldPrice.Value * item.Quantity : 0
			}).ToList();

			return Json(new { success = true, totalPrice = newTotalPrice, itemPrices });
		}

		return Json(new { success = false });
	}
}


