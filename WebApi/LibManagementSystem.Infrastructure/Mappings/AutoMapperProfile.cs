using AutoMapper;
using LibManagementSystem.Infrastructure.DTO;
using LibraryManagementSystem.Domain.Entities;

namespace LibManagementSystem.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<IssueDto, Issue>().ReverseMap();
            CreateMap<CreateIssueDto, Issue>().ReverseMap();
            CreateMap<DeleteIssueDto, Issue>().ReverseMap();
            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<MemberDto, Member>().ReverseMap();
        }
    }
}