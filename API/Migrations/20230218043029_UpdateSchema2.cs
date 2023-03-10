using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
               table: "StorageAreas",
               columns: new[] { "Name", "Size", "Available" },
               values: new object[] { "Small", 1, 5 });
            migrationBuilder.InsertData(
               table: "StorageAreas",
               columns: new[] { "Name", "Size", "Available" },
               values: new object[] { "Medium", 2, 3 });
            migrationBuilder.InsertData(
               table: "StorageAreas",
               columns: new[] { "Name", "Size", "Available" },
               values: new object[] { "Large", 3, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
