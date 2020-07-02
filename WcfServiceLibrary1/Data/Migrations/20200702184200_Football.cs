using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Football : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    NetWorth = table.Column<decimal>(type: "Money", nullable: false),
                    AverageAgePlayers = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    MarketValue = table.Column<decimal>(type: "Money", nullable: false),
                    Position = table.Column<string>(maxLength: 50, nullable: false),
                    Height = table.Column<float>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamLeftId = table.Column<int>(nullable: false),
                    TeamJoinedId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    MoneyAmount = table.Column<decimal>(type: "Money", nullable: false),
                    DateTransfer = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_TeamJoinedId",
                        column: x => x.TeamJoinedId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_TeamLeftId",
                        column: x => x.TeamLeftId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_PlayerId",
                table: "Transfers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_TeamJoinedId",
                table: "Transfers",
                column: "TeamJoinedId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_TeamLeftId",
                table: "Transfers",
                column: "TeamLeftId");

            migrationBuilder.Sql(@"CREATE TRIGGER [dbo].[SetAvgAgeTeam]
ON [dbo].[Players]
AFTER INSERT
AS
BEGIN
UPDATE Teams
SET AverageAgePlayers = (SELECT ISNULL(AVG(convert(decimal(16,2),convert(int,(datediff(day, DateBirth, CURRENT_TIMESTAMP) / 365.25)))),0) as avgAge
							FROM Players
							where Players.TeamId = Teams.Id)
END");

            migrationBuilder.Sql(@"CREATE TRIGGER [dbo].[SetAvgAgeTeamAfterDelete]
ON [dbo].[Players]
AFTER DELETE
AS
BEGIN
UPDATE Teams
SET AverageAgePlayers = (SELECT ISNULL(AVG(convert(decimal(16,2),convert(int,(datediff(day, DateBirth, CURRENT_TIMESTAMP) / 365.25)))),0) as avgAge
							FROM Players
							where Players.TeamId = Teams.Id)



END");

            migrationBuilder.Sql(@"CREATE TRIGGER [dbo].[SetAvgAgeTeamAfterUpdate]
ON [dbo].[Players]
AFTER UPDATE
AS
BEGIN
UPDATE Teams
SET AverageAgePlayers = (SELECT ISNULL(AVG(convert(decimal(16,2),convert(int,(datediff(day, DateBirth, CURRENT_TIMESTAMP) / 365.25)))),0) as avgAge
							FROM Players
							where Players.TeamId = Teams.Id)
END");

            migrationBuilder.Sql(@"CREATE TRIGGER [dbo].[DeleteTransfersWhenDeleteTeam]
ON [dbo].[Teams]
INSTEAD OF DELETE
AS
BEGIN
SET NOCOUNT ON;
DELETE FROM Transfers WHERE TeamLeftId IN (SELECT Id FROM deleted)
DELETE FROM Transfers WHERE TeamJoinedId IN (SELECT Id FROM deleted)
DELETE FROM Teams WHERE Id IN (SELECT Id FROM deleted)
END");

            migrationBuilder.Sql(@"CREATE TRIGGER [dbo].[ChangeTeamIdOnPlayer]
ON [dbo].[Transfers]
AFTER INSERT
AS
BEGIN
UPDATE Players
SET Players.TeamId = Transfers.TeamJoinedId
FROM Transfers 
WHERE Players.Id = Transfers.PlayerId
END");

            migrationBuilder.Sql(@"CREATE TRIGGER [dbo].[ChangeTeamIdOnPlayerAfterUpdate]
ON [dbo].[Transfers]
AFTER Update
AS
BEGIN
UPDATE Players
SET Players.TeamId = Transfers.TeamJoinedId
FROM Transfers 
WHERE Players.Id = Transfers.PlayerId
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
