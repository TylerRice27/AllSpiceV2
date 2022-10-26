using System.Collections.Generic;
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

        internal Favorite Create(Favorite newFavorite)
        {
            Recipe recipe = _rs.GetById(newFavorite.RecipeId);

            recipe.Id = newFavorite.RecipeId;
            return _repo.Create(newFavorite);
        }

        internal List<FavoriteViewModel> GetAccountFavorites(string userId)
        {
            return _repo.GetAccountFavorites(userId);
        }
    }
}