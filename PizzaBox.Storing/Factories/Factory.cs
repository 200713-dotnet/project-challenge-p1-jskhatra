using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storing.Factories
{
  public class Factory<T> : IFactory<T> where T : class, new()
  {
    protected readonly DbContext Context;

    public Factory(DbContext context)
    {
      Context = context;
    }

    public void Add(T entity)
    {
      Context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
      Context.Set<T>().AddRange(entities);
    }

    IEnumerable<T> IFactory<T>.Find(Expression<Func<T, bool>> predicate)
    {
      return Context.Set<T>().Where(predicate);
    }

    public T Get(int id)
    {
      return Context.Set<T>().Find(id);
    }

    IEnumerable<T> IFactory<T>.GetAll()
    {
      return Context.Set<T>().ToList();
    }

    public void Remove(T entity)
    {
      Context.Set<T>().Remove(entity);
    }

    public void RemoveRange(T entities)
    {
      Context.Set<T>().RemoveRange(entities);
    }
  }
}