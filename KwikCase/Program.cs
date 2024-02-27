using Kwik.Repository;
using Kwik.Services;
using KwikCase.Services;
using Microsoft.Data.SqlClient;
using System.Security.Principal;
using System.Transactions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Dapper;
using KwikCase.Models;
using KwikCase.Context;

var builder = WebApplication.CreateBuilder(args);
var connectionBuilder = new SqlConnectionStringBuilder();

builder.Configuration.AddJsonFile("appsettings.json");
var connectString = builder.Configuration.GetConnectionString("KvikCaseDB");
using var connection = new SqliteConnection(connectString);
connection.Open();


var rows = await connection.QueryAsync("select * from PersonData");

Console.WriteLine($"Rows {rows.FirstOrDefault()}");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountRepository, AccountRepo>();
builder.Services.AddDbContext<PersonContext>(options => options.UseSqlite(connectString));
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHostedService<DBInitHostedService>();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis:6379";
    options.InstanceName = "KwikCaseInstance";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();