using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Models
{
   public   class UserAccountDto : BaseEntity
    {

        public int Id { get; set; }
        public string UserName { get; set; }

        public string  password { get; set; }
    }
}
