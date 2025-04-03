using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.Services;
using TaktTusur.Eda.Application.ViewModels;

namespace TaktTusur.Eda.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class IngredientController(IIngredientsService ingredientsService) : ControllerBase
{
	[HttpGet]
	public PageViewModel<IdNameViewModel> Get(int skip = 0, int take = 10)
	{
		return ingredientsService.GetPage(skip, take);
	}
}