namespace TaktTusur.Eda.Api.Models;

public class MealPlanCreateModel
{
	public DateTimeOffset StartDate { get; set; }
	public DateTimeOffset EndDate { get; set; }
	public uint PeopleCount { get; set; }
}