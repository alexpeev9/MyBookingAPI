namespace DataAccess.Interfaces
{
    using DataStructure.Models;
    using System;
    using System.Collections.Generic;

    public interface IGuestHouseNearbyAttractionRepository
    {
        IEnumerable<GuestHouseNearbyAttraction> GuestHouseNearbyAttractions { get; }
    }
}
