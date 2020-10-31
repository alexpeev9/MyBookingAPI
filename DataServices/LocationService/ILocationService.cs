namespace DataServices.LocationService
{
    using DataStructure.DtoModels;
    using DataStructure.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    public interface ILocationService
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(int ID);
        LocationDto CreateLocation(LocationForCreationDto location);
        LocationForUpdateDto UpdateLocation(int ID,[FromBody]LocationForUpdateDto location);
        void DeleteLocation(int ID);
    }
}
