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
            return _repo.GetById(id);
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
            original.UpdatedAt = update.UpdatedAt ?? original.UpdatedAt;

            return _repo.Edit(original);

        }
    }
}