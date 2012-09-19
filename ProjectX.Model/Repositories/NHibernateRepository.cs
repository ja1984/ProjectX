using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using ProjectX.Model.Interfaces;
using System.Linq.Expressions;

namespace ProjectX.Model.Repositories
{
    public class NHibernateRepository : IDataRepository
    {
        private readonly ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }

        public bool Save<T>(T entity)
        {
            _session.SaveOrUpdate(entity);
            return true;
        }

        public bool Save<T>(System.Collections.Generic.IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            return true;
        }

        public bool Update<T>(T entity)
        {
            _session.Update(entity);
            return true;
        }

        public bool Delete<T>(T entity)
        {
            _session.Delete(entity);
            return true;
        }

        public bool Delete<T>(System.Collections.Generic.IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _session.Delete(entity);
            }
            return true;
        }

        public T Get<T>(int id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> All<T>()
        {
            return _session.Query<T>();
        }

        public T Query<T>(Expression<Func<T, bool>> expression)
        {
            return FilterBy(expression).Single();
        }

        public IQueryable<T> FilterBy<T>(Expression<Func<T, bool>> expression)
        {
            return All<T>().Where(expression).AsQueryable();
        }
    }
}
