namespace DataAccess.Repositories
{
    using DataAccess.Interfaces;
    using DataStructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class NearbyAttractionRepository : INearbyAttractionRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public NearbyAttractionRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<NearbyAttraction> NearbyAttractions => _appDbContext.NearbyAttractions.Include(c => c.Name);
    }
}
