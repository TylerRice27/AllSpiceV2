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
    public class FavoritesController : ControllerBase
    {
        private readonly FavoritesService _fs;


        private readonly Auth0Provider _auth0Provider;

        public FavoritesController(FavoritesService fs, Auth0Provider auth0Provider)
        {
            _fs = fs;
            _auth0Provider = auth0Provider;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Favorite>> Create([FromBody] Favorite newFavorite)

        {

            try
            {

                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                Favorite favorite = _fs.Create(newFavorite);
                return Ok(favorite);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


    }
}