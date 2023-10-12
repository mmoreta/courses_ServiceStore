using AutoMapper;
using ServiceStore.Api.Book.Models;

namespace ServiceStore.Api.Book.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookLibrary, BookDto>();
    }
}