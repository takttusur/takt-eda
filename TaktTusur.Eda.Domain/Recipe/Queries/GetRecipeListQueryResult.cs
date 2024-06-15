namespace TaktTusur.Eda.Domain.Recipe.Queries;

public class GetRecipeListQueryResult
{
	public List<RecipeListItemDto> Recipes { get; protected set; }

	public int TotalCount { get; set; }
}