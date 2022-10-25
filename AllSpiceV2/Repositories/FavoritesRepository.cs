using System.Data;
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
            (@AccountId, @RecipeId)
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newFavorite);
            newFavorite.Id = id;
            return newFavorite;
        }
    }
}