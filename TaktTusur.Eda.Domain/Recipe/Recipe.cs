using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.Recipe;

/// <summary>
/// The collection of ingredients and guide how to cook it. 
/// </summary>
public class Recipe : Entity
{
	private readonly List<RecipeIngredient> _ingredients = new List<RecipeIngredient>();

	protected Recipe(string name, int timeToCookInSeconds, int timeToPrepareInSeconds, string cookingGuideText)
	{
		Name = name;
		TimeToCookInSeconds = timeToCookInSeconds;
		TimeToPrepareInSeconds = timeToPrepareInSeconds;
		CookingGuideText = cookingGuideText;
	}

	/// <summary>
	/// Name of dish.
	/// </summary>
	/// <example>Veal ribs, chicken soup.</example>
	public string Name { get; protected set; }

	/// <summary>
	/// Ingredients. All measurements should be for one person.
	/// </summary>
	public IReadOnlyList<RecipeIngredient> Ingredients => _ingredients.AsReadOnly();

	/// <summary>
	/// How much time needed to prepare ingredients for this recipe in seconds.
	/// </summary>
	public int TimeToPrepareInSeconds { get; protected set; }

	/// <summary>
	/// Cooking time, when we have prepaired ingredients in seconds.
	/// </summary>
	public int TimeToCookInSeconds { get; protected set; }

	/// <summary>
	/// Description, how to prepare and cook the meal.
	/// </summary>
	public string CookingGuideText { get; protected set; }

	public static Recipe Create(string name, int timeToPrepareInSeconds = 0, int timeToCookInSeconds = 0,
		string cookingGuideText = "")
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new EntityValidationException(nameof(Name), "cannot be empty");

		return new Recipe(name, timeToCookInSeconds, timeToPrepareInSeconds, cookingGuideText);
	}
}