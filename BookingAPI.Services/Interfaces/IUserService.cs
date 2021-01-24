namespace BookingAPI.Services.Interfaces
{
    using BookingAPI.Models.AuthenticationDto;
    using BookingAPI.Models.Models;
    using System;
    using System.Collections.Generic;
    public interface IUserService
    {
        Object Authenticate(string username, string password);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
