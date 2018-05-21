using AutoMapper;
using Bueller.DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bueller.DAL.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeAccount, EmployeeAccountDto>().ReverseMap();
        }
    }
}
