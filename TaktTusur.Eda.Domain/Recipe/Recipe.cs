using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.Recipe;

/// <summary>
/// The collection of ingredients and guide how to cook it. 
/// </summary>
public class Recipe : Entity
{
	private readonly List<RecipeIngredient> _ingredients = new List<RecipeIngredient>();

	protected Recipe(string name, int timeToCookInSeconds, int timeToPrepareInSeconds, string cookingGuideText,
		uint revision)
	{
		Name = name;
		TimeToCookInSeconds = timeToCookInSeconds;
		TimeToPrepareInSeconds = timeToPrepareInSeconds;
		CookingGuideText = cookingGuideText;
		Revision = revision;
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

	/// <summary>
	/// The revision of current recipe. Need to confirm that correct recipe will be updated.
	/// </summary>
	public uint Revision { get; protected set; }

	/// <summary>
	/// Add ingredient to the recipe.
	/// </summary>
	/// <param name="ingredient">Ingredient.</param>
	/// <param name="unit">Measurement unit.</param>
	/// <param name="amountPerPerson">How much I need this for 1 person.</param>
	public void AddIngredient(Ingredient ingredient, MeasurementUnit unit, double amountPerPerson)
	{
		_ingredients.Add(RecipeIngredient.Create(ingredient, unit, amountPerPerson));
	}


	/// <summary>
	/// Updates the recipe information.
	/// </summary>
	/// <param name="name">The new name of the recipe.</param>
	/// <param name="timeToPrepareInSeconds">The new time to prepare the recipe in seconds.</param>
	/// <param name="timeToCookInSeconds">The new time to cook the recipe in seconds.</param>
	/// <param name="cookingGuideText">The new guide text for cooking the recipe.</param>
	/// <exception cref="EntityValidationException">Throws when name parameter is empty or null.</exception>
	public void UpdateRecipe(string name, int timeToPrepareInSeconds, int timeToCookInSeconds, string cookingGuideText)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new EntityValidationException(nameof(Name), "cannot be empty");

		bool isUpdated = false;

		if (Name != name)
		{
			Name = name;
			isUpdated = true;
		}

		if (TimeToPrepareInSeconds != timeToPrepareInSeconds)
		{
			TimeToPrepareInSeconds = timeToPrepareInSeconds;
			isUpdated = true;
		}

		if (TimeToCookInSeconds != timeToCookInSeconds)
		{
			TimeToCookInSeconds = timeToCookInSeconds;
			isUpdated = true;
		}

		if (CookingGuideText != cookingGuideText)
		{
			CookingGuideText = cookingGuideText;
			isUpdated = true;
		}

		if (isUpdated)
		{
			Revision++;
		}
	}

	/// <summary>
	/// Creates new Recipe.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="timeToPrepareInSeconds"></param>
	/// <param name="timeToCookInSeconds"></param>
	/// <param name="cookingGuideText"></param>
	/// <returns></returns>
	/// <exception cref="EntityValidationException">If input data is not valid.</exception>
	public static Recipe Create(string name, int timeToPrepareInSeconds = 0, int timeToCookInSeconds = 0,
		string cookingGuideText = "")
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new EntityValidationException(nameof(Name), "cannot be empty");

		return new Recipe(name, timeToCookInSeconds, timeToPrepareInSeconds, cookingGuideText, 0);
	}
}