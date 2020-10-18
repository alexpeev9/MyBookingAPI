using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.RepositoryWrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _appDbContext;
        private ILocationRepository _location;
        public ILocationRepository Location
        {
            get
            {
                if (_location == null)
                {
                    _location = new LocationRepository(_appDbContext);
                }
                return _location;
            }
        }
        
        public RepositoryWrapper(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}