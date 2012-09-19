using System.Collections.Generic;

namespace ProjectX.Model.Interfaces
{
    public interface IRepository: IReadOnlyRepository
    {
        bool Save<TEntity>(TEntity entity);
        bool Save<TEntity>(IEnumerable<TEntity> items);
        bool Update<TEntity>(TEntity entity);
        bool Delete<TEntity>(TEntity entity);
        bool Delete<TEntity>(IEnumerable<TEntity> entities);
    }
    
}