using AutoMapper;
using ContentManagement.Application.Features.Announcements.Dto;
using ContentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentManagement.Application.Common.Mappings
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<Announcement, AnnouncementDto>()
                .ForMember(dest => dest.AuthorUsername, 
                    opt => opt.MapFrom(src => src.Author.Username));

        }
    }
}
