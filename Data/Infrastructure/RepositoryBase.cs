
namespace MinimalAPI.Data;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.Extensions.Configuration;

public abstract class RepositoryBase<T> where T : class
{
    private CourseDataContext dataContext;
    private readonly DbSet<T> dbset;
    protected RepositoryBase(CourseDataContext dataContext)
    {
        this.dataContext = dataContext;
        dbset = this.dataContext.Set<T>();
    }

    public virtual void Add(T entity)
    {
        dbset.Add(entity);
    }
    public virtual void Update(T entity)
    {
        dbset.Attach(entity);
        this.dataContext.Entry(entity).State = EntityState.Modified;
    }
    public virtual void Delete(T entity)
    {
        dbset.Remove(entity);
    }
    public virtual void Delete(Expression<Func<T, bool>> where)
    {
        IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
        foreach (T obj in objects)
            dbset.Remove(obj);
    }
    public virtual T GetById(long id)
    {
        return dbset.Find(id);
    }
    public virtual T GetById(string id)
    {
        return dbset.Find(id);
    }
    public virtual IEnumerable<T> GetAll()
    {
        return dbset.ToList();
    }
    public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
    {
        return dbset.Where(where).ToList();
    }
    public T Get(Expression<Func<T, bool>> where)
    {

        return dbset.Where(where).FirstOrDefault<T>();
    }

    public virtual IEnumerable<T> GetInclude(Expression<Func<T, Object>> path, Expression<Func<T, bool>> where)
    {
        return dbset.Include(path).Where(where).ToList();
    }
    public virtual IEnumerable<T> GetInclude(Expression<Func<T, Object>> path)
    {
        return dbset.Include(path).ToList();
    }

    
}