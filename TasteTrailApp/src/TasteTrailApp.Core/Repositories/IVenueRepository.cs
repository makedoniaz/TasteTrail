using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IVenueRepository : IGetByCountAsync<Venue>, IGetByIdAsync<Venue, int>,
ICreateAsync<Venue>, IDeleteByIdAsync<Venue>, IPutAsync<Venue>
{
    
}
