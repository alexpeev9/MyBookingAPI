namespace DataStructure.DtoModels
{
    using DataStructure.Models;
    using System.Collections.Generic;
    public class LocationDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<GuestHouse> GuestHouses { get; set; }
    }
}
