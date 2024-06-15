namespace TaktTusur.Eda.Domain.Recipe;

/// <summary>
/// Ingredint. It's a product which can be used in recipe.
/// </summary>
public class Ingredient : Entity
{
	/// <summary>
	/// Name of product.
	/// </summary>
	/// <example>Potato, rice, milk...</example>
	public string Name { get; set; }
}