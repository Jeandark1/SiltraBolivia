using CargoApi.Application.Interfaces.Repositories;
using CargoApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace CargoApi.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        private IDbContextTransaction _transaction;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Obtener por ID
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Obtener por ID con includes
        public virtual async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        // Obtener todos los registros
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Obtener todos los registros con includes
        public virtual async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        // Buscar registros por condición
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        // Buscar registros por condición con includes
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        // Obtener el primer registro que cumpla con la condición
        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        // Obtener el primer registro que cumpla con la condición con includes
        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        // Verificar si existe algún registro que cumpla con la condición
        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        // Contar registros que cumplan con la condición
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ?
                await _dbSet.CountAsync() :
                await _dbSet.CountAsync(predicate);
        }

        // Agregar nuevo registro
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Agregar rango de registros
        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        // Actualizar registro
        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Actualizar rango de registros
        public virtual async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        // Eliminar registro
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Eliminar rango de registros
        public virtual async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // Guardar cambios en la base de datos
        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Métodos de transacción

        // Iniciar una transacción
        public virtual async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
            else
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }
        }

        // Commit de la transacción
        public virtual async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        // Rollback de la transacción
        public virtual async Task RollbackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        // Métodos de paginación
        public virtual async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            // Aplicar includes
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            // Aplicar predicado de filtrado
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // Obtener el total de registros antes de la paginación
            var totalCount = await query.CountAsync();

            // Aplicar ordenamiento
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Aplicar paginación
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }





        /*
        // Obtener por ID con includes
        public virtual async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        // Obtener todos los registros
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        // Obtener todos los registros con includes
        public virtual async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        // Buscar registros por condicion
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        // Buscar registros por condicion con includes
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            //var query = _dbSet.AsQueryable();  para busquedas simples

            var query = _dbSet.Where(predicate);  // para busquedas con condiciones

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        // Obtener el primer registro que cumpla con la condicion o null si no existe
        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        // Obtener el primer registro que cumpla con la condicion o null si no existe con includes
        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        // Verificar si existe algun registro que cumpla con la condicion
        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        // Contar registros que cumplan con la condicion
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ?
                await _dbSet.CountAsync() :
                await _dbSet.CountAsync(predicate);
        }

        // Agregar nuevo registro
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        // Agregar rango de registros
        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        // Actualizar registro
        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        // Actualizar rango de registros
        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        // Eliminar registro
        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        // Eliminar rango de registros
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        // Guardar cambios en la base de datos
        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Métodos de transacción, begin commit, rollback

        // Iniciar una transacción
        public virtual async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
            else
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }
        }

        // Commit de la transacción
        public virtual async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        // Rollback de la transacción
        public virtual async Task RollbackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
            }
        }

        // Métodos de paginación
        public virtual async Task<(IEnumerable<T> Items, int TotalCount)> 
        GetPagedAsync(
            int pageNumber, 
            int pageSize,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable();

            // Aplicar includes
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            // Aplicar predicado de filtrado
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            //obtener el total de registros antes de la paginacion
            var totalCount = await query.CountAsync();

            // Aplicar ordenamiento
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Aplicar paginación
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }   */

    }
}
