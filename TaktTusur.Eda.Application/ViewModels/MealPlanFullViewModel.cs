using TaktTusur.Eda.Domain.MealPlan;

namespace TaktTusur.Eda.Application.ViewModels;

public class MealPlanFullViewModel
{
	public long Id { get; set; }

	public Guid LongIdentifier { get; set; }

	public uint Revision { get; set; }

	public DateTimeOffset CreatedAt { get; set; }

	public DateTimeOffset UpdatedAt { get; set; }

	public List<MealPlanRecordViewModel> Records { get; set; }
}