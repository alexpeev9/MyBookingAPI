using BookingAPI.Models.AuthenticationDto;
using BookingAPI.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApi.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User FindUser(string username);
        IEnumerable<UserModel> GetAll { get; }
        UserModel GetById(int id);
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        void Save();
    }
}
