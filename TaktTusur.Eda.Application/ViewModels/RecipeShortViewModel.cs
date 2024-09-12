namespace TaktTusur.Eda.Application.ViewModels;

public class RecipeShortViewModel
{
	public long Id { get; set; }

	public string Name { get; set; }

	public int TimeToPrepareInSeconds { get; set; }

	public int TimeToCookInSeconds { get; set; }
}