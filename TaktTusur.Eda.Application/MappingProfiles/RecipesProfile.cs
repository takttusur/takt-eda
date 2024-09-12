using AutoMapper;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.MappingProfiles;

public class RecipesProfile : Profile
{
	public RecipesProfile()
	{
		CreateMap<Recipe, RecipeShortViewModel>();
		CreateMap<Recipe, RecipeFullViewModel>();
		CreateMap<RecipeIngredient, RecipeIngredientViewModel>()
			.ForMember(x => x.AmountPerPerson, m => m.MapFrom(x => x.AmountPerPerson))
			.ForMember(x => x.IngredientName, m => m.MapFrom(x => x.Ingredient.Name))
			.ForMember(x => x.MeasurementUnitName, m => m.MapFrom(x => x.Units.Name));
	}
}