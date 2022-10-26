using System;
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

        internal void Delete(int id, string userId)
        {
            Favorite original = this.GetById(id);
            if (original.AccountId != userId)
            {
                throw new Exception("You can not remove this favorite");

            }
            _repo.Delete(id);
            // return $" {original.Creator.Name} unfavorited this recipe";

        }

        internal Favorite GetById(int id)
        {
            Favorite favorite = _repo.GetById(id);
            if (favorite == null)
            {

                throw new Exception("No Favorite by that Id");
            }
            return favorite;
        }
    }
}