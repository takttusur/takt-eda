using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.MealPlan;

public interface IMealPlanRepository : IRepository<MealPlan>
{
	MealPlan GetByGuid(Guid guid);
}