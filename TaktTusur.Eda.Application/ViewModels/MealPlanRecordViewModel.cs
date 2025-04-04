using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.ViewModels;

public class MealPlanRecordViewModel
{
	public long Id { get; set; }

	public EatingTime EatingTime { get; set; }

	public uint AmountOfPeople { get; set; }

	public DateTimeOffset DateUtc { get; set; }

	public long RecipeId { get; set; }

	public string RecipeName { get; set; }

	public int TimeToPrepareInSeconds { get; set; }

	public int TimeToCookInSeconds { get; set; }
}