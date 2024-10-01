using TaktTusur.Eda.Domain.Base;
using TaktTusur.Eda.Domain.Recipe;

namespace TaktTusur.Eda.Domain.MealPlan;

/// <summary>
/// Plan contains recipes for each eating time.
/// </summary>
public class MealPlan : TimeTrackedEntity
{
	private readonly List<MealPlanRecord> _records = new List<MealPlanRecord>();

	public MealPlan(Guid longIdentifier, uint revision, DateTimeOffset createdAt, DateTimeOffset updatedAt)
	{
		LongIdentifier = longIdentifier;
		Revision = revision;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
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
		return new MealPlan(Guid.NewGuid(), 0, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
	}

	public void AddRecord(EatingTime eatingTime, uint people, DateTimeOffset date, Recipe.Recipe recipe)
	{
		var record = MealPlanRecord.Create(eatingTime, people, date, recipe);
		_records.Add(record);
		UpdatedAt = DateTimeOffset.Now;
	}
}