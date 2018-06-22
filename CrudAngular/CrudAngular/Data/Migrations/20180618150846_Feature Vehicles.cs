using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudAngular.Data.Migrations
{
    public partial class FeatureVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Models",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Models",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Models",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Models",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Models");
        }
    }
}
