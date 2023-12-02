

#nullable disable

using Infrastructure.SQL.Utils;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualBasic.CompilerServices;

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductDataBigSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(SqlExecuter.GetSql(nameof(ProductDataBigSeed)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
