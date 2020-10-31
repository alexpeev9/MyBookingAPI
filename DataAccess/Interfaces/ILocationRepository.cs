﻿namespace DataAccess.Interfaces
{
    using DataAccess.RepositoryBase;
    using DataStructure.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocationRepository : IRepositoryBase<Location>
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(int ID);
        void CreateLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(Location location);
    }
}
