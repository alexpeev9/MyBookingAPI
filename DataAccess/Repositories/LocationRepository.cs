namespace DataAccess.Repositories
{
    using DataAccess.Interfaces;
    using DataAccess.RepositoryBase;
    using DataStructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(ApplicationDbContext _appDbContext): base(_appDbContext)
        {
        }
        public IEnumerable<Location> GetAllLocations()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }
        public Location GetLocationById(int ID)
        {
            return FindByCondition(location => location.ID.Equals(ID))
                .FirstOrDefault();
        }
        public void CreateLocation(Location location)
        {
            Create(location);
        }
        public void UpdateLocation(Location location)
        {
            Update(location);
        }
        public void DeleteLocation(Location location)
        {
            Delete(location);
        }
    }
}
