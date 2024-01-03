using HealthCare.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HealthCare.Repository.Repository
{
    /// <summary>
    /// This is the generaic class for the crud of all the entities
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbContextFactory<HealthCareDbContext> _contextFactory;
      
        public Repository(IDbContextFactory<HealthCareDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// This is the generic function for the insertion of data 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Insert(TEntity entity)
        {
                int id = 0;

                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Set<TEntity>().Add(entity);
                    context.SaveChanges();

                    id = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
                }
                return id;
        }

        /// <summary>
        /// This is the Generic function for the insertion of data Async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var entityEntry = await context.Set<TEntity>().AddAsync(entity);
                    await context.SaveChangesAsync();
                    return (int)entityEntry.Property("Id").CurrentValue;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log it for debugging
                // You can also throw the exception if necessary
                // Example: throw new Exception("Error saving the entity.", ex);
                return -1; // or some error code to indicate failure
            }
        }

        /// <summary>
        /// This is the generic function to add a specific range of data async
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Set<TEntity>().AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This is the generic function to search some data on the basis of some condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
             return _contextFactory.CreateDbContext().Set<TEntity>().Where(predicate);
        }


        /// <summary>
        /// This is the generic function to get the all list of data async
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntity>> GetListAsync()
        {
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var list = await context.Set<TEntity>().ToListAsync();

                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// This is function is used to get the list of all data in a table
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetList()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        /// <summary>
        /// This function is used to get the data by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        /// <summary>
        /// This funciton is used to get the data by Id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var EntityLookUp = (await context.Set<TEntity>().FindAsync(id));
                context.Entry(EntityLookUp).State = EntityState.Detached;
                return EntityLookUp;
            }
        }

        /// <summary>
        /// This function is used to remove the data from the table by using its Id
        /// </summary>
        /// <param name="id"></param>
        public virtual void Remove(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var entityLookup = context.Set<TEntity>().Find(id);
                if (entityLookup != null)
                {
                    context.Set<TEntity>().Remove(entityLookup);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// This function is used to remove the data from the table by the entity
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TEntity entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                int id = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
                var entityLookup = context.Set<TEntity>().Find(id);
                if (entityLookup != null)
                {
                    context.Set<TEntity>().Remove(entityLookup);
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// This function is used to remove the specific range of data 
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Set<TEntity>().RemoveRange(entities);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// This function is used to get the first entity of the data 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().SingleOrDefaultAsync(predicate);
            }
        }

        /// <summary>
        /// This function is used to update the data in the table
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var local = context.Set<TEntity>().Local
                .FirstOrDefault(x => x.GetType().GetProperty("Id").Equals(entity.GetType().GetProperty("Id")));

                if (local != null)
                    context.Entry(local).State = EntityState.Detached;

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }           
        }

        /// <summary>
        /// This function is used to update the data async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var local = context.Set<TEntity>().Local
                .FirstOrDefault(x => x.GetType().GetProperty("Id").Equals(entity.GetType().GetProperty("Id")));

                if (local != null)
                    context.Entry(local).State = EntityState.Detached;

                context.Entry(entity).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }

        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TEntity>().AsNoTracking().Skip(skip).Take(limit).ToListAsync();
            }
        }

        public async Task<int> CountAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TEntity>().CountAsync();
            }
        }

        public virtual async Task<int> CountAsync(string search)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<TEntity>().CountAsync();
            }
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().AsNoTracking().ToList();
            }
        }

        public virtual IEnumerable<TEntity> GetAll(int skip, int limit)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().AsNoTracking().Skip(skip).Take(limit).ToList();
            }
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                int id = (int)entity.GetType().GetProperty("Id").GetValue(entity, null);
                var entityLookup = await context.Set<TEntity>().FindAsync(id);
                if (entityLookup != null)
                {
                    context.Set<TEntity>().Remove(entityLookup);
                }
            }
        }

        public virtual async Task<IEnumerable<TEntity>> SearchAsync(Func<TEntity, bool> Conditions)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var Result = context.Set<TEntity>().AsNoTracking().Where(Conditions).ToList();
                return await Task.FromResult(Result);
            }
        }
    }
}
