using System.Data;
using AllSpiceV2.Models;

namespace AllSpiceV2.Repositories
{
  public class RecipesRepository
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Recipe Create(Recipe newRecipe)
    {

      string sql = @"
            INSERT INTO tjrecipes
            (title, img, instructions, category, creatorId)
            VALUES
            (@Title, @Img, @Instructions, @Category, @CreatorId)";
      _db.Execute(sql, newRecipe);
      return newRecipe;

    }
  }

}