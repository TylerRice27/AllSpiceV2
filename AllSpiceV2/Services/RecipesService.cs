using System.Collections.Generic;
using AllSpiceV2.Models;
using AllSpiceV2.Repositories;

namespace AllSpiceV2.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal Recipe Create(Recipe newRecipe)
        {
            return _repo.Create(newRecipe);
        }

        internal List<Recipe> GetAll()
        {
            return _repo.GetAll();
        }

        internal Recipe GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}