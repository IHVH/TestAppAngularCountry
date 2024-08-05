using AutoMapper;
using TestAppAngularCountry.Server.Mapping;

namespace TestAppAngularCountry.Server.Tests.UnitTests
{
    public class MappingProfileTests
    {
        [Test]
        public void ValidateMappingConfigurationTest()
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
