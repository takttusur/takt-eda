namespace TaktTusur.Eda.Domain.Base;

/// <summary>
/// The <see cref="Entity"/> which is tracked by time.
/// </summary>
public class TimeTrackedEntity : Entity
{
	/// <summary>
	/// UTC date time when this entity was created.
	/// </summary>
	public DateTimeOffset CreatedAt { get; protected set; }

	/// <summary>
	/// UTC date time when this entity got update last time.
	/// </summary>
	public DateTimeOffset UpdatedAt { get; protected set; }
}