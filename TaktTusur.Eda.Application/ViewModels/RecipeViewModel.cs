namespace TaktTusur.Eda.Application.ViewModels;

public class RecipeViewModel
{
	public long Id { get; set; }

	public string Name { get; set; }

	public int TimeToPrepareInSeconds { get; set; }

	public int TimeToCookInSeconds { get; set; }

	public string CookingGuideText { get; set; }
}