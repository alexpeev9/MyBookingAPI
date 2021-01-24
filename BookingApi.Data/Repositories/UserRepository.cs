namespace BookingApi.Data.Repositories
{
    using BookingApi.Data.Repositories.Interfaces;
    using BookingAPI.Models.AuthenticationDto;
    using BookingAPI.Models.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public UserRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public User FindUser(string username) => _appDbContext.Users.Include(c => c.Role).SingleOrDefault(x => x.Username == username);
        public IEnumerable<UserModel> GetAll => _appDbContext.Users
                 .Include(x => x.Hotels)
                 .Include(x => x.Role)
                 .Select(x => new UserModel()
                 {
                     Id = x.Id,
                     Username = x.Username,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     PhoneNumber = x.PhoneNumber,
                     Role = x.Role.Name,
                     Hotels = x.Hotels.Select(z => z.Name).ToList(),
                 }).ToList();
        public UserModel GetById(int id) => _appDbContext.Users
              .Include(x => x.Hotels)
              .Include(x => x.Role)
              .Select(x => new UserModel()
              {
                  Id = x.Id,
                  Username = x.Username,
                  FirstName = x.FirstName,
                  LastName = x.LastName,
                  PhoneNumber = x.PhoneNumber,
                  Role = x.Role.Name,
                  Hotels = x.Hotels.Select(z => z.Name).ToList(),
              }).Where(x => x.Id == id).FirstOrDefault();
        public DbSet<User> Users => _appDbContext.Users;
        public DbSet<Role> Roles => _appDbContext.Roles;
        public void Save() => _appDbContext.SaveChanges();
    }
}
