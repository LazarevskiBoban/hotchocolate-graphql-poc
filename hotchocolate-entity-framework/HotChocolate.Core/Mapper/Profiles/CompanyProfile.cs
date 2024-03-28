using AutoMapper;
using HotChocolate.Core.Models.Entities;
using HotChocolate.Core.Models.GraphQL;

namespace HotChocolate.Core.Mapper.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>()
                .ReverseMap();
        }
    }
}