using TaktTusur.Eda.Domain.Base;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Domain.MealPlan;

/// <summary>
/// Information about one eating time. 
/// </summary>
public class MealPlanRecord : Entity
{
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

	/// <summary>
	/// The meal what will be cooked.
	/// </summary>
	public virtual Recipe.Recipe Recipe { get; protected set; }

	/// <summary>
	/// Parent MealPlan.
	/// </summary>
	public virtual MealPlan MealPlan { get; protected set; }

	public static MealPlanRecord Create(EatingTime time, uint amountOfPeople, DateTimeOffset dateUtc,
		Recipe.Recipe recipe)
	{
		return new MealPlanRecord()
		{
			EatingTime = time,
			AmountOfPeople = amountOfPeople,
			DateUtc = dateUtc,
			Recipe = recipe
		};
	}
}