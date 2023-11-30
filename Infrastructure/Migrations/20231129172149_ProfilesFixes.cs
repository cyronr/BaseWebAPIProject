using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProfilesFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileEvents_Profiles_ProfileId",
                table: "ProfileEvents");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileEvents_Profiles_ProfileId",
                table: "ProfileEvents",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileEvents_Profiles_ProfileId",
                table: "ProfileEvents");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileEvents_Profiles_ProfileId",
                table: "ProfileEvents",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
