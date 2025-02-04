using Project.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Utilities;

public static class RoleExtension
{
    public static string GetRole(this Roles role)
    {
        return role switch
        {
            Roles.Admin => (nameof(Roles.Admin)),
            Roles.User => (nameof(Roles.User))
        };
    }

}
