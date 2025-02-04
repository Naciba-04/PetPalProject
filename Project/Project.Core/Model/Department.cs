using Project.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model;

public class Department:BaseEntity        
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
