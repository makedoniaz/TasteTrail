using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories;
using TasteTrailApp.Core.Services.Base;

namespace TasteTrailApp.Infrastructure.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository venueRepository;

        public VenueService(IVenueRepository venueRepository)
        {
            this.venueRepository = venueRepository;
        }

        public async Task<int> CreateAsync(Venue entity)
        {
            var result = await this.venueRepository.CreateAsync(entity);
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            return await this.venueRepository.DeleteByIdAsync(id);
        }

        public async Task<List<Venue>> GetByCountAsync(int count)
        {
            var result = await this.venueRepository.GetByCountAsync(count);
            return result;
        }

        public async Task<Venue> GetByIdAsync(int id)
        {
            var result = await this.venueRepository.GetByIdAsync(id);
            ArgumentNullException.ThrowIfNull(result);
            return result;
        }

        public async Task<int> PutAsync(Venue entity)
        {
            return await this.venueRepository.PutAsync(entity);

        }
    }
}