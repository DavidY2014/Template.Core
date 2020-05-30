using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Nba.Core.IData;

namespace Nba.Core.DataImplement
{
    public class BaseRepository<TDbContext, TEntity> : IBaseRepository<TEntity>
           where TDbContext : DbContext
           where TEntity : class
    {
        protected DbSet<TEntity> MasterSet { get; }

        protected TDbContext Master { get; }

        protected TDbContext Slave { get; }
        public BaseRepository(TDbContext dbContext)
        {
            Master = dbContext;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            return MasterSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// 联合主键查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TEntity Find(params object[] keyValues)
        {
            return MasterSet.Find(keyValues);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return MasterSet.Where(predicate);
        }

        public int Insert(TEntity entity)
        {
            Master.Entry(entity).State = EntityState.Added;
            MasterSet.Add(entity);

            return Master.SaveChanges();
        }

        public int AddCollections<T>(List<T> entities)
        {
            var entityType = Master.Model.FindEntityType(typeof(T));
            var primaryKey = entityType.FindPrimaryKey();
            var keyValues = new object[primaryKey.Properties.Count];

            foreach (T e in entities)
            {
                for (int i = 0; i < keyValues.Length; i++)
                    keyValues[i] = primaryKey.Properties[i].GetGetter().GetClrValue(e);

                var obj = Master.Find(typeof(T), keyValues);

                if (obj == null)
                {
                    Master.Add(e);
                }
                else
                {
                    Master.Entry(obj).CurrentValues.SetValues(e);
                }
            }
            return Master.SaveChanges();
        }

        public Task<int> InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Master.Entry(entity).State = EntityState.Added;
            MasterSet.AddAsync(entity, cancellationToken);

            return Master.SaveChangesAsync();
        }

        public int BatchInsert(IEnumerable<TEntity> entities)
        {
            MasterSet.AddRange(entities);
            return Master.SaveChanges();
        }

        public Task<int> BatchInsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            MasterSet.AddRangeAsync(entities, cancellationToken);
            return Master.SaveChangesAsync();
        }

        public int Delete(object id)
        {
            var entity = MasterSet.Find(id);
            if (entity != null)
            {
                return Delete(entity);
            }

            return 0;
        }

        public int Delete(TEntity entity)
        {
            MasterSet.Remove(entity);
            return Master.SaveChanges();
        }

        public int Delete(params TEntity[] entities)
        {
            MasterSet.RemoveRange(entities);
            return Master.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            MasterSet.Update(entity);
            return Master.SaveChanges();
        }

        public int BatchUpdate(IEnumerable<TEntity> entities)
        {
            MasterSet.UpdateRange(entities);
            return Master.SaveChanges();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return MasterSet.Count(predicate);
        }

        public int ExecuteSql(string sql, params object[] parameters)
        {
            return Master.Database.ExecuteSqlCommand(sql, parameters);
        }

        public IEnumerable<T> Query<T>(string sql)
        {
            return Query<T>(sql, null);
        }

        public IEnumerable<T> Query<T>(string sql, object param)
        {
            var connection = Master.Database.GetDbConnection();
            return connection.Query<T>(sql, param);
        }

        public IQueryable<TEntity> FromSql(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
