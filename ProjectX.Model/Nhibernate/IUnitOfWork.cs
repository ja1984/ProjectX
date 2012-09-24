using System;
using NHibernate;

namespace Model.Nhibernate
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
	    void Commit();
	    void Rollback();
        
    }
}