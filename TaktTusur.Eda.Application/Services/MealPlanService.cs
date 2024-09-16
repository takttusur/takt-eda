using AutoMapper;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.MealPlan;

namespace TaktTusur.Eda.Application.Services;

public class MealPlanService(IMealPlanRepository repository, IMapper mapper) : IMealPlanService
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
}