using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Icon = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HouseTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NearbyAttractions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NearbyAttractions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GuestHouses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ContactNumber = table.Column<int>(nullable: false),
                    Info = table.Column<int>(nullable: false),
                    IsPremium = table.Column<bool>(nullable: false),
                    IsHot = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    HouseTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestHouses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GuestHouses_HouseTypes_HouseTypeID",
                        column: x => x.HouseTypeID,
                        principalTable: "HouseTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestHouses_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestHouseFacilities",
                columns: table => new
                {
                    GuestHouseId = table.Column<int>(nullable: false),
                    FacilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestHouseFacilities", x => new { x.GuestHouseId, x.FacilityId });
                    table.ForeignKey(
                        name: "FK_GuestHouseFacilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestHouseFacilities_GuestHouses_GuestHouseId",
                        column: x => x.GuestHouseId,
                        principalTable: "GuestHouses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestHouseNearbyAttractions",
                columns: table => new
                {
                    GuestHouseId = table.Column<int>(nullable: false),
                    NearbyAttractionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestHouseNearbyAttractions", x => new { x.GuestHouseId, x.NearbyAttractionId });
                    table.ForeignKey(
                        name: "FK_GuestHouseNearbyAttractions_GuestHouses_GuestHouseId",
                        column: x => x.GuestHouseId,
                        principalTable: "GuestHouses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestHouseNearbyAttractions_NearbyAttractions_NearbyAttractionId",
                        column: x => x.NearbyAttractionId,
                        principalTable: "NearbyAttractions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestHouseFacilities_FacilityId",
                table: "GuestHouseFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestHouseNearbyAttractions_NearbyAttractionId",
                table: "GuestHouseNearbyAttractions",
                column: "NearbyAttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestHouses_HouseTypeID",
                table: "GuestHouses",
                column: "HouseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GuestHouses_LocationId",
                table: "GuestHouses",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestHouseFacilities");

            migrationBuilder.DropTable(
                name: "GuestHouseNearbyAttractions");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "GuestHouses");

            migrationBuilder.DropTable(
                name: "NearbyAttractions");

            migrationBuilder.DropTable(
                name: "HouseTypes");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
