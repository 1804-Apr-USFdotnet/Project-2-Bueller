using Bueller.DA.Models;
using Bueller.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Repos
{
   public  class UserAccountRepo : Crud<UserAccountDto>
    {
        

        private readonly IDbContext _context;
        public UserAccountRepo(IDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
