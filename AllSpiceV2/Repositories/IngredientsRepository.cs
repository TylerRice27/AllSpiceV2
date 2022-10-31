using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    internal Ingredient GetById(int id)
    {
      string sql = @"
            SELECT * FROM tjingredients
            WHERE id = @id
            ";
      return _db.QueryFirstOrDefault<Ingredient>(sql, new { id });
    }

    internal void Delete(Ingredient original)
    {
      string sql = "DELETE FROM tjingredients WHERE id = @id LIMIT 1;";
      _db.Execute(sql, original);

    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
      string sql = @"
            SELECT * 
            FROM tjingredients 
            WHERE recipeId = @recipeId";
      return _db.Query<Ingredient>(sql, new { recipeId }).ToList();
    }
  }
}