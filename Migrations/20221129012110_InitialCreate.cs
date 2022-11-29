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
                name: "SnapshotReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PointerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PointerVersionNumber = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnapshotReferences", x => x.Id);
                    table.UniqueConstraint("AK_SnapshotReferences_PointerId_PointerVersionNumber", x => new { x.PointerId, x.PointerVersionNumber });
                });

            migrationBuilder.CreateTable(
                name: "Snapshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VersionNumber = table.Column<ulong>(type: "INTEGER", nullable: false),
                    SnapshotReferenceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snapshots", x => new { x.Id, x.VersionNumber });
                    table.ForeignKey(
                        name: "FK_Snapshots_SnapshotReferences_SnapshotReferenceId",
                        column: x => x.SnapshotReferenceId,
                        principalTable: "SnapshotReferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snapshots_SnapshotReferenceId",
                table: "Snapshots",
                column: "SnapshotReferenceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snapshots");

            migrationBuilder.DropTable(
                name: "SnapshotReferences");
        }
    }
}
