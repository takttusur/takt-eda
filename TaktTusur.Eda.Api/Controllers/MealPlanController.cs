using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Domain.MealPlan.Commands;

namespace TaktTusur.Eda.Api.Controllers;

public class MealPlanController : ControllerBase
{
	[HttpPost]
	public void Post(CreateMealPlanCommand createMealPlanCommand)
	{
	}

	[HttpGet]
	public void Get(long id)
	{
	}
}