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

        internal List<Favorite> GetAccountFavorites(string userId)
        {
            string sql = @"SELECT
            f.*,
            a.*
            FROM tjfavorites f
            JOIN accounts a on a.id = f.accountId;
            ";
            return _db.Query<Favorite, Profile, Favorite>(sql, (fav, profile) =>
            {
                fav.Creator = profile;
                return fav;
            }).ToList();
        }
    }
}