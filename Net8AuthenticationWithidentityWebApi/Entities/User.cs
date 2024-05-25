using Microsoft.AspNetCore.Identity;

namespace Net8AuthenticationWithidentityWebApi.Entities
{
    public class User : IdentityUser
    {
        public string? FullName {  get; set; }
        public int Contact { get; set; }
        public string? Address { get; set; }

    }
}
