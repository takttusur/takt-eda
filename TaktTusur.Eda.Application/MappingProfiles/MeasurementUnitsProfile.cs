using AutoMapper;
using TaktTusur.Eda.Application.ViewModels;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Application.Mappings;

public class MeasurementUnitsProfile : Profile
{
	public MeasurementUnitsProfile()
	{
		CreateMap<MeasurementUnit, MeasurementUnitViewModel>();
	}
}