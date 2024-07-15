namespace TasteTrailApp.Core.Common.Repositories.Base;

public interface IPutAsync<TEntity> // возвращает changesCount - результат вызова ExecuteAsync()
{
    Task<int> PutAsync(TEntity entity);
}
