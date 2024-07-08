using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IMenuService
    {
        Task<int> CreateAsync(Menu entity);
        Task<List<Menu>> GetAllAsync();
        Task<Menu> GetByIdAsync(int id);
        Task<int> DeleteByIdAsync(int id);
        Task<int> PutAsync(Menu entity);
    }
}
