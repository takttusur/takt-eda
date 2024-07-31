using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.DataAccess.Contexts;

public class EdaDbContext : DbContext
{
	public EdaDbContext(DbContextOptions<EdaDbContext> options) : base(options)
	{
	}

	public DbSet<MeasurementUnit> MeasurementUnits { get; protected set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var measurementUnit = modelBuilder.Entity<MeasurementUnit>();
		measurementUnit.ToTable("MeasurementUnits");
		measurementUnit.Property(p => p.Id)
			.IsRequired()
			.HasColumnName("id");
		measurementUnit.Property(p => p.Name)
			.IsRequired()
			.HasColumnName("name");
	}
}