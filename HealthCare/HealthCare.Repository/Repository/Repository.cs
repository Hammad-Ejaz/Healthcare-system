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
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbContextFactory<CamcoDbContext> _contextFactory;
      
        public Repository(IDbContextFactory<CamcoDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

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

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Set<TEntity>().AddRangeAsync(entities);
                await context.SaveChangesAsync();
            }
        }
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            //using (var context =)
            //{
                return _contextFactory.CreateDbContext().Set<TEntity>().Where(predicate);
            //}
        }

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

        public virtual IEnumerable<TEntity> GetList()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var EntityLookUp = (await context.Set<TEntity>().FindAsync(id));
                context.Entry(EntityLookUp).State = EntityState.Detached;
                return EntityLookUp;
            }
        }

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

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Set<TEntity>().RemoveRange(entities);
                context.SaveChanges();
            }
        }

        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().SingleOrDefaultAsync(predicate);
            }
        }

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
