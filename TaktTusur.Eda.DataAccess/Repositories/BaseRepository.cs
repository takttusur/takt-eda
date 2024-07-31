using Microsoft.EntityFrameworkCore;
using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.DataAccess.Repositories;

public abstract class BaseRepository<T>(DbContext dbContext) : IRepository<T>
	where T : Entity
{
	public abstract IQueryable<T> GetAll();

	public T? GetById(long id)
	{
		return dbContext.Find<T>(id);
	}

	public void Create(T entity)
	{
		dbContext.Add(entity);
		dbContext.SaveChanges();
	}

	public void Update(T entity)
	{
		dbContext.Update(entity);
		dbContext.SaveChanges();
	}

	public void Delete(T entity)
	{
		dbContext.Remove(entity);
		dbContext.SaveChanges();
	}
}