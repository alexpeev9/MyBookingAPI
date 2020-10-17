namespace DataAccess.Interfaces
{
    using DataStructure.Models;
    using System.Collections.Generic;
    public interface INearbyAttractionRepository
    {
        IEnumerable<NearbyAttraction> NearbyAttractions { get; }
    }
}
