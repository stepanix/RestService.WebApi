using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
