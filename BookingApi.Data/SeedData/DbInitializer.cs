namespace BookingApi.Data.SeedData
{
    using BookingAPI.Models.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
           if (!context.Roles.Any())
                {
                    context.Roles.AddRange(Roles.Select(c => c.Value));
                }
            context.SaveChanges();

           if (!context.Facilities.Any())
                {
                    context.Facilities.AddRange(Facilities.Select(c => c.Value));
                }
            context.SaveChanges();

            if (!context.LocationTypes.Any())
            {
                context.LocationTypes.AddRange(Locations.Select(c => c.Value));
            }
            context.SaveChanges();

            if (!context.Users.Any())
            {
                context.Users.AddRange(Users.Select(c => c.Value));
            }
            context.SaveChanges();
        }

        // Seed For Roles
        private static Dictionary<string, Role> roles;
        public static Dictionary<string, Role> Roles
        {
            get
            {
                if (roles == null)
                {
                    var roleList = new Role[]
                    {
                        new Role { Name = "User", Info = "Every new user get this role" },
                        new Role { Name = "Admin", Info = "Only the administrators have this role" }
                    };

                    roles = new Dictionary<string, Role>();

                    foreach (Role role in roleList)
                    {
                        roles.Add(role.Name, role);
                    }
                }
                return roles;
            }
        }
       
        // Seed for Facility
        private static Dictionary<string, Facility> facilities;
        public static Dictionary<string, Facility> Facilities
        {
            get
            {
                if (facilities == null)
                {
                    var facilityList = new Facility[]
                    {
                        new Facility { Name = "Gym", Info = "People can lift weights and stay in shape!" },
                        new Facility { Name = "Spa", Info = "You relax and chill in here!" },
                        new Facility { Name = "Swimming Pool", Info = "People can swim and stay in shape!" },
                        new Facility { Name = "Restaurant", Info = "Don't forget to tip the waitress." }
                    };

                    facilities = new Dictionary<string, Facility>();

                    foreach (Facility facility in facilityList)
                    {
                        facilities.Add(facility.Name, facility);
                    }
                }
                return facilities;
            }
        }

        // Seed for LocationType

        private static Dictionary<string, LocationType> locations;
        public static Dictionary<string, LocationType> Locations
        {
            get
            {
                if (locations == null)
                {
                    var locationList = new LocationType[]
                    {
                        new LocationType { Name = "Sea", Info = "The hotel is located near a sea" },
                        new LocationType { Name = "Mountain", Info = "The hotel is located near a mountain or on top of montain" },
                        new LocationType { Name = "City", Info = "The hotel is located inside a city." },
                        new LocationType { Name = "Village", Info = "Usually a place with no trafic and very relaxing" }
                    };

                    locations = new Dictionary<string, LocationType>();

                    foreach (LocationType location in locationList)
                    {
                        locations.Add(location.Name, location);
                    }
                }
                return locations;
            }
        }

        // Seed for User - Creates Admin

        private static Dictionary<string, User> users;
        public static Dictionary<string, User> Users
        {
            get
            {
                if (users == null)
                {
                    var userList = new User[]
                    {
                        new User { Username = "admin", FirstName = "Admin", LastName = "Admin", PhoneNumber = "+359877900718", Role = Roles["Admin"],
                                    PasswordSalt = new HMACSHA512().Key,
                                    PasswordHash = new HMACSHA512().ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin"))
                    } };
            

                    users = new Dictionary<string, User>();

                    foreach (User user in userList)
                    {
                        users.Add(user.Username, user);
                    }
                }
                return users;
            }
        }
    }
}