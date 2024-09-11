using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.MealPlan;

/// <summary>
/// Plan contains recipes for each eating time.
/// </summary>
public class MealPlan : Entity
{
	/// <summary>
	/// Collection of recipes and information about time and people.
	/// </summary>
	public IReadOnlyList<MealPlanRecord> Records { get; protected set; }
}