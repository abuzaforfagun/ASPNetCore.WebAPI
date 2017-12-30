using System.Collections.Generic;
using ASPNetCore.WebAPI.Core.Models;
using ASPNetCore.WebAPI.Presistance;
using AutoMapper;

namespace ASPNetCore.WebAPI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<KeyValuePresistance, Author>()
                .ForMember(a => a.BooksLink, opt => opt.Ignore());
            CreateMap<Author, KeyValuePresistance>();
            CreateMap<KeyValuePresistance, Category>().ReverseMap();
            CreateMap<AuthorBook, Book>();
            CreateMap<BookPresistance, Book>()
                .ForMember(b => b.AuthorsLink, opt => opt.Ignore()).ReverseMap();
            

        }
    }
}