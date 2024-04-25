using AutoMapper;
using Employee.Entity.Models;
using Employee.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Common
{
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<EmployeeMaster, EmployeModel>().ForMember(dest => dest.EmployeeAddress, opt => opt.MapFrom(src => src.AddressMasters));
                CreateMap<EmployeeMaster, EmployeModel>().ForMember(dest => dest.EmployeeAddress, opt => opt.MapFrom(src => src.AddressMasters)).ReverseMap();

                CreateMap<AddressMaster, AddressModel>();
                CreateMap<AddressMaster, AddressModel>().ReverseMap();
            }
        }
   
}
