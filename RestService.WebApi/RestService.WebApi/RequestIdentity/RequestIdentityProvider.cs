using System;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Threading;

namespace RestService.WebApi.RequestIdentity
{
    public class RequestIdentityProvider : IRequestIdentityProvider
    {
        private string requestId = null;
        private string userId = null;

        public string UserName
        {
            get
            {
                return GetRequestUserName();
            }
        }

        public string UserId
        {
            get
            {
                return GetRequestUserId();
            }
            set
            {
                userId = value;
            }
        }

        private string GetRequestUserId()
        {
            try
            {
                return HttpContext.Current.User.Identity.GetUserId();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string GetRequestUserName()
        {
            var userName = Thread.CurrentPrincipal.Identity.Name;
            if (string.IsNullOrWhiteSpace(userName)) return "Anonymous";
            return userName;
        }

        public void Dispose()
        {
        }
    }
}