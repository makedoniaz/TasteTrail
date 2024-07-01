namespace TasteTrailApp.Core.Repositories.Base;

public interface IDeleteByIdAsync<TId> // возвращает changesCount - результат вызова ExecuteAsync()
{
    Task<int> IDeleteByIdAsync(TId id);
}
