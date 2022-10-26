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

        internal List<FavoriteViewModel> GetAccountFavorites(string userId)
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
            return _db.Query<Account, FavoriteViewModel, FavoriteViewModel>(sql, (profile, recipe) =>
            {
                recipe.Creator = profile;
                return recipe;
            }, new { userId }).ToList();
        }
    }
}