namespace TaktTusur.Eda.Domain.Base;

public interface IRepository<T> where T : Entity
{
	IQueryable<T> GetAll();

	T? GetById(long id);

	void Create(T entity);

	void Update(T entity);

	void Delete(T entity);
}