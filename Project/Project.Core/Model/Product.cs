using Project.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public int Quantity { get; set; }
    public decimal OldPrice { get; set; }
    public decimal? NewPrice { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    
}
