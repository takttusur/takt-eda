using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Domain.Base;
using TaktTusur.Eda.Domain.MealPlan.Commands;
using TaktTusur.Eda.Domain.MealPlan.Queries;

namespace TaktTusur.Eda.Api.Controllers;

/// <summary>
/// Manage meal plans(create, change, view).
/// </summary>
public class MealPlanController(MediatR.IMediator mediator) : ControllerBase
{
	/// <summary>
	/// Schedule a generate meal plan task with parameters.
	/// </summary>
	/// <param name="generateMealPlanCommand">Parameters of meal plan.</param>
	[HttpPost("generate")]
	public async Task<ActionResult<IdDto>> Post(GenerateMealPlanCommand generateMealPlanCommand)
	{
		var id = await mediator.Send(generateMealPlanCommand, this.Request.HttpContext.RequestAborted);

		return Created(Url.Action("Get", new
		{
			id = id.Id
		}), id);
	}

	/// <summary>
	/// Get a meal plan by id. 
	/// </summary>
	/// <param name="id">Identifier of meal plan.</param>
	[HttpGet("{id:long}")]
	public async Task<ActionResult<GetMealPlanQueryResult>> Get(long id)
	{
		var query = GetMealPlanQuery.Create(id);
		var result = await mediator.Send(query);

		return result;
	}
}