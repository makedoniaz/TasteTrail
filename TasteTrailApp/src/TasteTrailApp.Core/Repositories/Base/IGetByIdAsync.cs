namespace TasteTrailApp.Core.Repositories.Base;

public interface IGetByIdAsync<TEntity, TId>
{
    Task<TEntity> GetByIdAsync(TId id);
}
