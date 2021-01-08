namespace BookingAPI.Services.Interfaces
{
    using BookingAPI.Models.DtoModels.FacilityDto;
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    public interface IFacilityService
    {
        List<FacilityModel> GetAll();
        FacilityModel GetById(int id);
        Facility Create(Facility facility);
        void Update(Facility user);
        void Delete(int id);
    }
}
