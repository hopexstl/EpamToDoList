// <copyright file="20240229192506_ChangeTableName.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace TodoListApp.Services.Db.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// Migration to change the name of the 'Entities' table to 'TodoList'.
    /// </summary>
    public partial class ChangeTableName : Migration
    {
        /// <summary>
        /// Applies changes to the database schema to rename the 'Entities' table to 'TodoList'.
        /// This includes dropping the existing primary key constraint, renaming the table, and then adding a new primary key constraint.
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="MigrationBuilder"/> used to build and execute migration operations.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "TodoList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoList",
                table: "TodoList",
                column: "Id");
        }

        /// <summary>
        /// Reverts the schema changes made in the <see cref="Up"/> method by renaming the 'TodoList' table back to 'Entities'.
        /// This includes dropping the 'TodoList' table's primary key constraint, renaming the table back to 'Entities', and then re-adding the primary key constraint.
        /// </summary>
        /// <param name="migrationBuilder">The <see cref="MigrationBuilder"/> used to build and execute migration operations.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoList",
                table: "TodoList");

            migrationBuilder.RenameTable(
                name: "TodoList",
                newName: "Entities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");
        }
    }
}
