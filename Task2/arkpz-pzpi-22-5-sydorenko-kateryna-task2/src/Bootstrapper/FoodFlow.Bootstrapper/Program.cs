using FoodFlow.Modules.Culinary.Api;
using FoodFlow.Modules.Users.Api;
using FoodFlow.Modules.Spots.Api;
using FoodFlow.Common.IntegrationEvents;
using FoodFlow.Modules.Movements.Api;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FoodFlow.Modules.Measurements.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodFlow", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.RegisterIntegrationEventsUtils();
builder.Services.AddCulinaryModule(builder.Configuration);
builder.Services.AddSpotsModule(builder.Configuration);
builder.Services.AddUsersModule(builder.Configuration);
builder.Services.AddMovementsModule(builder.Configuration);
builder.Services.AddMeasurementsModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCulinaryModule();
app.UseSpotsModule();
app.UseUsersModule();
app.UseMovementsModule();
app.UseMeasurementsModule();

app.MapControllers();

app.Run();