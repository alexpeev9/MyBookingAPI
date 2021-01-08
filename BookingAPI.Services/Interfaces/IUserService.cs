namespace BookingAPI.Services.Interfaces
{
    using BookingAPI.Models.Models;
    using System;
    using System.Collections.Generic;
    public interface IUserService
    {
        Object Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
