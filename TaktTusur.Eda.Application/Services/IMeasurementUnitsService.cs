using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.ViewModels;

namespace TaktTusur.Eda.Application.Services;

public interface IMeasurementUnitsService
{
	public PageViewModel<MeasurementUnitViewModel> GetPage(int skip, int take);
}