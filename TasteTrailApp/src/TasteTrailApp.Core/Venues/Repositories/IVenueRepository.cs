using TasteTrailApp.Core.Common.Repositories.Base;
using TasteTrailApp.Core.Venues.Models;

namespace TasteTrailApp.Core.Venues.Repositories;

public interface IVenueRepository : IGetByCountAsync<Venue>, IGetByIdAsync<Venue, int>,
ICreateAsync<Venue>, IDeleteByIdAsync<int>, IPutAsync<Venue>
{
    Task<int> CreateAsyncReturningId(Venue venue);

    Task PatchLogoUrlPathAsync(Venue venue, string logoUrlPath);
}
