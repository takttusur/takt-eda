using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.Services;
using TaktTusur.Eda.Application.ViewModels;

namespace TaktTusur.Eda.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController(IRecipesService recipesService) : ControllerBase
{
	[HttpGet]
	public PageViewModel<RecipeShortViewModel> Get(int skip = 0, int take = 10)
	{
		return recipesService.GetPage(skip, take);
	}

	[HttpGet("{id:long}")]
	public RecipeFullViewModel Get(long id)
	{
		return recipesService.GetRecipeById(id);
	}
}