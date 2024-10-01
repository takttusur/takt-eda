using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.MealPlan;

namespace TaktTusur.Eda.Application.Services;

public interface IMealPlanService : IHasPaging<MealPlan, MealPlanShortViewModel>
{
	MealPlanFullViewModel GetById(long id);

	MealPlanFullViewModel GetByGuid(Guid guid);

	MealPlanFullViewModel CreateMealPlan(DateTimeOffset startDate, DateTimeOffset endDate, uint peopleCount);
}