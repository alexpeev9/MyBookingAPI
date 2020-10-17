namespace DataAccess.Interfaces
{
    using DataStructure.Models;
    using System.Collections.Generic;
    public interface ILocationRepository
    {
        IEnumerable<Location> Locations { get; }
    }
}
