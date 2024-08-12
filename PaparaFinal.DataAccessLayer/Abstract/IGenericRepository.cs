using System.Linq.Expressions;

namespace PaparaFinal.DataAccessLayer.Abstract;

public interface IGenericRepository<T> where T : class
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    T GetById(int id);
    List<T> GetAll();
    Task<List<T>> Where(Expression<Func<T, bool>> expression,params string[] includes);
    Task<T> FirstOrDefault(Expression<Func<T, bool>> expression,params string[] includes);

}