namespace TasteTrailApp.Core.Common.Repositories.Base;

public interface IGetAllAsync<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
}
