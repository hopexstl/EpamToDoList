// <copyright file="20240317211003_Added_Tags.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace TodoList.Services.Db.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// Migration for adding the 'Tags' table to the database.
    /// </summary>
    /// <remarks>
    /// This migration creates the 'Tags' table with an 'Id', 'Name', and 'TaskId' columns.
    /// - 'Id' is the primary key with auto-increment enabled.
    /// - 'Name' stores the tag's name and cannot be null.
    /// - 'TaskId' is a foreign key that links each tag to a specific task, enforcing a relationship where each tag is associated with one task.
    /// This migration also sets up a foreign key constraint from the 'Tags' table to the 'Tasks' table, ensuring referential integrity.
    /// On rollback, this migration will remove the 'Tags' table from the database.
    /// </remarks>
    public partial class Added_Tags : Migration
    {
        /// <summary>
        /// Upgrades the database by adding the 'Tags' table.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder used to build the migration.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TaskId",
                table: "Tags",
                column: "TaskId");
        }

        /// <summary>
        /// Downgrades the database by removing the 'Tags' table.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder used to build the migration.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
