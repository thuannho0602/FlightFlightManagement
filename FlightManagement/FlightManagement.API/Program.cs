using FlightManagement.API;
using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Repository;
using FlightManagement.Repository.Implementations;
using FlightManagement.Services;
using FlightManagement.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


/// Add Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("FlightManagement.API")));

builder.Services.AddIdentity<User, IdentityRole<Guid>>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               //.AddUserStore<UserStore>()
               .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add Services
builder.Services.AddTransient<IPlaneRepository, PlaneRepository>();
builder.Services.AddScoped<IPlaneServices, PlaneServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddTransient<IAirportDepartureRepository, AirportDepartureRepository>();
builder.Services.AddScoped<IAirportDepartureServices, AirportDepartureServices>();


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
