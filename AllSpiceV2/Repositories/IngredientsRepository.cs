using System.Data;
using AllSpiceV2.Models;
using Dapper;

namespace AllSpiceV2.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient Create(Ingredient newIngredient)
        {
            string sql = @"
            INSERT INTO tjingredients
            (name, quantity, recipeId)
            VALUES
            (@Name, @Quantity, @RecipeId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newIngredient);
            newIngredient.Id = id;
            return newIngredient;
        }
    }
}