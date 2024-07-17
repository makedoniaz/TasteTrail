using TasteTrailApp.Core.Menus.Models;

namespace TasteTrailApp.Core.Menus.Services
{
    public interface IMenuService
    {
        Task CreateAsync(Menu entity);

        Task<List<Menu>> GetAllAsync();

        Task<Menu> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(Menu entity);

        Task<IEnumerable<Menu>> GetAllMenusByVenueId(int venueId);
    }
}
