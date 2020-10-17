namespace DataAccess.Interfaces
{
    using DataStructure.Models;
    using System.Collections.Generic;
    public interface IGuestHouseRepository
    {
        IEnumerable<GuestHouse> GuestHouses { get; }
        IEnumerable<GuestHouse> HotGuestHouses { get; }
        IEnumerable<GuestHouse> PremiumGuestHouses { get; }
    }
}
