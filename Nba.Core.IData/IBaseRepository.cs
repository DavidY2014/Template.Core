using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nba.Core.IData
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<T> Query<T>(string sql);
        IEnumerable<T> Query<T>(string sql, object param);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// 联合主键查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TEntity Find(params object[] keyValues);

        int Insert(TEntity entity);
        int BatchInsert(IEnumerable<TEntity> entities);

        int Delete(object id);
        int Delete(TEntity entity);

        int Delete(params TEntity[] entities);

        IQueryable<TEntity> FromSql(string sql, params object[] parameters);
        int ExecuteSql(string sql, params object[] parameters);

        int Update(TEntity entity);

        int BatchUpdate(IEnumerable<TEntity> entities);

        int Count(Expression<Func<TEntity, bool>> predicate = null);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
