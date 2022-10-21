using AllSpiceV2.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpiceV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _fs;

        public FavoritesController(FavoritesService fs)
        {
            _fs = fs;
        }
    }
}