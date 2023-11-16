using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class SystemData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantMenus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Meal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Adults = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<int>(type: "int", nullable: false),
                    Categories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
                    BedType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountsRestaurantMenus",
                columns: table => new
                {
                    AccountsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantMenusId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsRestaurantMenus", x => new { x.AccountsId, x.RestaurantMenusId });
                    table.ForeignKey(
                        name: "FK_AccountsRestaurantMenus_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsRestaurantMenus_RestaurantMenus_RestaurantMenusId",
                        column: x => x.RestaurantMenusId,
                        principalTable: "RestaurantMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Revenue = table.Column<float>(type: "real", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantMenuId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RestaurantMenusId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orderings_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderings_RestaurantMenus_RestaurantMenusId",
                        column: x => x.RestaurantMenusId,
                        principalTable: "RestaurantMenus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountsRooms",
                columns: table => new
                {
                    AccountsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsRooms", x => new { x.AccountsId, x.RoomsId });
                    table.ForeignKey(
                        name: "FK_AccountsRooms_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountsRooms_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revenue = table.Column<float>(type: "real", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_History_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoryStaffs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revenue = table.Column<float>(type: "real", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryStaffs_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryStaffs_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomBookings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomBookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomReviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Evaluation = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomReviews_Accounts_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomReviews_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomsFacilities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Closet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BathRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirConditioner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wifi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialFeatures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomsFacilities_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsRestaurantMenus_RestaurantMenusId",
                table: "AccountsRestaurantMenus",
                column: "RestaurantMenusId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsRooms_RoomsId",
                table: "AccountsRooms",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_History_AccountsId",
                table: "History",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_History_RoomsId",
                table: "History",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryStaffs_AccountsId",
                table: "HistoryStaffs",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryStaffs_RoomsId",
                table: "HistoryStaffs",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_AccountsId",
                table: "Orderings",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderings_RestaurantMenusId",
                table: "Orderings",
                column: "RestaurantMenusId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_RoomId",
                table: "RoomBookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReviews_AccountsId",
                table: "RoomReviews",
                column: "AccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReviews_RoomsId",
                table: "RoomReviews",
                column: "RoomsId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsFacilities_RoomId",
                table: "RoomsFacilities",
                column: "RoomId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsRestaurantMenus");

            migrationBuilder.DropTable(
                name: "AccountsRooms");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "HistoryStaffs");

            migrationBuilder.DropTable(
                name: "Orderings");

            migrationBuilder.DropTable(
                name: "RoomBookings");

            migrationBuilder.DropTable(
                name: "RoomReviews");

            migrationBuilder.DropTable(
                name: "RoomsFacilities");

            migrationBuilder.DropTable(
                name: "RestaurantMenus");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
