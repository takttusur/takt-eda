using AutoMapper;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.MealPlan;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.Services;

public class MealPlanService(IMealPlanRepository repository, IMapper mapper, IRecipeRepository recipeRepository)
	: IMealPlanService
{
	public PageViewModel<MealPlanShortViewModel> GetPage(int skip, int take)
	{
		var query = repository.GetAll().OrderBy(x => x.Id).Skip(skip).Take(take);
		var data = mapper.ProjectTo<MealPlanShortViewModel>(query);
		return new PageViewModel<MealPlanShortViewModel>()
		{
			Skip = skip,
			Take = take,
			TotalCount = repository.GetAll().Count(),
			Data = data.ToList()
		};
	}

	public MealPlanFullViewModel GetById(long id)
	{
		var query = repository.GetById(id);

		return mapper.Map<MealPlanFullViewModel>(query);
	}

	public MealPlanFullViewModel GetByGuid(Guid guid)
	{
		var query = repository.GetByGuid(guid);

		return mapper.Map<MealPlanFullViewModel>(query);
	}

	public MealPlanFullViewModel CreateMealPlan(DateTimeOffset startDate, DateTimeOffset endDate, uint peopleCount)
	{
		var recipes = recipeRepository.GetAll().ToArray();
		var count = recipes.Length;
		var random = new Random();

		var mealPlan = MealPlan.Create();

		for (var currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
		{
			mealPlan.AddRecord(EatingTime.Breakfast, peopleCount, currentDate, recipes[random.Next(count)]);
			mealPlan.AddRecord(EatingTime.Lunch, peopleCount, currentDate, recipes[random.Next(count)]);
			mealPlan.AddRecord(EatingTime.Dinner, peopleCount, currentDate, recipes[random.Next(count)]);
		}

		repository.Create(mealPlan);

		return mapper.Map<MealPlan, MealPlanFullViewModel>(mealPlan);
	}
}