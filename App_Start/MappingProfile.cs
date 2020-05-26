using AutoMapper;
using MyFitness.Dtos;
using MyFitness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFitness.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Food, foodDto>();
            Mapper.CreateMap<foodDto, Food>();
            Mapper.CreateMap<myFoodDto, MyFood>();
            Mapper.CreateMap<MyFood, myFoodDto>();
        }
    }
}