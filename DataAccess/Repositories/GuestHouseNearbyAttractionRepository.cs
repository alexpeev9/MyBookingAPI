namespace DataAccess.Repositories
{
    using DataAccess.Interfaces;
    using DataStructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class GuestHouseNearbyAttractionRepository : IGuestHouseNearbyAttractionRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public GuestHouseNearbyAttractionRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<GuestHouseNearbyAttraction> GuestHouseNearbyAttractions => _appDbContext.GuestHouseNearbyAttractions.Include(c => c.GuestHouse);
    }
}
