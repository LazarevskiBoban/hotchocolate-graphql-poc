using AutoMapper;
using HotChocolate.Core.Mapper;

namespace HotChocolate.GraphQLAPI.Registrations
{
    public static class MapperRegistrations
    {
        public static void RegisterAutoMapper(this WebApplicationBuilder builder)
        {
            IMapper mapper = ProfileMapper.Configure();

            builder.Services.AddSingleton(mapper);
        }
    }
}