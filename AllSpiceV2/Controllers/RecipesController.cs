using System;
using System.Threading.Tasks;
using AllSpiceV2.Models;
using AllSpiceV2.Services;
using CodeWorks.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpiceV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {

        private readonly RecipesService _rs;

        private readonly Auth0Provider _auth0Provider;

        public RecipesController(RecipesService rs, Auth0Provider auth0Provider)
        {
            _rs = rs;
            _auth0Provider = auth0Provider;
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
        {

            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                newRecipe.CreatorId = userInfo.Id;
                Recipe jambajuice = _rs.Create(newRecipe);
                return Ok(jambajuice);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}