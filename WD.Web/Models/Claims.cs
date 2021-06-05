using System.Collections.Generic;
using System.Security.Claims;

namespace WD.Web.Models
{
    public static class Claims
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Role", "Create Role"),
            new Claim("Delete Role", "Delete Role"),
            new Claim("Edit Role", "Edit Role"),
        };
    }
}
