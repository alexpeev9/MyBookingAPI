namespace BookingAPI.Services.Interfaces
{
    using BookingAPI.Models.DtoModels.LocationTypeDto;
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    public interface ILocationTypeService
    {
        List<LocationTypeModel> GetAll();
        LocationTypeModel GetById(int id);
        LocationType Create(LocationType locationType);
        void Update(LocationType locationType);
        void Delete(int id);
    }
}
