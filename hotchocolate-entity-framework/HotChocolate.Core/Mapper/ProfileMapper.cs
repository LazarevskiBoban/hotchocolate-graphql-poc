using AutoMapper;
using HotChocolate.Core.Mapper.Profiles;

namespace HotChocolate.Core.Mapper
{
    public static class ProfileMapper
    {
        public static IMapper Configure()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new CompanyProfile());
                config.AddProfile(new EmployeeProfile());
            });

            return mapperConfig.CreateMapper();
        }
    }
}