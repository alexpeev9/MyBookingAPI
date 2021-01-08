namespace BookingAPI.Services
{
    using BookingApi.Data;
    using BookingApi.Data.Exceptions;
    using BookingAPI.Models.AppSettings;
    using BookingAPI.Models.Models;
    using BookingAPI.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Text;
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly AppSettings _appSettings;

        public UserService(ApplicationDbContext appDbContext, IOptions<AppSettings> appSettings)
        {
            _appDbContext = appDbContext;
            _appSettings = appSettings.Value;
        }

        public Object Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _appDbContext.Users.Include(c => c.Role).SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //NameIdentifier
                    new Claim(ClaimTypes.Name, user.Id.ToString()),                  
                    new Claim(ClaimTypes.Role, user.Role.Name),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // authentication successful

            // return basic user info and authentication token
            return new
            {
                user.Id,
                user.Username,
                user.FirstName,
                user.LastName,
                user.Role.Name,
                user.PhoneNumber,
                Token = tokenString
            };
        }

        public IEnumerable<User> GetAll()
        {
            return _appDbContext.Users;
        }

        public User GetById(int id)
        {
            return _appDbContext.Users.Find(id);
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_appDbContext.Users.Any(x => x.Username == user.Username))
                throw new AppException("Username \"" + user.Username + "\" is already taken");

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            // every user Gets role "User"
            var role = _appDbContext.Roles.Where(x => x.Name == "User").FirstOrDefault();

            user.Role = role;

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();

            return user;
        }

        public void Update(User userParam, string password = null)
        {
            var user = _appDbContext.Users.Find(userParam.Id);
            
            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_appDbContext.Users.Any(x => x.Username == userParam.Username))
                    throw new AppException("Username " + userParam.Username + " is already taken");

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
                user.FirstName = userParam.FirstName;

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
                user.LastName = userParam.LastName;

            if (!string.IsNullOrWhiteSpace(userParam.PhoneNumber))
                user.PhoneNumber = userParam.PhoneNumber;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _appDbContext.Users.Update(user);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _appDbContext.Users.Find(id);
            if (user != null)
            {
                _appDbContext.Users.Remove(user);
                _appDbContext.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
    }
}
