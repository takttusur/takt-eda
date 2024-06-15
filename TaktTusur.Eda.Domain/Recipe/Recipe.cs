namespace TaktTusur.Eda.Domain.Recipe;

/// <summary>
/// The collection of ingredients and guide how to cook it. 
/// </summary>
public class Recipe : Entity
{
	/// <summary>
	/// Name of dish.
	/// </summary>
	/// <example>Veal ribs, chicken soup.</example>
	public string Name { get; set; }

	/// <summary>
	/// Ingredients. All measurements should be for one person.
	/// </summary>
	public IReadOnlyCollection<RecipeIngredient> Ingredients { get; set; }

	/// <summary>
	/// How much time needed to prepare ingredients for this recipe in seconds.
	/// </summary>
	public int TimeToPrepareInSeconds { get; set; }

	/// <summary>
	/// Cooking time, when we have prepaired ingredients in seconds.
	/// </summary>
	public int TimeToCookInSeconds { get; set; }

	/// <summary>
	/// Description, how to prepare and cook the meal.
	/// </summary>
	public string CookingGuideText { get; set; }
}