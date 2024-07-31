namespace TaktTusur.Eda.Application.Paging;

public class PageViewModel<T>
{
	public int Skip { get; set; }

	public int Take { get; set; }

	public int TotalCount { get; set; }

	public IReadOnlyList<T> Data { get; set; }
}