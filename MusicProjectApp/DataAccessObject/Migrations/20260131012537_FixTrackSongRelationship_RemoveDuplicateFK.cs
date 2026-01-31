using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class FixTrackSongRelationship_RemoveDuplicateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteTypes_Notes_NoteID",
                table: "NoteTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Songs_SongID",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.RenameColumn(
                name: "SongID",
                table: "Tracks",
                newName: "SheetID");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_SongID",
                table: "Tracks",
                newName: "IX_Tracks_SheetID");

            migrationBuilder.RenameColumn(
                name: "NoteID",
                table: "NoteTypes",
                newName: "MusicalEventEventID");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTypes_NoteID",
                table: "NoteTypes",
                newName: "IX_NoteTypes_MusicalEventEventID");

            migrationBuilder.AddColumn<int>(
                name: "ClefType",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentID",
                table: "Tracks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentName",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTablature",
                table: "Tracks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Transpose",
                table: "Tracks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InitialTempoBPM",
                table: "Sheets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InitialTempoText",
                table: "Sheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Sheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "NoteTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndBarline",
                table: "Measures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeftBarline",
                table: "Measures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RightBarline",
                table: "Measures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeSignatureID",
                table: "Measures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotationItems",
                columns: table => new
                {
                    NotationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureID = table.Column<int>(type: "int", nullable: false),
                    StartBeat = table.Column<float>(type: "real", nullable: false),
                    EndBeat = table.Column<float>(type: "real", nullable: true),
                    Articulation = table.Column<int>(type: "int", nullable: true),
                    Dynamic = table.Column<int>(type: "int", nullable: true),
                    IsHairpinStart = table.Column<bool>(type: "bit", nullable: true),
                    IsHairpinEnd = table.Column<bool>(type: "bit", nullable: true),
                    HairpinType = table.Column<int>(type: "int", nullable: true),
                    IsCrescendo = table.Column<bool>(type: "bit", nullable: false),
                    IsDiminuendo = table.Column<bool>(type: "bit", nullable: false),
                    Ornament = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLyric = table.Column<bool>(type: "bit", nullable: false),
                    IsStaffText = table.Column<bool>(type: "bit", nullable: false),
                    IsSustainPedal = table.Column<bool>(type: "bit", nullable: false),
                    PedalStart = table.Column<bool>(type: "bit", nullable: false),
                    PedalEnd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotationItems", x => x.NotationID);
                    table.ForeignKey(
                        name: "FK_NotationItems_Measures_MeasureID",
                        column: x => x.MeasureID,
                        principalTable: "Measures",
                        principalColumn: "MeasureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TupletGroups",
                columns: table => new
                {
                    TupletID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualNotes = table.Column<int>(type: "int", nullable: false),
                    NormalNotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TupletGroups", x => x.TupletID);
                });

            migrationBuilder.CreateTable(
                name: "MusicalEvents",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureID = table.Column<int>(type: "int", nullable: false),
                    StartBeat = table.Column<float>(type: "real", nullable: false),
                    DurationInBeats = table.Column<float>(type: "real", nullable: false),
                    IsRest = table.Column<bool>(type: "bit", nullable: false),
                    IsChord = table.Column<bool>(type: "bit", nullable: false),
                    IsGraceNote = table.Column<bool>(type: "bit", nullable: false),
                    GraceDurationRatio = table.Column<float>(type: "real", nullable: false),
                    BaseNoteType = table.Column<int>(type: "int", nullable: false),
                    DotCount = table.Column<int>(type: "int", nullable: false),
                    TupletID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicalEvents", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_MusicalEvents_Measures_MeasureID",
                        column: x => x.MeasureID,
                        principalTable: "Measures",
                        principalColumn: "MeasureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicalEvents_TupletGroups_TupletID",
                        column: x => x.TupletID,
                        principalTable: "TupletGroups",
                        principalColumn: "TupletID");
                });

            migrationBuilder.CreateTable(
                name: "NotePitches",
                columns: table => new
                {
                    NotePitchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicalEventID = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<int>(type: "int", nullable: false),
                    Octave = table.Column<int>(type: "int", nullable: false),
                    Alter = table.Column<int>(type: "int", nullable: false),
                    StringNumber = table.Column<int>(type: "int", nullable: true),
                    Fret = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotePitches", x => x.NotePitchID);
                    table.ForeignKey(
                        name: "FK_NotePitches_MusicalEvents_MusicalEventID",
                        column: x => x.MusicalEventID,
                        principalTable: "MusicalEvents",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measures_TimeSignatureID",
                table: "Measures",
                column: "TimeSignatureID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicalEvents_MeasureID",
                table: "MusicalEvents",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicalEvents_TupletID",
                table: "MusicalEvents",
                column: "TupletID");

            migrationBuilder.CreateIndex(
                name: "IX_NotationItems_MeasureID",
                table: "NotationItems",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_NotePitches_MusicalEventID",
                table: "NotePitches",
                column: "MusicalEventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Measures_TimeSignatures_TimeSignatureID",
                table: "Measures",
                column: "TimeSignatureID",
                principalTable: "TimeSignatures",
                principalColumn: "TimeSignatureID");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTypes_MusicalEvents_MusicalEventEventID",
                table: "NoteTypes",
                column: "MusicalEventEventID",
                principalTable: "MusicalEvents",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Sheets_SheetID",
                table: "Tracks",
                column: "SheetID",
                principalTable: "Sheets",
                principalColumn: "SheetID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measures_TimeSignatures_TimeSignatureID",
                table: "Measures");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteTypes_MusicalEvents_MusicalEventEventID",
                table: "NoteTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Sheets_SheetID",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "NotationItems");

            migrationBuilder.DropTable(
                name: "NotePitches");

            migrationBuilder.DropTable(
                name: "MusicalEvents");

            migrationBuilder.DropTable(
                name: "TupletGroups");

            migrationBuilder.DropIndex(
                name: "IX_Measures_TimeSignatureID",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "ClefType",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "InstrumentID",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "InstrumentName",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "IsTablature",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Transpose",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "InitialTempoBPM",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "InitialTempoText",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "NoteTypes");

            migrationBuilder.DropColumn(
                name: "EndBarline",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "LeftBarline",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "RightBarline",
                table: "Measures");

            migrationBuilder.DropColumn(
                name: "TimeSignatureID",
                table: "Measures");

            migrationBuilder.RenameColumn(
                name: "SheetID",
                table: "Tracks",
                newName: "SongID");

            migrationBuilder.RenameIndex(
                name: "IX_Tracks_SheetID",
                table: "Tracks",
                newName: "IX_Tracks_SongID");

            migrationBuilder.RenameColumn(
                name: "MusicalEventEventID",
                table: "NoteTypes",
                newName: "NoteID");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTypes_MusicalEventEventID",
                table: "NoteTypes",
                newName: "IX_NoteTypes_NoteID");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeasureID = table.Column<int>(type: "int", nullable: false),
                    Alter = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    IsChord = table.Column<bool>(type: "bit", nullable: false),
                    Octave = table.Column<int>(type: "int", nullable: false),
                    Pitch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartBeat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_Notes_Measures_MeasureID",
                        column: x => x.MeasureID,
                        principalTable: "Measures",
                        principalColumn: "MeasureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_MeasureID",
                table: "Notes",
                column: "MeasureID");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTypes_Notes_NoteID",
                table: "NoteTypes",
                column: "NoteID",
                principalTable: "Notes",
                principalColumn: "NoteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Songs_SongID",
                table: "Tracks",
                column: "SongID",
                principalTable: "Songs",
                principalColumn: "SongID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
