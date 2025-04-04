using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Api.Models;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.Services;
using TaktTusur.Eda.Application.ViewModels;

namespace TaktTusur.Eda.Api.Controllers;

/// <summary>
/// Manage meal plans(create, change, view).
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class MealPlanController(IMealPlanService mealPlanService) : ControllerBase
{
	[HttpGet]
	public PageViewModel<MealPlanShortViewModel> GetAll(int skip = 0, int take = 10)
	{
		return mealPlanService.GetPage(skip, take);
	}

	[HttpGet("{longId:guid}")]
	public MealPlanFullViewModel Get(Guid longId)
	{
		return mealPlanService.GetByGuid(longId);
	}

	/// <summary>
	/// Creates new MealPlan. Empty or autofilled.
	/// </summary>
	/// <param name="model">The model for meal plan creation</param>
	/// <returns>Autofilled meal plan.</returns>
	[HttpPost]
	public MealPlanFullViewModel CreateMealPlan([FromBody] MealPlanCreateModel model)
	{
		return mealPlanService.CreateMealPlan(model.StartDate, model.EndDate, model.PeopleCount, true);
	}
}