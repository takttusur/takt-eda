using Microsoft.AspNetCore.Mvc;
using TaktTusur.Eda.Domain.Recipe;
using TaktTusur.Eda.Domain.Recipe.Queries;

namespace TaktTusur.Eda.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
	[HttpGet]
	public GetRecipeListQueryResult Get(int skip, int take)
	{
		return null;
	}

	[HttpGet("{id:long}")]
	public FullRecipeDto Get(long id)
	{
		return null;
	}
}