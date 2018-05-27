using AutoMapper;
using Bueller.DA.Models;
using Bueller.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Repos
{
    public class BookRepo : Crud<Book>
        {
            private readonly IDbContext _context;
            public BookRepo(IDbContext context) : base(context)
            {
                _context = context;
            }

            public IEnumerable<BookDto> GetBookbyClassId(int id)
            {
                var temp = this.Entities.Where(x => x.ClassId == id);
                return Mapper.Map<IEnumerable<BookDto>>(temp);
            }
        

         
        }
    }

