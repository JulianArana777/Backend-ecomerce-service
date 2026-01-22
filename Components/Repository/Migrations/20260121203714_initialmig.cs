using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBackend.Components.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initialmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    price = table.Column<float>(type: "decimal(18,2)", nullable: false),
                    pictureurl = table.Column<string>(type: "TEXT", nullable: false),
                    producttypeid = table.Column<int>(type: "INTEGER", nullable: false),
                    productbrandid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductsBrand_productbrandid",
                        column: x => x.productbrandid,
                        principalTable: "ProductsBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductsType_producttypeid",
                        column: x => x.producttypeid,
                        principalTable: "ProductsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_productbrandid",
                table: "Products",
                column: "productbrandid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_producttypeid",
                table: "Products",
                column: "producttypeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductsBrand");

            migrationBuilder.DropTable(
                name: "ProductsType");
        }
    }
}
