using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RentStation.Dtos;
using RentStation.Models;

namespace RentStation.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Game, GameDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Category, CategoryDto>();

            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<GameDto, Game>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}