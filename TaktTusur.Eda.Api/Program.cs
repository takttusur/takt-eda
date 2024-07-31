using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using TaktTusur.Eda.Application.MappingProfiles;
using TaktTusur.Eda.Application.Services;
using TaktTusur.Eda.Infrastructure.Contexts;
using TaktTusur.Eda.Infrastructure.Repositories;
using TaktTusur.Eda.Domain.Recipe;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EdaDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(EdaDbContext)));
});

builder.Services.AddScoped<IMeasurementUnitsRepository, MeasurementUnitsRepository>();
builder.Services.AddScoped<IIngredientsRepository, IngredientsRepository>();

builder.Services.AddScoped<IMeasurementUnitsService, ValuesDictionaryService>();
builder.Services.AddScoped<IIngredientsService, ValuesDictionaryService>();

builder.Services.AddAutoMapper(config => { config.AddProfile<MeasurementUnitsProfile>(); });
builder.Services.AddAutoMapper(config => { config.AddProfile<IngredientsProfile>(); });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();