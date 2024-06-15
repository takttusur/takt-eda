namespace TaktTusur.Eda.Domain.Recipe.Queries;

/// <summary>
/// Small model for recipe.
/// </summary>
public class RecipeListItemDto
{
	public long Id { get; set; }

	public string Name { get; set; }

	public int TotalCookingTimeInSec { get; set; }
}