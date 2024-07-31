using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using TaktTusur.Eda.DataAccess.Contexts;
using TaktTusur.Eda.DataAccess.Repositories;
using TaktTusur.Eda.Domain.Recipe;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
	builder.Configuration.Sources.Add(new JsonConfigurationSource()
	{
		Path = Path.Combine("Configurations", "appsettings.development.json")
	});
}

builder.Services.AddDbContext<EdaDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(EdaDbContext)));
});

builder.Services.AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>();

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