using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Linq.Expressions;
using System.Reflection;
using MySql.Data.MySqlClient;
using model;

namespace Ipaloma.Model
{
    public class EFHelpler<T> where T : class
    {
     DBContext dbContext = new DBContext();
        /// <summary>
        /// 实体新增
        /// </summary>
        /// <param name="model"></param>
        public int add(params T[] paramList)
        {
            foreach (var model in paramList)
            {
                dbContext.Entry<T>(model).State = EntityState.Added;
            }
            return dbContext.SaveChanges();
        }
        /// <summary>
        /// 实体查询
        /// </summary>
        public IEnumerable<T> getSearchList()
        {
            return dbContext.Set<T>().ToList();
        }
        /// <summary>
        /// 实体查询
        /// </summary>
        public IEnumerable<T> getSearchList(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return dbContext.Set<T>().Where(where);
        }
        /// <summary>
        /// 实体分页查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IEnumerable<T> getSearchListByPage<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderBy, int pageSize, int pageIndex)
        {
            return dbContext.Set<T>().Where(where).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        /// <summary>
        /// 实体删除
        /// </summary>
        /// <param name="model"></param>
        public int delete(params T[] paramList)
        {
            foreach (var model in paramList)
            {
                dbContext.Entry<T>(model).State = EntityState.Deleted;
            }
           return dbContext.SaveChanges();
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="strIds">需要删除ID，以逗号分隔</param>
        /// <param name="strTable">需要操作表名称</param>
        /// <param name="strKey">ID，字段名</param>
        /// <returns></returns>
        public int delete(string strIds, string strTable,string strKey)
        {
            return dbContext.Database.ExecuteSqlCommand("delete from "+strTable +" where "+strKey+" in ("+strIds+")");
        }
        /// <summary>
        /// 按照条件修改数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dic"></param>
        public int update(Expression<Func<T, bool>> where, Dictionary<string, object> dic)
        {
            IEnumerable<T> result = dbContext.Set<T>().Where(where).ToList();
            Type type = typeof(T);
            List<PropertyInfo> propertyList = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).ToList();
            //遍历结果集
            foreach (T entity in result)
            {
                foreach (PropertyInfo propertyInfo in propertyList)
                {
                    string propertyName = propertyInfo.Name;
                    if (dic.ContainsKey(propertyName))
                    {
                        //设置值
                        propertyInfo.SetValue(entity, dic[propertyName], null);
                    }
                }
            }
           return dbContext.SaveChanges();
        }
    }
}
