using AutoMapper;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Base;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.Services;

public class ValuesDictionaryService(
	IMeasurementUnitsRepository measurementUnitsRepository,
	IIngredientsRepository ingredientsRepository,
	IMapper mapper) : IMeasurementUnitsService, IIngredientsService
{
	PageViewModel<IdNameViewModel> IHasPaging<MeasurementUnit, IdNameViewModel>.GetPage(int skip, int take)
	{
		return GetByData(measurementUnitsRepository, skip, take);
	}

	PageViewModel<IdNameViewModel> IHasPaging<Ingredient, IdNameViewModel>.GetPage(int skip, int take)
	{
		return GetByData(ingredientsRepository, skip, take);
	}

	private PageViewModel<IdNameViewModel> GetByData<T>(IRepository<T> repository, int skip, int take) where T : Entity
	{
		var data = repository.GetAll().Skip(skip).Take(take);
		var totalCount = repository.GetAll().Count();
		var measurementUnitViewModels = mapper.Map<List<IdNameViewModel>>(data);
		var pageViewModel = new PageViewModel<IdNameViewModel>
		{
			Skip = skip, Take = take, TotalCount = totalCount, Data = measurementUnitViewModels
		};
		return pageViewModel;
	}
}