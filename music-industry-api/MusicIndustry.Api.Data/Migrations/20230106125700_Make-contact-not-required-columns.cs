using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicIndustry.Api.Data.Migrations
{
    public partial class Makecontactnotrequiredcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneCell",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneBusiness",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Fax",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneCell",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneBusiness",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Fax",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine1",
                schema: "dbo",
                table: "Contacts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "");
        }
    }
}
