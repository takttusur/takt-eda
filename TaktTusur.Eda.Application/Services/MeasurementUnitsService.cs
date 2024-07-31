using AutoMapper;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.Services;

public class MeasurementUnitsService(IMeasurementUnitsRepository repository, IMapper mapper) : IMeasurementUnitsService
{
	public PageViewModel<MeasurementUnitViewModel> GetPage(int skip, int take)
	{
		var data = repository.GetAll().OrderBy(u => u.Name).Skip(skip).Take(take);
		var totalCount = repository.GetAll().Count();
		var measurementUnitViewModels = mapper.Map<List<MeasurementUnitViewModel>>(data);
		var pageViewModel = new PageViewModel<MeasurementUnitViewModel>
		{
			Skip = skip, Take = take, TotalCount = totalCount, Data = measurementUnitViewModels
		};
		return pageViewModel;
	}
}