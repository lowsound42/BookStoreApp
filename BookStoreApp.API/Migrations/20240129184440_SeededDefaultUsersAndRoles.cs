using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ac873ff7-da62-4bd5-ba57-c5b174812b0d", null, "User", "USER" },
                    { "bcfd68cd-b1ee-4273-b185-3487a655459e", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "96873c6a-da0c-4fa3-b1ca-a1f37c32f8bf", 0, "76c58d36-c0ea-4c30-a890-b3838ba3f0a4", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEP0urMrIHMQG4S7TO6l/5bv8pRenjcbPz6xATi3+ZGgVbzEVCD37vn0eOOCPnOy0ng==", null, false, "a9deeeb2-7120-4d7a-ace2-faf3844f9202", false, "admin@bookstore.com" },
                    { "b896a1e7-8e4b-474b-a5ac-5c839d9a9d0b", 0, "0967b200-689e-41b3-a496-1521f39789b8", "user@bookstore.com", false, "System", "USER", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAELCRqHj2TbXWZaxm9UN4mxeruVkZcn0QhVxxBLaPv1x1kfWZW+BfhrDyxNhgkki4tw==", null, false, "f2d6a75f-4717-4318-9d24-ee36b74f458c", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bcfd68cd-b1ee-4273-b185-3487a655459e", "96873c6a-da0c-4fa3-b1ca-a1f37c32f8bf" },
                    { "ac873ff7-da62-4bd5-ba57-c5b174812b0d", "b896a1e7-8e4b-474b-a5ac-5c839d9a9d0b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bcfd68cd-b1ee-4273-b185-3487a655459e", "96873c6a-da0c-4fa3-b1ca-a1f37c32f8bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ac873ff7-da62-4bd5-ba57-c5b174812b0d", "b896a1e7-8e4b-474b-a5ac-5c839d9a9d0b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac873ff7-da62-4bd5-ba57-c5b174812b0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcfd68cd-b1ee-4273-b185-3487a655459e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96873c6a-da0c-4fa3-b1ca-a1f37c32f8bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b896a1e7-8e4b-474b-a5ac-5c839d9a9d0b");
        }
    }
}
