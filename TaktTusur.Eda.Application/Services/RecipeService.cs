using AutoMapper;
using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.Services;

public class RecipeService(IRecipeRepository repository, IMapper mapper) : IRecipesService
{
	public PageViewModel<RecipeViewModel> GetPage(int skip, int take)
	{
		var query = repository.GetAll().OrderBy(x => x.Name).Skip(skip).Take(take);
		var data = mapper.ProjectTo<RecipeViewModel>(query);
		return new PageViewModel<RecipeViewModel>()
		{
			Skip = skip,
			Take = take,
			TotalCount = repository.GetAll().Count(),
			Data = data.ToList()
		};
	}
}