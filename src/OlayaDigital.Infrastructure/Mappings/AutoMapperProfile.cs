using AutoMapper;
using OlayaDigital.Core.DTOs;
using OlayaDigital.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OlayaDigital.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<User, UserSecurityDto>().ReverseMap();
        }
    }
}
