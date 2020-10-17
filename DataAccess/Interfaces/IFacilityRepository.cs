namespace DataAccess.Interfaces
{
    using DataStructure.Models;
    using System;
    using System.Collections.Generic;

    public interface IFacilityRepository
    {
        IEnumerable<Facility> Facilities { get; }
    }
}
