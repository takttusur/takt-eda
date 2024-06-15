namespace TaktTusur.Eda.Domain.Recipe;

/// <summary>
/// Units for measuring products.
/// </summary>
public class MeasurementUnit : Entity
{
	/// <summary>
	/// Name of unit.
	/// </summary>
	/// <example>kilogram, litre, pack.</example>
	public string Name { get; set; }
}