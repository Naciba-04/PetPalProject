using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.BL.DTOs.BasketDTO;
using Project.BL.Services.Abstraction;
using Project.Core.Model;
using Project.DAL.Contexts;
using System;

namespace Project.MVC.Controllers;

public class CartController(PetPatFinalProjectDbContext _context, IProductService _productService) : Controller
{
    public IActionResult Index()
    {
        BasketDto basket = GetBasket();
        return View(basket);
    }

    [HttpPost]
    public IActionResult AddToBasket(int productId, int quantity)
    {
        var product = _context.Products.Find(productId);
        if (product == null)
        {
            return RedirectToAction("Index", "Shop");
        }

        var basket = GetBasket();
        var basketItem = basket.Items.FirstOrDefault(i => i.Id == productId);

        int availableStock = product.Quantity; 

        if (basketItem == null)
        {
            if (quantity > availableStock)
            {
                quantity = availableStock; 
            }

            basket.Items.Add(new BasketItemDto
            {
                Id = productId,
                Title = product.Title,
                NewPrice = product.NewPrice,
                OldPrice = product.OldPrice,
                Quantity = quantity > 0 ? quantity : 1,
                ImageUrl = product.CoverImageUrl
            });
        }
        else
        {
            if (basketItem.Quantity + quantity > availableStock)
            {
                basketItem.Quantity = availableStock; 
            }
            else
            {
                basketItem.Quantity += quantity;
            }
        }

        var basketJson = JsonConvert.SerializeObject(basket);
        Response.Cookies.Append("Basket", basketJson, new CookieOptions
        {
            Expires = DateTime.Now.AddDays(7),
            HttpOnly = true
        });

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
		var basket = GetBasket();
		var basketItem = basket.Items.FirstOrDefault(i => i.Id == productId);

		if (basketItem != null)
		{
			basket.Items.Remove(basketItem); 

			var basketJson = JsonConvert.SerializeObject(basket);
			Response.Cookies.Append("Basket", basketJson, new CookieOptions
			{
				Expires = DateTime.Now.AddDays(7),
				HttpOnly = true
			});

			decimal newTotalPrice = basket.Items.Sum(item =>
				item.NewPrice.HasValue ? item.NewPrice.Value * item.Quantity :
				item.OldPrice.HasValue ? item.OldPrice.Value * item.Quantity : 0);

			return Json(new { success = true, totalPrice = newTotalPrice });
		}

		return Json(new { success = false });
	}


	[HttpPost]
    public IActionResult UpdateQuantity(int productId, int quantity)
    {
        var basket = GetBasket();
        var basketItem = basket.Items.FirstOrDefault(i => i.Id == productId);
        var product = _context.Products.Find(productId);

        if (basketItem != null && product != null)
        {
            int availableStock = product.Quantity; 

            if (quantity > availableStock)
            {
                quantity = availableStock; 
            }

            basketItem.Quantity = quantity > 0 ? quantity : 1; 

            var basketJson = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", basketJson, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            });

            decimal newTotalPrice = basket.Items.Sum(item =>
                item.NewPrice.HasValue ? item.NewPrice.Value * item.Quantity :
                item.OldPrice.HasValue ? item.OldPrice.Value * item.Quantity : 0);

            var itemPrices = basket.Items.Select(item => new
            {
                itemId = item.Id,
                itemTotal = item.NewPrice.HasValue ? item.NewPrice.Value * item.Quantity :
                            item.OldPrice.HasValue ? item.OldPrice.Value * item.Quantity : 0
            }).ToList();

            return Json(new { success = true, totalPrice = newTotalPrice, itemPrices, correctedQuantity = quantity });
        }

        return Json(new { success = false });
    }

}
