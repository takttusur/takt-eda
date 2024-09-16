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
	}
}