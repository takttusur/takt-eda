using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TaktTusur.Eda.Domain.Base;

namespace TaktTusur.Eda.Infrastructure.Repositories;

public abstract class BaseRepository<T>(DbContext dbContext) : IRepository<T>
	where T : Entity
{
	public abstract IQueryable<T> GetAll(bool useTracking = false);

	public virtual T? GetById(long id)
	{
		return GetById(id, []);
	}

	public virtual T? GetById(long id, params Func<IQueryable<T>, IQueryable<T>>[] includes)
	{
		IQueryable<T> query = dbContext.Set<T>();

		foreach (var path in includes)
		{
			query = path(query);
		}

		return query.SingleOrDefault(e => e.Id == id);
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