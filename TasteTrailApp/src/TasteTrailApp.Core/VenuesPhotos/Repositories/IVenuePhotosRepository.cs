using TasteTrailApp.Core.Common.Repositories.Base;
using TasteTrailApp.Core.VenuesPhotos.Models;

namespace TasteTrailApp.Core.VenuesPhotos.Repositories;

public interface IVenuePhotosRepository : IGetAllAsync<VenuePhotos>, ICreateAsync<VenuePhotos>,
IDeleteByIdAsync<int>, IPutAsync<VenuePhotos>
{
    
}
