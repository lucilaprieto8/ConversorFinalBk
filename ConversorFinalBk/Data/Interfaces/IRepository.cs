namespace ConversorFinalBk.Data.Interfaces
{
    public interface IRepository <TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll ();
        TEntity GetById(object id);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(object id);
        bool Exist(object id);
        bool Save();
    }
}
