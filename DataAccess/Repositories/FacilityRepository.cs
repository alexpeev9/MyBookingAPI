namespace DataAccess.Repositories
{
    using DataAccess.Interfaces;
    using DataStructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class FacilityRepository : IFacilityRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public FacilityRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Facility> Facilities => _appDbContext.Facilities.Include(c => c.Name);
    }
}
