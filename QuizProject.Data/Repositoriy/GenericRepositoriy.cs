using Microsoft.EntityFrameworkCore;
using QuizProject.Data.DbContexts;
using QuizProject.Data.IRepositoriy;
using QuizProject.Domain.Commons;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QuizProject.Data.Repositoriy
{
    public class GenericRepositoriy<T> : IGenericRepositoriy<T> where T : Auditable
    {
        private readonly QuizProjectDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepositoriy(QuizProjectDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).Entity;

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await GetAsync(x => x.Id == id);
            if (deleted is null) 
                return false;

            _dbSet.Remove(deleted);
            return true;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isTracking = true, string[] includes = null)
        {
            var getAll = expression is null ? _dbSet : _dbSet.Where(expression);

            if (includes != null)
                foreach (var include in includes)
                    if (!string.IsNullOrEmpty(include))
                        getAll = getAll.Include(include);

            if (!isTracking)
                _dbSet.AsNoTracking();

            return getAll;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracking = true, string[] includes = null)
            => await GetAll(expression, isTracking, includes).FirstOrDefaultAsync();        

        public T Update(T entity)
            => _dbSet.Update(entity).Entity;

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
