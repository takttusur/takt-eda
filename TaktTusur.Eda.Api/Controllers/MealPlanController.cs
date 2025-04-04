using Microsoft.AspNetCore.Mvc;
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
	/// <param name="startDate">Start date for plan.</param>
	/// <param name="endDate">End date for plan.</param>
	/// <param name="peopleCount">How many people will eat.</param>
	/// <param name="autofill">Is autofilling needed?</param>
	/// <returns>Empty meal plan, but can be autofilleld later.</returns>
	[HttpPost]
	public MealPlanFullViewModel CreateMealPlan(DateTimeOffset startDate, DateTimeOffset endDate, uint peopleCount,
		bool autofill = false)
	{
		return mealPlanService.CreateMealPlan(startDate, endDate, peopleCount, autofill);
	}
}