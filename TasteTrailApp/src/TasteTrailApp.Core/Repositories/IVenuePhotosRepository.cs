using TasteTrailApp.Core.Models;
using TasteTrailApp.Core.Repositories.Base;

namespace TasteTrailApp.Core.Repositories;

public interface IVenuePhotosRepository : IGetAllAsync<VenuePhotos>, ICreateAsync<VenuePhotos>,
IDeleteByIdAsync<VenuePhotos>, IPutAsync<VenuePhotos>
{
    
}
