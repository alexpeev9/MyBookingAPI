namespace DataAccess
{
    using DataStructure.Models;
    using System.Collections.Generic;
    using System.Linq;
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {

            if (!context.Locations.Any())
            {
                context.Locations.AddRange(Locations.Select(c => c.Value));
            }
            if (!context.HouseTypes.Any())
            {
                context.HouseTypes.AddRange(HouseTypes.Select(c => c.Value));
            }
            if (!context.NearbyAttractions.Any())
            {
                context.NearbyAttractions.AddRange(NearbyAttractions.Select(c => c.Value));
            }
            if (!context.Facilities.Any())
            {
                context.Facilities.AddRange(Facilities.Select(c => c.Value));
            }
            if (!context.GuestHouses.Any())
            {
                context.GuestHouses.AddRange(GuestHouses.Select(c => c.Value));
            }
            if (!context.GuestHouseFacilities.Any())
            {
                context.GuestHouseFacilities.AddRange(GuestHouseFacilities);
            }
            if (!context.GuestHouseNearbyAttractions.Any())
            {
                context.GuestHouseNearbyAttractions.AddRange(GuestHouseNearbyAttractions);
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Location> locations;
        public static Dictionary<string, Location> Locations
        {
            get
            {
                if (locations == null)
                {
                    var locationList = new Location[]
                    {
                        new Location { Name = "Veliko Tarnovo", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Fortress_at_Veliko_Tarnovo.JPG/250px-Fortress_at_Veliko_Tarnovo.JPG" },
                        new Location { Name = "Sofia", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/74/1-Sofia-parliament-square-ifb.JPG/250px-1-Sofia-parliament-square-ifb.JPG"},
                        new Location { Name = "Burgas", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Burgas%2C_Bulgaria_-_panoramio_%2814%29.jpg/250px-Burgas%2C_Bulgaria_-_panoramio_%2814%29.jpg"}
                    };

                    locations = new Dictionary<string, Location>();

                    foreach (Location location in locationList)
                    {
                        locations.Add(location.Name, location);
                    }
                }
                return locations;
            }  
        }
        private static Dictionary<string, GuestHouse> guestHouses;
        public static Dictionary<string, GuestHouse> GuestHouses
        {
            get
            {
                if (guestHouses == null)
                {
                    var guestHousesList = new GuestHouse[]
                    {
                        new GuestHouse {
                            Name = "Moskito",
                            ContactNumber = 359877900718,
                            Info = "Very goood place where you can rest",
                            IsPremium = true,
                            IsHot = false,
                            Address = "Ledenik",
                            Location = Locations["Veliko Tarnovo"],
                            HouseType = HouseTypes["Vilas"]
                        },
                    };
                    guestHouses = new Dictionary<string, GuestHouse>();

                    foreach (GuestHouse guestHouse in guestHousesList)
                    {
                        guestHouses.Add(guestHouse.Name, guestHouse);
                    }
                }

                return guestHouses;
            }
        }

        private static Dictionary<string, Facility> facilities;
        public static Dictionary<string, Facility> Facilities
        {
            get
            {
                if (facilities == null)
                {
                    var facilitiesList = new Facility[]
                    {
                        new Facility { Name = "Air Conditioner", Icon = "https://img.icons8.com/pastel-glyph/344/air-conditioner--v2.png" },
                        new Facility { Name = "Swimming Pool", Icon = "https://img.icons8.com/cotton/64/000000/swimming-pool--v1.png" },
                        new Facility { Name = "Parking", Icon = "https://img.icons8.com/pastel-glyph/64/000000/parking--v1.png" },
                        new Facility { Name = "Spa", Icon = "https://img.icons8.com/ios-filled/50/000000/spa.png" },
                        new Facility { Name = "Restaurant", Icon = "https://img.icons8.com/android/24/000000/restaurant.png" },

                    };

                    facilities = new Dictionary<string, Facility>();

                    foreach (Facility facility in facilitiesList)
                    {
                        facilities.Add(facility.Name, facility);
                    }
                }

                return facilities;
            }
        }
        private static Dictionary<string, HouseType> housetypes;
        public static Dictionary<string, HouseType> HouseTypes
        {
            get
            {
                if (housetypes == null)
                {
                    var houseTypeList = new HouseType[]
                    {
                        new HouseType { Name = "Cabin", ImageUrl = "https://cf.bstatic.com/static/img/theme-index/carousel_320x240/card-image-chalet_300/8ee014fcc493cb3334e25893a1dee8c6d36ed0ba.jpg" },
                        new HouseType { Name = "Cottage", ImageUrl = "https://cf.bstatic.com/static/img/theme-index/carousel_320x240/bg_cottages/5e1fd9cd716f4825c6c7eac5abe692c52cc64516.jpg" },
                        new HouseType { Name = "Resort", ImageUrl = "https://cf.bstatic.com/static/img/theme-index/carousel_320x240/bg_resorts/6f87c6143fbd51a0bb5d15ca3b9cf84211ab0884.jpg" },
                        new HouseType { Name = "Vilas", ImageUrl = "https://cf.bstatic.com/static/img/theme-index/carousel_320x240/card-image-villas_300/dd0d7f8202676306a661aa4f0cf1ffab31286211.jpg" },

                    };

                    housetypes = new Dictionary<string, HouseType>();

                    foreach (HouseType housetype in houseTypeList)
                    {
                        housetypes.Add(housetype.Name, housetype);
                    }
                }

                return housetypes;
            }
        }
        private static Dictionary<string, NearbyAttraction> nearbyAttractions;
        public static Dictionary<string, NearbyAttraction> NearbyAttractions
        {
            get
            {
                if (nearbyAttractions == null)
                {
                    var nearbyAttractionsList = new NearbyAttraction[]
                    {
                        new NearbyAttraction { Name = "Sea", ImageUrl = "https://arisaigseakayakcentre.co.uk/wp-content/uploads/2014/10/sea-kayak-knoydart-2-300x300.jpg" },
                        new NearbyAttraction { Name = "Mountain", ImageUrl = "https://themes.muffingroup.com/be/tourist/wp-content/uploads/2014/09/home_tourist_gallery6-300x300.jpg" },
                        new NearbyAttraction { Name = "River", ImageUrl = "https://meloman-bg.com/album_src/0825646215478.jpg" },

                    };

                    nearbyAttractions = new Dictionary<string, NearbyAttraction>();

                    foreach (NearbyAttraction nearbyAttraction in nearbyAttractionsList)
                    {
                        nearbyAttractions.Add(nearbyAttraction.Name, nearbyAttraction);
                    }
                }
                return nearbyAttractions;
            }
        }

        private static List<GuestHouseFacility> guestHouseFacilities;
        public static List<GuestHouseFacility> GuestHouseFacilities
        {
            get
            {
                if (guestHouseFacilities == null)
                {
                    var guestHouseFacilitiesList = new GuestHouseFacility[]
                    {
                       new GuestHouseFacility { GuestHouse = GuestHouses["Moskito"] , Facility = Facilities["Air Conditioner"] },
                       new GuestHouseFacility { GuestHouse = GuestHouses["Moskito"] , Facility = Facilities["Parking"] },
                    };

                    guestHouseFacilities = new List<GuestHouseFacility>();

                   foreach (GuestHouseFacility guestHouseFacilitie in guestHouseFacilitiesList)
                    {
                        guestHouseFacilities.Add(guestHouseFacilitie);
                    }
                }
                return guestHouseFacilities;
            }
        }
        private static List <GuestHouseNearbyAttraction> guestHouseNearbyAttractions;
        public static List<GuestHouseNearbyAttraction> GuestHouseNearbyAttractions
        {
            get
            {
                if (guestHouseNearbyAttractions == null)
                {
                    var guestHouseNearbyAttractionsList = new GuestHouseNearbyAttraction[]
                    {
                       new GuestHouseNearbyAttraction { GuestHouse = GuestHouses["Moskito"] , NearbyAttraction = NearbyAttractions["River"] },
                       new GuestHouseNearbyAttraction { GuestHouse = GuestHouses["Moskito"] , NearbyAttraction = NearbyAttractions["Mountain"] },
                    };

                    guestHouseNearbyAttractions = new List<GuestHouseNearbyAttraction>();

                    foreach (GuestHouseNearbyAttraction guestHouseNearbyAttraction in guestHouseNearbyAttractionsList)
                    {
                        guestHouseNearbyAttractions.Add(guestHouseNearbyAttraction);
                    }
                }
                return guestHouseNearbyAttractions;
            }
        }
    }
}
