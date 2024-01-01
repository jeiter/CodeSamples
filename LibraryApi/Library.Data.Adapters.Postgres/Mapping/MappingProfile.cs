using AutoMapper;
using Library.Core.Models;
using Library.Data.Adapters.Postgres.Models;

namespace Library.Data.Adapters.Postgres.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookEntity>()
            .ForMember(b => b.Id, opt => opt.Ignore());
        CreateMap<BookEntity, Book>();
    }
}
