using Entities.Models;
using Manager.Context;
using Manager.Repositories.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Repositories.Concrete
{
    /// <summary>
    /// This class includes CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Database entity.
    /// </typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseModel, new()
    {
        /// <summary>
        /// DbContext.
        /// </summary>
        private protected readonly IEasyExamContext context;
        /// <summary>
        /// Database collection.
        /// </summary>
        private protected Func<string> collection = () => null;
        /// <summary>
        /// Application db context.
        /// </summary>
        private protected Func<IEasyExamContext, IMongoCollection<TEntity>> set;
        /// <summary>
        /// Document id.
        /// </summary>
        private string primaryKey;
        /// <summary>
        /// Document id.
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                if (!string.IsNullOrEmpty(primaryKey))
                    return primaryKey;
                var property = typeof(TEntity).GetProperties().FirstOrDefault(x => x.GetCustomAttributes(typeof(BsonIdAttribute), false).Count() > 0);
                var attribute = property.GetCustomAttributes(typeof(BsonElementAttribute), false).FirstOrDefault();
                primaryKey = (attribute as BsonElementAttribute)?.ElementName ?? property.Name;
                return primaryKey;
            }
        }

        /// <summary>
        /// Ctor method.
        /// </summary>
        /// <param name="context">
        /// Application dbContext.
        /// </param>
        public BaseRepository(IEasyExamContext context)
        {
            this.context = context;
            set = (ctx) => ctx.Set<TEntity>(collection()); // default set method
        }

        /// <summary>
        /// Insert document.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        public virtual TEntity Add(TEntity value)
        {
            set(context).InsertOne(value);
            return value;
        }

        /// <summary>
        /// Async insert document.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        public virtual async Task<TEntity> AddAsync(TEntity value)
        {
            await set(context).InsertOneAsync(value);
            return value;
        }

        /// <summary>
        /// Remove document.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        public virtual void Delete(TEntity value)
        {
            set(context).DeleteOne(new BsonDocument(new BsonElement(PrimaryKey, BsonValue.Create(value.ToBsonDocument()["_id"]))));
        }

        /// <summary>
        /// Remove document.
        /// </summary>
        /// <param name="id">
        /// Document id.
        /// </param>
        public virtual void Delete(string id)
        {
            set(context).DeleteOne(new BsonDocument(new BsonElement(PrimaryKey, BsonValue.Create(id))));
        }

        /// <summary>
        /// Remove document.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        public virtual async Task DeleteAsync(TEntity value)
        {
            await set(context).DeleteOneAsync(new BsonDocument(new BsonElement("_id", BsonValue.Create(value.ToBsonDocument()["_id"]))));
        }

        /// <summary>
        /// Remove document.
        /// </summary>
        /// <param name="id">
        /// Document id.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        public virtual async Task DeleteAsync(string id)
        {
            await set(context).DeleteOneAsync(new BsonDocument(new BsonElement("_id", BsonValue.Create(id))));
        }
        /// <summary>
        /// Get database entity.
        /// </summary>
        /// <param name="filter">
        /// Expression for database entity.
        /// </param>
        /// <returns>
        /// Queryable database entity.
        /// </returns>
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return Get().Where(filter);
        }

        /// <summary>
        /// Get queryable database entity.
        /// </summary>
        /// <returns>
        /// Queryable database entity.
        /// </returns>
        public virtual IQueryable<TEntity> Get()
        {
            return set(context).AsQueryable();
        }

        /// <summary>
        /// Get activity rules for database entity.
        /// </summary>
        /// <returns>
        /// Queryable database entity.
        /// </returns>
        public virtual IQueryable<TEntity> GetActiveRules()
        {
            return Get();
        }

        /// <summary>
        /// Get list database entity.
        /// </summary>
        /// <param name="func">
        /// Expression for database entity.
        /// </param>
        /// <returns>
        /// List of database entity.
        /// </returns>
        public virtual Task<List<TEntity>> GetMultiple(Expression<Func<TEntity, bool>> func)
        {
            return Task.FromResult(Get().Where(func).ToList());
        }

        /// <summary>
        /// Async Get list database entity.
        /// </summary>
        /// <param name="query">
        /// Query for database entity.
        /// </param>
        /// <returns>
        /// List of database entity.
        /// </returns>
        public Task<List<TEntity>> GetMultiple(IQueryable<TEntity> query)
        {
            return Task.FromResult(query.ToList());
        }

        /// <summary>
        /// Async Get single database entity.
        /// </summary>
        /// <param name="func">
        /// Expression of database entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> func)
        {
            return set(context).AsQueryable().FirstOrDefault(func);
        }
        /// <summary>
        /// Get single database entity.
        /// </summary>
        /// <param name="id">
        /// Document id for database entity.
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        public virtual TEntity GetSingle(string id)
        {
            return set(context).Find(new BsonDocument(new BsonElement("_id", BsonValue.Create(id)))).FirstOrDefault();
        }
        /// <summary>
        /// Async get single database entity.
        /// </summary>
        /// <param name="query">
        /// Expression for database entity
        /// </param>
        /// <returns>
        /// Database entity.
        /// </returns>
        public virtual Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> query)
        {
            TaskCompletionSource<TEntity> tcs = new TaskCompletionSource<TEntity>();
            var entity = set(context).AsQueryable().FirstOrDefault(query);
            tcs.TrySetResult(entity);
            return tcs.Task;
        }
        /// <summary>
        /// Async get single database entity.
        /// </summary>
        /// <param name="id">
        /// Document id for database entity.
        /// </param>
        public Task<TEntity> GetSingleAsync(string id)
        {
            return Task.Run(() => GetSingle(id));
        }
        /// <summary>
        /// Insert document.
        /// </summary>
        /// <param name="value">
        /// Database entity
        /// </param>
        public virtual void Insert(TEntity value)
        {
            set(context).InsertOne(value);
        }
        /// <summary>
        /// Replace database entity.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        public virtual void Replace(TEntity value)
        {
            set(context).ReplaceOne(new BsonDocument(new BsonElement("_id", BsonValue.Create(value.ToBsonDocument()["_id"]))), value);
        }
        /// <summary>
        /// Async replace database entity.
        /// </summary>
        /// <param name="value">
        /// Database Entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        public virtual async Task ReplaceAsync(TEntity value)
        {
            await set(context).ReplaceOneAsync(new BsonDocument(new BsonElement("_id", BsonValue.Create(value.ToBsonDocument()["_id"]))), value);
        }
        /// <summary>
        /// Update databese entity.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        public virtual void Update(TEntity value)
        {
            var filter = new BsonDocument(new BsonElement("_id", BsonValue.Create(value.ToBsonDocument()["_id"])));
            var edited = set(context).Find(filter).First();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                var _val = property.GetValue(value);
                if (!_val.Equals(default))
                    property.SetValue(edited, _val);
            }
            set(context).ReplaceOne(filter, edited);
        }
        /// <summary>
        /// Async update database entity.
        /// </summary>
        /// <param name="value">
        /// Database entity.
        /// </param>
        /// <returns>
        /// NoContent.
        /// </returns>
        public virtual async Task UpdateAsync(TEntity value)
        {
            var filter = new BsonDocument(new BsonElement("_id", BsonValue.Create(value.ToBsonDocument()["_id"])));
            var edited = await set(context).Find(filter).FirstAsync();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                var _val = property.GetValue(value);
                if (!_val.Equals(default))
                    property.SetValue(edited, _val);
            }
            await set(context).ReplaceOneAsync(filter, edited);
        }
    }
}
