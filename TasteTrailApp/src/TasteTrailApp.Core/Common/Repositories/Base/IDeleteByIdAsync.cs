namespace TasteTrailApp.Core.Common.Repositories.Base;

public interface IDeleteByIdAsync<TId> // возвращает changesCount - результат вызова ExecuteAsync()
{
    Task<int> DeleteByIdAsync(TId id);
}
