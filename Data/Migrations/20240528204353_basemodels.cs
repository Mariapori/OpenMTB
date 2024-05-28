using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenMTB.Data.Migrations
{
    /// <inheritdoc />
    public partial class basemodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompetitionName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParticipantName = table.Column<string>(type: "TEXT", nullable: false),
                    ParticipantCompetitionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_CompetitionSet_ParticipantCompetitionId",
                        column: x => x.ParticipantCompetitionId,
                        principalTable: "CompetitionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_CompetitionSet_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "CompetitionSet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParticipantId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompetitionId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_CompetitionSet_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "CompetitionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ParticipantCompetitionId",
                table: "Participants",
                column: "ParticipantCompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_CompetitionId",
                table: "Results",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_ParticipantId",
                table: "Results",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_SeriesId",
                table: "Results",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_CompetitionId",
                table: "Series",
                column: "CompetitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "CompetitionSet");
        }
    }
}
