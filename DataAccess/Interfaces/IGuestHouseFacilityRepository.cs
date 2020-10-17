namespace DataAccess.Interfaces
{
    using DataStructure.Models;
    using System;
    using System.Collections.Generic;

    public interface IGuestHouseFacilityRepository
    {
        IEnumerable<GuestHouseFacility> GuestHouseFacilities { get; }
    }
}
