namespace TasteTrailApp.Core.MenuItem.Services
{
    public interface IMenuItemService
    {
        Task CreateAsync(Models.MenuItem entity);

        Task<List<Models.MenuItem>> GetByCountAsync(int count);

        Task<Models.MenuItem> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(Models.MenuItem entity);

        Task<IEnumerable<Models.MenuItem>> GetAllMenuItemsByMenuId(int menuId);
    }
}
