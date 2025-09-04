using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EwidencjaNajemcow.Migrations
{
    /// <inheritdoc />
    public partial class RenameFieldsToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imie",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "KodPocztowy",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "Miasto",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Tenants",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Nazwisko",
                table: "Tenants",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "NumerUmowy",
                table: "Rentals",
                newName: "ContractNumber");

            migrationBuilder.RenameColumn(
                name: "DataOd",
                table: "Rentals",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DataDo",
                table: "Rentals",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "Czynsz",
                table: "Rentals",
                newName: "MonthlyRent");

            migrationBuilder.RenameColumn(
                name: "CzyAktywna",
                table: "Rentals",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "WynajmowanePrzez",
                table: "Apartments",
                newName: "RentedBy");

            migrationBuilder.RenameColumn(
                name: "Ulica",
                table: "Apartments",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "NumerMieszkania",
                table: "Apartments",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "NumerBudynku",
                table: "Apartments",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Metraz",
                table: "Apartments",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "LiczbaPokoi",
                table: "Apartments",
                newName: "NumberOfRooms");

            migrationBuilder.RenameColumn(
                name: "CzyWynajete",
                table: "Apartments",
                newName: "IsRented");

            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingNumber",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Apartments");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Tenants",
                newName: "Telefon");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Tenants",
                newName: "Nazwisko");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Rentals",
                newName: "DataOd");

            migrationBuilder.RenameColumn(
                name: "MonthlyRent",
                table: "Rentals",
                newName: "Czynsz");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Rentals",
                newName: "CzyAktywna");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Rentals",
                newName: "DataDo");

            migrationBuilder.RenameColumn(
                name: "ContractNumber",
                table: "Rentals",
                newName: "NumerUmowy");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Apartments",
                newName: "Ulica");

            migrationBuilder.RenameColumn(
                name: "RentedBy",
                table: "Apartments",
                newName: "WynajmowanePrzez");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Apartments",
                newName: "NumerMieszkania");

            migrationBuilder.RenameColumn(
                name: "NumberOfRooms",
                table: "Apartments",
                newName: "LiczbaPokoi");

            migrationBuilder.RenameColumn(
                name: "IsRented",
                table: "Apartments",
                newName: "CzyWynajete");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Apartments",
                newName: "NumerBudynku");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Apartments",
                newName: "Metraz");

            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "Tenants",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KodPocztowy",
                table: "Apartments",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Miasto",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
