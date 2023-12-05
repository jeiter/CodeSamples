using AutoMapper;
using Library.Core.Models;
using Library.Data.Adapters.Sql.Models;

namespace Library.Data.Adapters.Sql.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookEntity>();
    }
}
