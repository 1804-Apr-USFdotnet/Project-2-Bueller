using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DA
{

 
    public  class IdentityContext : IdentityDbContext<IdentityUser>
    {


        class MyClass
        {


            static void Main(string[] args)
            {
          
                IdentityContext db = new IdentityContext();
             
                db.SaveChanges();
           
            }
        }
        public IdentityContext() : base("IdentityDb")
        {

        }
    }
}
