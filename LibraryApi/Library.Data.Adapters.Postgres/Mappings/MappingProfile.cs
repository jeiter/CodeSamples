using AutoMapper;
using Library.Core.Models;
using Library.Data.Adapters.Postgres.Models;

namespace Library.Data.Adapters.Postgres.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookEntity>().ReverseMap();
    }
}
