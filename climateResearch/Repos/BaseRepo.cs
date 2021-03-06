using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using climateResearch.Models.Entities;
using climateResearch.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace climateResearch.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase, new()

    {
        private readonly DbSet<T> table;
        protected ClimateDbContext Db { get; }

        public BaseRepo()
        {
            Db = new ClimateDbContext();
            table = Db.Set<T>();
        }

        public int Add(T entity)
        {
            table.Add(entity);
            return SaveChanges();
        }
        public int AddRange(IList<T> entities)
        {
            table.AddRange(entities);
            return SaveChanges();
        }
        public int Delete(long id)
        {
            T entity = GetOne(id);
            return Delete(entity);
        }
        public int Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public List<T> ExecuteQuery(string sql) => table.SqlQuery(sql).ToList();
        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => table.SqlQuery(sql, sqlParametersObjects).ToList();


        public T GetOne(long? id) => table.Find(id);
        public virtual List<T> GetAll() => table.ToList();
        public virtual List<T> GetAllAndInclude(string[] entityToInclude)
        {
            foreach(string entity in entityToInclude)
            {
                table.Include(entity);
            }
            return table.ToList();
            
        }

        public int Save(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        internal int SaveChanges()
        {
            try
            {
                return Db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Генерируется, когда обновление базы данных терпит неудачу.
                // Проверить внутреннее исключение (исключения), чтобы получить
                // дополнительные сведения и выяснить, на какие объекты это повлияло.
                // Пока что просто повторно сгенерировать исключение.
                throw;
            }
            catch (CommitFailedException ex)
            {
                // Обработать здесь отказы транзакции.
                // Пока что просто повторно сгенерировать исключение,
                throw;

            }
            catch (Exception ex)
            {
                // Произошло какое-то другое исключение, которое должно быть обработано,
                throw;

            }
        }
    }
}