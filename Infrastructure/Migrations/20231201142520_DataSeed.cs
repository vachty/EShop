using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.InsertData(
		        table: "Products",
		        columns: new[]
		        {
			        "Id", "Name", "ImgUri", "Price", "Description", "CreatedOn", "CreatedBy", "UpdatedOn", "UpdatedBy"
		        },
		        values: new object[]
		        {
			        Guid.NewGuid(), "Nothing", "umguri.com/fsfsfsf/img.jpg", 15, "", DateTime.Now, "systemseed",
			        DateTime.Now, "systemseed"
		        });
        }
    }
}
