using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace psl.API.Infrastructure
{
    public interface IBaseRepository<TEntity, TModel>
    {
        void Save(); //Save changes made to the context.
        bool Any(Expression<Func<TEntity, bool>> lambda); //Test whether any rows meet the specified criteria.
        IEnumerable<TModel> All(); //Retrieves all rows in a table
        IEnumerable<TModel> All(params Expression<Func<TEntity, object>>[] includeProperties); //Same as All but with overridden navigator properties
        int Count(); //Count all rows in table
        int Count(Expression<Func<TEntity, bool>> lambda); //Count rows returned after executing WHERE clause
        int Count(QueryModel<TModel> query); //Count rows returned after matching query
        int Count(QueryModel<TModel> query, Expression<Func<TEntity, bool>> lambda); //Count rows returned after matching query and executing WHERE clause
        void Delete(int id); //Delete single row
        void Delete(IEnumerable<int> ids); //Delete multiple rows
        void DeleteUnsaved(int id); //Delete single row without saving changes
        void DeleteUnsaved(IEnumerable<int> ids); //Delete multiple rows without saving changes
        void MarkAsDeleted(int id); //Set “MarkedForDeletion” column to true.
        void MarkAsDeletedUnsaved(int id); //Set “MarkedForDeletion” column to true without saving changes.
        IEnumerable<TModel> FindBy(Expression<Func<TEntity, bool>> lambda); //Get rows that match WHERE clause
        IEnumerable<TModel> FindBy(Expression<Func<TEntity, bool>> lambda, params Expression<Func<TEntity, object>>[] includeProperties); //Same as FindBy but with overridden navigator properties
        IEnumerable<TModel> FindBy(Dictionary<string, int> keys); //Get rows that have specified key values
        IEnumerable<TModel> FindBy(QueryModel<TModel> query); //Get rows that match query
        IEnumerable<TModel> FindBy(QueryModel<TModel> query, Expression<Func<TEntity, bool>> lambda); //Get rows that match query and WHERE clause
        IEnumerable<TModel> FindByLazy(Expression<Func<TEntity, bool>> lambda); //Same as FindBy but without any navigator properties included
        TModel FindByKey(int key, params Expression<Func<TEntity, object>>[] includeProperties);
        TModel FindByKey(int id); //Retrieves a single row from a table by primary key 
        TModel FindByKey(string id); //Retrieves a single row from a table by primary key with type string.
        TModel FindByKey(long id);  //Retrieves a single row from a table by primary key with type long.
        TModel FindByKey(int id, string keyName); //Retrieves a single row from a table by primary key not named “Id”
        TModel FindByKey(string id, string keyName); //Retrieves a single row from a table by primary key not named “Id” with type string.
        TModel FindByKey(long val, string keyName);  //Retrieves a single row from a table by primary key not named “Id” with type long.
        TModel FindSingle(Expression<Func<TEntity, bool>> lambda); //Retrieves a single row from a table using custom WHERE clause.
        TModel Insert(TModel model); //Insert single row
        void Insert(IEnumerable<TModel> model); //Insert multiple rows
        void InsertUnsaved(TModel model); //Insert single row without saving changes
        void InsertUnsaved(IEnumerable<TModel> model); //Insert multiple rows without saving changes
        TModel InsertUntracked(TModel model); //Insert single row into only the table for this repository, ignoring the rest of the nodes in the graph.
        void BulkInsert(IEnumerable<TModel> model); //Bulk Insert multiple rows
        TModel Update(TModel model); //Update single row
        TEntity UpdateUnsaved(TModel model); //Update single row without saving changes
        IEnumerable<TModel> Update(IEnumerable<TModel> model); //Update multiple rows
        IEnumerable<TEntity> UpdateUnsaved(IEnumerable<TModel> model); //Update multiple rows without saving changes
        TModel UpdateUntracked(TModel model, int id); //Update single row in only the table for this repository, ignoring the rest of the nodes in the graph.
        IEnumerable<TModel> Query(IEnumerable<TModel> model, QueryModel<TModel> query);
    }

    public class BaseRepository<TContext, TEntity, TModel> : IBaseRepository<TEntity, TModel> where TEntity : class where TContext : DbContext
    {
        protected readonly TContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(TContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> BaseDbSet => _dbSet.AsNoTracking();
        public virtual IQueryable<TEntity> DbSetAll => IncludeAll(_dbSet.AsNoTracking());
        public virtual IQueryable<TEntity> DbSet => Include(_dbSet.AsNoTracking());
        public virtual IQueryable<TEntity> DbSetSingle => IncludeSingle(_dbSet.AsNoTracking());

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Any(Expression<Func<TEntity, bool>> lambda)
        {
            return DbSetAll.Any(lambda);
        }

        public virtual IEnumerable<TModel> All()
        {
            var result = DbSetAll.ToList();
            return result.Select(Map);
        }

        public IEnumerable<TModel> All(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IEnumerable<TEntity> results = AllEntities(includeProperties).ToList();
            return results.Select(Map);
        }

        //Same as All without the mapping from the entity to the view model
        protected IEnumerable<TEntity> AllEntities()
        {
            return DbSetAll.ToList();
        }

        //Retrieve all entities with navigator properties included
        protected IQueryable<TEntity> AllEntities(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbSet.AsNoTracking();

            return includeProperties.Aggregate(queryable,
                (current, includeProperty) => current.Include(includeProperty));
        }

        public int Count()
        {
            return All().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> lambda)
        {
            return FindBy(lambda).Count();
        }

        public int Count(QueryModel<TModel> query)
        {
            return FindBy(query).Count();
        }

        public int Count(QueryModel<TModel> query, Expression<Func<TEntity, bool>> lambda)
        {
            return FindBy(query, lambda).Count();
        }

        public void Delete(int id)
        {
            var entity = FindEntityByKey(id);
            _dbSet.Remove(entity);
            Save();
        }

        public void Delete(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                var entity = FindEntityByKey(id);
                _dbSet.Remove(entity);
            }
            Save();
        }

        public void DeleteUnsaved(int id)
        {
            var entity = FindEntityByKey(id);
            _dbSet.Remove(entity);
        }

        public void DeleteUnsaved(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                var entity = FindEntityByKey(id);
                _dbSet.Remove(entity);
            }
        }

        public void MarkAsDeleted(int id)
        {
            throw new NotImplementedException();
        }

        public void MarkAsDeletedUnsaved(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> FindBy(Expression<Func<TEntity, bool>> lambda)
        {
            IEnumerable<TEntity> results = DbSet.Where(lambda).ToList();
            return results.Select(Map);
        }

        public virtual IEnumerable<TModel> FindBy(QueryModel<TModel> query)
        {
            IEnumerable<TModel> results = DbSet.ToList().Select(Map);
            return Query(results, query);
        }

        public virtual IEnumerable<TModel> FindBy(QueryModel<TModel> query, Expression<Func<TEntity, bool>> lambda)
        {
            IEnumerable<TModel> results = DbSet.Where(lambda).ToList().Select(Map);
            return Query(results, query);
        }

        public IEnumerable<TModel> FindBy(Dictionary<string, int> keys)
        {
            Expression<Func<TEntity, bool>> lambda = Utils.BuildLambdaForFindByKeys<TEntity>(keys);
            IEnumerable<TEntity> result = DbSet.Where(lambda);
            return result.Select(Map);
        }

        public IEnumerable<TModel> FindBy(Expression<Func<TEntity, bool>> lambda, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = AllEntities(includeProperties);
            IEnumerable<TEntity> results = query.Where(lambda).ToList();
            return results.Select(x => _mapper.Map<TModel>(x));
        }

        public IEnumerable<TModel> FindByLazy(Expression<Func<TEntity, bool>> lambda)
        {
            IEnumerable<TEntity> results = _dbSet.AsNoTracking().Where(lambda).ToList();
            return results.Select(Map);
        }

        public IEnumerable<TModel> Query(IEnumerable<TModel> model, QueryModel<TModel> query)
        {
            var filteredResults = model.Where(query.Predicate);
            var orderedResults = query.OrderBy == null ? filteredResults : filteredResults.OrderBy(query.OrderBy);
            return query.Take == 0 ? orderedResults
                : orderedResults.Skip(query.Skip).Take(query.Take);
        }

        //Get rows that match WHERE clause.
        protected IEnumerable<TEntity> FindEntitiesBy(Expression<Func<TEntity, bool>> lambda)
        {
            return DbSet.Where(lambda).ToList();
        }

        //Same as FindBy but with overridden navigator properties.
        protected IEnumerable<TEntity> FindEntitiesBy(Expression<Func<TEntity, bool>> lambda, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return DbSet.Where(lambda).ToList();
        }

        //Get rows that have specified key values.
        protected IEnumerable<TEntity> FindEntitiesBy(Dictionary<string, int> keys)
        {
            return DbSet;
        }

        //Get rows that match query.
        protected IEnumerable<TEntity> FindEntitiesBy(QueryModel<TModel> query)
        {
            return DbSet;
        }

        //Get rows that match query and WHERE clause.
        protected IEnumerable<TEntity> FindEntitiesBy(QueryModel<TModel> query, Expression<Func<TEntity, bool>> lambda)
        {
            return DbSet.Where(lambda).ToList();
        }

        //Same as FindBy but without any navigator properties included.
        protected IEnumerable<TEntity> FindEntitiesByLazy(Expression<Func<TEntity, bool>> lambda)
        {
            return DbSet.Where(lambda).ToList();
        }

        public TModel FindByKey(int id)
        {
            TEntity result = FindEntityByKey(id);
            return Map(result);
        }

        public TModel FindByKey(string id)
        {
            TEntity result = FindEntityByKey(id);
            return Map(result);
        }

        public TModel FindByKey(long id)
        {
            TEntity result = FindEntityByKey(id);
            return Map(result);
        }

        public TModel FindByKey(int val, string keyName)
        {
            Expression<Func<TEntity, bool>> lambda = Utils.BuildLambdaForFindByKey<TEntity>(val, keyName);
            TEntity result = DbSetSingle.SingleOrDefault(lambda);
            return Map(result);
        }

        public TModel FindByKey(string val, string keyName)
        {
            Expression<Func<TEntity, bool>> lambda = Utils.BuildLambdaForFindByKey<TEntity>(val, keyName);
            TEntity result = DbSetSingle.SingleOrDefault(lambda);
            return Map(result);
        }

        public TModel FindByKey(long val, string keyName)
        {
            Expression<Func<TEntity, bool>> lambda = Utils.BuildLambdaForFindByKey<TEntity>(val, keyName);
            TEntity result = DbSetSingle.SingleOrDefault(lambda);
            return Map(result);
        }

        public TModel FindByKey(int key, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = AllEntities(includeProperties);
            Expression<Func<TEntity, bool>> lambda = Utils.BuildLambdaForFindByKey<TEntity>(key);
            TEntity result = query.SingleOrDefault(lambda);
            return _mapper.Map<TModel>(result);
        }

        public TModel FindSingle(Expression<Func<TEntity, bool>> lambda)
        {
            TEntity result = FindSingleEntity(lambda);
            return Map(result);
        }

        //Retrieves a single row from a table by primary key. 
        protected virtual TEntity FindEntityByKey(int id)
        {
            var lambda = Utils.BuildLambdaForFindByKey<TEntity>(id);
            return DbSetSingle.SingleOrDefault(lambda);
        }

        //Retrieves a single row from a table by primary key with type string .
        protected virtual TEntity FindEntityByKey(string id)
        {
            var lambda = Utils.BuildLambdaForFindByKey<TEntity>(id);
            return DbSetSingle.SingleOrDefault(lambda);
        }

        //Retrieves a single row from a table by primary key with type long. 
        protected virtual TEntity FindEntityByKey(long id)
        {
            var lambda = Utils.BuildLambdaForFindByKey<TEntity>(id);
            return DbSetSingle.SingleOrDefault(lambda);
        }

        //Retrieves a single row from a table by primary key not named “Id”.
        protected TEntity FindEntityByKey(int id, string keyName)
        {
            var lambda = Utils.BuildLambdaForFindByKey<TEntity>(id, keyName);
            return DbSetSingle.SingleOrDefault(lambda);
        }

        //Retrieves a single row from a table by primary key not named “Id” with type string.
        protected TEntity FindEntityByKey(string val, string keyName)
        {
            var lambda = Utils.BuildLambdaForFindByKey<TEntity>(val, keyName);
            return DbSetSingle.SingleOrDefault(lambda);
        }

        //Retrieves a single row from a table by primary key not named “Id” with type long.
        protected TEntity FindEntityByKey(long val, string keyName)
        {
            var lambda = Utils.BuildLambdaForFindByKey<TEntity>(val, keyName);
            return DbSetSingle.SingleOrDefault(lambda);
        }

        //Retrieves a single row from a table using custom WHERE clause. 
        protected TEntity FindSingleEntity(Expression<Func<TEntity, bool>> lambda)
        {
            return DbSetSingle.SingleOrDefault(lambda);
        }

        protected virtual IQueryable<TEntity> Include(IQueryable<TEntity> queryable)
        {
            return queryable;
        }

        protected virtual IQueryable<TEntity> IncludeAll(IQueryable<TEntity> queryable)
        {
            return queryable;
        }

        protected virtual IQueryable<TEntity> IncludeSingle(IQueryable<TEntity> queryable)
        {
            return Include(queryable);
        }

        public virtual TModel Insert(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _context.ChangeTracker.TrackGraph(entity, (EntityEntryGraphNode node) =>
            {
                var entry = node.Entry;
                entry.State = entry.IsKeySet ? EntityState.Modified : EntityState.Added;
            });
            Save();
            return Map(entity);
        }

        public void Insert(IEnumerable<TModel> model)
        {
            foreach (TModel item in model)
            {
                TEntity entity = _mapper.Map<TEntity>(item);
                _dbSet.Add(entity);
            }
            Save();
        }

        public void InsertUnsaved(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _dbSet.Add(entity);
        }

        public void InsertUnsaved(IEnumerable<TModel> model)
        {
            foreach (TModel item in model)
            {
                TEntity entity = _mapper.Map<TEntity>(item);
                _dbSet.Add(entity);
            }
        }

        public TModel InsertUntracked(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _dbSet.Add(entity);
            Save();
            return Map(entity);
        }

        public void BulkInsert(IEnumerable<TModel> model)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Update(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _context.ChangeTracker.TrackGraph(entity, (EntityEntryGraphNode node) =>
            {
                var entry = node.Entry;
                entry.State = entry.IsKeySet ? EntityState.Modified : EntityState.Added;
            });
            Save();
            return Map(entity);
        }

        public IEnumerable<TModel> Update(IEnumerable<TModel> model)
        {
            var results = model.Select(x => UpdateUnsaved(x));
            Save();
            return results.Select(Map);
        }

        public TEntity UpdateUnsaved(TModel model)
        {
            TEntity entity = _mapper.Map<TEntity>(model);
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IEnumerable<TEntity> UpdateUnsaved(IEnumerable<TModel> model)
        {
            return model.Select(x => UpdateUnsaved(x));
        }

        public TModel UpdateUntracked(TModel model, int id)
        {
            var entity = FindEntityByKey(id);

            _mapper.Map(model, entity);

            foreach (var item in _context.ChangeTracker.Entries<TEntity>().ToList())
            {
                _context.Entry<TEntity>(item.Entity).State = EntityState.Detached;
            }

            _context.Entry(entity).State = EntityState.Modified;
            Save();
            return Map(entity);
        }

        public IEnumerable<TModel> Map(IEnumerable<TEntity> entities)
        {
            return entities.Select(Map);
        }

        public virtual TModel Map(TEntity entity)
        {
            return _mapper.Map<TModel>(entity);
        }

        public IEnumerable<TEntity> Map(IEnumerable<TModel> models)
        {
            return models.Select(Map);
        }

        public virtual TEntity Map(TModel model)
        {
            return _mapper.Map<TEntity>(model);
        }

        //Detach an entity and all nodes in its graph from the context.
        protected void Detach(TEntity entity)
        {
            _context.ChangeTracker.TrackGraph(entity, (EntityEntryGraphNode node) =>
            {
                var entry = node.Entry;
                entry.State = EntityState.Detached;
            });
        }
    }

    public static class BaseExtensions
    {
        public static void TryUpdateManyToMany<T, TKey, TContext>(this TContext db, IEnumerable<T> currentItems, IEnumerable<T> newItems, Func<T, TKey> getKey) where T : class where TContext : DbContext
        {
            db.Set<T>().RemoveRange(currentItems.Except(newItems, getKey));
            db.Set<T>().AddRange(newItems.Except(currentItems, getKey));
        }

        public static IEnumerable<T> Except<T, TKey>(this IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKeyFunc)
        {
            return items
                .GroupJoin(other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
                .Select(t => t.t.item);
        }
    }
}
