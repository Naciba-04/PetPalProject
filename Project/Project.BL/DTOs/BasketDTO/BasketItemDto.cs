using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.BasketDTO;

public class BasketItemDto
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal? NewPrice { get; set; }
	public decimal? OldPrice { get; set; } 
	public double Price
	{
		get
		{
			Console.WriteLine($"NewPrice: {NewPrice}, OldPrice: {OldPrice}"); 
																			  
			if (NewPrice.HasValue)
			{
				return (double)NewPrice.Value; 
			}

			if (OldPrice.HasValue)
			{
				return (double)OldPrice.Value;  
			}

			return 0;  
		}
	}
	public string ImageUrl { get; set; }
	public int Quantity { get; set; }
}


