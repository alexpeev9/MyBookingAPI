namespace BookingApi.Data.Repositories.Interfaces
{
    using BookingAPI.Models.DtoModels.HotelDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    public interface IHotelRepository
    {
        List<HotelModel> GetAll { get; }
        HotelModel GetById(int id);
        DbSet<Hotel> Hotels { get; }
        User FindUser(int id);
        LocationType FindLocation(int id);
        public void Save();
    }
}
