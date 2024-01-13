using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ImageColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "359dceee-9ead-400b-b250-0479f9f56269");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "fec78d39-45a8-483a-94b6-090f05f77709");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "9fdf3177-9b1d-40ce-ba9c-e6bd00c0773b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "601af004-5f79-49b6-afd9-3f8b5a357fb9", "AQAAAAEAACcQAAAAEIcHHF/s6RctN8/adh2He0zBNeC+MlBsFL4IAs3K/KaR4OJFZezLMZWa8IHv5ZuLrA==", "881206bb-708d-4c7b-91fe-193ac29aae5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42281692-b56c-4fb2-a9f2-e987a708ecb0", "AQAAAAEAACcQAAAAEI3/3Ad73RoiQ0ao3deRLnG7raA74eZ1ijQAnhAZnQ3y55jY7Nf6ytecKOpd7kpRBA==", "0a691542-ce71-446a-978a-2452b60668b3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "f143da83-3c4a-4c7d-a432-a698bca2c412");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "dcd5d3ea-4d6d-4932-afcc-de95f8272869");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "b97cacae-49d8-49af-8410-4803e94c16ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b8e1303-a609-465f-863a-47dc73c63aa6", "AQAAAAEAACcQAAAAEICrlZ8itUSxGl2QmB9Uy+YfrS9iwS6lDeMHvYMOnj+zHaWBie5tfGjbEqzHY0nenw==", "a033009e-3b7e-4ae9-b397-025ec1f91fa6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cbe5f40-113d-4307-869f-8e4849cdb2f3", "AQAAAAEAACcQAAAAEA4RKfNupwvbNY3HtETK1ooC3X2QY77UH+iqtUFvkw5nV7wIMhNGONNweHEcMS+6HQ==", "c7a98922-4346-47b6-b520-b83d868a94e4" });
        }
    }
}
