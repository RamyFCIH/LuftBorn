using AutoMapper;
using LuftBorn.Application.Dtos.Books;
using LuftBorn.Domain.Books;
using System.Linq;

namespace LuftBorn.Application.MappingProfiles.Books
{
    public sealed class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<IQueryable<Book>,IQueryable<BookDto>>().ReverseMap(); 
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
