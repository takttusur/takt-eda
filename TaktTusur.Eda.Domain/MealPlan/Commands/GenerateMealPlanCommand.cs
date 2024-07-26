using System.ComponentModel.DataAnnotations;
using MediatR;
using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.MealPlan.Commands;

/// <summary>
/// Generate a meal plan based on parameters.
/// </summary>
public class GenerateMealPlanCommand : IRequest<IdDto>
{
	protected GenerateMealPlanCommand(int days, int peopleCount)
	{
		Days = days;
		PeopleCount = peopleCount;
	}

	/// <summary>
	/// Trip duration in days.
	/// </summary>
	[Range(1, 14, ErrorMessage = "allowed values from 1 to 14")]
	public int Days { get; }

	/// <summary>
	/// Count of participants.
	/// </summary>
	[System.ComponentModel.DataAnnotations.Range(1, 30, ErrorMessage = "allowed values from 1 to 30")]
	public int PeopleCount { get; }
}