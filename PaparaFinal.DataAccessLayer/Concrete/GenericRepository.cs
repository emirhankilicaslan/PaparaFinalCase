using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaparaFinal.DataAccessLayer.Abstract;
using PaparaFinal.DataAccessLayer.Context;

namespace PaparaFinal.DataAccessLayer.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly PaparaDbContext _context;

    public GenericRepository(PaparaDbContext context)
    {
        _context = context;
    }
    
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    
    public async Task<List<T>> Where(Expression<Func<T, bool>> expression,params string[] includes)
    {
        var query = _context.Set<T>().Where(expression).AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return await EntityFrameworkQueryableExtensions.ToListAsync(query);
    }
    
    public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression,params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return query.Where(expression).FirstOrDefault();
    }
}