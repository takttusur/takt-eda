using AutoMapper;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.MappingProfiles;

public class RecipesProfile : Profile
{
	public RecipesProfile()
	{
		CreateMap<Recipe, RecipeViewModel>();
	}
}