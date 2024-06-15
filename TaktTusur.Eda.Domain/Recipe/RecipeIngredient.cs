namespace TaktTusur.Eda.Domain.Recipe;

public class RecipeIngredient : Entity
{
	public Ingredient Ingredient { get; set; }

	public MeasurementUnit Units { get; set; }

	/// <summary>
	/// Amout of ingredient to cook the meal for one person.
	/// </summary>
	public decimal AmountPerPerson { get; set; }
}