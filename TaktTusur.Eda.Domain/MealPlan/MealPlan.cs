using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Domain.MealPlan;

/// <summary>
/// Plan contains recipes for each eating time.
/// </summary>
public class MealPlan : Entity
{
	private readonly List<MealPlanRecord> _records = new List<MealPlanRecord>();

	public MealPlan(Guid longIdentifier, uint revision)
	{
		LongIdentifier = longIdentifier;
		Revision = revision;
	}

	/// <summary>
	/// Need to use GUID access to the meal plan. It's much safer than access by id.
	/// </summary>
	public Guid LongIdentifier { get; protected set; }

	/// <summary>
	/// The version of meal plan.
	/// Use this to check that the correct version should be updated.
	/// </summary>
	public uint Revision { get; protected set; }

	/// <summary>
	/// Collection of recipes and information about time and people.
	/// </summary>
	public IReadOnlyList<MealPlanRecord> Records => _records;

	/// <summary>
	/// Create the MealPlan.
	/// </summary>
	/// <returns>New meal plan with GUID.</returns>
	public static MealPlan Create()
	{
		return new MealPlan(Guid.NewGuid(), 0);
	}
}