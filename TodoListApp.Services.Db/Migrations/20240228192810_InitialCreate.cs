// <copyright file="20240228192810_InitialCreate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace TodoListApp.Services.Db.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// Initial migration to create the database schema for the Todo List application.
    /// </summary>
    public partial class InitialCreate : Migration
    {
        /// <summary>
        /// Builds the initial database schema by creating necessary database objects.
        /// This method is called when the migration is applied to the database.
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="MigrationBuilder"/> used to build the migration operations.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                });
        }

        /// <summary>
        /// Reverts the changes made in the <see cref="Up"/> method by dropping the created database objects.
        /// This method is called when the migration is rolled back.
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="MigrationBuilder"/> used to build the migration operations.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities");
        }
    }
}
