using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialPush : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "facility",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Icon = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facility", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "housetype",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_housetype", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "nearbyattraction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearbyattraction", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "guesthouse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ContactNumber = table.Column<long>(nullable: false),
                    Info = table.Column<string>(maxLength: 150, nullable: false),
                    IsPremium = table.Column<bool>(nullable: false),
                    IsHot = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    HouseTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guesthouse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_guesthouse_housetype_HouseTypeID",
                        column: x => x.HouseTypeID,
                        principalTable: "housetype",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_guesthouse_location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "houseattraction",
                columns: table => new
                {
                    GuestHouseId = table.Column<int>(nullable: false),
                    NearbyAttractionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_houseattraction", x => new { x.GuestHouseId, x.NearbyAttractionId });
                    table.ForeignKey(
                        name: "FK_houseattraction_guesthouse_GuestHouseId",
                        column: x => x.GuestHouseId,
                        principalTable: "guesthouse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_houseattraction_nearbyattraction_NearbyAttractionId",
                        column: x => x.NearbyAttractionId,
                        principalTable: "nearbyattraction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "housefacility",
                columns: table => new
                {
                    GuestHouseId = table.Column<int>(nullable: false),
                    FacilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_housefacility", x => new { x.GuestHouseId, x.FacilityId });
                    table.ForeignKey(
                        name: "FK_housefacility_facility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "facility",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_housefacility_guesthouse_GuestHouseId",
                        column: x => x.GuestHouseId,
                        principalTable: "guesthouse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_guesthouse_HouseTypeID",
                table: "guesthouse",
                column: "HouseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_guesthouse_LocationId",
                table: "guesthouse",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_houseattraction_NearbyAttractionId",
                table: "houseattraction",
                column: "NearbyAttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_housefacility_FacilityId",
                table: "housefacility",
                column: "FacilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "houseattraction");

            migrationBuilder.DropTable(
                name: "housefacility");

            migrationBuilder.DropTable(
                name: "nearbyattraction");

            migrationBuilder.DropTable(
                name: "facility");

            migrationBuilder.DropTable(
                name: "guesthouse");

            migrationBuilder.DropTable(
                name: "housetype");

            migrationBuilder.DropTable(
                name: "location");
        }
    }
}
