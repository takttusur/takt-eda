using TaktTusur.Eda.Domain.Base;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Domain.MealPlan;

/// <summary>
/// Information about one eating time. 
/// </summary>
public class MealPlanRecord : Entity
{
	public uint Id { get; protected set; }

	/// <summary>
	/// The meal what will be cooked.
	/// </summary>
	public Recipe.Recipe Recipe { get; protected set; }

	/// <summary>
	/// Eating time, based on day.
	/// </summary>
	public EatingTime EatingTime { get; protected set; }

	/// <summary>
	/// How much people will eat.
	/// </summary>
	public uint AmountOfPeople { get; protected set; }

	/// <summary>
	/// The date, when this meal will be eaten.
	/// </summary>
	public DateTimeOffset DateUtc { get; protected set; }
}