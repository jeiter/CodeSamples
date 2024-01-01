using AutoMapper;
using Library.Data.Adapters.Postgres.Mapping;

namespace Library.Data.Adapters.Postgres.Tests.Mapping;

public class MappingTest
{
    [Fact]
    public void MappingProfile_IsValid()
    {
        // Arrange
        var config = new MapperConfiguration(c => c.AddProfile<MappingProfile>());

        // Act/Assert
        config.AssertConfigurationIsValid();
    }
}
