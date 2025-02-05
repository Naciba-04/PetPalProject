using Project.Core.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Model;

public class Rating : BaseEntity
{
    [Range(1, 5)]
    public int Score { get; set; }
    public string? Comment { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}
