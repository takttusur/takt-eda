using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.DataAccess.Contexts;

public class EdaDbContext : DbContext
{
	public EdaDbContext(DbContextOptions<EdaDbContext> options) : base(options)
	{
	}

	public DbSet<MeasurementUnit> MeasurementUnits { get; protected set; }
}