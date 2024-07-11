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

        public async Task CreateAsync(Venue entity, IFormFile? logo)
        {
            var changesCount = await this.venueRepository.CreateAsync(entity);

            if (changesCount == 0) {
                throw new InvalidOperationException("Venue delete didn't apply!");
            }
        }

        public async Task<int> CreateAsyncRerturningId(Venue venue)
        {
            var createdId = await this.venueRepository.CreateAsyncRerturningId(venue);
            return createdId;
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

        public async Task SetVenueLogo(Venue venue, IFormFile? logo) {
            if (logo is null)
                return;

            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var uploadsFolder = Path.Combine(wwwrootPath, "images");
            var extension = new FileInfo(logo.FileName).Extension[1..];

            string logoPath = $"images/{venue.Id}.{extension}";
            await venueRepository.PatchLogoUrlPathAsync(venue, logoPath);

            var filePath = Path.Combine(uploadsFolder, $"{venue.Id}.{extension}");

            using var newFileStream = File.Create(filePath);
            await logo.CopyToAsync(newFileStream);
        }

        public async Task DeleteVenueLogoAsync(int venueId)
        {
            var venue = await venueRepository.GetByIdAsync(venueId);

            if (venue is null || venue.LogoUrlPath is null)
                return;

            File.Delete("wwwroot/" +venue.LogoUrlPath);
        }
    }
}