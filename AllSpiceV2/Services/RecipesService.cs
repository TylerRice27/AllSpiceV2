using System;
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

            Recipe recipe = _repo.GetById(id);
            if (recipe == null)
            {
                throw new Exception("No Recipe by That Id");
            }
            return recipe;
        }

        internal Recipe Edit(Recipe update, string userId)
        {
            Recipe original = GetById(update.Id);
            if (original.CreatorId != userId)
            {
                throw new Exception("You are not the owner of this recipe");
            }
            original.Title = update.Title ?? original.Title;
            original.Instructions = update.Instructions ?? original.Instructions;
            original.Category = update.Category ?? original.Category;
            original.Img = update.Img ?? original.Img;

            return _repo.Edit(original);

        }

        internal string Delete(int id, string userId)
        {

            Recipe original = GetById(id);
            if (original.CreatorId != userId)
            {
                throw new Exception("You can not delete this recipe");

            }
            _repo.Delete(id);
            return $"You deleted {original.Title}";
        }
    }
}