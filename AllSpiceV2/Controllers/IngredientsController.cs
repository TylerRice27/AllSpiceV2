using AllSpiceV2.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllSpiceV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _is;

        public IngredientsController(IngredientsService @is)
        {
            _is = @is;
        }
    }
}