namespace TaktTusur.Eda.Domain.Base;

public class EntityValidationException : Exception
{
	private const string MessageTemplate = "Incorrect value for {0}: {1}";

	public EntityValidationException(string field, string reason)
		: base(string.Format(MessageTemplate, field, reason))
	{
		Field = field;
		Reason = reason;
	}

	public string Field { get; protected set; }

	public string Reason { get; protected set; }
}