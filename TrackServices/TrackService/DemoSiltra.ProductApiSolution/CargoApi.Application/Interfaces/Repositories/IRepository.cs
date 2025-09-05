

using System.Linq.Expressions;

namespace CargoApi.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {

        // CRUD BASICO

        // obtener informacion de usuario por ID
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);

        // Obtener todos los registros
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        // Buscar registros
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        // Obtener primer registro
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        // Verificar existencia
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        // Contar registros
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

        // Operaciones de escritura (estos deben devolver las entidades afectadas)
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteRangeAsync(IEnumerable<T> entities);


        // guardar cambios en la base de datos
        Task SaveChangesAsync();

        // Métodos de transacción, begin commit, rollback
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        // Métodos de paginación
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);

    }
}
