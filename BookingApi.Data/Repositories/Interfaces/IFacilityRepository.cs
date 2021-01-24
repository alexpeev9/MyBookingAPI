namespace BookingApi.Data.Repositories.Interfaces
{
    using BookingAPI.Models.DtoModels.FacilityDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    public interface IFacilityRepository
    {
        List<FacilityModel> GetAll { get; }
        FacilityModel GetById(int id);
        DbSet<Facility> Facilities { get; }
        void Save();
    }
}
