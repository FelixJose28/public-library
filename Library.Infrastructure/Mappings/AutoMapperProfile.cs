using AutoMapper;
using Library.Core.Models.Dtos;
using Library.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Alert, AlertDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            //CreateMap<BookDocumentPostDto, Book>().ReverseMap().ForMember(dest => dest.Documents, act => act.Ignore());
            CreateMap<BookStatus, BookStatusDto>().ReverseMap();
            CreateMap<LiteraryGender, LiteraryGenderDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<RegisterBook, RegisterBookDto>().ReverseMap();
            CreateMap<Request, RequestDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Telephone, TelephoneDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Login, LoginDto>().ReverseMap();
        }
    }
}
