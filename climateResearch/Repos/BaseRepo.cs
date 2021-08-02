using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace climateResearch.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase, new()

    {
        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int AddRange(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id, byte[] timestamp)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetOne(int? id)
        {
            throw new NotImplementedException();
        }

        public int Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}