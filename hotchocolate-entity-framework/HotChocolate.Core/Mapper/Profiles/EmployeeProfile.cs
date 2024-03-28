using AutoMapper;
using HotChocolate.Core.Models.Entities;
using HotChocolate.Core.Models.GraphQL;

namespace HotChocolate.Core.Mapper.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ReverseMap();
        }
    }
}