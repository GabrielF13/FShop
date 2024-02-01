using Microsoft.AspNetCore.Identity;

namespace FShop.IdentityServer.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = String.Empty;
        public string LasttName { get; set; } = String.Empty;
    }
}
