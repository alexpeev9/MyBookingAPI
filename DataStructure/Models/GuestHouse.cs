﻿namespace DataStructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class GuestHouse : Model 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ContactNumber { get; set; }
        [Required]
        public int Info { get; set; }
        [Required]
        public bool IsPremium { get; set; }
        [Required]
        public bool IsHot { get; set; }
        [Required]
        public string Address { get; set; }
        public int LocationId { get; set; }
        // MARK:- One-to-Many Relationships
        public virtual Location Location { get; set; }
        public virtual Type Type { get; set; }
        
        // MARK:- Many-to-Many Relationships
        public ICollection<GuestHouseFacility> GuestHouseFacility { get; set; }
        public ICollection<GuestHouseNearbyAttraction> GuestHouseNearbyAttraction { get; set; }
    }
}
