using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.Recipe;

public class RecipeIngredient : Entity
{
	protected RecipeIngredient(double amountPerPerson)
	{
		AmountPerPerson = amountPerPerson;
	}

	/// <summary>
	/// Ingredient. Part of dish.
	/// </summary>
	public Ingredient Ingredient { get; protected set; }

	/// <summary>
	/// Measurement units for ingredient.
	/// </summary>
	public MeasurementUnit Units { get; protected set; }

	/// <summary>
	/// Amout of ingredient to cook the meal for one person.
	/// </summary>
	public double AmountPerPerson { get; protected set; }

	/// <summary>
	/// Recipe which has this ingredient.
	/// </summary>
	public virtual Recipe? Recipe { get; protected set; }

	public static RecipeIngredient Create(Ingredient ingredient, MeasurementUnit measurementUnit,
		double amountPerPerson)
	{
		if (amountPerPerson <= 0)
			throw new EntityValidationException(nameof(AmountPerPerson), "should have positive value");

		return new RecipeIngredient(amountPerPerson)
		{
			Ingredient = ingredient,
			Units = measurementUnit
		};
	}
}