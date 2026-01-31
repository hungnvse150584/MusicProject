using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class FixInstrumentSoundOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoundPacks",
                columns: table => new
                {
                    SoundPackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    OwnerAccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundPacks", x => x.SoundPackID);
                });

            migrationBuilder.CreateTable(
                name: "Sounds",
                columns: table => new
                {
                    SoundID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleRate = table.Column<int>(type: "int", nullable: true),
                    Channels = table.Column<int>(type: "int", nullable: true),
                    SizeBytes = table.Column<long>(type: "bigint", nullable: true),
                    InstrumentType = table.Column<int>(type: "int", nullable: false),
                    IsPremium = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OwnerAccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultInstrumentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sounds", x => x.SoundID);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    InstrumentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DefaultSoundID = table.Column<int>(type: "int", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    OwnerAccountId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.InstrumentID);
                    table.ForeignKey(
                        name: "FK_Instruments_Sounds_DefaultSoundID",
                        column: x => x.DefaultSoundID,
                        principalTable: "Sounds",
                        principalColumn: "SoundID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SoundPackItems",
                columns: table => new
                {
                    SoundPackItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoundPackID = table.Column<int>(type: "int", nullable: false),
                    SoundID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundPackItems", x => x.SoundPackItemID);
                    table.ForeignKey(
                        name: "FK_SoundPackItems_SoundPacks_SoundPackID",
                        column: x => x.SoundPackID,
                        principalTable: "SoundPacks",
                        principalColumn: "SoundPackID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoundPackItems_Sounds_SoundID",
                        column: x => x.SoundID,
                        principalTable: "Sounds",
                        principalColumn: "SoundID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_InstrumentID",
                table: "Tracks",
                column: "InstrumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_DefaultSoundID",
                table: "Instruments",
                column: "DefaultSoundID",
                unique: true,
                filter: "[DefaultSoundID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SoundPackItems_SoundID",
                table: "SoundPackItems",
                column: "SoundID");

            migrationBuilder.CreateIndex(
                name: "IX_SoundPackItems_SoundPackID",
                table: "SoundPackItems",
                column: "SoundPackID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Instruments_InstrumentID",
                table: "Tracks",
                column: "InstrumentID",
                principalTable: "Instruments",
                principalColumn: "InstrumentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Instruments_InstrumentID",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "SoundPackItems");

            migrationBuilder.DropTable(
                name: "SoundPacks");

            migrationBuilder.DropTable(
                name: "Sounds");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_InstrumentID",
                table: "Tracks");
        }
    }
}
