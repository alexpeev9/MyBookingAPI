namespace DataAccess.Interfaces
{
    using DataStructure.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHouseTypeRepository
    {
        IEnumerable<HouseType> HouseTypes { get; }
    }
}
