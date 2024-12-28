using Microsoft.EntityFrameworkCore;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.Services;
using SafraCoin.Infra.Db;
using AutoMapper;
using SafraCoin.Infra.AutoMapping;
using Microsoft.EntityFrameworkCore.Storage;
using SafraCoin.Infra.Settings;
using Microsoft.AspNetCore.Identity;
using SafraCoin.Core.Models;
using SafraCoin.Core.Interfaces.Repositories;
using SafraCoin.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(SafraCoinProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), 
        b => b.MigrationsAssembly("SafraCoin")));

builder.Services.AddScoped<IInvestorRepository, InvestorRepository>();
builder.Services.AddScoped<IInvestorsService, InvestorsService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

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
