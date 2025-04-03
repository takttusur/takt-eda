namespace TaktTusur.Eda.Api.Tests.Infrastructure;

public class ListResponse<T>
{
	public int Skip { get; set; }

	public int Take { get; set; }

	public int TotalCount { get; set; }

	public List<T> Data { get; set; }
}