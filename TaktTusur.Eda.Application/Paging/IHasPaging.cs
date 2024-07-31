namespace TaktTusur.Eda.Application.Paging;

public interface IHasPaging<in TSourceModel, TViewModel>
{
	public PageViewModel<TViewModel> GetPage(int skip, int take);
}