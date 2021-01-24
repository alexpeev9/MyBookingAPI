namespace BookingApi.Data.Repositories.Interfaces
{
    using BookingAPI.Models.DtoModels.LocationTypeDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface ILocationTypeRepository 
    {
        List<LocationTypeModel> GetAllLocations { get; }
        LocationTypeModel GetLocationById(int Id);
        DbSet<LocationType> Locations { get; }
        void Save();
    }
}
