namespace BookingAPI.Models.DtoModels.FacilityDto
{
    using System.Collections.Generic;
    public class FacilityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }
        public List<string> Hotels { get; set; }
    }
}
