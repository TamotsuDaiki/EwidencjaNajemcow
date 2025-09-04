using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EwidencjaNajemcow.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRentalAndApartmentfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Apartments_ApartmentId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Tenants_TenantId",
                table: "Rentals");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Apartments_ApartmentId",
                table: "Rentals",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Tenants_TenantId",
                table: "Rentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Apartments_ApartmentId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Tenants_TenantId",
                table: "Rentals");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Apartments_ApartmentId",
                table: "Rentals",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Tenants_TenantId",
                table: "Rentals",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
