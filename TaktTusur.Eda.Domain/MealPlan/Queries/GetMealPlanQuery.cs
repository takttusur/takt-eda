using System.ComponentModel.DataAnnotations;
using MediatR;

namespace TaktTusur.Eda.Domain.MealPlan.Queries;

/// <summary>
/// Get a meal plan.
/// </summary>
public class GetMealPlanQuery : IRequest<GetMealPlanQueryResult>
{
	protected GetMealPlanQuery(long id)
	{
		Id = id;
	}

	/// <summary>
	/// Identifier of plan.
	/// </summary>
	[System.ComponentModel.DataAnnotations.Range(0, long.MaxValue)]
	public long Id { get; }

	public static GetMealPlanQuery Create(long id)
	{
		if (id < 0)
			throw new ValidationException();

		return new GetMealPlanQuery(id);
	}
}