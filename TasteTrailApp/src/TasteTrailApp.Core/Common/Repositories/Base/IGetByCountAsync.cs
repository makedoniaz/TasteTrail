namespace TasteTrailApp.Core.Common.Repositories.Base;

public interface IGetByCountAsync<TEntity> // получаем определенное количество объектов, чтобы потом сделать пагинацию
{
    Task<List<TEntity>> GetByCountAsync(int count);
}
