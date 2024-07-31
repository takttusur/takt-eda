using AutoMapper;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.MappingProfiles;

public class MeasurementUnitsProfile : Profile
{
	public MeasurementUnitsProfile()
	{
		CreateMap<MeasurementUnit, IdNameViewModel>();
	}
}