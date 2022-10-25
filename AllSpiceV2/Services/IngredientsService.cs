using System;
using System.Collections.Generic;
using AllSpiceV2.Models;
using AllSpiceV2.Repositories;

namespace AllSpiceV2.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;
        private readonly RecipesService _rs;

        public IngredientsService(IngredientsRepository repo, RecipesService rs)
        {
            _repo = repo;
            _rs = rs;
        }

        internal Ingredient Create(Ingredient newIngredient)
        {
            return _repo.Create(newIngredient);
        }

        internal Ingredient GetById(int id)
        {
            Ingredient found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        public List<Ingredient> GetIngredientsByRecipe(int recipeId)
        {

            return _repo.GetIngredientsByRecipe(recipeId);

        }

        internal Ingredient Delete(int id, string userId)
        {
            Ingredient original = this.GetById(id);
            Recipe found = _rs.GetById(original.RecipeId);
            if (found.CreatorId != userId)
            {
                throw new Exception("This is not yours.");
            }
            _repo.Delete(original);
            return original;
        }
    }
}