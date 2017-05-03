using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestService.Domain.Identity
{
    public class UserLogin : IdentityUserLogin
    {
        public int Id { get; set; }
    }
}
