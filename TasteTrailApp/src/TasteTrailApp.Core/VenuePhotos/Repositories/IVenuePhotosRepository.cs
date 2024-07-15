using TasteTrailApp.Core.Common.Repositories.Base;

namespace TasteTrailApp.Core.VenuePhotos.Repositories;

public interface IVenuePhotosRepository : IGetAllAsync<Models.VenuePhotos>, ICreateAsync<Models.VenuePhotos>,
IDeleteByIdAsync<int>, IPutAsync<Models.VenuePhotos>
{
    
}
