namespace BookingAPI.Models.DtoModels
{
    using AutoMapper;
    using BookingAPI.Models.AuthenticationDto;
    using BookingAPI.Models.DtoModels.FacilityDto;
    using BookingAPI.Models.DtoModels.HotelDto;
    using BookingAPI.Models.DtoModels.HotelFacilityDto;
    using BookingAPI.Models.DtoModels.LocationTypeDto;
    using BookingAPI.Models.Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // User
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            // LocationType
            CreateMap<LocationType, LocationTypeModel>();
            CreateMap<LocationTypeCreateModel, LocationType>();
            CreateMap<LocationTypeUpdateModel, LocationType>();

            //Hotel
            CreateMap<Hotel, HotelModel>();
            CreateMap<HotelCreateModel, Hotel>();
            CreateMap<HotelUpdateModel, Hotel>();

            //HotelFacility
            CreateMap<HotelFacility, HotelFacilityModel>();
            CreateMap<HotelFacilityCreateModel, HotelFacility>();

            // Facility
            CreateMap<Facility, FacilityModel>();
            CreateMap<FacilityUpdateModel, Facility>();
            CreateMap<FacilityCreateModel, Facility>();
            CreateMap<Hotel, HotelFacility>();
                        //.ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.Id))
                        //.ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src));
            //CreateMap<Hotel, HotelModel>();
            //CreateMap<HotelUpdateModel, Hotel>();
            //CreateMap<HotelCreateModel, Hotel>();
                         
                         //.AfterMap((src, dest) => {
                         //    foreach(var b in src.HotelFacilities)
                         //    {
                         //        if(!dest.Hotel.Name.Contains(b.Hotel.Name))
                         //        {

                         //        }
                         //        else
                         //        {
                         //            dest.Hotel = new Hotel { Id = src.Id , Name = src.Name , Info = src.Info };
                         //        }
                         //    }
                         //})
                        //.ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.Id))
                        //.ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src));
        }
    }
}
