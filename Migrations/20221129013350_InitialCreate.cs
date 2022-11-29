using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreBug.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snapshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VersionNumber = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snapshots", x => new { x.Id, x.VersionNumber });
                });

            migrationBuilder.CreateTable(
                name: "SnapshotReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PointerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PointerVersionNumber = table.Column<ulong>(type: "INTEGER", nullable: false),
                    SnapshotId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SnapshotVersionNumber = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnapshotReferences", x => x.Id);
                    table.UniqueConstraint("AK_SnapshotReferences_PointerId_PointerVersionNumber", x => new { x.PointerId, x.PointerVersionNumber });
                    table.ForeignKey(
                        name: "FK_SnapshotReferences_Snapshots_SnapshotId_SnapshotVersionNumber",
                        columns: x => new { x.SnapshotId, x.SnapshotVersionNumber },
                        principalTable: "Snapshots",
                        principalColumns: new[] { "Id", "VersionNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SnapshotReferences_SnapshotId_SnapshotVersionNumber",
                table: "SnapshotReferences",
                columns: new[] { "SnapshotId", "SnapshotVersionNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SnapshotReferences");

            migrationBuilder.DropTable(
                name: "Snapshots");
        }
    }
}
