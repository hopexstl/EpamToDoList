// <copyright file="20240317191611_UpdateCommentsRelationship.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace TodoList.Services.Db.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <summary>
    /// Handles the migration for updating the relationship between Comments and Tasks.
    /// This migration adds a foreign key from Comments to Tasks, establishing a many-to-one relationship.
    /// </summary>
    public partial class UpdateCommentsRelationship : Migration
    {
        /// <summary>
        /// Applies the necessary changes to the database schema to create the relationship.
        /// It creates an index for the 'TaskId' column in the 'Comments' table and adds a foreign key constraint.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder used to apply changes to the database.</param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_TaskId",
                table: "Comments",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <summary>
        /// Reverts the changes made in the Up method.
        /// It removes the foreign key and the index related to the 'TaskId' column in the 'Comments' table.
        /// </summary>
        /// <param name="migrationBuilder">The migration builder used to revert changes from the database.</param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TaskId",
                table: "Comments");
        }
    }
}
