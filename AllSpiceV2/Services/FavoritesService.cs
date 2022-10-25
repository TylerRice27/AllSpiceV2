using AllSpiceV2.Models;
using AllSpiceV2.Repositories;

namespace AllSpiceV2.Services
{
    public class FavoritesService
    {

        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite Create(Favorite newFavorite)
        {
            return _repo.Create(newFavorite);
        }
    }
}