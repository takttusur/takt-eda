using TaktTusur.Eda.Application.Paging;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.Services;

public interface IRecipesService : IHasPaging<Recipe, RecipeShortViewModel>
{
	RecipeFullViewModel GetRecipeById(long id);
}