using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjektZawody.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Competitions",
                columns: new[] { "Id", "CompetitionStatus", "MaxAge", "MinAge", "Name" },
                values: new object[,]
                {
                    { -2, 3, 10, 11, "Siatkowka" },
                    { -1, 1, 10, 11, "Nozna" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Age", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -3, 12, "Dorian", "Nawigator" },
                    { -2, 15, "Dagmar", "Poszukiwacz" },
                    { -1, 10, "Darek", "Odkrywca " }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "CompetitionId", "PlayerId", "Points" },
                values: new object[,]
                {
                    { -1, -3, 0 },
                    { -2, -2, 0 },
                    { -1, -2, 5 },
                    { -2, -1, 0 },
                    { -1, -1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumns: new[] { "CompetitionId", "PlayerId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumns: new[] { "CompetitionId", "PlayerId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumns: new[] { "CompetitionId", "PlayerId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumns: new[] { "CompetitionId", "PlayerId" },
                keyValues: new object[] { -2, -1 });

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumns: new[] { "CompetitionId", "PlayerId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.DeleteData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Competitions",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
