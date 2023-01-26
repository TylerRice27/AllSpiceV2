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


            // NOTE Come Back Here Later We are going to have to write an unquie column/index in sql
            // NOTE OR we can write a new route to our favorites table and do a getById  and if it the one we are creating matches
            // the new recipe id and the creator id then throw an error 

            // if ()
            // {
            //     throw new Exception("You have already favorited this recipe");
            // }
            Favorite favorite = _repo.Create(newFavorite);
            return favorite;
        }

        internal List<FavoritedRecipe> GetAccountFavorites(string userId)
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