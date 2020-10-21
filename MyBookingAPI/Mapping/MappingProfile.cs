namespace MyBookingAPI.Mapping
{
    using AutoMapper;
    using DataStructure.DtoModels;
    using DataStructure.Models;
    using System;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<LocationForCreationDto, Location>();
            CreateMap<LocationForUpdateDto, Location>();
        }
    }
}
