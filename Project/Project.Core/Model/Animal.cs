using Project.Core.Enums;
using Project.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model;

public class Animal:BaseEntity
{
    public string Title { get; set; }  
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public Gender Gender { get; set; }  
    public string Color { get; set; }
    public decimal Weight { get; set; }  
}
