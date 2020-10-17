using DataAccess.Interfaces;
using DataStructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class GuestHouseFacilityRepository : IGuestHouseFacilityRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public GuestHouseFacilityRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<GuestHouseFacility> GuestHouseFacilities => _appDbContext.GuestHouseFacilities.Include(c => c.GuestHouse);
    }
}
