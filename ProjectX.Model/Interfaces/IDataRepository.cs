namespace ProjectX.Model.Interfaces
{
    public interface IDataRepository : IRepository
    {
        TEntity Get<TEntity>(int id);
    }
}
