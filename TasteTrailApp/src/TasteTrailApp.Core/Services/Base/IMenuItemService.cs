using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IMenuItemService
    {
        Task<int> CreateAsync(MenuItem entity);
        Task<List<MenuItem>> GetByCountAsync(int count);
        Task<MenuItem> GetByIdAsync(int id);
        Task<int> DeleteByIdAsync(int id);
        Task<int> PutAsync(MenuItem entity);
    }
}
