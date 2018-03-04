using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BikeRental.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    BikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BikeCategory = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(maxLength: 25, nullable: false),
                    DateOfLastService = table.Column<DateTime>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    RentalPriceAdditionalHour = table.Column<double>(nullable: false),
                    RentalPriceHourOne = table.Column<double>(nullable: false),
                    notes = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.BikeID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(type: "Date", nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    HouseNumber = table.Column<string>(maxLength: 10, nullable: true),
                    LastName = table.Column<string>(maxLength: 75, nullable: false),
                    Street = table.Column<string>(maxLength: 75, nullable: false),
                    Town = table.Column<string>(maxLength: 75, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BikeID = table.Column<int>(nullable: false),
                    Costs = table.Column<double>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    RentalBegin = table.Column<DateTime>(nullable: false),
                    RentalEnd = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rentals_Bikes_BikeID",
                        column: x => x.BikeID,
                        principalTable: "Bikes",
                        principalColumn: "BikeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BikeID",
                table: "Rentals",
                column: "BikeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerID",
                table: "Rentals",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
