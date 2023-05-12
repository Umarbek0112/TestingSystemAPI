using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using QuizProject.Domain.Commons;

namespace QuizProject.Data.IRepositoriy
{
    public interface IGenericRepositoriy<T> where T : Auditable
    {
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isTracking = true, string[] includes = null);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking = true, string[] includes = null);
        public Task<T> CreateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
        public T Update(T entity);
        public Task SaveChangesAsync();
    }
}
