using Microsoft.AspNetCore.Http;
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

        public async Task CreateAsync(Venue entity, IFormFile? image)
        {
            var changesCount = await this.venueRepository.CreateAsync(entity);

            if (changesCount == 0) {
                throw new InvalidOperationException("Venue delete didn't apply!");
            }

            if (image is null)
                return;

            
            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadsFolder = Path.Combine(wwwrootPath, "images");
            var extension = new FileInfo(image.FileName).Extension[1..];

            entity.LogoUrlPath = $"images/{entity.Id}.{extension}";
            var filePath = Path.Combine(uploadsFolder, $"{entity.Id}.{extension}");

            using var newFileStream = File.Create(filePath);
            await image.CopyToAsync(newFileStream);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var changesCount = await this.venueRepository.DeleteByIdAsync(id);

            if (changesCount == 0)
                throw new InvalidOperationException("Venue delete didn't apply!");
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

        public async Task PutAsync(Venue entity)
        {
            var changesCount = await this.venueRepository.PutAsync(entity);

            if (changesCount == 0)
                throw new InvalidOperationException("Venue put didn't apply!");
        }
    }
}