using AutoMapper;
using Library.Api.Controllers.Mapping;

namespace Library.Api.Controllers.Tests.Mapping;

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