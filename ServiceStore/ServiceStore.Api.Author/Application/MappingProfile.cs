using AutoMapper;
using ServiceStore.Api.Author.Models;

namespace ServiceStore.Api.Author.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuthorBook, AuthorDto>();
    }
}