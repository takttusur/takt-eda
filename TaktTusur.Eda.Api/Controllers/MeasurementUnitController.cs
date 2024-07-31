using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.Services;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MeasurementUnitController(IMeasurementUnitsService service) : ControllerBase
{
	[HttpGet]
	public PageViewModel<MeasurementUnitViewModel> Get(int skip = 0, int take = 10)
	{
		return service.GetPage(skip, take);
	}
}