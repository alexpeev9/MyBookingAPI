namespace BookingAPI.Services.Interfaces
{
    using BookingAPI.Models.DtoModels.HotelDto;
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    public interface IHotelService
    {
        List<HotelModel> GetAll();
        HotelModel GetById(int id);
        Hotel Create(Hotel hotel, int userId);
        void Update(Hotel hotel);
        void Delete(int id);
        Hotel FindHotel(int id);
    }
}
