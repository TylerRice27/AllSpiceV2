using AllSpiceV2.Models;
using AllSpiceV2.Repositories;

namespace AllSpiceV2.Services
{
    public class FavoritesService
    {

        private readonly FavoritesRepository _repo;

        private readonly RecipesService _rs;

        public FavoritesService(FavoritesRepository repo, RecipesService rs)
        {
            _repo = repo;
            _rs = rs;
        }

        internal Favorite Create(Favorite newFavorite, string userId)
        {
            Recipe recipe = _rs.GetById(newFavorite.RecipeId);

            recipe.Id = newFavorite.RecipeId;
            return _repo.Create(newFavorite);
        }
    }
}