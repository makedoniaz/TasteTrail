namespace TasteTrailApp.Core.Repositories.Base;

public interface IPutAsync<TEntity> // возвращает changesCount - результат вызова ExecuteAsync()
{
    Task<int> IPutAsync(TEntity entity);
}
