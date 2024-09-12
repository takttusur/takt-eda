using System.Linq.Expressions;

namespace TaktTusur.Eda.Domain.Base;

public interface IRepository<T> where T : Entity
{
	IQueryable<T> GetAll(bool useTracking = false);

	T? GetById(long id);

	T? GetById(long id, params Func<IQueryable<T>, IQueryable<T>>[] includes);

	void Create(T entity);

	void Update(T entity);

	void Delete(T entity);
}