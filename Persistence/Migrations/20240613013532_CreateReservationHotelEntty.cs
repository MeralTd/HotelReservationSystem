using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateReservationHotelEntty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservation_hotels",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hotel_name = table.Column<string>(type: "text", nullable: false),
                    room_number = table.Column<string>(type: "text", nullable: true),
                    hotel_checkin_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    hotel_checkout_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    address_line1 = table.Column<string>(type: "text", nullable: false),
                    address_line2 = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation_hotels", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservation_hotels");
        }
    }
}
