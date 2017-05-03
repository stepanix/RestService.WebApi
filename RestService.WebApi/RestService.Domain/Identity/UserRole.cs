using Microsoft.AspNet.Identity.EntityFramework;

namespace RestService.Domain.Identity
{
    public class UserRole : IdentityUserRole
    {
        public int Id { get; set; }
    }
}
