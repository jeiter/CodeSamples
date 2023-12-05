using AutoMapper;
using Library.Api.Models;
using Library.Core.Models;

namespace Library.Api.Controllers.Mapping;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<Book, BookResponse>();
    }
}

