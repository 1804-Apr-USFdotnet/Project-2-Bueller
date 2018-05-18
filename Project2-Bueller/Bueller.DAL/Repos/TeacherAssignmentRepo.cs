using Bueller.DA;
using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Repos
{
  public  class TeacherAssignmentRepo :   Crud<Assignment>
    {

       
        private   IDbContext db;
        ICrud<Assignment> crud;
        private BuellerContext bueller;

        public TeacherAssignmentRepo(IDbContext context) : base(context)
        {
            db = context;

        }



        //IQueryable<Assignment> ICrud<Assignment>.Table => throw new NotImplementedException();



    }

}
