using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MeasurementUnitController : ControllerBase
{
	private readonly IMeasurementUnitRepository _repository;

	public MeasurementUnitController(IMeasurementUnitRepository repository)
	{
		_repository = repository;
	}

	[HttpGet]
	public IEnumerable<MeasurementUnit> Get()
	{
		return _repository.GetAll();
	}
}