

using Microsoft.AspNet.Identity;
using System.Web;


namespace RestService.Service.Services.Base
{
    public class DomainService : IDomainService
    {
        public DomainService()
        {
        }

        public string GetCurrentUserId()
        {
           return HttpContext.Current.User.Identity.GetUserId();
        }

        public string GetCurrentUserName()
        {
            return HttpContext.Current.User.Identity.GetUserName();
        }
    }
}
