using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ProjectX.Model.Entities;

namespace Model.Nhibernate
{
    public class NhibernateHelper
    {

        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;
        public NhibernateHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        private ISessionFactory CreateSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Entity>()
                                   .Conventions.Add(new MyIdConvention())
                )
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(false, false, false))
                .BuildSessionFactory();

            return _sessionFactory;
        }
    }
}