namespace DataAccess.Repositories
{
    using DataAccess.Interfaces;
    using DataStructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public LocationRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Location> Locations => _appDbContext.Locations.Include(c => c.Name);
    }
}
