namespace BookingAPI.Models.DtoModels.LocationTypeDto
{
    using System.Collections.Generic;
    public class LocationTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public List<string> Hotels { get; set; }
    }
}
