using AutoMapper;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.MealPlan;

namespace TaktTusur.Eda.Application.MappingProfiles;

public class MealPlansProfile : Profile
{
	public MealPlansProfile()
	{
		CreateMap<MealPlan, MealPlanShortViewModel>();
		CreateMap<MealPlan, MealPlanFullViewModel>();

		CreateMap<MealPlanRecord, MealPlanRecordViewModel>()
			.ForMember(x => x.RecipeId,
				x => x.MapFrom(m => m.Recipe.Id))
			.ForMember(x => x.RecipeName,
				x => x.MapFrom(m => m.Recipe.Name))
			.ForMember(x => x.TimeToCookInSeconds,
				x => x.MapFrom(m => m.Recipe.TimeToCookInSeconds))
			.ForMember(x => x.TimeToPrepareInSeconds,
				x => x.MapFrom(m => m.Recipe.TimeToPrepareInSeconds));
	}
}