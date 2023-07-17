using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setting_shippings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name_Of_Shipping = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value_Of_shipping = table.Column<int>(type: "int", nullable: false),
                    Number_Of_Days = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting_shippings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setting_Weights",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    weight_shipping = table.Column<double>(type: "float", nullable: false),
                    Extra_weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting_Weights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VillageShippings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillageShippings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regular_Shipping = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Id_Governate = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Governates_Id_Governate",
                        column: x => x.Id_Governate,
                        principalTable: "Governates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Id_city = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Cities_Id_city",
                        column: x => x.Id_city,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Branch = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    type_of_discount = table.Column<int>(type: "int", nullable: true),
                    company_percantage = table.Column<int>(type: "int", nullable: true),
                    Representive_Id_Branch = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Governate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Per_Rejected_order = table.Column<double>(type: "float", nullable: true),
                    Id_City = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Trader_Id_Branch = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Trader_Id_Governate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Branches_Id_Branch",
                        column: x => x.Id_Branch,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Branches_Representive_Id_Branch",
                        column: x => x.Representive_Id_Branch,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Branches_Trader_Id_Branch",
                        column: x => x.Trader_Id_Branch,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Cities_Id_City",
                        column: x => x.Id_City,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Governates_Id_Governate",
                        column: x => x.Id_Governate,
                        principalTable: "Governates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Governates_Trader_Id_Governate",
                        column: x => x.Trader_Id_Governate,
                        principalTable: "Governates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id_Order = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    orderStatus = table.Column<int>(type: "int", nullable: false),
                    Client_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Governate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_City = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Branch = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Village_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    flag_of_villagee = table.Column<bool>(type: "bit", nullable: false),
                    Id_representive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentivesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Trader = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total_weight = table.Column<double>(type: "float", nullable: false),
                    OrderShippingTotalCost = table.Column<double>(type: "float", nullable: false),
                    ProductTotalCost = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ShippingTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Setting_WeightId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VillageShippingId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id_Order);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_Id_Trader",
                        column: x => x.Id_Trader,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_RepresentivesId",
                        column: x => x.RepresentivesId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Branches_Id_Branch",
                        column: x => x.Id_Branch,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Cities_Id_City",
                        column: x => x.Id_City,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Governates_Id_Governate",
                        column: x => x.Id_Governate,
                        principalTable: "Governates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Setting_Weights_Setting_WeightId",
                        column: x => x.Setting_WeightId,
                        principalTable: "Setting_Weights",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Setting_shippings_ShippingTypeId",
                        column: x => x.ShippingTypeId,
                        principalTable: "Setting_shippings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_VillageShippings_VillageShippingId",
                        column: x => x.VillageShippingId,
                        principalTable: "VillageShippings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Special_Price_Traders",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Id_Trader = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_city = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Governate = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Special_Price_Traders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Special_Price_Traders_AspNetUsers_Id_Trader",
                        column: x => x.Id_Trader,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Special_Price_Traders_Cities_Id_city",
                        column: x => x.Id_city,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Special_Price_Traders_Governates_Id_Governate",
                        column: x => x.Id_Governate,
                        principalTable: "Governates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Orders",
                columns: table => new
                {
                    Id_employee = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Order = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Orders", x => new { x.Id_employee, x.Id_Order });
                    table.ForeignKey(
                        name: "FK_Employee_Orders_AspNetUsers_Id_employee",
                        column: x => x.Id_employee,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Orders_Orders_Id_Order",
                        column: x => x.Id_Order,
                        principalTable: "Orders",
                        principalColumn: "Id_Order",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Id_Order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderId_Order = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Orders_orderId_Order",
                        column: x => x.orderId_Order,
                        principalTable: "Orders",
                        principalColumn: "Id_Order");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id_Branch",
                table: "AspNetUsers",
                column: "Id_Branch");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id_City",
                table: "AspNetUsers",
                column: "Id_City");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id_Governate",
                table: "AspNetUsers",
                column: "Id_Governate");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Representive_Id_Branch",
                table: "AspNetUsers",
                column: "Representive_Id_Branch");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Trader_Id_Branch",
                table: "AspNetUsers",
                column: "Trader_Id_Branch");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Trader_Id_Governate",
                table: "AspNetUsers",
                column: "Trader_Id_Governate");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Id_city",
                table: "Branches",
                column: "Id_city");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Id_Governate",
                table: "Cities",
                column: "Id_Governate");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Orders_Id_Order",
                table: "Employee_Orders",
                column: "Id_Order");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_Branch",
                table: "Orders",
                column: "Id_Branch",
                unique: true,
                filter: "[Id_Branch] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_City",
                table: "Orders",
                column: "Id_City");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_Governate",
                table: "Orders",
                column: "Id_Governate");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_Trader",
                table: "Orders",
                column: "Id_Trader");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RepresentivesId",
                table: "Orders",
                column: "RepresentivesId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Setting_WeightId",
                table: "Orders",
                column: "Setting_WeightId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingTypeId",
                table: "Orders",
                column: "ShippingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VillageShippingId",
                table: "Orders",
                column: "VillageShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_orderId_Order",
                table: "Products",
                column: "orderId_Order");

            migrationBuilder.CreateIndex(
                name: "IX_Special_Price_Traders_Id_city",
                table: "Special_Price_Traders",
                column: "Id_city");

            migrationBuilder.CreateIndex(
                name: "IX_Special_Price_Traders_Id_Governate",
                table: "Special_Price_Traders",
                column: "Id_Governate");

            migrationBuilder.CreateIndex(
                name: "IX_Special_Price_Traders_Id_Trader",
                table: "Special_Price_Traders",
                column: "Id_Trader");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Employee_Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Special_Price_Traders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Setting_Weights");

            migrationBuilder.DropTable(
                name: "Setting_shippings");

            migrationBuilder.DropTable(
                name: "VillageShippings");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Governates");
        }
    }
}
