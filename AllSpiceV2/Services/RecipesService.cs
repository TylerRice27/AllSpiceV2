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
    }
}