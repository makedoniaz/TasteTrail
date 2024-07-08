namespace TasteTrailApp.Core.Repositories.Base;

public interface IGetAllAsync<TEntity>
{
    Task<List<TEntity>?> GetAllAsync();
}
