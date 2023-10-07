using AutoMapper;

namespace Library.Api.Controllers.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
            CreateMap<Core.Models.Book, Models.Book>();
        }
    }
}

