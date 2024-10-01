using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.Services;
using TaktTusur.Eda.Application.ViewModels;

namespace TaktTusur.Eda.Api.Controllers;

/// <summary>
/// Manage meal plans(create, change, view).
/// </summary>
[ApiController]
[Route("[controller]")]
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

	[HttpPost]
	public MealPlanFullViewModel CreateMealPlan(DateTimeOffset startDate, DateTimeOffset endDate, uint peopleCount)
	{
		return mealPlanService.CreateMealPlan(startDate, endDate, peopleCount);
	}
}