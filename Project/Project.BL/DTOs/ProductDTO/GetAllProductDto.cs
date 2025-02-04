using Microsoft.AspNetCore.Http;
using Project.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.ProductDTO;

public class GetAllProductDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public int Quantity { get; set; }
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string DepartmentName { get; set; }
}
