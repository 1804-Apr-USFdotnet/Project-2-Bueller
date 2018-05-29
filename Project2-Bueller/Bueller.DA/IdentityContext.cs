using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext() : base("IdentityDb")
        {

        }
    }
}
