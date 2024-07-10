using TasteTrailApp.Core.Models;

namespace TasteTrailApp.Core.Services.Base
{
    public interface IMenuService
    {
        Task CreateAsync(Menu entity);

        Task<List<Menu>> GetAllAsync();

        Task<Menu> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(Menu entity);
    }
}
