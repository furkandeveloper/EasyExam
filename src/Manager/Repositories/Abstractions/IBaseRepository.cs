using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Repositories.Abstractions
{
    /// <summary>
    /// This interface includes CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Database entity.
    /// </typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseModel, new()
    {
        /// <summary>
        /// Insert document.
        /// </summary>
        /// <param name="value">
        /// Database entity
        /// </param>
        void Insert(TEntity value);
        /// <summary>
        /// Insert document.
        /// </summary>
        /// <param name="value">
        /// Database Entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        TEntity Add(TEntity value);
        /// <summary>
        /// Async insert document.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        Task<TEntity> AddAsync(TEntity value);
        /// <summary>
        /// Remove document.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        void Delete(TEntity value);
        /// <summary>
        /// Remove document.
        /// </summary>
        /// <param name="id">
        /// Document id.
        /// </param>
        void Delete(string id);
        /// <summary>
        /// Async remove document.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// NoContent
        /// </returns>
        Task DeleteAsync(TEntity value);
        /// <summary>
        /// Async remove document.
        /// </summary>
        /// <param name="id">
        /// Document id.
        /// </param>
        /// <returns>
        /// NoContent
        /// </returns>
        Task DeleteAsync(string id);
        /// <summary>
        /// Get database entity.
        /// </summary>
        /// <param name="filter">
        /// Expression for database entity.
        /// </param>
        /// <returns>
        /// Queryable database entity.
        /// </returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        /// <summary>
        /// Get database entity.
        /// </summary>
        /// <returns>
        /// Queryable database entity.
        /// </returns>
        IQueryable<TEntity> Get();
        /// <summary>
        /// Get list database entity.
        /// </summary>
        /// <param name="func">
        /// Expression for database entity.
        /// </param>
        /// <returns>
        /// List of database entity.
        /// </returns>
        Task<List<TEntity>> GetMultiple(Expression<Func<TEntity, bool>> func);
        /// <summary>
        /// Async Get list database entity.
        /// </summary>
        /// <param name="query">
        /// Query for database entity.
        /// </param>
        /// <returns>
        /// List of database entity.
        /// </returns>
        Task<List<TEntity>> GetMultiple(IQueryable<TEntity> query);
        /// <summary>
        /// Async Get single database entity.
        /// </summary>
        /// <param name="func">
        /// Expression of database entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        TEntity GetSingle(Expression<Func<TEntity, bool>> func);
        /// <summary>
        /// Get single database entity.
        /// </summary>
        /// <param name="id">
        /// Document id for database entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        TEntity GetSingle(string id);
        /// <summary>
        /// Async get single database entity.
        /// </summary>
        /// <param name="query">
        /// Expression for database entity
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> query);
        /// <summary>
        /// Async get single database entity.
        /// </summary>
        /// <param name="id">
        /// Document id for database entity.
        /// </param>
        Task<TEntity> GetSingleAsync(string id);
        /// <summary>
        /// Replace database entity.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        void Replace(TEntity value);
        /// <summary>
        /// Async replace database entity.
        /// </summary>
        /// <param name="value">
        /// Database Entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        Task ReplaceAsync(TEntity value);
        /// <summary>
        /// Update databese entity.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        void Update(TEntity value);
        /// <summary>
        /// Async update database entity.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        Task UpdateAsync(TEntity value);
        /// <summary>
        /// Get activity rules for database entity.
        /// </summary>
        /// <returns>
        /// Queryable database entity.
        /// </returns>
        IQueryable<TEntity> GetActiveRules();
    }
}
