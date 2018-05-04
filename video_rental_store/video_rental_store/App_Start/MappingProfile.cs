using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using video_rental_store.Dtos;
using video_rental_store.Models;

namespace video_rental_store.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(p => p.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie,MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(p => p.Id, opt => opt.Ignore());

            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<MemberShipTypeDto, MemberShipType>().ForMember(p => p.Id, opt => opt.Ignore());

            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>().ForMember(p => p.Id, opt => opt.Ignore());
        }
    }
}