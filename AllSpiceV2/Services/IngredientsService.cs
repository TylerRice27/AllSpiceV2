using System.Collections.Generic;
using AllSpiceV2.Models;
using AllSpiceV2.Repositories;

namespace AllSpiceV2.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

        public IngredientsService(IngredientsRepository repo)
        {
            _repo = repo;
        }

        internal Ingredient Create(Ingredient newIngredient)
        {
            return _repo.Create(newIngredient);
        }

        public List<Ingredient> GetIngredientsByRecipe(int recipeId)
        {

            return _repo.GetIngredientsByRecipe(recipeId);

        }
    }
}