// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Capstone.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TodoList.Services.Db.Services;
using TodoList.Services.Interfaces;
using TodoListApp.Services.Db;
using TodoListApp.Services.Db.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoListDbContext>(
    options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), x =>
    {
        x.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
    }).LogTo(Console.WriteLine, LogLevel.Information);
}, ServiceLifetime.Transient);

builder.Services.AddTransient<ITodoListService, TodoListDatabaseService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
