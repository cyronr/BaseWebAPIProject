using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileEventType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEventType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_ProfileStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProfileStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profiles_ProfileType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProfileType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProfileEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeId = table.Column<int>(type: "integer", nullable: false),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    AddInfo = table.Column<string>(type: "text", nullable: false),
                    CallerProfileId = table.Column<int>(type: "integer", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileEvents_ProfileEventType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ProfileEventType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProfileEvents_Profiles_CallerProfileId",
                        column: x => x.CallerProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProfileEvents_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProfileEventType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Updated" },
                    { 3, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "ProfileStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Prepared" },
                    { 2, "Active" },
                    { 3, "Locked" },
                    { 4, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "ProfileType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Facility" },
                    { 2, "Patient" },
                    { 3, "Doctor" },
                    { 4, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEvents_CallerProfileId",
                table: "ProfileEvents",
                column: "CallerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEvents_ProfileId",
                table: "ProfileEvents",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEvents_TypeId",
                table: "ProfileEvents",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_StatusId",
                table: "Profiles",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_TypeId",
                table: "Profiles",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileEvents");

            migrationBuilder.DropTable(
                name: "ProfileEventType");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "ProfileStatus");

            migrationBuilder.DropTable(
                name: "ProfileType");
        }
    }
}
