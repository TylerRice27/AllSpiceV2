using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpiceV2.Models;
using Dapper;

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
           (@Title, @Img, @Instructions, @Category, @CreatorId);
           SELECT LAST_INSERT_ID();";

            int id = _db.ExecuteScalar<int>(sql, newRecipe);
            newRecipe.Id = id;
            return newRecipe;

        }

        internal Recipe GetById(int id)
        {
            string sql = @"
            SELECT
            r.*,
            a.*
            FROM tjrecipes r
            JOIN accounts a ON a.id = r.creatorId
            WHERE r.id = @id;
            ";
            return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
            {
                recipe.Creator = profile;
                return recipe;
            }, new { id }).FirstOrDefault();

        }

        internal List<Recipe> GetAll()
        {
            string sql = @"SELECT 
           r.*,
           a.*
           FROM tjrecipes r
           JOIN accounts a ON a.id = r.creatorId;
           ";
            return _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
            {
                recipe.Creator = profile;
                return recipe;
            }).ToList();
        }

        internal void Delete(int id)
        {
            string sql = " DELETE FROM tjrecipes WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }

        internal Recipe Edit(Recipe original)
        {
            string sql = @"
            UPDATE tjrecipes
            SET
            title = @Title,
            img = @Img,
            instructions = @Instructions,
            category = @Category,
            updatedAt = @UpdatedAt
            WHERE id = @Id;
            "; _db.Execute(sql, original);
            return original;
        }


    }

}
