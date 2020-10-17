namespace DataAccess.Repositories
{
    using DataAccess.Interfaces;
    using DataStructure.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class HouseTypeRepository : IHouseTypeRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public HouseTypeRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<HouseType> HouseTypes => _appDbContext.HouseTypes.Include(c => c.Name);
    }
}
