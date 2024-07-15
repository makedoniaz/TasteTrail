namespace TasteTrailApp.Core.Common.Repositories.Base;

public interface ICreateAsync<TEntity> // возвращает changesCount - результат вызова ExecuteAsync()
{
    Task<int> CreateAsync(TEntity entity);
}
