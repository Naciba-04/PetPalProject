using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs.AppUserDTO;

public class RegisterDto
{
    [Required, MaxLength(32), MinLength(9)]
    public string FullName { get; set; }
    [Required, MaxLength(32), MinLength(3)]
    public string UserName { get; set; }
    [Required, MaxLength(256), EmailAddress]
    public string Email { get; set; }
    [Required, MaxLength(256), DataType(DataType.Password)]
    public string Password { get; set; }
    [Required, MaxLength(256), DataType(DataType.Password), Compare("Password")]
    public string RePassword { get; set; }
}
