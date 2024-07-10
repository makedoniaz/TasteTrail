using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IMenuItemService
    {
        Task CreateAsync(MenuItem entity);

        Task<List<MenuItem>> GetByCountAsync(int count);

        Task<MenuItem> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(MenuItem entity);
    }
}
