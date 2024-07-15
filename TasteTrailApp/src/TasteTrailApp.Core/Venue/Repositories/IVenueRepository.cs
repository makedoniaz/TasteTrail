using TasteTrailApp.Core.Common.Repositories.Base;

namespace TasteTrailApp.Core.Venue.Repositories;

public interface IVenueRepository : IGetByCountAsync<Models.Venue>, IGetByIdAsync<Models.Venue, int>,
ICreateAsync<Models.Venue>, IDeleteByIdAsync<int>, IPutAsync<Models.Venue>
{
    Task<int> CreateAsyncReturningId(Models.Venue venue);

    Task PatchLogoUrlPathAsync(Models.Venue venue, string logoUrlPath);
}
