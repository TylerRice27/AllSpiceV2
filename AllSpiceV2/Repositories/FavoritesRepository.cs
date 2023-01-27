using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpiceV2.Models;
using Dapper;

namespace AllSpiceV2.Repositories
{
    public class FavoritesRepository
    {

        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite Create(Favorite newFavorite)
        {
            string sql = @"
            INSERT INTO tjfavorites
            (accountId, recipeId)
            VALUES
            (@AccountId, @RecipeId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newFavorite);

            newFavorite.Id = id;
            return newFavorite;
        }

        internal List<FavoritedRecipe> GetAccountFavorites(string userId)
        {
            string sql = @"
            SELECT
            a.*,
            r.*,
            f.id AS FavoriteId
            FROM tjfavorites f
            JOIN tjrecipes r on r.id = f.recipeId
            JOIN accounts a on a.id = r.creatorId
            WHERE f.accountId = @userId;
            ";
            return _db.Query<Account, FavoritedRecipe, FavoritedRecipe>(sql, (profile, recipe) =>
            {
                recipe.Creator = profile;
                return recipe;
            }, new { userId }).ToList();
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM tjfavorites WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }

        internal Favorite GetById(int id)
        {
            string sql = "SELECT * FROM tjfavorites WHERE tjfavorites.id = @id";
            return _db.QueryFirstOrDefault<Favorite>(sql, new { id });
        }

        internal FavoritedRecipe GetFavoritedRecipeById(int id)
        {
            string sql = @"
      SELECT
      r.*,
      a.*,
      f.*
      FROM tjfavorites f
      JOIN tjrecipes r ON r.id = f.recipeId
      JOIN accounts a ON a.id = r.creatorId
      WHERE f.id = @id
      ;";

            return _db.Query<FavoritedRecipe, Account, Favorite, FavoritedRecipe>(sql, (r, a, f) =>
             {
                 r.FavoriteId = f.Id;
                 r.Creator = a;
                 return r;
             }, new { id }).FirstOrDefault();
        }
    }
}