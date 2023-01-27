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
                newFavorite.AccountId = userInfo.Id;
                FavoritedRecipe favoritedRecipe = _fs.Create(newFavorite);
                return Ok(favoritedRecipe);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        [HttpGet("{id}")]
        public ActionResult<Favorite> GetById(int id)
        {
            try
            {
                Favorite favorite = _fs.GetById(id);
                return Ok(favorite);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }




        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Favorite>> Delete(int id)

        {

            try
            {
                Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
                _fs.Delete(id, userInfo.Id);
                return Ok($"Deleted Favorited Recipe");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}