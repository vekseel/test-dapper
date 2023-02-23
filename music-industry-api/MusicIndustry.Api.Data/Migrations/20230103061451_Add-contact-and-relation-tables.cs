using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicIndustry.Api.Data.Migrations
{
    public partial class Addcontactandrelationtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Company = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, defaultValue: ""),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValue: ""),
                    PhoneCell = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    PhoneBusiness = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    AddressLine1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    AddressLine2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: ""),
                    Zip = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, defaultValue: ""),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())"),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "('')"),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())"),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "('')"),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())"),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "('')"),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())"),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureVersions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())"),
                    DateModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicianContacts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())"),
                    MusicianId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicianContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "dbo",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianContacts_Musicians_MusicianId",
                        column: x => x.MusicianId,
                        principalSchema: "dbo",
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabelContacts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicLabelId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabelContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicLabelContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "dbo",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicLabelContacts_MusicLabels_MusicLabelId",
                        column: x => x.MusicLabelId,
                        principalSchema: "dbo",
                        principalTable: "MusicLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatformContacts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(SYSDATETIMEOFFSET())"),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatformContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "dbo",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformContacts_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "dbo",
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicianContacts_ContactId",
                schema: "dbo",
                table: "MusicianContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianContacts_MusicianId",
                schema: "dbo",
                table: "MusicianContacts",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLabelContacts_ContactId",
                schema: "dbo",
                table: "MusicLabelContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLabelContacts_MusicLabelId",
                schema: "dbo",
                table: "MusicLabelContacts",
                column: "MusicLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformContacts_ContactId",
                schema: "dbo",
                table: "PlatformContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatformContacts_PlatformId",
                schema: "dbo",
                table: "PlatformContacts",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicianContacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MusicLabelContacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlatformContacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProcedureVersions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Musicians",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MusicLabels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Platforms",
                schema: "dbo");
        }
    }
}
