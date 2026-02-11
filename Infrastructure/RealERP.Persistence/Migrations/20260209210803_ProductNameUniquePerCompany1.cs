using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealERP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductNameUniquePerCompany1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name_CompanyId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_CompanyId",
                table: "Products",
                columns: new[] { "Name", "CompanyId" },
                unique: true,
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name_CompanyId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_CompanyId",
                table: "Products",
                columns: new[] { "Name", "CompanyId" },
                unique: true,
                filter: "[CompanyId] IS NOT NULL");
        }
    }
}
