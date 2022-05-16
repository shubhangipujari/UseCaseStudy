using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminService.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER_DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MOBILE_NUMBER = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    GENDER = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    ROLE_NAME = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    AGE = table.Column<int>(type: "int", nullable: false),
                    IS_ACTIVE = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    PASSWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER_DETAILS");
        }
    }
}
