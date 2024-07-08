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
            return await this.venueRepository.CreateAsync(entity);
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            return await this.venueRepository.DeleteByIdAsync(id);
        }

        public async Task<List<Venue>?> GetByCountAsync(int count)
        {
            return await this.venueRepository.GetByCountAsync(count);
        }

        public async Task<Venue?> GetByIdAsync(int id)
        {
            return await this.venueRepository.GetByIdAsync(id);

        }

        public async Task<int> PutAsync(Venue entity)
        {
            return await this.venueRepository.PutAsync(entity);

        }
    }
}