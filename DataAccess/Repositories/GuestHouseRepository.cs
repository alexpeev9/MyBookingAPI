namespace DataAccess.Repositories
{
    using DataAccess.Interfaces;
    using DataStructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class GuestHouseRepository : IGuestHouseRepository
    {
            private readonly ApplicationDbContext _appDbContext;
            public GuestHouseRepository(ApplicationDbContext appDbContext)
            {
                _appDbContext = appDbContext;
            }
            public IEnumerable<GuestHouse> GuestHouses => _appDbContext.GuestHouses.Include(c => c.Name);
            public IEnumerable<GuestHouse> HotGuestHouses => _appDbContext.GuestHouses.Where(p => p.IsHot);
            public IEnumerable<GuestHouse> PremiumGuestHouses => _appDbContext.GuestHouses.Where(p => p.IsPremium);
        public GuestHouse GetGuestHouseById(int guestHouseId) => _appDbContext.GuestHouses.FirstOrDefault(p => p.ID == guestHouseId);
     }
}
