namespace TasteTrailApp.Core.Menu.Services
{
    public interface IMenuService
    {
        Task CreateAsync(Models.Menu entity);

        Task<List<Models.Menu>> GetAllAsync();

        Task<Models.Menu> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
        
        Task PutAsync(Models.Menu entity);

        Task<IEnumerable<Models.Menu>> GetAllMenusByVenueId(int venueId);
    }
}
