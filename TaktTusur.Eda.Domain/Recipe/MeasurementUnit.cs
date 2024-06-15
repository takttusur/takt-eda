using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.Recipe;

/// <summary>
/// Units for measuring products.
/// </summary>
public class MeasurementUnit : Entity
{
	protected MeasurementUnit(string name)
	{
		Name = name;
	}

	/// <summary>
	/// Name of unit.
	/// </summary>
	/// <example>kilogram, litre, pack.</example>
	public string Name { get; protected set; }

	public static MeasurementUnit Create(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new EntityValidationException(nameof(Name), "cannot be empty");

		return new MeasurementUnit(name);
	}
}